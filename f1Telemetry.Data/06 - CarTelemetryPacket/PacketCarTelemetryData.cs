using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data
{
    public class PacketCarTelemetryData
    {
        PacketHeader m_header;        // Header

        CarTelemetryData[] m_carTelemetryData = new CarTelemetryData[22];

        byte m_mfdPanelIndex;       /* Index of MFD panel open - 255 = MFD closed
                                     * Single player, race – 0 = Car setup, 1 = Pits
                                     * 2 = Damage, 3 =  Engine, 4 = Temperatures
                                     * May vary depending on game mode
                                     */

        byte m_mfdPanelIndexSecondaryPlayer;   // See above
        sbyte m_suggestedGear;       // Suggested gear for the player (1-8)
                                    // 0 if no gear suggested

    }
}
