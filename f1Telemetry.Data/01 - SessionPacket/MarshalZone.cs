namespace f1Telemetry.Data;
 public class MarshalZone
    {
        public float ZoneStart { get; set; }
        public int ZoneFlag { get; set; }

        public static MarshalZone FromArray(byte[] data)
        {
            var zoneStart = BitConverter.ToSingle(data, 0);
            var zoneFlag = data[0 + 4];
            return new MarshalZone { ZoneStart = zoneStart, ZoneFlag = zoneFlag };
        }
    }