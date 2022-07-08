using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    public class LapData
    {
        uint m_lastLapTimeInMS;            // Last lap time in milliseconds
        uint m_currentLapTimeInMS;     // Current time around the lap in milliseconds
        ushort m_sector1TimeInMS;           // Sector 1 time in milliseconds
        ushort m_sector2TimeInMS;           // Sector 2 time in milliseconds
        float m_lapDistance;         // Distance vehicle is around current lap in metres – could
                                     // be negative if line hasn’t been crossed yet

        float m_totalDistance;       // Total distance travelled in session in metres – could
                                     // be negative if line hasn’t been crossed yet

        float m_safetyCarDelta;            // Delta in seconds for safety car
        byte m_carPosition;             // Car race position
        byte m_currentLapNum;       // Current lap number
        byte m_pitStatus;               // 0 = none, 1 = pitting, 2 = in pit area
        byte m_numPitStops;                 // Number of pit stops taken in this race
        byte m_sector;                  // 0 = sector1, 1 = sector2, 2 = sector3
        byte m_currentLapInvalid;       // Current lap invalid - 0 = valid, 1 = invalid
        byte m_penalties;               // Accumulated time penalties in seconds to be added
        byte m_warnings;                  // Accumulated number of warnings issued
        byte m_numUnservedDriveThroughPens;  // Num drive through pens left to serve
        byte m_numUnservedStopGoPens;        // Num stop go pens left to serve
        byte m_gridPosition;            // Grid position the vehicle started the race in
        byte m_driverStatus;            /* Status of driver - 0 = in garage, 1 = flying lap
                                         * 2 = in lap, 3 = out lap, 4 = on track
                                         */

        byte m_resultStatus;              /* Result status - 0 = invalid, 1 = inactive, 2 = active
                                           * 3 = finished, 4 = didnotfinish, 5 = disqualified
                                           * 6 = not classified, 7 = retired
                                           */
        byte m_pitLaneTimerActive;          // Pit lane timing, 0 = inactive, 1 = active
        ushort m_pitLaneTimeInLaneInMS;      // If active, the current time spent in the pit lane in ms
        ushort m_pitStopTimerInMS;           // Time of the actual pit stop in ms
        byte m_pitStopShouldServePen;   	 // Whether the car should serve a penalty at this stop

        public static LapData FromArray(byte[] bytes) 
        {
            var reader = new BinaryReader(new MemoryStream(bytes));

            var s = new LapData();

            s.m_lastLapTimeInMS = reader.ReadUInt32();
            s.m_currentLapTimeInMS = reader.ReadUInt32();
            s.m_sector1TimeInMS = reader.ReadUInt16();
            s.m_sector2TimeInMS = reader.ReadUInt16();
            s.m_lapDistance = reader.ReadSingle();
            s.m_totalDistance = reader.ReadSingle();
            s.m_safetyCarDelta = reader.ReadSingle();
            s.m_carPosition = reader.ReadByte();
            s.m_currentLapNum = reader.ReadByte();
            s.m_pitStatus = reader.ReadByte();
            s.m_numPitStops = reader.ReadByte();
            s.m_sector = reader.ReadByte();
            s.m_currentLapInvalid = reader.ReadByte();
            s.m_penalties = reader.ReadByte();
            s.m_warnings = reader.ReadByte();
            s.m_numUnservedDriveThroughPens = reader.ReadByte();
            s.m_numUnservedStopGoPens = reader.ReadByte();
            s.m_gridPosition = reader.ReadByte();
            s.m_driverStatus = reader.ReadByte();
            s.m_resultStatus = reader.ReadByte();
            s.m_pitLaneTimerActive = reader.ReadByte();
            s.m_pitLaneTimeInLaneInMS = reader.ReadUInt16();
            s.m_pitStopTimerInMS = reader.ReadUInt16();
            s.m_pitStopShouldServePen = reader.ReadByte();

            return s;


        }
    }
}
