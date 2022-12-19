namespace f1Telemetry.Data;

public class CarDamageData
{
    readonly float[] m_tyresWear = new float[4]; // Tyre wear (percentage)
    readonly sbyte[] m_tyresDamage = new sbyte[4]; // Tyre damage (percentage)
    readonly sbyte[] m_brakesDamage = new sbyte[4]; // Brakes damage (percentage)
    sbyte m_frontLeftWingDamage; // Front left wing damage (percentage)
    sbyte m_frontRightWingDamage; // Front right wing damage (percentage)
    sbyte m_rearWingDamage; // Rear wing damage (percentage)
    sbyte m_floorDamage; // Floor damage (percentage)
    sbyte m_diffuserDamage; // Diffuser damage (percentage)
    sbyte m_sidepodDamage; // Sidepod damage (percentage)
    sbyte m_drsFault; // Indicator for DRS fault, 0 = OK, 1 = fault
    sbyte m_ersFault; // Indicator for ERS fault, 0 = OK, 1 = fault
    sbyte m_gearBoxDamage; // Gear box damage (percentage)
    sbyte m_engineDamage; // Engine damage (percentage)
    sbyte m_engineMGUHWear; // Engine wear MGU-H (percentage)
    sbyte m_engineESWear; // Engine wear ES (percentage)
    sbyte m_engineCEWear; // Engine wear CE (percentage)
    sbyte m_engineICEWear; // Engine wear ICE (percentage)
    sbyte m_engineMGUKWear; // Engine wear MGU-K (percentage)
    sbyte m_engineTCWear; // Engine wear TC (percentage)
    sbyte m_engineBlown; // Engine blown, 0 = OK, 1 = fault
    sbyte m_engineSeized; // Engine seized, 0 = OK, 1 = fault

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
            res.m_tyresDamage[i] = reader.ReadSByte();
        }
        for (int i = 0; i < 4; i++)
        {
            res.m_brakesDamage[i] = reader.ReadSByte();
        }
        res.m_frontLeftWingDamage = reader.ReadSByte();
        res.m_frontRightWingDamage = reader.ReadSByte();
        res.m_rearWingDamage = reader.ReadSByte();
        res.m_floorDamage = reader.ReadSByte();
        res.m_diffuserDamage = reader.ReadSByte();
        res.m_sidepodDamage = reader.ReadSByte();
        res.m_drsFault = reader.ReadSByte();
        res.m_ersFault = reader.ReadSByte();
        res.m_gearBoxDamage = reader.ReadSByte();
        res.m_engineDamage = reader.ReadSByte();
        res.m_engineMGUHWear = reader.ReadSByte();
        res.m_engineESWear = reader.ReadSByte();
        res.m_engineCEWear = reader.ReadSByte();
        res.m_engineICEWear = reader.ReadSByte();
        res.m_engineMGUKWear = reader.ReadSByte();
        res.m_engineTCWear = reader.ReadSByte();
        res.m_engineBlown = reader.ReadSByte();
        res.m_engineSeized = reader.ReadSByte();
        return res;
    }
}