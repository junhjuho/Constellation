using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConstellationViewer : MonoBehaviour
{
    // ���ڸ� CSV ������
    [SerializeField]
    TextAsset starDataCSV;
    [SerializeField]
    TextAsset starMajorDataCSV;
    [SerializeField]
    TextAsset constellationNameDataCSV;
    [SerializeField]
    TextAsset constellationPositionDataCSV;
    [SerializeField]
    TextAsset constellationLineDataCSV;

    [SerializeField]
    GameObject constellationPrefab; // ���ڸ��� ������

    // ���ڸ� ������
    List<StarData> starData;
    List<StarMajorData> starMajorData;
    List<ConstellationNameData> constellationNameData;
    List<ConstellationPositionData> constellationPositionData;
    List<ConstellationLineData> constellationLineData;

    // ������ ���ڸ��� ������
    List<ConstellationData> constellationData;

    void Start()
    {

        // CSV ������ �б�
        LoadCSV();

        // ���ڸ� �������� ����
        ArrangementData();

        // ���ڸ��� �ۼ�
        CreateConstellation();
    }

    // CSV ������ �б�

    void LoadCSV()
    {
        starData = CsvLoader<StarData>.LoadData(starDataCSV);
        starMajorData = CsvLoader<StarMajorData>.LoadData(starMajorDataCSV);
        constellationNameData = CsvLoader<ConstellationNameData>.LoadData(constellationNameDataCSV);
        constellationPositionData = CsvLoader<ConstellationPositionData>.LoadData(constellationPositionDataCSV);
        constellationLineData = CsvLoader<ConstellationLineData>.LoadData(constellationLineDataCSV);
    }

    // ���ڸ� �������� ����
    void ArrangementData()
    {
        // �� �����͸� ����
        MergeStarData();

        constellationData = new List<ConstellationData>();
        
        // ���ڸ� �̸����κ��� ���ڸ��� �ʿ��� �����͸� ����
        foreach(var name in constellationNameData)
        {
            constellationData.Add(CollectConstellationData(name));
        }

        // ���ڸ��� ������ �ʴ� ���� ����
        var data = new ConstellationData();
        data.Stars = starData.Where(s => s.UseConstellation == false).ToList();
        constellationData.Add(data);
    }

    // �� �����͸� ����
    void MergeStarData()
    {
        //�̹��� ����� �ʿ��� ���� �Ǻ��Ѵ�
        foreach(var star in starMajorData)
        {
            // ���� �����Ͱ� �ִ°�?
            var data = starData.FirstOrDefault(s => star.Hip == s.Hip);
            if(data != null)
            {
                // ���� �����Ͱ� ������, ��ġ �����͸� �����Ѵ�
                data.RightAscension = star.RightAscension;
                data.Declination = star.Declination;
            }
            else
            {
                // ���� �����Ͱ� ���� ���, 5����� ������ ����Ʈ ��Ͽ� �߰�
                if (star.ApparentMagnitude <= 5.0f)
                {
                    starData.Add(star);
                }
            }
        }
    }

    // ���ڸ� �������� ����
    ConstellationData CollectConstellationData(ConstellationNameData name)
    {
        var data = new ConstellationData();

        // ���ڸ��� �̸� ���
        data.Name = name;

        // ���ڸ� ID�� ���� ���� ���
        data.Position = constellationPositionData.FirstOrDefault(s => name.Id == s.Id);

        // ���ڸ� ��Ī�� ���� ���� ���
        data.Lines = constellationLineData.Where(s => name.Summary == s.Name).ToList();

        // ���ڸ� ���� ����ϰ� �ִ� ���� ���
        data.Stars = new List<StarData>();
        foreach(var line in data.Lines)
        {
            var start = starData.FirstOrDefault(s => s.Hip == line.StartHip);
            data.Stars.Add(start);
            var end = starData.FirstOrDefault(s => s.Hip == line.EndHip);
            data.Stars.Add(end);

            // ���ڸ��� ���Ǵ� ��
            start.UseConstellation = end.UseConstellation = true;
        }

        return data;
    }

    // ���ڸ��� �ۼ�
    void CreateConstellation()
    {
        // �� ���ڸ��� �ۼ�
        foreach(var data in constellationData)
        {
            var constellation = Instantiate(constellationPrefab);
            var drawConstellation = constellation.GetComponent<DrawConstellation>();

            drawConstellation.ConstellationData = data;

            // �ڽ��� �ڽ����� �Ѵ�
            constellation.transform.SetParent(transform, false);
        }
    }
}
