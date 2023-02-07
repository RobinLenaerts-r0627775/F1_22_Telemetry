namespace f1Telemetry.Data;
public class LapData
{
     public uint LastLapTimeInMs { get; set; }
        public uint CurrentLapTimeInMs { get; set; }
        public ushort Sector1TimeInMs { get; set; }
        public ushort Sector2TimeInMs { get; set; }
        public float LapDistance { get; set; }
        public float TotalDistance { get; set; }
        public float SafetyCarDelta { get; set; }
        public byte CarPosition { get; set; }
        public byte CurrentLapNum { get; set; }
        public byte PitStatus { get; set; }
        public byte NumPitStops { get; set; }
        public byte Sector { get; set; }
        public byte CurrentLapInvalid { get; set; }
        public byte Penalties { get; set; }
        public byte Warnings { get; set; }
        public byte NumUnservedDriveThroughPens { get; set; }
        public byte NumUnservedStopGoPens { get; set; }
        public byte GridPosition { get; set; }
        public byte DriverStatus { get; set; }
        public byte ResultStatus { get; set; }
        public byte PitLaneTimerActive { get; set; }
        public ushort PitLaneTimeInLaneInMs { get; set; }
        public ushort PitStopTimerInMs { get; set; }
        public byte PitStopShouldServePen { get; set; }   	 // Whether the car should serve a penalty at this stop

    public static LapData FromArray(byte[] data)
    {
        if (data == null || data.Length != 42)
        {
            throw new ArgumentException("Invalid data array. Array must be non-null and have a length of 42 bytes.");
        }

        LapData lapData = new LapData();

        int offset = 0;
        lapData.LastLapTimeInMs = BitConverter.ToUInt32(data, offset);
        offset += 4;
        lapData.CurrentLapTimeInMs = BitConverter.ToUInt32(data, offset);
        offset += 4;
        lapData.Sector1TimeInMs = BitConverter.ToUInt16(data, offset);
        offset += 2;
        lapData.Sector2TimeInMs = BitConverter.ToUInt16(data, offset);
        offset += 2;
        lapData.LapDistance = BitConverter.ToSingle(data, offset);
        offset += 4;
        lapData.TotalDistance = BitConverter.ToSingle(data, offset);
        offset += 4;
        lapData.SafetyCarDelta = BitConverter.ToSingle(data, offset);
        offset += 4;
        lapData.CarPosition = data[offset];
        offset++;
        lapData.CurrentLapNum = data[offset];
        offset++;
        lapData.PitStatus = data[offset];
        offset++;
        lapData.NumPitStops = data[offset];
        offset++;
        lapData.Sector = data[offset];
        offset++;
        lapData.CurrentLapInvalid = data[offset];
        offset++;
        lapData.Penalties = data[offset];
        offset++;
        lapData.Warnings = data[offset];
        offset++;
        lapData.NumUnservedDriveThroughPens = data[offset];
        offset++;
        lapData.NumUnservedStopGoPens = data[offset];
        offset++;
        lapData.GridPosition = data[offset];
        offset++;
        lapData.DriverStatus = data[offset];
        offset++;
        lapData.ResultStatus = data[offset];
        offset++;
        lapData.PitLaneTimerActive = data[offset];
        offset++;
        lapData.PitLaneTimeInLaneInMs = BitConverter.ToUInt16(data, offset);
        offset += 2;
        lapData.PitStopTimerInMs = BitConverter.ToUInt16(data, offset);
        offset += 2;
        lapData.PitStopShouldServePen = data[offset];

        return lapData;
    }
}
