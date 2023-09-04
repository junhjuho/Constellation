using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvLoader<TCsvData> where TCsvData : CsvData, new()
{
    // TextAsset ������ �б�
    public static List<TCsvData> LoadData(TextAsset csvText)
    {
        var data = new List<TCsvData>();  // ����Ʈ �ۼ�  
        var reader = new StringReader(csvText.text); // ���ڿ� �б�

        // 1�྿ �������� ������ ó���� �ǽ�
        while (reader.Peek() > -1)
        {
            //1�� �б�
            var line = reader.ReadLine();
            // ������ �ۼ�
            var csvData = new TCsvData();
            // ,�� ������ �������� �迭�� �ۼ��ϰ� �����͸� ���
            csvData.SetData(line.Split(','));
            // ����Ʈ�� ���
            data.Add(csvData);
        }
        return data;
    }

}
