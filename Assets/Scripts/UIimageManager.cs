using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIimageManager : MonoBehaviour
{
    
    public GameObject constellationViewer;
    public GameObject stellaImage;
    public GameObject virgo;
    public GameObject libra;
    public GameObject scorpius;
    public GameObject sagittarius;
    public GameObject capricornus;
    public GameObject aquarius;
    public GameObject pisces;
    public GameObject aries;
    public GameObject taurus;
    public GameObject gemini;
    public GameObject cancer;
    public GameObject leo;
    public GameObject orion;
    public GameObject canismajor;
    public GameObject canisminor;
    public GameObject cassiopeia;
    public GameObject bootes;
    public GameObject auriga;
    public GameObject perseus;
    public GameObject pegasus;
    public GameObject lyra;
    public GameObject cygnus;
    public GameObject aquila;
    public GameObject ursamajor;
    public GameObject ursaminor;
    public GameObject andromeda;
    public GameObject ground;

    public Transform g;
    

    GameObject viewer;

    public float rotSpeed = 1f; 

    Vector3 springRot;
    Vector3 summerRot;
    Vector3 autumnRot;
    Vector3 winterRot;
    Vector3 southRot;
    Vector3 northRot;

    Quaternion startRot;
    Quaternion spring;
    Quaternion summer;
    Quaternion autumn;
    Quaternion winter;
    Quaternion south;
    Quaternion north;

    bool obj = false;
    bool springRotating = false;
    bool summerRotating = false;
    bool autumnRotating = false;
    bool winterRotating = false;
    bool southRotating = false;
    bool northRotating = false;

    void Start()
    {
        viewer = GameObject.Find("ConstellationViewer");
        springRot = new Vector3(51.412f, -70.8f, 15.227f);
        summerRot = new Vector3(-22.14f, 17.86f, 49.477f);
        autumnRot = new Vector3(-52.95f, 86.797f, 2.558f);
        winterRot = new Vector3(8.628f, 186.566f, -52.504f);
        southRot = new Vector3(0f, 0f, 125f);
        northRot = new Vector3(0f, 0f, 53f);

        startRot = g.rotation;
        spring = Quaternion.Euler(springRot);
        summer = Quaternion.Euler(summerRot);
        autumn = Quaternion.Euler(autumnRot);
        winter = Quaternion.Euler(winterRot);
        south = Quaternion.Euler(southRot);
        north = Quaternion.Euler(northRot);

    }

    // Update is called once per frame
    void Update()
    {
        if (southRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, south, step);

            if (Quaternion.Angle(g.rotation, south) < 0.1f)
            {
                southRotating = false;
            }
        }
        else if (northRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, north, step);

            if (Quaternion.Angle(g.rotation, north) < 0.1f)
            {
                northRotating = false;
            }
        }
        else if (springRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, spring, step);

            if(Quaternion.Angle(g.rotation, spring) < 0.1f)
            {
                springRotating = false;
            }
        }
        else if (summerRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, summer, step);

            if (Quaternion.Angle(g.rotation, summer) < 0.1f)
            {
                summerRotating = false;
            }
        }
        else if (autumnRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, autumn, step);

            if (Quaternion.Angle(g.rotation, autumn) < 0.1f)
            {
                autumnRotating = false;
            }
        }
        else if (winterRotating)
        {
            float step = rotSpeed * Time.deltaTime;
            g.rotation = Quaternion.Lerp(g.rotation, winter, step);

            if (Quaternion.Angle(g.rotation, winter) < 0.1f)
            {
                winterRotating = false;
            }
        }
    }
    public void RemoveGround()
    {
        if (!obj)
        {
            ground.SetActive(true);
            obj = true;
        }
        else
        {
            ground.SetActive(false);
            obj = false;
        }
    }
    public void SouthernRot()
    {
        southRotating = true;
    }
    public void northernRot()
    {
        northRotating = true;
    }

    public void NorthernImage() // ��ü �̹���
    {
        if (!obj)
        {
            virgo.SetActive(true);
            libra.SetActive(true);
            scorpius.SetActive(true);
            sagittarius.SetActive(true);
            capricornus.SetActive(true);
            aquarius.SetActive(true);
            pisces.SetActive(true);
            aries.SetActive(true);
            taurus.SetActive(true);
            gemini.SetActive(true);
            cancer.SetActive(true);
            leo.SetActive(true);
            orion.SetActive(true);
            canismajor.SetActive(true);
            canisminor.SetActive(true);
            cassiopeia.SetActive(true);
            bootes.SetActive(true);
            auriga.SetActive(true);
            perseus.SetActive(true);
            pegasus.SetActive(true);
            lyra.SetActive(true);
            cygnus.SetActive(true);
            aquila.SetActive(true);
            ursamajor.SetActive(true);
            ursaminor.SetActive(true);
            andromeda.SetActive(true);

            obj = true;
        }
        else
        {
            virgo.SetActive(false);
            libra.SetActive(false);
            scorpius.SetActive(false);
            sagittarius.SetActive(false);
            capricornus.SetActive(false);
            aquarius.SetActive(false);
            pisces.SetActive(false);
            aries.SetActive(false);
            taurus.SetActive(false);
            gemini.SetActive(false);
            cancer.SetActive(false);
            leo.SetActive(false);
            orion.SetActive(false);
            canismajor.SetActive(false);
            canisminor.SetActive(false);
            cassiopeia.SetActive(false);
            bootes.SetActive(false);
            auriga.SetActive(false);
            perseus.SetActive(false);
            pegasus.SetActive(false);
            lyra.SetActive(false);
            cygnus.SetActive(false);
            aquila.SetActive(false);
            ursamajor.SetActive(false);
            ursaminor.SetActive(false);
            andromeda.SetActive(false);

            obj = false;
        }
    }
    public void SpringImage() // �� ���ڸ� �̹���
    {
        springRotating = true;

        if (!obj)
        {
            virgo.SetActive(true);
            libra.SetActive(true);
            leo.SetActive(true);
            bootes.SetActive(true);
            obj = true;
        }
        else
        {
            virgo.SetActive(false);
            libra.SetActive(false);
            leo.SetActive(false);
            bootes.SetActive(false);
            obj = false;
        }

        
    }   
    public void SummerImage() // ���� ���ڸ� �̹���
    {
        summerRotating = true;

        if (!obj)
        {
            scorpius.SetActive(true);
            sagittarius.SetActive(true);
            cygnus.SetActive(true);
            aquila.SetActive(true);
            lyra.SetActive(true);
            obj = true;
        }
        else
        {
            scorpius.SetActive(false);
            sagittarius.SetActive(false);
            cygnus.SetActive(false);
            aquila.SetActive(false);
            lyra.SetActive(false);
            obj = false;
        }

    }
    public void AutumnImage() // ���� ���ڸ� �̹���
    {
        autumnRotating = true;
        if (!obj)
        {
            pegasus.SetActive(true);
            perseus.SetActive(true);
            cassiopeia.SetActive(true);
            andromeda.SetActive(true);
            aquarius.SetActive(true);
            pisces.SetActive(true);
            capricornus.SetActive(true);
            aries.SetActive(true);
            obj = true;
        }
        else
        {
            pegasus.SetActive(false);
            perseus.SetActive(false);
            cassiopeia.SetActive(false);
            andromeda.SetActive(false);
            aquarius.SetActive(false);
            pisces.SetActive(false);
            capricornus.SetActive(false);
            aries.SetActive(false);
            obj = false;
        }
    }
    public void WinterImage() // �ܿ� ���ڸ� �̹���
    {
        winterRotating = true;  
        if (!obj)
        {
            orion.SetActive(true);
            taurus.SetActive(true);
            auriga.SetActive(true);
            canismajor.SetActive(true);
            canisminor.SetActive(true);
            gemini.SetActive(true);
            cancer.SetActive(true);
            obj = true;
        }
        else
        {
            orion.SetActive(false);
            taurus.SetActive(false);
            auriga.SetActive(false);
            canismajor.SetActive(false);
            canisminor.SetActive(false);
            gemini.SetActive(false);
            cancer.SetActive(false);
            obj = false;
        }
    }
    public void Virgo() // ó���ڸ�
    {
        if (!obj)
        {
            virgo.SetActive(true);
            obj = true;
        }
        else
        {
            virgo.SetActive(false);
            obj= false;
        }
    } 
    public void Libra()// õĪ�ڸ�
    {
        if (!obj)
        {
            libra.SetActive(true);
            obj = true;
        }
        else
        {
            libra.SetActive(false);
            obj = false;
        }
    } 
    public void Scorpius()// �����ڸ�
    {
        if (!obj)
        {
            scorpius.SetActive(true);
            obj = true;
        }
        else
        {
            scorpius.SetActive(false);
            obj = false;
        }
    } 
    public void Sagittarius()
    {
        if (!obj)
        {
            sagittarius.SetActive(true);
            obj = true;
        }
        else
        {
            sagittarius.SetActive(false);
            obj = false;
        }
    } // �ü��ڸ�
    public void Capricornus()
    {
        if (!obj)
        {
            capricornus.SetActive(true);
            obj = true;
        }
        else
        {
            capricornus.SetActive(false);
            obj = false;
        }
    } // �����ڸ�
    public void Aquarius()
    {
        if (!obj)
        {
            aquarius.SetActive(true);
            obj = true;
        }
        else
        {
            aquarius.SetActive(false);
            obj = false;
        }
    } // �����ڸ�
    public void Pisces()
    {
        if (!obj)
        {
            pisces.SetActive(true);
            obj = true;
        }
        else
        {
            pisces.SetActive(false);
            obj = false;
        }
    } // ������ڸ�
    public void Aries()
    {
        if (!obj)
        {
            aries.SetActive(true);
            obj = true;
        }
        else
        {
            aries.SetActive(false);
            obj = false;
        }
    } // ���ڸ�
    public void Taurus()
    {
        if (!obj)
        {
            taurus.SetActive(true);
            obj = true;
        }
        else
        {
            taurus.SetActive(false);
            obj = false;
        }
    } // Ȳ���ڸ�
    public void Gemini()
    {
        if (!obj)
        {
            gemini.SetActive(true);
            obj = true;
        }
        else
        {
            gemini.SetActive(false);
            obj = false;
        }
    } // �ֵ����ڸ�
    public void Cancer()
    {
        if (!obj)
        {
            cancer.SetActive(true);
            obj = true;
        }
        else
        {
            cancer.SetActive(false);
            obj = false;
        }
    } // ���ڸ�
    public void Leo()
    {
        if (!obj)
        {
            leo.SetActive(true);
            obj = true;
        }
        else
        {
            leo.SetActive(false);
            obj = false;
        }
    } // �����ڸ�
    public void Andromeda()
    {
        if (!obj)
        {
            andromeda.SetActive(true);
            obj = true;
        }
        else
        {
            andromeda.SetActive(false);
            obj = false;
        }
    } // �ȵ�θ޴��ڸ�
    public void Aquila()
    {
        if (!obj)
        {
            aquila.SetActive(true);
            obj = true;
        }
        else
        {
            aquila.SetActive(false);
            obj = false;
        }
    } // �������ڸ�
    public void Auriga()
    {
        if (!obj)
        {
            auriga.SetActive(true);
            obj = true;
        }
        else
        {
            auriga.SetActive(false);
            obj = false;
        }
    } // �������ڸ�
    public void Bootes()
    {
        if (!obj)
        {
            bootes.SetActive(true);
            obj = true;
        }
        else
        {
            bootes.SetActive(false);
            obj = false;
        }
    } // ���ڸ�
    public void CanisMajor()
    {
        if (!obj)
        {
            canismajor.SetActive(true);
            obj = true;
        }
        else
        {
            canismajor.SetActive(false);
            obj = false;
        }
    } // ū���ڸ�
    public void CanisMinor()
    {
        if (!obj)
        {
            canisminor.SetActive(true);
            obj = true;
        }
        else
        {
            canisminor.SetActive(false);
            obj = false;
        }
    } // �������ڸ�
    public void Cassiopeia()
    {
        if (!obj)
        {
            cassiopeia.SetActive(true);
            obj = true;
        }
        else
        {
            cassiopeia.SetActive(false);
            obj = false;
        }
    } // ī�ÿ����̾��ڸ�
    public void Orion()
    {
        if (!obj)
        {
            orion.SetActive(true);
            obj = true;
        }
        else
        {
            orion.SetActive(false);
            obj = false;
        }
    } // �������ڸ�
    public void Perseus()
    {
        if (!obj)
        {
            perseus.SetActive(true);
            obj = true;
        }
        else
        {
            perseus.SetActive(false);
            obj = false;
        }
    } // �丣���콺�ڸ�
    public void Pegasus()
    {
        if (!obj)
        {
            pegasus.SetActive(true);
            obj = true;
        }
        else
        {
            pegasus.SetActive(false);
            obj = false;
        }
    } // �䰡�����ڸ�
    public void Lyra()
    {
        if (!obj)
        {
            lyra.SetActive(true);
            obj = true;
        }
        else
        {
            lyra.SetActive(false);
            obj = false;
        }
    } // �Ź����ڸ�
    public void Cygnus()
    {
        if (!obj)
        {
            cygnus.SetActive(true);
            obj = true;
        }
        else
        {
            cygnus.SetActive(false);
            obj = false;
        }
    } // �����ڸ�
    public void UrsaMajor()
    {
        if (!obj)
        {
            ursamajor.SetActive(true);
            obj = true;
        }
        else
        {
            ursamajor.SetActive(false);
            obj = false;
        }
    } // ū���ڸ�
    public void UrsaMinor()
    {
        if (!obj)
        {
            ursaminor.SetActive(true);
            obj = true;
        }
        else
        {
            ursaminor.SetActive(false);
            obj = false;
        }
    } // �������ڸ�
}
