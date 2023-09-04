public class ConstellationLineData : CsvData
{
    public string Name { get; set; } // ���ڸ� �̸�   
    public int StartHip { get; set; } // ���� ���� HIP ��ȣ
    public int EndHip { get; set; }  // ���� ���� HIP ��ȣ

    public override void SetData(string[] data)
    {
        Name = data[0];
        StartHip = int.Parse(data[1]);
        EndHip = int.Parse(data[2]);
    }
}
