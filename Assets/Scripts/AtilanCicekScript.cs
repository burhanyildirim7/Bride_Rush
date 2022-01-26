using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtilanCicekScript : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 3f);
    }


    void FixedUpdate()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * 10f);


    }
}
