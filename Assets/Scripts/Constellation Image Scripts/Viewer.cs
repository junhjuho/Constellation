using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer : MonoBehaviour
{
    public GameObject andromeda;
    public GameObject antlia;
    public GameObject apus;
    public GameObject aquarius;
    public GameObject aquila;
    public GameObject ara;
    public GameObject aries;
    public GameObject auriga;
    public GameObject bootes;
    public GameObject caelum;
    public GameObject camelopardalis;
    public GameObject cancer;
    public GameObject canesvenatici;
    public GameObject canismajor;
    public GameObject canisminor;
    public GameObject capricornus;
    public GameObject carina;
    public GameObject cassiopeia;
    public GameObject centaurus;
    public GameObject cepheus;
    public GameObject cetus;
    public GameObject chamaeleon;
    public GameObject circinus;
    public GameObject columba;
    public GameObject comaberenices;
    public GameObject coronaaustralis;
    public GameObject coronaborealis;
    public GameObject corvus;
    public GameObject crater;
    public GameObject crux;
    public GameObject cygnus;
    public GameObject delphinus;
    public GameObject dorado;
    public GameObject draco;
    public GameObject equuleus;
    public GameObject eridanus;
    public GameObject fornax;
    public GameObject gemini;
    public GameObject grus;
    public GameObject hercules;
    public GameObject horologium;
    public GameObject hydra;
    public GameObject hydrus;
    public GameObject indus;
    public GameObject lacerta;
    public GameObject leo;
    public GameObject leominor;
    public GameObject lepus;
    public GameObject libra;
    public GameObject lupus;
    public GameObject lynx;
    public GameObject lyra;
    public GameObject mensa;
    public GameObject microscopium;
    public GameObject monoceros;
    public GameObject musca;
    public GameObject norma;
    public GameObject octans;
    public GameObject ophiuchus;
    public GameObject orion;
    public GameObject pavo;
    public GameObject pegasus;
    public GameObject perseus;
    public GameObject phoenix;
    public GameObject pictor;
    public GameObject pisces;
    public GameObject piscisaustrinus;
    public GameObject puppis;
    public GameObject pyxis;
    public GameObject reticulum;
    public GameObject sagitta;
    public GameObject sagittarius;
    public GameObject scorpius;
    public GameObject sculptor;
    public GameObject scutum;
    public GameObject serpens;
    public GameObject sextans;
    public GameObject taurus;
    public GameObject telescopium;
    public GameObject triangulum;
    public GameObject triangulumaustrale;
    public GameObject tucana;
    public GameObject ursamajor;
    public GameObject ursaminor;
    public GameObject vela;
    public GameObject virgo;
    public GameObject volans;
    public GameObject vulpecula;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        andromeda = transform.Find("Andromeda").gameObject; // �ȵ�θ޴��ڸ�
        antlia = transform.Find("Antlia").gameObject; // ���������ڸ�
        apus = transform.Find("Apus").gameObject; // �ض����ڸ�
        aquarius = transform.Find("Aquarius").gameObject; // �����ڸ�
        aquila = transform.Find("Aquila").gameObject; // �������ڸ�
        ara = transform.Find("Ara").gameObject; // �����ڸ�
        aries = transform.Find("Aries").gameObject; // ���ڸ�
        auriga = transform.Find("Auriga").gameObject; // �������ڸ�
        bootes = transform.Find("Bootes").gameObject; // ���ڸ�
        caelum = transform.Find("Caelum").gameObject; // ����Į�ڸ�
        camelopardalis = transform.Find("Camelopardalis").gameObject; // �⸰�ڸ�
        cancer = transform.Find("Cancer").gameObject; // ���ڸ�
        canesvenatici = transform.Find("Canes Venatici").gameObject; // ��ɰ��ڸ�
        canismajor = transform.Find("Canis Major").gameObject; // ū���ڸ�
        canisminor = transform.Find("Canis Minor").gameObject; // �������ڸ�
        capricornus = transform.Find("Capricornus").gameObject; // �����ڸ�
        carina = transform.Find("Carina").gameObject; // ����ڸ�
        cassiopeia = transform.Find("Cassiopeia").gameObject; // ī�ÿ����̾��ڸ�
        centaurus = transform.Find("Centaurus").gameObject; // ��Ÿ��罺�ڸ�
        cepheus = transform.Find("Cepheus").gameObject; // ����콺�ڸ�
        cetus = transform.Find("Cetus").gameObject; // ���ڸ�
        chamaeleon = transform.Find("Chamaeleon").gameObject; // ī�᷹���ڸ�
        circinus = transform.Find("Circinus").gameObject; // ���۽��ڸ�
        columba = transform.Find("Columba").gameObject; // ��ѱ��ڸ�
        comaberenices = transform.Find("Coma Berenices").gameObject; // �Ӹ����ڸ�
        coronaaustralis = transform.Find("Corona Australis").gameObject; // ���ʿհ��ڸ�
        coronaborealis = transform.Find("Corona Borealis").gameObject; // ���ʿհ��ڸ�
        corvus = transform.Find("Corvus").gameObject; // ����ڸ�
        crater = transform.Find("Crater").gameObject; // ���ڸ�
        crux = transform.Find("Crux").gameObject; // �������ڸ�
        cygnus = transform.Find("Cygnus").gameObject; // �����ڸ�
        delphinus = transform.Find("Delphinus").gameObject; // �����ڸ�
        dorado = transform.Find("Dorado").gameObject; // Ȳ��ġ�ڸ�
        draco = transform.Find("Draco").gameObject; // ���ڸ�
        equuleus = transform.Find("Equuleus").gameObject; // �������ڸ� 
        eridanus = transform.Find("Eridanus").gameObject; // �����ٴ����ڸ�
        fornax = transform.Find("Fornax").gameObject; // ȭ���ڸ�
        gemini = transform.Find("Gemini").gameObject; // �ֵ����ڸ�
        grus = transform.Find("Grus").gameObject;    // �η���ڸ�
        hercules = transform.Find("Hercules").gameObject;  // ���Ŭ�����ڸ�
        horologium = transform.Find("Horologium").gameObject;   //�ð��ڸ�
        hydra = transform.Find("Hydra").gameObject;   //�ٴٹ��ڸ�
        hydrus = transform.Find("Hydrus").gameObject;   //�����ڸ�
        indus = transform.Find("Indus").gameObject;   //�ε���ڸ�
        lacerta = transform.Find("Lacerta").gameObject; // �������ڸ�
        leo = transform.Find("Leo").gameObject;  // �����ڸ�
        leominor = transform.Find("Leo Minor").gameObject; // ���������ڸ�
        lepus = transform.Find("Lepus").gameObject; // �䳢�ڸ�
        libra = transform.Find("Libra").gameObject; // õĪ�ڸ�
        lupus = transform.Find("Lupus").gameObject; // �̸��ڸ�
        lynx = transform.Find("Lynx").gameObject; // �������ڸ�
        lyra = transform.Find("Lyra").gameObject; // �Ź����ڸ�
        mensa = transform.Find("Mensa").gameObject; // ���̺���ڸ�
        microscopium = transform.Find("Microscopium").gameObject; // ���̰��ڸ�
        monoceros = transform.Find("Monoceros").gameObject; // �ܻԼ��ڸ�
        musca = transform.Find("Musca").gameObject; // �ĸ��ڸ�
        norma = transform.Find("Norma").gameObject; // �������ڸ�
        octans = transform.Find("Octans").gameObject; // �Ⱥ����ڸ�
        ophiuchus = transform.Find("Ophiuchus").gameObject; // �������ڸ�
        orion = transform.Find("Orion").gameObject; // �������ڸ�
        pavo = transform.Find("Pavo").gameObject; // �����ڸ�
        pegasus = transform.Find("Pegasus").gameObject; // �䰡�����ڸ�
        perseus = transform.Find("Perseus").gameObject; // �丣���콺�ڸ�
        phoenix = transform.Find("Phoenix").gameObject; // �һ����ڸ�
        pictor = transform.Find("Pictor").gameObject; // ȭ���ڸ�
        pisces = transform.Find("Pisces").gameObject; // ������ڸ�
        piscisaustrinus = transform.Find("Piscis Austrinus").gameObject; // ���ʹ�����ڸ�
        puppis = transform.Find("Puppis").gameObject; // ���ڸ�
        pyxis = transform.Find("Pyxis").gameObject; // ��ħ���ڸ�
        reticulum = transform.Find("Reticulum").gameObject; // �׹��ڸ�
        sagitta = transform.Find("Sagitta").gameObject; // ȭ���ڸ�
        sagittarius = transform.Find("Sagittarius").gameObject; // �ü��ڸ�
        scorpius = transform.Find("Scorpius").gameObject; // �����ڸ�
        sculptor = transform.Find("Sculptor").gameObject; // �������ڸ�
        scutum = transform.Find("Scutum").gameObject; // �����ڸ�
        serpens = transform.Find("Serpens").gameObject; // ���ڸ�
        sextans = transform.Find("Sextans").gameObject; // �������ڸ�
        taurus = transform.Find("Taurus").gameObject; // Ȳ���ڸ�
        telescopium = transform.Find("Telescopium").gameObject; //�������ڸ�
        triangulum = transform.Find("Triangulum").gameObject; // �ﰢ���ڸ�
        triangulumaustrale = transform.Find("Triangulum Australe").gameObject; // ���ʻﰢ���ڸ�
        tucana = transform.Find("Tucana").gameObject; // ū�θ����ڸ�
        ursamajor = transform.Find("Ursa Major").gameObject; // ū���ڸ�
        ursaminor = transform.Find("Ursa Minor").gameObject; // �������ڸ�
        vela = transform.Find("Vela").gameObject; // ���ڸ�
        virgo = transform.Find("Virgo").gameObject; // ó���ڸ�
        volans = transform.Find("Volans").gameObject; // ��ġ�ڸ�
        vulpecula = transform.Find("Vulpecula").gameObject; // �����ڸ�
    }
}
