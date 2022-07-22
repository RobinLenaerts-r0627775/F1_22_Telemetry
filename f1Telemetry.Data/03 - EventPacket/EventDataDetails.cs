using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data;

public class EventDataDetails
{
    byte vehicleIdx; // Vehicle index of car achieving fastest lap
    float lapTime; // Lap time is in seconds

    byte penaltyType; // Penalty type – see Appendices
    byte infringementType; // Infringement type – see Appendices
    byte otherVehicleIdx; // Vehicle index of the other car involved
    byte time; // Time gained, or time spent doing action in seconds
    byte lapNum; // Lap the penalty occurred on
    byte placesGained; // Number of places gained by this

    float speed; // Top speed achieved in kilometres per hour
    byte isOverallFastestInSession; // Overall fastest speed in session = 1, otherwise 0
    byte isDriverFastestInSession; // Fastest speed for driver in session = 1, otherwise 0

    byte fastestVehicleIdxInSession; // Vehicle index of the vehicle that is the fastest in this session
    float fastestSpeedInSession; // Speed of the vehicle that is the fastest

    byte numLights; // Number of lights showing

    uint flashbackFrameIdentifier; // Frame identifier flashed back to
    float flashbackSessionTime; // Session time flashed back to

    uint m_buttonStatus; // Bit flags specifying which buttons are being pressed

    public static EventDataDetails FromArray(byte[] packet, string eventCode)
    {
        var s = new EventDataDetails();
        var reader = new BinaryReader(new MemoryStream(packet));

        switch (eventCode)
        {
            case "SSTA":
                break;
            case "SEND":
                break;
            case "FTLP":
                s.vehicleIdx = reader.ReadByte();
                s.lapTime = reader.ReadSingle();
                break;
            case "RTMT":
                s.vehicleIdx = reader.ReadByte();
                break;
            case "DRSE":
                break;
            case "DRSD":
                break;
            case "TMPT":
                s.vehicleIdx = reader.ReadByte();
                break;
            case "CHQF":
                break;
            case "RCWN":
                s.vehicleIdx = reader.ReadByte();
                break;
            case "PENA":
                s.penaltyType = reader.ReadByte();
                s.infringementType = reader.ReadByte();
                s.vehicleIdx = reader.ReadByte();
                s.otherVehicleIdx = reader.ReadByte();
                s.time = reader.ReadByte();
                s.lapNum = reader.ReadByte();
                s.placesGained = reader.ReadByte();
                break;
            case "SPTP":
                s.vehicleIdx = reader.ReadByte();
                s.speed = reader.ReadSingle();
                s.isOverallFastestInSession = reader.ReadByte();
                s.isDriverFastestInSession = reader.ReadByte();
                s.fastestVehicleIdxInSession = reader.ReadByte();
                s.fastestSpeedInSession = reader.ReadSByte();
                break;
            case "STLG":
                s.numLights = reader.ReadByte();
                break;
            case "LGOT":
                break;
            case "DTSV":
                s.vehicleIdx = reader.ReadByte();
                break;
            case "SGSV":
                s.vehicleIdx = reader.ReadByte();
                break;
            case "FLBK":
                s.flashbackFrameIdentifier = reader.ReadUInt32();
                s.flashbackSessionTime = reader.ReadByte();
                break;
            case "BUTN":
                s.m_buttonStatus = reader.ReadUInt32();
                break;
        }

        return s;
    }
}