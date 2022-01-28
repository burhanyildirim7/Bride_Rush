using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosacakNedimelerScript : MonoBehaviour
{
    [SerializeField] private GameObject _kalpEmoji;

    [SerializeField] private GameObject _elindekiCicek;

    [SerializeField] private Animator _animator;

    private bool _hareketEt;

    private bool _yavaslamaSiniri;

    private GameObject _target;

    private Quaternion _anlikRotation;


    private bool _donmeSiniri;

    void Start()
    {
        _kalpEmoji.SetActive(false);
        _elindekiCicek.SetActive(false);

        _hareketEt = true;
        _yavaslamaSiniri = false;

        //_anlikRotation.y = 180;
        //transform.rotation = Quaternion.Euler(0, 180, 0);

        _donmeSiniri = false;
    }


    void FixedUpdate()
    {
        if (GameController._oyunAktif == true && _hareketEt == true)
        {
            if (_donmeSiniri == true)
            {
                if (_yavaslamaSiniri == false)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * 7f);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _anlikRotation.y, 0), 70 * Time.deltaTime);
                }
                else
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _anlikRotation.y, 0), 60 * Time.deltaTime);
                    transform.Translate(Vector3.forward * Time.deltaTime * 6f);
                    _target = GameObject.FindGameObjectWithTag("Player");
                    transform.LookAt(_target.transform.position);
                }
            }
            else
            {
                if (_yavaslamaSiniri == false)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * 7f);
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _anlikRotation.y, 0), 70 * Time.deltaTime);
                }
                else
                {
                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _anlikRotation.y, 0), 60 * Time.deltaTime);
                    transform.Translate(Vector3.forward * Time.deltaTime * 6f);
                    _target = GameObject.FindGameObjectWithTag("Player");
                    transform.LookAt(_target.transform.position);
                }
            }


        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AtilanCicek")
        {
            _kalpEmoji.SetActive(true);
            _elindekiCicek.SetActive(true);
            _hareketEt = false;
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            _animator.SetBool("Victory", true);

            Destroy(gameObject, 2f);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "NedimeYavaslamaSiniri")
        {
            _yavaslamaSiniri = true;
        }
        else if (other.gameObject.tag == "Player")
        {

            // MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            _kalpEmoji.SetActive(true);
            _elindekiCicek.SetActive(true);
            _hareketEt = false;
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            _animator.SetBool("Victory", true);

            Destroy(gameObject, 2f);
        }
        else if (other.gameObject.tag == "SagaDonmeSiniri")
        {
            //_anlikRotation = transform.rotation;
            //_duzGidiyor = false;
            //_solaDondu = true;
            _anlikRotation.y = 270;
            //transform.rotation = Quaternion.Lerp(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
            _donmeSiniri = true;
            Debug.Log("Sağa Dön!!!");
        }
        else if (other.gameObject.tag == "SolaDonmeSiniri")
        {
            //_anlikRotation = transform.rotation;
            //_duzGidiyor = false;
            //_solaDondu = true;
            _anlikRotation.y = 90;
            _donmeSiniri = true;
            // transform.rotation = Quaternion.Slerp(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
        }
        else if (other.gameObject.tag == "DuzGitmeSiniri")
        {
            //_anlikRotation = transform.rotation;
            //_solaDondu = false;
            //_solaDondu = false;
            //_duzGidiyor = true;
            _anlikRotation.y = 180;
            _donmeSiniri = true;
            // transform.rotation = Quaternion.Slerp(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
        }
        else
        {

        }
    }
}
