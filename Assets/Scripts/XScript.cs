using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AtilanBuket")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            other.gameObject.GetComponent<AtilanBuket>().EfektPatlat();

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().WinOlaylari();
        }
        else
        {

        }
    }


}
