using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterPaketiMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private float _donmeSpeed;

    private float _firstSpeed;

    public static bool _karakteriDurdur;

    private Quaternion _anlikRotation;

    public static bool _sagaDondu;

    public static bool _solaDondu;

    public static bool _duzGidiyor;

    void Start()
    {
        _firstSpeed = _speed;
        _karakteriDurdur = false;
        _duzGidiyor = true;
        _solaDondu = false;
        _sagaDondu = false;
        //_donmeSpeed = 70;
        _anlikRotation.y = 0;
    }


    void FixedUpdate()
    {
        if (GameController._oyunAktif)
        {
            transform.Translate(Vector3.back * Time.deltaTime * _speed);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, _anlikRotation.y, 0), _donmeSpeed * Time.deltaTime);
        }
        else
        {

        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "KarakterPaketi")
        {
            if (other.gameObject.tag == "SagaDonmeSiniri")
            {
                //_anlikRotation = transform.rotation;
                _duzGidiyor = false;
                _solaDondu = true;
                _anlikRotation.y = 0;
                //transform.rotation = Quaternion.Lerp(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
                // transform.rotation = Quaternion.RotateTowards(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
                Debug.Log("Sağa Dön!!!");
            }
            else if (other.gameObject.tag == "SolaDonmeSiniri")
            {
                //_anlikRotation = transform.rotation;
                _duzGidiyor = false;
                _solaDondu = true;
                _anlikRotation.y = -90;
                // transform.rotation = Quaternion.Slerp(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
            }
            else if (other.gameObject.tag == "DuzGitmeSiniri")
            {
                //_anlikRotation = transform.rotation;
                _solaDondu = false;
                _solaDondu = false;
                _duzGidiyor = true;
                _anlikRotation.y = 0;
                // transform.rotation = Quaternion.Slerp(transform.rotation, _anlikRotation, _donmeSpeed * Time.deltaTime);
            }
            else
            {

            }
        }
        else
        {

        }

    }

    public void AciyiNormaleDondur()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _anlikRotation.y = 0;
    }
}
