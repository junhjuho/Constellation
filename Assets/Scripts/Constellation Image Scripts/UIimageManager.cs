using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WindowsMR.Input;

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
    public GameObject corvus;
    public GameObject crater;
    public GameObject crux;
    public GameObject delphinus;
    public GameObject dorado;
    public GameObject draco;
    public GameObject equuleus;
    public GameObject eridanus;
    public GameObject fornax;
    public GameObject grus;
    public GameObject hercules;
    public GameObject horologium;
    public GameObject hydra;
    public GameObject hydrus;
    public GameObject indus;
    public GameObject lacerta;
    public GameObject leominor;
    public GameObject lepus;
    public GameObject lupus;
    public GameObject lynx;
    public GameObject mensa;
    public GameObject microscopium;
    public GameObject monoceros;
    public GameObject musca;
    public GameObject norma;
    public GameObject octans;
    public GameObject ophiuchus;
    public GameObject pavo;
    public GameObject phoenix;
    public GameObject pictor;
    public GameObject vela;
    public GameObject volans;
    public GameObject vulpecula;
    public GameObject piscisaustrinus;
    public GameObject puppis;
    public GameObject pyxis;
    public GameObject reticulum;
    public GameObject sagitta;
    public GameObject sculptor;
    public GameObject scutum;
    public GameObject serpens;
    public GameObject sextans;
    public GameObject telescopium;
    public GameObject triangulumaustrale;
    public GameObject triangulum;
    public GameObject tucana;


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
            cepheus.SetActive(true);
            draco.SetActive(true);
            camelopardalis.SetActive(true);
            aquarius.SetActive(true);
            aquila.SetActive (true);
            canesvenatici.SetActive(true);
            capricornus.SetActive(true);
            cetus.SetActive(true);
            comaberenices.SetActive(true);
            coronaBorealis.SetActive(true);
            corvus.SetActive(true);
            crater.SetActive(true);
            delphinus.SetActive(true);
            equuleus.SetActive(true);
            eridanus.SetActive(true);
            hercules.SetActive(true);
            hydra.SetActive(true);
            lacerta.SetActive(true);
            leominor.SetActive (true);
            lepus.SetActive(true);
            lynx.SetActive(true);
            monoceros.SetActive(true);
            ophiuchus.SetActive(true);
            piscisaustrinus.SetActive(true);
            sagitta.SetActive(true);
            scutum.SetActive(true);
            serpens.SetActive(true);
            sextans.SetActive(true);
            triangulum.SetActive(true);
            vulpecula.SetActive(true);

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
            cepheus.SetActive(false);
            draco.SetActive(false);
            camelopardalis.SetActive(false);
            aquarius.SetActive(false);
            aquila.SetActive(false);
            canesvenatici.SetActive(false);
            capricornus.SetActive(false);
            cetus.SetActive(false);
            comaberenices.SetActive(false);
            coronaBorealis.SetActive(false);
            corvus.SetActive(false);
            crater.SetActive(false);
            delphinus.SetActive(false);
            equuleus.SetActive(false);
            eridanus.SetActive(false);
            hercules.SetActive(false);
            hydra.SetActive(false);
            lacerta.SetActive(false);
            leominor.SetActive(false);
            lepus.SetActive(false);
            lynx.SetActive(false);
            monoceros.SetActive(false);
            ophiuchus.SetActive(false);
            piscisaustrinus.SetActive(false);
            sagitta.SetActive(false);
            scutum.SetActive(false);
            serpens.SetActive(false);
            sextans.SetActive(false);
            triangulum.SetActive(false);
            vulpecula.SetActive(false);

            obj = false;
        }
    }

    public void SouthernImage()
    {
        if (!obj)
        {
            antila.SetActive(true);
            apus.SetActive(true);
            ara.SetActive(true);
            caelum.SetActive(true);
            carina.SetActive(true);
            centaurus.SetActive(true);
            chamaeleon.SetActive(true);
            circinus.SetActive(true);
            columba.SetActive(true);
            coronaAustralis.SetActive(true);
            crux.SetActive(true);
            horologium.SetActive(true);
            hydrus.SetActive(true);
            indus.SetActive(true);
            lupus.SetActive(true);
            mensa.SetActive(true);
            microscopium.SetActive(true);
            musca.SetActive(true);
            norma.SetActive(true);
            octans.SetActive(true);
            pavo.SetActive(true);
            phoenix.SetActive(true);
            pictor.SetActive(true);
            puppis.SetActive(true);
            pyxis.SetActive(true);
            reticulum.SetActive(true);
            sculptor.SetActive(true);
            telescopium.SetActive(true);
            triangulumaustrale.SetActive(true);
            tucana.SetActive(true);
            vela.SetActive(true);
            volans.SetActive(true);
        }
        else
        {
            antila.SetActive(false);
            apus.SetActive(false);
            ara.SetActive(false);
            caelum.SetActive(false);
            carina.SetActive(false);
            centaurus.SetActive(false);
            chamaeleon.SetActive(false);
            circinus.SetActive(false);
            columba.SetActive(false);
            coronaAustralis.SetActive(false);
            crux.SetActive(false);
            horologium.SetActive(false);
            hydrus.SetActive(false);
            indus.SetActive(false);
            lupus.SetActive(false);
            mensa.SetActive(false);
            microscopium.SetActive(false);
            musca.SetActive(false);
            norma.SetActive(false);
            octans.SetActive(false);
            pavo.SetActive(false);
            phoenix.SetActive(false);
            pictor.SetActive(false);
            puppis.SetActive(false);
            pyxis.SetActive(false);
            reticulum.SetActive(false);
            sculptor.SetActive(false);
            telescopium.SetActive(false);
            triangulumaustrale.SetActive(false);
            tucana.SetActive(false);
            vela.SetActive(false);
            volans.SetActive(false);
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
    public void Corvus() // 까마귀자리
    {
        if (!obj)
        {
            corvus.SetActive(true);
            obj = true;
        }
        else
        {
            corvus.SetActive(false);
            obj = false;
        }
    }
    public void Crater() // 컵자리
    {
        if (!obj)
        {
            crater.SetActive(true);
            obj = true;
        }
        else
        {
            crater.SetActive(false);
            obj = false;
        }
    }
    public void Crux() // 남십자자리
    {
        if (!obj)
        {
            crux.SetActive(true);
            obj = true;
        }
        else
        {
            crux.SetActive(false);
            obj = false;
        }
    }
    public void Delphinus() // 돌고래자리
    {
        if (!obj)
        {
            delphinus.SetActive(true);
            obj = true;
        }
        else
        {
            delphinus.SetActive(false);
            obj = false;
        }
    }
    public void Dorado() // 황새치자리
    {
        if (!obj)
        {
            dorado.SetActive(true);
            obj = true;
        }
        else
        {
            dorado.SetActive(false);
            obj = false;
        }
    }
    public void Draco() // 용자리
    {
        if (!obj)
        {
            draco.SetActive(true);
            obj = true;
        }
        else
        {
            draco.SetActive(false);
            obj = false;
        }
    }
    public void Equuleus() // 조랑말자리
    {
        if (!obj)
        {
            equuleus.SetActive(true);
            obj = true;
        }
        else
        {
            equuleus.SetActive(false);
            obj = false;
        }
    }
    public void Eridanus() // 에리다누스자리
    {
        if (!obj)
        {
            eridanus.SetActive(true);
            obj = true;
        }
        else
        {
            eridanus.SetActive(false);
            obj = false;
        }
    }
    public void Fornax() // 화로자리
    {
        if (!obj)
        {
            fornax.SetActive(true);
            obj = true;
        }
        else
        {
            fornax.SetActive(false);
            obj = false;
        }
    }
    public void Grus() // 두루미자리
    {
        if (!obj)
        {
            grus.SetActive(true);
            obj = true;
        }
        else
        {
            grus.SetActive(false);
            obj = false;
        }
    }
    public void Hercules() // 헤라클레스자리
    {
        if (!obj)
        {
            hercules.SetActive(true);
            obj = true;
        }
        else
        {
            hercules.SetActive(false);
            obj = false;
        }
    }
    public void Horologium() // 시계자리
    {
        if (!obj)
        {
            horologium.SetActive(true);
            obj = true;
        }
        else
        {
            horologium.SetActive(false);
            obj = false;
        }
    }
    public void Hydra() // 바다뱀자리

    {
        if (!obj)
        {
            hydra.SetActive(true);
            obj = true;
        }
        else
        {
            hydra.SetActive(false);
            obj = false;
        }
    }
    public void Hydrus() // 물뱀자리
    {
        if (!obj)
        {
            hydrus.SetActive(true);
            obj = true;
        }
        else
        {
            hydrus.SetActive(false);
            obj = false;
        }
    }
    public void Indus() // 인디언자리

    {
        if (!obj)
        {
            indus.SetActive(true);
            obj = true;
        }
        else
        {
            indus.SetActive(false);
            obj = false;
        }
    }
    public void Lacerta() // 도마뱀자리
    {
        if (!obj)
        {
            lacerta.SetActive(true);
            obj = true;
        }
        else
        {
            lacerta.SetActive(false);
            obj = false;
        }
    }
    public void LeoMinor() // 작은사자자리

    {
        if (!obj)
        {
            leominor.SetActive(true);
            obj = true;
        }
        else
        {
            leominor.SetActive(false);
            obj = false;
        }
    }
    public void Lepus() // 토끼자리
    {
        if (!obj)
        {
            lepus.SetActive(true);
            obj = true;
        }
        else
        {
            lepus.SetActive(false);
            obj = false;
        }
    }
    public void Lupus() // 이리자리
    {
        if (!obj)
        {
            lupus.SetActive(true);
            obj = true;
        }
        else
        {
            lupus.SetActive(false);
            obj = false;
        }
    }
    public void Lynx() // 살쾡이자리
    {
        if (!obj)
        {
            lynx.SetActive(true);
            obj = true;
        }
        else
        {
            lynx.SetActive(false);
            obj = false;
        }
    }
    public void Mensa() // 테이블산자리
    {
        if (!obj)
        {
            mensa.SetActive(true);
            obj = true;
        }
        else
        {
            mensa.SetActive(false);
            obj = false;
        }
    }
    public void Microscopium() // 현미경자리
    {
        if (!obj)
        {
            microscopium.SetActive(true);
            obj = true;
        }
        else
        {
            microscopium.SetActive(false);
            obj = false;
        }
    }
    public void Monoceros() // 외뿔소자리
    {
        if (!obj)
        {
            monoceros.SetActive(true);
            obj = true;
        }
        else
        {
            monoceros.SetActive(false);
            obj = false;
        }
    }
    public void Musca() // 파리자리
    {
        if (!obj)
        {
            musca.SetActive(true);
            obj = true;
        }
        else
        {
            musca.SetActive(false);
            obj = false;
        }
    }
    public void Norma() // 직각자자리
    {
        if (!obj)
        {
            norma.SetActive(true);
            obj = true;
        }
        else
        {
            norma.SetActive(false);
            obj = false;
        }
    }
    public void Octans() // 팔분의자리
    {
        if (!obj)
        {
            octans.SetActive(true);
            obj = true;
        }
        else
        {
            octans.SetActive(false);
            obj = false;
        }
    }
    public void Ophiuchus() // 뱀주인자리
    {
        if (!obj)
        {
            ophiuchus.SetActive(true);
            obj = true;
        }
        else
        {
            ophiuchus.SetActive(false);
            obj = false;
        }
    }
    public void Pavo() // 공작자리
    {
        if (!obj)
        {
            pavo.SetActive(true);
            obj = true;
        }
        else
        {
            pavo.SetActive(false);
            obj = false;
        }
    }
    public void Phoenix() // 불사조자리
    {
        if (!obj)
        {
            phoenix.SetActive(true);
            obj = true;
        }
        else
        {
            phoenix.SetActive(false);
            obj = false;
        }
    }
    public void Pictor() // 조각가자리
    {
        if (!obj)
        {
            pictor.SetActive(true);
            obj = true;
        }
        else
        {
            pictor.SetActive(false);
            obj = false;
        }
    }
    public void Vela() // 돛자리
    {
        if (!obj)
        {
            vela.SetActive(true);
            obj = true;
        }
        else
        {
            vela.SetActive(false);
            obj = false;
        }
    }
    public void Vulpecula() // 작은여우자리
    {
        if (!obj)
        {
            vulpecula.SetActive(true);
            obj = true;
        }
        else
        {
            vulpecula.SetActive(false);
            obj = false;
        }
    }
    public void PiscisAustrinus() // 남쪽물고기자리
    {
        if (!obj)
        {
            piscisaustrinus.SetActive(true);
            obj = true;
        }
        else
        {
            piscisaustrinus.SetActive(false);
            obj = false;
        }
    }
    public void Puppis() // 고물자리
    {
        if (!obj)
        {
            puppis.SetActive(true);
            obj = true;
        }
        else
        {
            puppis.SetActive(false);
            obj = false;
        }
    }
    public void Pyxis() // 나침반자리
    {
        if (!obj)
        {
            pyxis.SetActive(true);
            obj = true;
        }
        else
        {
            pyxis.SetActive(false);
            obj = false;
        }
    }
    public void Reticulum() // 그물자리
    {
        if (!obj)
        {
            reticulum.SetActive(true);
            obj = true;
        }
        else
        {
            reticulum.SetActive(false);
            obj = false;
        }
    }
    public void Sagitta() // 화살자리
    {
        if (!obj)
        {
            sagitta.SetActive(true);
            obj = true;
        }
        else
        {
            sagitta.SetActive(false);
            obj = false;
        }
    }
    public void Sculptor() // 조각가자리
    {
        if (!obj)
        {
            sculptor.SetActive(true);
            obj = true;
        }
        else
        {
            sculptor.SetActive(false);
            obj = false;
        }
    }
    public void Scutum() // 방패자리
    {
        if (!obj)
        {
            scutum.SetActive(true);
            obj = true;
        }
        else
        {
            scutum.SetActive(false);
            obj = false;
        }
    }
    public void Serpens() // 뱀자리
    {
        if (!obj)
        {
            serpens.SetActive(true);
            obj = true;
        }
        else
        {
            serpens.SetActive(false);
            obj = false;
        }
    }
    public void Sextans() // 육분의자리
    {
        if (!obj)
        {
            sextans.SetActive(true);
            obj = true;
        }
        else
        {
            sextans.SetActive(false);
            obj = false;
        }
    }
    public void Telescopium() // 망원경자리
    {
        if (!obj)
        {
            telescopium.SetActive(true);
            obj = true;
        }
        else
        {
            telescopium.SetActive(false);
            obj = false;
        }
    }
    public void TriangulumAustrale() // 남쪽삼각형자리
    {
        if (!obj)
        {
            triangulumaustrale.SetActive(true);
            obj = true;
        }
        else
        {
            triangulumaustrale.SetActive(false);
            obj = false;
        }
    }
    public void Triangulum() // 삼각형자리
    {
        if (!obj)
        {
            triangulum.SetActive(true);
            obj = true;
        }
        else
        {
            triangulum.SetActive(false);
            obj = false;
        }
    }
    public void Tucana() // 큰부리새자리
    {
        if (!obj)
        {
            tucana.SetActive(true);
            obj = true;
        }
        else
        {
            tucana.SetActive(false);
            obj = false;
        }
    }

}
