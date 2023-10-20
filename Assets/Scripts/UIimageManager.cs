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
    public GameObject antila;
    public GameObject apus;
    public GameObject ara;
    public GameObject caelum;
    public GameObject camelopardalis;
    public GameObject canesvenatici;
    public GameObject carina;
    public GameObject centaurus;
    public GameObject cepheus;
    public GameObject cetus;
    public GameObject chamaeleon;
    public GameObject circinus;
    public GameObject columba;
    public GameObject comaberenices;
    public GameObject coronaAustralis;
    public GameObject coronaBorealis;


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

    public void NorthernImage() // 전체 이미지
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
    public void SpringImage() // 봄 별자리 이미지
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
    public void SummerImage() // 여름 별자리 이미지
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
    public void AutumnImage() // 가을 별자리 이미지
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
    public void WinterImage() // 겨울 별자리 이미지
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
    public void Virgo() // 처녀자리
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
    public void Libra()// 천칭자리
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
    public void Scorpius()// 전갈자리
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
    } // 궁수자리
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
    } // 염소자리
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
    } // 물병자리
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
    } // 물고기자리
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
    } // 양자리
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
    } // 황소자리
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
    } // 쌍둥이자리
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
    } // 게자리
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
    } // 사자자리
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
    } // 안드로메다자리
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
    } // 독수리자리
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
    } // 마차부자리
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
    } // 목동자리
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
    } // 큰개자리
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
    } // 작은개자리
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
    } // 카시오페이아자리
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
    } // 오리온자리
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
    } // 페르세우스자리
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
    } // 페가수스자리
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
    } // 거문고자리
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
    } // 백조자리
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
    } // 큰곰자리
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
    } // 작은곰자리
    public void Antila() // 공기펌프자리
    {
        if (!obj)
        {
            antila.SetActive(true);
            obj = true;
        }
        else
        {
            antila.SetActive(false);
            obj = false;
        }
    }
    public void Apus() // 극락조자리
    {
        if (!obj)
        {
            apus.SetActive(true);
            obj = true;
        }
        else
        {
            apus.SetActive(false);
            obj = false;
        }
    }
    public void Ara() // 제단자리
    {
        if (!obj)
        {
            ara.SetActive(true);
            obj = true;
        }
        else
        {
            ara.SetActive(false);
            obj = false;
        }
    }
    public void Caelum() // 조각칼자리
    {
        if (!obj)
        {
            caelum.SetActive(true);
            obj = true;
        }
        else
        {
            caelum.SetActive(false);
            obj = false;
        }
    }
    public void Camelopardalis() // 기린자리
    {
        if (!obj)
        {
            camelopardalis.SetActive(true);
            obj = true;
        }
        else
        {
            camelopardalis.SetActive(false);
            obj = false;
        }
    }
    public void CanesVenatici() // 사냥개자리
    {
        if (!obj)
        {
            canesvenatici.SetActive(true);
            obj = true;
        }
        else
        {
            canesvenatici.SetActive(false);
            obj = false;
        }
    }
    public void Carina() // 용골자리
    {
        if (!obj)
        {
            carina.SetActive(true);
            obj = true;
        }
        else
        {
            carina.SetActive(false);
            obj = false;
        }
    }
    public void Centaurus() // 센타우루스자리
    {
        if (!obj)
        {
            centaurus.SetActive(true);
            obj = true;
        }
        else
        {
            centaurus.SetActive(false);
            obj = false;
        }
    }
    public void Cepheus() // 세페우스자리
    {
        if (!obj)
        {
            cepheus.SetActive(true);
            obj = true;
        }
        else
        {
            cepheus.SetActive(false);
            obj = false;
        }
    }
    public void Cetus() // 고래자리
    {
        if (!obj)
        {
            cetus.SetActive(true);
            obj = true;
        }
        else
        {
            cetus.SetActive(false);
            obj = false;
        }
    }
    public void Chamaeleon() // 카멜레온자리
    {
        if (!obj)
        {
            chamaeleon.SetActive(true);
            obj = true;
        }
        else
        {
            chamaeleon.SetActive(false);
            obj = false;
        }
    }
    public void Circinus() // 컴퍼스자리
    {
        if (!obj)
        {
            circinus.SetActive(true);
            obj = true;
        }
        else
        {
            circinus.SetActive(false);
            obj = false;
        }
    }
    public void Columba() // 비둘기자리
    {
        if (!obj)
        {
            columba.SetActive(true);
            obj = true;
        }
        else
        {
            columba.SetActive(false);
            obj = false;
        }
    }
    public void ComaBerenices() // 머리털자리
    {
        if (!obj)
        {
            comaberenices.SetActive(true);
            obj = true;
        }
        else
        {
            comaberenices.SetActive(false);
            obj = false;
        }
    }
    public void CoronaAustralis() // 남쪽왕관자리
    {
        if (!obj)
        {
            coronaAustralis.SetActive(true);
            obj = true;
        }
        else
        {
            coronaAustralis.SetActive(false);
            obj = false;
        }
    }
    public void CoronaBorealis() // 북쪽왕관자리
    {
        if (!obj)
        {
            coronaBorealis.SetActive(true);
            obj = true;
        }
        else
        {
            coronaBorealis.SetActive(false);
            obj = false;
        }
    }
}
