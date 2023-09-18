using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    [SerializeField]
    int lineCount = 100;        // ������ �׸��� ��
    [SerializeField]
    Color color = Color.white;  // ������ ��
    [SerializeField]
    float radius = 1000.0f;     // ���� �ݰ�
    public float rotationSpeed = 30f;

    Material lineMaterial;      // ������ ���͸���

    // ������ ���͸��� �ۼ�
    void CreateLineMaterial()
    {
        // �ѹ��� �ۼ��Ѵ�
        if(lineMaterial == null)
        {
            // ����Ƽ�� ǥ�� ���̴��� ���
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            // ���͸����� �ۼ��ؼ� ���̴��� ����
            lineMaterial = new Material(shader);
            // �� ���͸����� ���̷���Ű�� ǥ������ �ʴ´�, ���� �������� �ʴ´�
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    // ��� ī�޶��� ���� �׸� �Ŀ� ȣ��Ǵ� �׸��� �Լ�
    public void OnRenderObject()
    {
        // ���͸����� �ۼ�
        CreateLineMaterial();

        // ���͸����� ����
        lineMaterial.SetPass(0);

        // ���� ��Ʈ���� ������ ����
        GL.PushMatrix();

        // ���� ��Ʈ���� ������ �� ���� ������Ʈ�� ��Ʈ���� ������ ����
        GL.MultMatrix(transform.localToWorldMatrix);

        // ���� �׸��⸦ �����Ѵ�
        GL.Begin(GL.LINES);

        // �÷� ����
        GL.Color(color);

        // XZ ��鿡 ���� �׸���
        {
            // ó���� ���� ��ġ
            var startPoint = new Vector3(Mathf.Cos(0.0f) * radius, 0.0f, Mathf.Sin(0.0f) * radius);

            // �ϳ� ���� ���� ��ġ
            var oldPoint = startPoint;
            for(var Li = 0; Li < lineCount; ++Li)
            {
                // �̹��� ����
                var angleRadian = (float)Li / (float)lineCount * (Mathf.PI * 2.0f);

                // �̹��� ���� ��ġ
                var newPoint = new Vector3(Mathf.Cos(angleRadian) * radius, 0.0f, Mathf.Sin(angleRadian) * radius);

                // ������ ���� ��ġ���� �̹� ��ġ�� ������ �ߴ´�
                GL.Vertex(oldPoint);
                GL.Vertex(newPoint);
                
                // �̹� ��ġ�� ����
                oldPoint = newPoint;
            }

            // �������� �������� ó�� �������� ������ �ߴ´�
            GL.Vertex(oldPoint);
            GL.Vertex(startPoint);
        }
        //���� �׸��⸦ �����Ѵ�
        GL.End();

        // ������ ��Ʈ���� ������ �ǵ�����
        GL.PopMatrix();
    }

    void Update()
    {
        // Y���� �߽����� ȸ��
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
