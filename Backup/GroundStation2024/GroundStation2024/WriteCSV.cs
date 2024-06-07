using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation2024
{
    public static class WriteCSV
    {
        public static void WriteTelemetry(object packetObj)
        {
            PacketString packet = (PacketString)packetObj;

            List<PacketString> telemetryDataPacket = new List<PacketString>
            {
                new PacketString { teamID = packet.teamID, missionTime = packet.missionTime, packetCount = packet.packetCount, mode = packet.mode, state = packet.state,
                altitude = packet.altitude, airSpeed = packet.airSpeed, HS_Deployed = packet.HS_Deployed, PC_Deployed = packet.HS_Deployed, temperature = packet.temperature,
                voltage = packet.voltage, pressure = packet.pressure, GPS_Time = packet.GPS_Time, GPS_Altitude = packet.GPS_Altitude, GPS_Latitude = packet.GPS_Latitude,
                GPS_Longitude = packet.GPS_Longitude, GPS_Sats = packet.GPS_Sats, TiltX = packet.TiltX, TiltY = packet.TiltY, RotZ = packet.RotZ, CMD_Echo = packet.CMD_Echo}

            };

            if (File.Exists("Flight_2045.csv") == false)
            {
                using (var writer = new StreamWriter("Flight_2045.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(telemetryDataPacket);
                }
 
            }

            else
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };

                using (var stream = File.Open("Flight_2045.csv", FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(telemetryDataPacket);
                }
            }
        }
    }
}
