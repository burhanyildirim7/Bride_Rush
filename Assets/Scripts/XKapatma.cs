using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XKapatma : MonoBehaviour
{

    [SerializeField] private GameObject _canvas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AtilanBuket")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            _canvas.SetActive(false);
        }
        else
        {

        }
    }
}
