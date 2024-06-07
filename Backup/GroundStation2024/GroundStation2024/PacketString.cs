using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroundStation2024
{
    public class PacketString
    {
        public string teamID { get;  set; }
        public string missionTime { get;  set; }
        public string packetCount { get;  set; }
        public string mode { get;  set; }
        public string state { get;   set; }
        public string altitude { get;  set; }
        public string airSpeed { get;  set; }
        public string HS_Deployed { get;   set; }
        public string PC_Deployed { get;   set; }
        public string temperature { get;   set; }
        public string voltage { get;   set; }
        public string pressure { get;   set; }
        public string GPS_Time { get;   set; }
        public string GPS_Altitude { get;   set; }
        public string GPS_Latitude { get;   set; }
        public string GPS_Longitude { get;   set; }
        public string GPS_Sats { get;   set; }
        public string TiltX { get;   set; }
        public string TiltY { get;   set; }
        public string RotZ { get;   set; }
        public string CMD_Echo { get;   set; }
    }
}
