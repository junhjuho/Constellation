public class StarData : CsvData
{
    public int Hip { get; set; }   // HIP ��ȣ
    public float RightAscension { get; set; } // ����
    public float Declination { get; set; } // ����
    public float ApparentMagnitude { get; set; } // �õ��
    public string ColorType;  // ��
    public bool UseConstellation; // ���ڸ����� ���Ǵ� ������

    public override void SetData(string[] data)
    {
        Hip = int.Parse(data[0]);
        RightAscension = RightAscensionToDegree(int.Parse(data[1]), int.Parse(data[2]), float.Parse(data[3]));
        Declination = DeclinationToDegree(int.Parse(data[4]), int.Parse(data[5]), float.Parse(data[6]));
        ApparentMagnitude = float.Parse(data[7]);
        ColorType = data[13].Substring(0, 1);
    }

}
