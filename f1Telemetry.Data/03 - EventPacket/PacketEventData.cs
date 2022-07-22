using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data;

public class PacketEventData
{
    PacketHeader m_header; // Header
    byte[] m_eventStringCode = new byte[4]; // Event string code, see below

    EventDataDetails m_eventDetails; // Event details - should be interpreted differently
    // for each type

    public PacketEventData(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        var m_header = PacketHeader.FromArray(reader.ReadBytes(24));

        m_eventStringCode = reader.ReadBytes(4);
        var eventStringCode = Encoding.ASCII.GetString(m_eventStringCode);
        byte[] bytes = new byte[0];
        switch (eventStringCode)
        {
            case "SSTA":
                break;
            case "SEND":
                break;
            case "FTLP":
                bytes = reader.ReadBytes(5);
                break;
            case "RTMT":
                bytes = reader.ReadBytes(1);
                break;
            case "DRSE":
                break;
            case "DRSD":
                break;
            case "TMPT":
                bytes = reader.ReadBytes(1);
                break;
            case "CHQF":
                break;
            case "RCWN":
                bytes = reader.ReadBytes(1);
                break;
            case "PENA":
                bytes = reader.ReadBytes(7);
                break;
            case "SPTP":
                bytes = reader.ReadBytes(12);
                break;
            case "STLG":
                bytes = reader.ReadBytes(1);
                break;
            case "LGOT":
                break;
            case "DTSV":
                bytes = reader.ReadBytes(1);
                break;
            case "SGSV":
                bytes = reader.ReadBytes(1);
                break;
            case "FLBK":
                bytes = reader.ReadBytes(8);
                break;
            case "BUTN":
                bytes = reader.ReadBytes(4);
                break;
        }

        m_eventDetails = EventDataDetails.FromArray(bytes, eventStringCode);
    }
}