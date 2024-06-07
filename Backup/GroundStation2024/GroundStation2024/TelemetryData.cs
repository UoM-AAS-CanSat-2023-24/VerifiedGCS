using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation2024
{
    public class TelemetryData
    {
        public int newTeamID { get; private set; }
        public TimeOnly newMissionTime { get; private set; }
        public int newPacketCount { get; private set; }
        public char newMode { get; private set; }
        public string newState { get; private set; }
        public float newAltitude { get; private set; }
        public float newAirSpeed { get; private set; }
        public char newHS_Deployed { get; private set; }
        public char newPC_Deployed { get; private set; }
        public float newTemperature { get; private set; }
        public float newVoltage { get; private set; }
        public float newPressure { get; private set; }
        public TimeOnly newGPS_Time { get; private set; }
        public float newGPS_Altitude { get; private set; }
        public float newGPS_Latitude { get; private set; }
        public float newGPS_Longitude { get; private set; }
        public int newGPS_Sats { get; private set; }
        public float newTiltX { get; private set; }
        public float newTiltY { get; private set; }
        public float newRotZ { get; private set; }
        public string newCMD_Echo { get; private set; }

        public float newSimulatedPressure { get; private set; }
        public TimeOnly newSIMPTime { get; private set; }
        public bool simPacket { get; private set; }
        public PacketString packetString { get; private set; }
        public string fullString { get; private set; }


        public int[] teamIDTelemetry { get; private set; }
        public TimeOnly[] missionTimeTelemetry { get; private set; }
        public int[] packetCountTelemetry { get; private set; }
        public char[] modeTelemetry { get; private set; }
        public string[] stateTelemetry { get; private set; }
        public float[] altitudeTelemetry { get; private set; }
        public float[] airSpeedTelemetry { get; private set; }
        public char[] HS_DeployedTelemetry { get; private set; }
        public char[] PC_DeployedTelemetry { get; private set; }
        public float[] temperatureTelemetry { get; private set; }
        public float[] voltageTelemetry { get; private set; }

        public float[] pressureTelemetry { get; private set; }
        public TimeOnly[] GPS_TimeTelemetry { get; private set; }
        public float[] GPS_AltitudeTelemetry { get; private set; }
        public float[] GPS_LatitudeTelemetry { get; private set; }
        public float[] GPS_LongitudeTelemetry { get; private set; }
        public int[] GPS_SatsTelemetry { get; private set; }
        public float[] tiltXTelemetry { get; private set; }
        public float[] tiltYTelemetry { get; private set; }
        public float[] rotZTelemetry { get; private set; }
        public string[] CMD_EchoTelemetry { get; private set; }

        public float[] simulatedPressureTelemetry { get; private set; }
        public TimeOnly[] simpTimeTelemetry { get; private set; }



        private DateOnly dateNow = DateOnly.FromDateTime(DateTime.Now);
        public DateTime[] missionTimeDateTime { get; private set; }
        public DateTime[] GPS_TimeDateTime { get; private set; }
        public DateTime[] simpDateTime {  get; private set; }

        //public string[] dataTableArray { get; private set; }

        public TelemetryData() 
        {
            this.teamIDTelemetry = new int[0];
            this.missionTimeTelemetry = new TimeOnly[0];
            this.packetCountTelemetry = new int[0];
            this.modeTelemetry = new char[0];
            this.stateTelemetry = new string[0];
            this.altitudeTelemetry = new float[0];
            this.airSpeedTelemetry = new float[0];
            this.HS_DeployedTelemetry = new char[0];
            this.PC_DeployedTelemetry = new char[0];
            this.temperatureTelemetry = new float[0];
            this.voltageTelemetry = new float[0];
            this.pressureTelemetry = new float[0];
            this.GPS_TimeTelemetry = new TimeOnly[0];
            this.GPS_AltitudeTelemetry = new float[0];
            this.GPS_LatitudeTelemetry = new float[0];
            this.GPS_LongitudeTelemetry = new float[0];
            this.GPS_SatsTelemetry = new int[0];
            this.tiltXTelemetry = new float[0];
            this.tiltYTelemetry = new float[0];
            this.rotZTelemetry = new float[0];
            this.CMD_EchoTelemetry = new string[0];

            this.simulatedPressureTelemetry = new float[0];
            this.simpTimeTelemetry = new TimeOnly[0];
            this.simPacket = false;

            this.missionTimeDateTime = new DateTime[0];
            this.GPS_TimeDateTime = new DateTime[0];
            this.simpDateTime = new DateTime[0];

            this.packetString = new PacketString();
            //this.dataTableArray = new string[0];
        }

        public void SetNewData (string dataString)
        {
            string[] dataArray = ParseDataString(dataString);

            string[] stringDataArray = ParsePacketString(dataString);

            if (dataArray[1] == "SIMP")
            {
                newSimulatedPressure = float.Parse(dataArray[2]);
                newSIMPTime = new TimeOnly(Int32.Parse(dataArray[3]), Int32.Parse(dataArray[4]), Int32.Parse(dataArray[5]));

                simulatedPressureTelemetry = simulatedPressureTelemetry.Append(newSimulatedPressure).ToArray();
                DateTime simulatedPressureDateTime = new DateTime (dateNow.Year,dateNow.Month, dateNow.Day, newSIMPTime.Hour, newSIMPTime.Minute, newSIMPTime.Second);
                simpDateTime = simpDateTime.Append(simulatedPressureDateTime).ToArray();
               
                simPacket = true;
            }

            else 
            {
                newTeamID = Int32.Parse(dataArray[0]);
                newMissionTime = new TimeOnly(Int32.Parse(dataArray[1]), Int32.Parse(dataArray[2]), Int32.Parse(dataArray[3]));
                newPacketCount = Int32.Parse(dataArray[4]);
                newMode = char.Parse(dataArray[5]);
                newState = dataArray[6]; // To change
                newAltitude = float.Parse(dataArray[7]);
                newAirSpeed = float.Parse(dataArray[8]);
                newHS_Deployed = char.Parse(dataArray[9]);
                newPC_Deployed = char.Parse(dataArray[10]);
                newTemperature = float.Parse(dataArray[11]);
                newVoltage = float.Parse(dataArray[12]);
                newPressure = float.Parse(dataArray[13]);
                newGPS_Time = new TimeOnly(Int32.Parse(dataArray[14]), Int32.Parse(dataArray[15]), Int32.Parse(dataArray[16]));
                newGPS_Altitude = float.Parse(dataArray[17]);
                newGPS_Latitude = float.Parse(dataArray[18]);
                newGPS_Longitude = float.Parse(dataArray[19]);
                newGPS_Sats = Int32.Parse(dataArray[20]);
                newTiltX = float.Parse(dataArray[21]);
                newTiltY = float.Parse(dataArray[22]);
                newRotZ = float.Parse(dataArray[23]);
                newCMD_Echo = dataArray[24]; //To change

                //Conditionals for STATE and CMD_ECHO telemetry expansion

                //CMD_ECHO

                if(newCMD_Echo == "CXON")
                {
                    newCMD_Echo = "CXON";
                }
                else if(newCMD_Echo == "CXOF")
                {
                    newCMD_Echo = "CXOFF";
                }
                else if(newCMD_Echo == "STGP")
                {
                    newCMD_Echo = "STGPS";
                }
                else if(newCMD_Echo == "STUT")
                {
                    newCMD_Echo = "STUTC";
                }
                else if (newCMD_Echo == "SIME")
                {
                    newCMD_Echo = "SIMENABLE";
                }
                else if(newCMD_Echo == "SIMA")
                {
                    newCMD_Echo = "SIMACTIVATE";
                }
                else if(newCMD_Echo == "SIMD")
                {
                    newCMD_Echo = "SIMDISABLE";
                }
                else if(newCMD_Echo == "CALL")
                {
                    newCMD_Echo = "CAL";
                }
                else if(newCMD_Echo == "BCON")
                {
                    newCMD_Echo = "BCNON";
                }
                else if (newCMD_Echo == "BCOF")
                {
                    newCMD_Echo = "BCNOFF";
                }

                teamIDTelemetry = teamIDTelemetry.Append(newTeamID).ToArray();
                missionTimeTelemetry = missionTimeTelemetry.Append(newMissionTime).ToArray();
                packetCountTelemetry = packetCountTelemetry.Append(newPacketCount).ToArray();
                modeTelemetry = modeTelemetry.Append(newMode).ToArray();
                stateTelemetry = stateTelemetry.Append(newState).ToArray();
                altitudeTelemetry = altitudeTelemetry.Append(newAltitude).ToArray();
                airSpeedTelemetry = airSpeedTelemetry.Append(newAirSpeed).ToArray();
                HS_DeployedTelemetry = HS_DeployedTelemetry.Append(newHS_Deployed).ToArray();
                PC_DeployedTelemetry = PC_DeployedTelemetry.Append(newPC_Deployed).ToArray();
                temperatureTelemetry = temperatureTelemetry.Append(newTemperature).ToArray();
                voltageTelemetry = voltageTelemetry.Append(newVoltage).ToArray();
                pressureTelemetry = pressureTelemetry.Append(newPressure).ToArray();
                GPS_TimeTelemetry = GPS_TimeTelemetry.Append(newGPS_Time).ToArray();
                GPS_AltitudeTelemetry = GPS_AltitudeTelemetry.Append(newGPS_Altitude).ToArray();
                GPS_LatitudeTelemetry = GPS_LatitudeTelemetry.Append(newGPS_Latitude).ToArray();
                GPS_LongitudeTelemetry = GPS_LongitudeTelemetry.Append(newGPS_Longitude).ToArray();
                GPS_SatsTelemetry = GPS_SatsTelemetry.Append(newGPS_Sats).ToArray();
                tiltXTelemetry = tiltXTelemetry.Append(newTiltX).ToArray();
                tiltYTelemetry = tiltYTelemetry.Append(newTiltY).ToArray();
                rotZTelemetry = rotZTelemetry.Append(newRotZ).ToArray();
                CMD_EchoTelemetry = CMD_EchoTelemetry.Append(newCMD_Echo).ToArray();

                DateTime missionDateTime = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, newMissionTime.Hour, newMissionTime.Minute, newMissionTime.Second);
                missionTimeDateTime = missionTimeDateTime.Append(missionDateTime).ToArray();

                SetNewPacketString(stringDataArray);
            }
            

        }

        private string[] ParseDataString(string dataString)
        {
            char [] delimiterChars = { ',', ':' };
            string[] packet = dataString.Split(delimiterChars);
            //Debug.Write("Packet[0]: " + packet[0] + " Packet[1]: " + packet[1] + " Packet[2]" + packet[2]);
            return packet;
        }

        private string[] ParsePacketString(string dataString)
        {
            char delimeter = ',';
            string[] packet = dataString.Split(delimeter);
            return packet;
        }

        private void SetNewPacketString(string[] stringDataArray)
        {
            packetString.teamID = stringDataArray[0];
            packetString.missionTime = stringDataArray[1];
            packetString.packetCount = stringDataArray[2];
            packetString.mode = stringDataArray[3];
            packetString.state = stringDataArray[4];
            packetString.altitude = stringDataArray[5];
            packetString.airSpeed = stringDataArray[6];
            packetString.HS_Deployed = stringDataArray[7];
            packetString.PC_Deployed = stringDataArray[8];
            packetString.temperature = stringDataArray[9];
            packetString.voltage = stringDataArray[10];
            packetString.pressure = stringDataArray[11];
            packetString.GPS_Time = stringDataArray[12];
            packetString.GPS_Altitude = stringDataArray[13];
            packetString.GPS_Latitude = stringDataArray[14];
            packetString.GPS_Longitude = stringDataArray[15];
            packetString.GPS_Sats = stringDataArray[16];
            packetString.TiltX = stringDataArray[17];
            packetString.TiltY = stringDataArray[18];
            packetString.RotZ = stringDataArray[19];
            packetString.CMD_Echo = stringDataArray[20];

            //Conditionals for STATE and CMD_ECHO telemetry expansion for string data (Stringpacket)

            //CMD_ECHO

            if (packetString.CMD_Echo == "CXON")
            {
                packetString.CMD_Echo = "CXON";
            }
            else if (packetString.CMD_Echo == "CXOF")
            {
                packetString.CMD_Echo = "CXOFF";
            }
            else if (packetString.CMD_Echo == "STGP")
            {
                packetString.CMD_Echo = "STGPS";
            }
            else if (packetString.CMD_Echo == "STUT")
            {
                packetString.CMD_Echo = "STUTC";
            }
            else if (packetString.CMD_Echo == "SIME")
            {
                packetString.CMD_Echo = "SIMENABLE";
            }
            else if (packetString.CMD_Echo == "SIMA")
            {
                packetString.CMD_Echo = "SIMACTIVATE";
            }
            else if (packetString.CMD_Echo == "SIMD")
            {
                packetString.CMD_Echo = "SIMDISABLE";
            }
            else if (packetString.CMD_Echo == "CALL")
            {
                packetString.CMD_Echo = "CAL";
            }
            else if (packetString.CMD_Echo == "BCON")
            {
                packetString.CMD_Echo = "BCNON";
            }
            else if (packetString.CMD_Echo == "BCOF")
            {
                packetString.CMD_Echo = "BCNOFF";
            }

            fullString = packetString.teamID +  "," + packetString.missionTime + "," + packetString.packetCount + "," + packetString.mode + "," + 
                packetString.state + "," + packetString.altitude + "," + packetString.airSpeed + "," + packetString.HS_Deployed + "," + packetString.PC_Deployed + "," + packetString.temperature + "," + packetString.pressure + "," + packetString.voltage
                + "," + packetString.GPS_Time + "," + packetString.GPS_Altitude + "," + packetString.GPS_Latitude + "," + packetString.GPS_Longitude + "," + packetString.GPS_Sats + "," + packetString.TiltX
                + "," + packetString.TiltY + packetString.RotZ + "," + packetString.CMD_Echo;
        }
    }
}
