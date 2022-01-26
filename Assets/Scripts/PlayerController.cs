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

    private int _elmasSayisi;

    private GameObject _player;

    private UIController _uiController;

    private int _toplananElmasSayisi;

    private float _buketDegeri;

    private float _atisHizi;



    void Start()
    {
        LevelStart();

        _uiController = GameObject.Find("UIController").GetComponent<UIController>();

    }


    private void FixedUpdate()
    {
        if (GameController._oyunAktif == true)
        {
            _atisHizi += Time.deltaTime;

            if (_atisHizi > 0.5f)
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
            }

        }
        else if (other.gameObject.tag == "Collectable")
        {
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
            }

        }
        else
        {

        }
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
        _atisHizi = 0;
        _buketDegeri = 10;
        float buketbuyuklugu = _buketDegeri / 100;
        _buketPaketi.transform.localScale = new Vector3(buketbuyuklugu, buketbuyuklugu, buketbuyuklugu);
        _toplananElmasSayisi = 1;
        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");
        _karakterPaketi.transform.position = new Vector3(0, 0, 0);
        _karakterPaketi.transform.rotation = Quaternion.Euler(0, 0, 0);
        _player = GameObject.FindWithTag("Player");
        _player.transform.localPosition = new Vector3(0, 1, 0);
        AnimasyonResetle();
    }



}
