using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private int _iyiToplanabilirDeger;

    [SerializeField] private int _kötüToplanabilirDeger;

    [SerializeField] private GameObject _karakterPaketi;

    [SerializeField] private Animator _gelinAnimator;

    [SerializeField] private GameObject _buketPaketi;

    [SerializeField] private List<GameObject> _cicekAtisNoktalari = new List<GameObject>();

    [SerializeField] private GameObject _atilacakCicekObjesi;

    [SerializeField] private GameObject _atilacakBuketSpawnPoint;

    [SerializeField] private GameObject _atilacakBuketObjesi;

    [SerializeField] private GameObject _vCamScript;

    private int _elmasSayisi;

    private GameObject _player;

    public UIController _uiController;

    private int _toplananElmasSayisi;

    private float _buketDegeri;

    private float _atisHizi;

    private GameObject _atilanBuket;


    void Start()
    {
        LevelStart();

       // _uiController = GameObject.Find("UIController").GetComponent<UIController>();

    }


    private void FixedUpdate()
    {
        if (GameController._oyunAktif == true)
        {
            _atisHizi += Time.deltaTime;

            if (_atisHizi > 0.2f)
            {
                if (_buketDegeri < 20)
                {
                    _cicekAtisNoktalari[1].SetActive(false);
                    _cicekAtisNoktalari[2].SetActive(false);
                    _cicekAtisNoktalari[3].SetActive(false);
                    _cicekAtisNoktalari[4].SetActive(false);
                    _cicekAtisNoktalari[0].SetActive(true);

                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[0].transform.GetChild(0).transform.position, Quaternion.identity);

                    _atisHizi = 0;

                }
                else if (_buketDegeri >= 20 && _buketDegeri < 30)
                {
                    _cicekAtisNoktalari[0].SetActive(false);
                    _cicekAtisNoktalari[2].SetActive(false);
                    _cicekAtisNoktalari[3].SetActive(false);
                    _cicekAtisNoktalari[4].SetActive(false);
                    _cicekAtisNoktalari[1].SetActive(true);

                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[1].transform.GetChild(0).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[1].transform.GetChild(1).transform.position, Quaternion.identity);

                    _atisHizi = 0;
                }
                else if (_buketDegeri >= 30 && _buketDegeri < 40)
                {
                    _cicekAtisNoktalari[1].SetActive(false);
                    _cicekAtisNoktalari[0].SetActive(false);
                    _cicekAtisNoktalari[3].SetActive(false);
                    _cicekAtisNoktalari[4].SetActive(false);
                    _cicekAtisNoktalari[2].SetActive(true);

                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[2].transform.GetChild(0).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[2].transform.GetChild(1).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[2].transform.GetChild(2).transform.position, Quaternion.identity);

                    _atisHizi = 0;
                }
                else if (_buketDegeri >= 40 && _buketDegeri < 50)
                {
                    _cicekAtisNoktalari[1].SetActive(false);
                    _cicekAtisNoktalari[2].SetActive(false);
                    _cicekAtisNoktalari[0].SetActive(false);
                    _cicekAtisNoktalari[4].SetActive(false);
                    _cicekAtisNoktalari[3].SetActive(true);

                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[3].transform.GetChild(0).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[3].transform.GetChild(1).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[3].transform.GetChild(2).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[3].transform.GetChild(3).transform.position, Quaternion.identity);

                    _atisHizi = 0;
                }
                else if (_buketDegeri >= 50)
                {
                    _cicekAtisNoktalari[1].SetActive(false);
                    _cicekAtisNoktalari[2].SetActive(false);
                    _cicekAtisNoktalari[3].SetActive(false);
                    _cicekAtisNoktalari[0].SetActive(false);
                    _cicekAtisNoktalari[4].SetActive(true);

                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[4].transform.GetChild(0).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[4].transform.GetChild(1).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[4].transform.GetChild(2).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[4].transform.GetChild(3).transform.position, Quaternion.identity);
                    Instantiate(_atilacakCicekObjesi, _cicekAtisNoktalari[4].transform.GetChild(4).transform.position, Quaternion.identity);

                    _atisHizi = 0;
                }
                else
                {

                }
            }
            else
            {

            }
        }
        else
        {

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Elmas")
        {
            _elmasSayisi += 1;
            _toplananElmasSayisi += 1;
            PlayerPrefs.SetInt("ElmasSayisi", _elmasSayisi);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "DegersizEsya")
        {

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            if (_buketDegeri > 10)
            {
                _buketDegeri -= 1;
                float buketbuyuklugu = _buketDegeri / 100;
                _buketPaketi.transform.localScale = new Vector3(buketbuyuklugu, buketbuyuklugu, buketbuyuklugu);
                _gelinAnimator.SetBool("Kosma", false);
                _gelinAnimator.SetBool("Tokezleme", true);
                _gelinAnimator.SetBool("Kosma", true);
                Invoke("TokezlemeKapat", 0.5f);
            }
            else
            {
                GameController._oyunAktif = false;
                _gelinAnimator.SetBool("Kosma", false);
                _gelinAnimator.SetBool("Tokezleme", false);
                _gelinAnimator.SetBool("Dusme", true);
                Invoke("LoseScreenAc", 3f);
                _uiController.LevelSonuElmasSayisi(0);
            }

        }
        else if (other.gameObject.tag == "Collectable")
        {

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            if (_buketDegeri < 50)
            {
                _buketDegeri += 1;
                float buketbuyuklugu = _buketDegeri / 100;
                _buketPaketi.transform.localScale = new Vector3(buketbuyuklugu, buketbuyuklugu, buketbuyuklugu);
            }
            else
            {

            }

            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "ToplamaKapisi")
        {

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            if (_buketDegeri < 50)
            {
                _buketDegeri += other.gameObject.GetComponent<KapiScript>()._kapiDegeri;
                float buketbuyuklugu = _buketDegeri / 100;
                _buketPaketi.transform.localScale = new Vector3(buketbuyuklugu, buketbuyuklugu, buketbuyuklugu);
            }
            else
            {

            }


        }
        else if (other.gameObject.tag == "CikartmaKapisi")
        {

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            if (_buketDegeri > (9 + other.gameObject.GetComponent<KapiScript>()._kapiDegeri))
            {
                _buketDegeri -= other.gameObject.GetComponent<KapiScript>()._kapiDegeri;
                float buketbuyuklugu = _buketDegeri / 100;
                _buketPaketi.transform.localScale = new Vector3(buketbuyuklugu, buketbuyuklugu, buketbuyuklugu);

            }
            else
            {
                GameController._oyunAktif = false;
                _gelinAnimator.SetBool("Kosma", false);
                _gelinAnimator.SetBool("Tokezleme", false);
                _gelinAnimator.SetBool("Dusme", true);
                Invoke("LoseScreenAc", 3f);
                _uiController.LevelSonuElmasSayisi(0);
            }

        }
        else if (other.gameObject.tag == "KosanNedime")
        {

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            if (_buketDegeri > 10)
            {
                _buketDegeri -= 1;
                float buketbuyuklugu = _buketDegeri / 100;
                _buketPaketi.transform.localScale = new Vector3(buketbuyuklugu, buketbuyuklugu, buketbuyuklugu);
                _gelinAnimator.SetBool("Kosma", false);
                _gelinAnimator.SetBool("Tokezleme", true);
                _gelinAnimator.SetBool("Kosma", true);
                Invoke("TokezlemeKapat", 0.5f);
            }
            else
            {
                GameController._oyunAktif = false;
                _gelinAnimator.SetBool("Kosma", false);
                _gelinAnimator.SetBool("Tokezleme", false);
                _gelinAnimator.SetBool("Dusme", true);
                Invoke("LoseScreenAc", 3f);
                _uiController.LevelSonuElmasSayisi(0);
            }

        }
       else if (other.gameObject.tag == "FinishSiniri")
        {

            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            GameController._oyunAktif = false;
            _player.transform.localPosition = new Vector3(0, 0.55f, 0);
            //GameObject.FindGameObjectWithTag("NedimePaketi").gameObject.SetActive(false);
            //GameObject.FindGameObjectWithTag("FinishPaketi").gameObject.SetActive(true);
            _gelinAnimator.SetBool("Kosma", false);
            _gelinAnimator.SetBool("Tokezleme", false);
            _gelinAnimator.SetBool("Idle", true);

            if (_buketDegeri < 14)
            {
                int deger = (int)_buketDegeri;
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 14 && _buketDegeri < 18)
            {
                int deger = (int)(_buketDegeri * 2);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 18 && _buketDegeri < 22)
            {
                int deger = (int)(_buketDegeri * 3);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 22 && _buketDegeri < 26)
            {
                int deger = (int)(_buketDegeri * 4);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 26 && _buketDegeri < 30)
            {
                int deger = (int)(_buketDegeri * 5);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 30 && _buketDegeri < 34)
            {
                int deger = (int)(_buketDegeri * 6);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 34 && _buketDegeri < 38)
            {
                int deger = (int)(_buketDegeri * 7);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 38 && _buketDegeri < 42)
            {
                int deger = (int)(_buketDegeri * 8);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 42 && _buketDegeri < 46)
            {
                int deger = (int)(_buketDegeri * 9);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else if (_buketDegeri >= 46)
            {
                int deger = (int)(_buketDegeri * 10);
                _uiController.LevelSonuElmasSayisi(deger);
            }
            else
            {

            }

            StartCoroutine("FinishOlaylari");

        }
        else
        {

        }
    }

    IEnumerator FinishOlaylari()
    {
        yield return new WaitForSeconds(1f);
        _gelinAnimator.SetBool("Idle", false);
        _gelinAnimator.SetBool("Sevinme", true);
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("BuketPaketi").SetActive(false);
        _atilanBuket = Instantiate(_atilacakBuketObjesi, _atilacakBuketSpawnPoint.transform.position, Quaternion.identity);
        _atilanBuket.GetComponent<AtilanBuket>().AtilanBuketForce(200, (_buketDegeri * 4));
        _vCamScript.GetComponent<VCamScript>().HedefDegistir();
        GameController._buketAtildi = true;
        yield return new WaitForSeconds(0.1f);
        GameController._buketAtildi = false;
    }

    public void WinOlaylari()
    {
        Invoke("WinScreenAc", 2f);
    }

    private void WinScreenAc()
    {
        _uiController.WinScreenPanelOpen();
    }

    private void LoseScreenAc()
    {
        _uiController.LoseScreenPanelOpen();
    }

    public void GelinKossun()
    {
        _gelinAnimator.SetBool("Idle", false);
        _gelinAnimator.SetBool("Kosma", true);
    }

    private void TokezlemeKapat()
    {
        _gelinAnimator.SetBool("Tokezleme", false);
    }

    private void AnimasyonResetle()
    {
        _gelinAnimator.SetBool("Dusme", false);
        _gelinAnimator.SetBool("Kosma", false);
        _gelinAnimator.SetBool("Tokezleme", false);
        _gelinAnimator.SetBool("Sevinme", false);
        _gelinAnimator.SetBool("Idle", true);
    }




    public void LevelStart()
    {
        GameController._buketAtildi = false;
        _atisHizi = 0;
        _buketDegeri = 10;
        _buketPaketi.SetActive(true);
        float buketbuyuklugu = _buketDegeri / 100;
        _buketPaketi.transform.localScale = new Vector3(buketbuyuklugu, buketbuyuklugu, buketbuyuklugu);
        _toplananElmasSayisi = 1;
        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");
        _karakterPaketi.transform.position = new Vector3(0, 0, 0);
        _karakterPaketi.transform.rotation = Quaternion.Euler(0, 0, 0);
        _karakterPaketi.GetComponent<KarakterPaketiMovement>().AciyiNormaleDondur();
        _player = GameObject.FindWithTag("Player");
        _player.transform.localPosition = new Vector3(0, 0.55f, 0);
        _vCamScript.GetComponent<VCamScript>().KameraResetle();
        AnimasyonResetle();
        //GameObject.FindGameObjectWithTag("NedimePaketi").gameObject.SetActive(true);
        //GameObject.FindGameObjectWithTag("FinishPaketi").gameObject.SetActive(false);
    }



}
