using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using System.Collections;
using System.Buffers.Binary;
using OpenTK.Graphics.OpenGL;

namespace GroundStation2024
{
    public class RFSerialPort
    {
        public delegate void UpdateDataHandler(string dataString);
        public event UpdateDataHandler PacketReceived;
        public const int offset = 5;
        //public int blockSizeLimit = 116;
        public SerialPort Port { get; set; }

        public RFSerialPort(string portName, int baudRate)
        {
            Initialize(portName, baudRate);
        }

        public void ReadAsynchronously()
        {
            //Open port
            Port.Open();

            //Loop continously awaiting received packets
            while (true)
            {
                //First 8 bytes of packet give information about packet size, etc.. so wait for those to arrive i.e. let the buffer fill to 8 bytes
                if (Port.BytesToRead >= 8)
                {
                    //Begin reading data if first byte is Xbee packet start delimeter
                    if ((byte)Port.ReadByte() == 0x7E)
                    {
                        //Read next 7 bytes:

                        int lengthMSB = Port.ReadByte();
                        int lengthLSB = Port.ReadByte();

                        byte frameType = (byte)Port.ReadByte();

                        //If length LSB is 0x7D and frametype is 0x5E this means extra escape character was added, and actual packet length is 126 (0x7E) bytes.

                        if ((byte)lengthMSB == 0x7D && frameType == 0x5E)
                        {
                            lengthLSB = 126;

                            //Actual frameType:
                            frameType = (byte)Port.ReadByte();
                        }

                        byte sourceAddressHI = (byte)Port.ReadByte();
                        byte sourceAddressLO = (byte)Port.ReadByte();
                        byte RSSI = (byte)Port.ReadByte();
                        byte options = (byte)Port.ReadByte();

                        int dataAPIsize = lengthLSB - offset; //Size of byte array that will store only the data frame. lengthLSB includes all bytes except for two length, start delim. and checksum bytes, so must offset these.
                        while (Port.BytesToRead < dataAPIsize + 1)
                        {
                            //Do nothing until port has packet fully available
                        }

                        byte[] buffer = new byte[dataAPIsize]; //Byte array of received data frame

                        Debug.Write("In Buffer: ");
                        for (int i = 0; i < dataAPIsize; i++)
                        {
                            buffer[i] = (byte)Port.ReadByte();
                            Debug.Write((char)buffer[i]);
                        }
                        Debug.Write("\n");
                        byte weirdByte = (byte)Port.ReadByte();
                        string bufferString = ByteToString(buffer, dataAPIsize); //Convert byte array of data to string
                        Debug.Write("ToString: " + bufferString + '\n');

                        PacketReceived.Invoke(bufferString); //Raise an event that will try to parse this data and update the UI. The event calls the UpdateTelemetry() method in Form1.cs.

                    }

                    else
                    {
                        Port.ReadByte(); //Get rid of bytes until 0x7E is found
                    }
                }
            }
        }

        public void Write(string commandString)
        {
            byte[] commandDataFrame = StringToBytes(commandString);

            for (int i = 0; i < commandDataFrame.Length; i++)
            {
                Debug.WriteLine("commandDataFrame[i" + i + "] " + commandDataFrame[i]);
            }

            byte[] packet = BuildAPIFrame(commandDataFrame);


            if (Port.IsOpen == true)
            {
                Port.Write(packet, 0, packet.Length);

                for (int i = 0; i < packet.Length; i++)
                {
                    Debug.Write("packet[" + i + "] = ");
                    Debug.WriteLine("{0:x}", packet[i]);
                }


            }

            else
            {
                Port.Open();
                Port.Write(packet, 0, packet.Length);
                //Port.Close();
            }
        }

        private byte[] BuildAPIFrame(byte[] dataFrame)
        {
            //7E(start) 00(zero) 0B(size: 11+data frame size) 00 00 00 7D 33 A2 00 41 F2 34 81 00 (MAC address + other stuff) (insert data frame) 62 (checksum)
            int frameOffset = 8;
            int initalLength = 5; //address (2) + frame id(1) + frame type(1) + options(1)
            int sum = 0;

            Debug.Write("Dataframe length: " + dataFrame.Length);
            Debug.Write("initalLength + dataFrame.Length = " + initalLength + "+" + dataFrame.Length + " !\n");

            if((initalLength + dataFrame.Length == 0x13) || (initalLength+dataFrame.Length == 0x11))
            {
                byte[] frameAPI = new byte[dataFrame.Length + frameOffset + 2]; //Add extra byte for escape character
                Debug.Write("Escaped branch");

                frameAPI[0] = 0x7E;
                frameAPI[1] = 0x00;
                frameAPI[2] = 0x7D;
                frameAPI[3] = (byte)((byte)(initalLength + dataFrame.Length)^0x20); //initial length is default offset, add data frame size to that offset
                frameAPI[4] = 0x01;
                frameAPI[5] = 0x00;
                frameAPI[6] = 0x00;
                frameAPI[7] = 0x02;
                frameAPI[8] = 0x00;

                frameOffset=frameOffset+1;

                for (int i = 0; i < dataFrame.Length; i++)
                {
                    frameAPI[i + frameOffset] = dataFrame[i];
                }

                for (int i = 4; i < frameAPI.Length - 1; i++) // Start from frameAPI[4]
                {
                    sum += frameAPI[i];
                }

                int lowerByte = sum % 256;
                byte checksum = (byte)(255 - lowerByte);

                if ((checksum == 0x7E) || (checksum == 0x7D) || (checksum == 0x11) || (checksum == 0x13))
                {
                    frameAPI[frameAPI.Length - 1] = 0x7D;
                    byte escapedChecksumVal = (byte)(checksum ^ 0x20);
                    byte[] newFrameAPI = new byte[frameAPI.Length + 1];
                    frameAPI.CopyTo(newFrameAPI, 0);
                    newFrameAPI[newFrameAPI.Length - 1] = escapedChecksumVal;

                    return newFrameAPI;
                }
                else
                {
                    frameAPI[frameAPI.Length - 1] = checksum; // checksum 
                }

                for (int i = 0; i < frameAPI.Length; i++)
                {
                    Debug.Write("frameAPI[" + i + "] = ");
                    Debug.WriteLine("{0:x}", frameAPI[i]);
                }

                return frameAPI;
            }
            else
            {
                byte[] frameAPI = new byte[dataFrame.Length + frameOffset + 1];

                frameAPI[0] = 0x7E;
                frameAPI[1] = 0x00;
                frameAPI[2] = (byte)(initalLength + dataFrame.Length); //initial length is default offset, add data frame size to that offset
                frameAPI[3] = 0x01;
                frameAPI[4] = 0x00;
                frameAPI[5] = 0x00;
                frameAPI[6] = 0x02;
                frameAPI[7] = 0x00;

                for (int i = 0; i < dataFrame.Length; i++)
                {
                    frameAPI[i + frameOffset] = dataFrame[i];
                }

                for (int i = 3; i < frameAPI.Length - 1; i++)
                {
                    sum += frameAPI[i];
                }

                int lowerByte = sum % 256;
                byte checksum = (byte)(255 - lowerByte);

                if ((checksum == 0x7E) || (checksum == 0x7D) || (checksum == 0x11) || (checksum == 0x13))
                {
                    frameAPI[frameAPI.Length - 1] = 0x7D;
                    byte escapedChecksumVal = (byte)(checksum ^ 0x20);
                    byte[] newFrameAPI = new byte[frameAPI.Length + 1];
                    frameAPI.CopyTo(newFrameAPI, 0);
                    newFrameAPI[newFrameAPI.Length - 1] = escapedChecksumVal;

                    return newFrameAPI;
                }
                else
                {
                    frameAPI[frameAPI.Length - 1] = checksum; // checksum 
                }

                for (int i = 0; i < frameAPI.Length; i++)
                {
                    Debug.Write("frameAPI[" + i + "] = ");
                    Debug.WriteLine("{0:x}", frameAPI[i]);
                }

                return frameAPI;
            }
            
        }

        private byte[] StringToBytes(string str)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(str);
            return byteArray;
        }

        private string ByteToString(byte[] buffer, int dataBlockSize)
        {
            string bufferString = string.Empty;
            //int skipBytes = 8;

            for (int i = 0; i < dataBlockSize; i++) //!NOT NEEDED, DATABLOCKSIZE NOW CONTAINS ONLY DATAFRAME //-1 to exclude unecessary char at end of string
            {
                bufferString += (char)buffer[i];
            }
            Debug.Write(bufferString);
            return bufferString;
        }

        public void Initialize(string portName, int baudRate)
        {
            //Create new instance
            this.Port = new SerialPort();

            //Set properties
            Port.PortName = portName;
            Port.BaudRate = baudRate;
            Port.Parity = Parity.None;
            Port.StopBits = StopBits.One;
            Port.DataBits = 8;
            Port.Handshake = Handshake.None;
            Port.RtsEnable = true;

        }
    }
}
