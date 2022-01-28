using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtilanCicekScript : MonoBehaviour
{
    private Quaternion _karakterPaketi;

    private void Start()
    {
        Destroy(gameObject, 1f);

        _karakterPaketi = GameObject.FindGameObjectWithTag("KarakterPaketi").transform.rotation;
        transform.rotation = Quaternion.Euler(0, _karakterPaketi.eulerAngles.y, 0);
        // Debug.Log(_karakterPaketi.eulerAngles.y);

    }


    void FixedUpdate()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * 10f);




    }
}
