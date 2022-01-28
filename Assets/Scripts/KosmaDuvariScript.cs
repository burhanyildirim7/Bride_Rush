using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosmaDuvariScript : MonoBehaviour
{
    [SerializeField] private GameObject _acilacakNedimeler;
    void Start()
    {
        _acilacakNedimeler.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _acilacakNedimeler.SetActive(true);
        }
        else
        {

        }
    }
}
