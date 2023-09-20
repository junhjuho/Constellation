public class ConstellationNameData : CsvData
{
    public int Id { get; set; }  // ���ڸ� ID
    public string Summary { get; set; } // ��Ī  
    public string Name { get; set; } // �����
    public string KoreanName { get; set; } // �ѱ۸�
                                           
    public override void SetData(string[] data)
    {
        Id = int.Parse(data[0]);
        Summary = data[1];
        Name = data[2];
        KoreanName = data[3];
    }
}
