using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSiniriScript : MonoBehaviour
{
    [SerializeField] private GameObject _finishPaketi;
    [SerializeField] private List<GameObject> _kapatilacaklar = new List<GameObject>();

    void Start()
    {
        _finishPaketi.SetActive(false);
        _kapatilacaklar[0].SetActive(true);
        _kapatilacaklar[1].SetActive(true);
        _kapatilacaklar[2].SetActive(true);
        _kapatilacaklar[3].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _finishPaketi.SetActive(true);
            _kapatilacaklar[0].SetActive(false);
            _kapatilacaklar[1].SetActive(false);
            _kapatilacaklar[2].SetActive(false);
            _kapatilacaklar[3].SetActive(false);
        }
    }
}
