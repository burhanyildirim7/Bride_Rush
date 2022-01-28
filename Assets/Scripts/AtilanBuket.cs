using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtilanBuket : MonoBehaviour
{
    private float _yukariForce;
    private float _ileriForce;

    [SerializeField] private GameObject _efekt;

    Rigidbody m_Rigidbody;

    private Quaternion _karakterPaketi;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        _efekt.SetActive(false);

        _karakterPaketi = GameObject.FindGameObjectWithTag("KarakterPaketi").transform.rotation;
        transform.rotation = Quaternion.Euler(0, _karakterPaketi.eulerAngles.y, 0);
    }

    void FixedUpdate()
    {
        if (GameController._buketAtildi == true)
        {
            m_Rigidbody.AddForce(transform.up * _yukariForce);
            m_Rigidbody.AddForce(transform.forward * _ileriForce);

        }
        else
        {

        }
    }

    public void AtilanBuketForce(float yukarideger, float ilerideger)
    {
        _yukariForce = yukarideger;
        _ileriForce = ilerideger;
    }

    public void EfektPatlat()
    {
        _efekt.SetActive(true);
        Destroy(gameObject, 10f);
    }
}
