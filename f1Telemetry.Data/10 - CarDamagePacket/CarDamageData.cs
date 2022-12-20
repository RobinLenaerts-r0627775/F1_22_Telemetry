namespace f1Telemetry.Data;

public class CarDamageData
{
    readonly float[] m_tyresWear = new float[4]; // Tyre wear (percentage)
    readonly byte[] m_tyresDamage = new byte[4]; // Tyre damage (percentage)
    readonly byte[] m_brakesDamage = new byte[4]; // Brakes damage (percentage)
    byte m_frontLeftWingDamage; // Front left wing damage (percentage)
    byte m_frontRightWingDamage; // Front right wing damage (percentage)
    byte m_rearWingDamage; // Rear wing damage (percentage)
    byte m_floorDamage; // Floor damage (percentage)
    byte m_diffuserDamage; // Diffuser damage (percentage)
    byte m_sidepodDamage; // Sidepod damage (percentage)
    byte m_drsFault; // Indicator for DRS fault, 0 = OK, 1 = fault
    byte m_ersFault; // Indicator for ERS fault, 0 = OK, 1 = fault
    byte m_gearBoxDamage; // Gear box damage (percentage)
    byte m_engineDamage; // Engine damage (percentage)
    byte m_engineMGUHWear; // Engine wear MGU-H (percentage)
    byte m_engineESWear; // Engine wear ES (percentage)
    byte m_engineCEWear; // Engine wear CE (percentage)
    byte m_engineICEWear; // Engine wear ICE (percentage)
    byte m_engineMGUKWear; // Engine wear MGU-K (percentage)
    byte m_engineTCWear; // Engine wear TC (percentage)
    byte m_engineBlown; // Engine blown, 0 = OK, 1 = fault
    byte m_engineSeized; // Engine seized, 0 = OK, 1 = fault

    public static CarDamageData FromArray(byte[] packet)
    {
        var reader = new BinaryReader(new MemoryStream(packet));
        var res = new CarDamageData();
        for (int i = 0; i < 4; i++)
        {
            res.m_tyresWear[i] = reader.ReadSingle();
        }
        for (int i = 0; i < 4; i++)
        {
            res.m_tyresDamage[i] = reader.ReadByte();
        }
        for (int i = 0; i < 4; i++)
        {
            res.m_brakesDamage[i] = reader.ReadByte();
        }
        res.m_frontLeftWingDamage = reader.ReadByte();
        res.m_frontRightWingDamage = reader.ReadByte();
        res.m_rearWingDamage = reader.ReadByte();
        res.m_floorDamage = reader.ReadByte();
        res.m_diffuserDamage = reader.ReadByte();
        res.m_sidepodDamage = reader.ReadByte();
        res.m_drsFault = reader.ReadByte();
        res.m_ersFault = reader.ReadByte();
        res.m_gearBoxDamage = reader.ReadByte();
        res.m_engineDamage = reader.ReadByte();
        res.m_engineMGUHWear = reader.ReadByte();
        res.m_engineESWear = reader.ReadByte();
        res.m_engineCEWear = reader.ReadByte();
        res.m_engineICEWear = reader.ReadByte();
        res.m_engineMGUKWear = reader.ReadByte();
        res.m_engineTCWear = reader.ReadByte();
        res.m_engineBlown = reader.ReadByte();
        res.m_engineSeized = reader.ReadByte();
        return res;
    }
}