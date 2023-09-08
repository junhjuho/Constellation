using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawConstellation : MonoBehaviour
{
    public float boxSize = 3.0f;
    static float SpaceSize = 1000.0f; // ���ڸ� ���� �ݰ�
    static float StarBaseSize = 8.0f; // ���� ũ�� ����

    [SerializeField]
    GameObject starPrefab; // ���� ������
    [SerializeField]
    GameObject linePrefab; // ���ڸ� ���� ������
    [SerializeField]
    GameObject namePrefab; // ���ڸ� �̸��� ������

    public ConstellationData ConstellationData { get; set; } // �׸��� ���ڸ� ������

    GameObject linesParent;  // ������ ���ϴ� ���� ������Ʈ

    //������ ���ϴ� ���� ������Ʈ�� ������Ƽ
    public GameObject Linesparent { get { return linesParent; } }

    void Start()
    {
        // GameObject�� �̸��� ���ڸ� �̸����� ����
        if(ConstellationData.Name != null)
        {
            gameObject.name = ConstellationData.Name.Name;
        }

        // �����ͷκ��� ���ڸ��� �ۼ�
        CreateConstellation();
    }

    // ���ڸ��� �ۼ�
    void CreateConstellation()
    {
        // ����Ʈ�κ��� ���� �ۼ�
        foreach(var star in ConstellationData.Stars)
        {
            //���� �ۼ�
            var starObject = CreateStar(star);
            // �ڽ��� �ڽĿ��� ����
            starObject.transform.SetParent(transform, false);
        }

        if(ConstellationData.Lines != null)
        {
            // ���ڸ� ���� �θ� �ۼ�
            linesParent = new GameObject("Lines");
            // �ڽ��� �ڽĿ��� ����
            linesParent.transform.SetParent(transform, false);
            var parent = linesParent.transform;

            // ����Ʈ�κ��� ���ڸ� ���� �ۼ�
            foreach(var line in ConstellationData.Lines)
            {
                // ���ڸ� ���� �ۼ�
                var lineObject = CreateLine(line);
                // ���ڸ� ���� �θ��� �ڽĿ��� ����
                lineObject.transform.SetParent(parent, false);
            }
        }

        if(ConstellationData.Name != null)
        {
            // ���ڸ� �̸��� �ۼ�
            var nameObject = CreateName(ConstellationData.Name, ConstellationData.Position, ConstellationData.Des);
            // �ڽ��� �ڽĿ��� ����
            nameObject.transform.SetParent(transform, false);
        }
    }

    // ���� �ۼ�
    GameObject CreateStar(StarData starData)
    {
        // ���� ���������κ��� �ν��Ͻ� �ۼ�
        var star = Instantiate(starPrefab);
        var starTrans = star.transform;

        // ���� ���̴� �������� ȸ����Ų��
        starTrans.localRotation = Quaternion.Euler(starData.Declination, starData.RightAscension, 0.0f);
        // ���� �̸��� HIP ��ȣ�� �Ѵ�
        star.name = string.Format("{0}", starData.Hip);

        var child = starTrans.GetChild(0);
        // �ڽ��� ���� ��ġ�� õ���� ��ġ�� �̵���Ų��
        child.transform.localPosition = new Vector3(0.0f, 0.0f, SpaceSize);

        // �õ���� ���� ũ��� �Ѵ�
        var size = StarBaseSize - starData.ApparentMagnitude;
        child.transform.localScale = new Vector3(size, size, size);

        // Renderer ���
        var meshRenderer = child.GetComponent<Renderer>();
        var color = Color.white;

        // ���� �÷� Ÿ�Կ� ���� ���� �����Ѵ�
        switch (starData.ColorType)
        {
            case "O":  // �Ķ�
                color = Color.blue;
                break;

            case "B": // û��
                color = Color.Lerp(Color.blue, Color.white, 0.5f);
                break;
            
            default:
            case "A": // ���
                color = Color.white;
                break;

            case "F": // Ȳ��
                color = Color.Lerp(Color.white, Color.yellow, 0.5f);
                break;

            case "G": // ���
                color = Color.yellow;
                break;

            case "K":  // ��Ȳ
                color = new Color(243.0f / 255.0f, 152.0f / 255.0f, 0.0f);
                break;

            case "M":
                color = new Color(200.0f / 255.0f, 10.0f / 255.0f, 0.0f);
                break;
        }

        // ���͸��� ���� �����Ѵ�
        meshRenderer.material.SetColor("_Color", color);

        return star;
    }

    // ���ڸ� ���� �ۼ�
    GameObject CreateLine(ConstellationLineData lineData)
    {
        // �������� ���� ������ ���
        var start = GetStar(lineData.StartHip);
        // ������ ���� ������ ���
        var end = GetStar(lineData.EndHip);
        // ���ڸ� ���� ���������κ��� �ν��Ͻ� �ۼ�
        var line = Instantiate(linePrefab);
        // LineRenderer�� ���
        var lineRenderer = line.GetComponent<LineRenderer>();

        // LineRenderer �� �������� ������ ��ġ�� ���(���� ���̴� �������� ȸ����Ų ��, õ���� ��ġ���� �̵���Ų��)
        lineRenderer.SetPosition(0, Quaternion.Euler(start.Declination, start.RightAscension, 0.0f) * new Vector3(0.0f, 0.0f, SpaceSize));
        lineRenderer.SetPosition(1, Quaternion.Euler(end.Declination, end.RightAscension, 0.0f) * new Vector3(0.0f, 0.0f, SpaceSize));

        return line;
    }

    // StarData�� ������ �˻�
    StarData GetStar(int hip)
    {
        // ���� HIP ��ȣ�� �˻�
        return ConstellationData.Stars.FirstOrDefault(s => hip == s.Hip);
    }

    // ���ڸ� �̸��� �ۼ�
    GameObject CreateName(ConstellationNameData nameData, ConstellationPositionData positionData, ConstellationDesData desData)
    {
        // ���ڸ� �̸��� ���������κ��� �ν��Ͻ� �ۼ�
        var text = Instantiate(namePrefab);
        var textTrans = text.transform;

        // ���� ���̴� �������� ȸ����Ų��
        textTrans.localRotation = Quaternion.Euler(positionData.Declination, positionData.RightAscension, 0.0f);
        text.name = nameData.Name;

        // �ڽ��� 3D text ��ġ�� õ���� ��ġ�� �̵���Ų��
        var child1 = textTrans.GetChild(0);
        //var child2 = textTrans.GetChild(1);

        child1.transform.localPosition = new Vector3(0.0f, 0.0f, SpaceSize);
        //child2.transform.localPosition = new Vector3(0.0f, -1f, SpaceSize);

        // TextMesh�� ����ϰ� ���ڸ� �̸����� �����Ѵ�
        var textMesh1 = child1.GetComponent<TextMesh>();
        //var textMesh2 = child2.GetComponent<TextMesh>();
        textMesh1.text = string.Format("{0}�ڸ�", nameData.KoreanName);
        //textMesh2.text = string.Format("{0}", desData.Description);


        textTrans.localScale = new Vector3(15.0f, 15.0f, 1f);
        textMesh1.anchor = TextAnchor.MiddleCenter;
        
               
        //textMesh2.anchor = TextAnchor.MiddleCenter;
        
        var boxCollider = text.AddComponent<BoxCollider>();

        boxCollider.size = new Vector3(10f, 4f, 0.1f);

        // Set the position of the Box Collider to match the text position
        boxCollider.center = child1.localPosition;
        
        // Enable the Box Collider
        boxCollider.enabled = true;              

        return text;
    }
}
