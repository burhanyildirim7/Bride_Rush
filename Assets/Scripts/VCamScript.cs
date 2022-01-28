using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VCamScript : MonoBehaviour
{

    private CinemachineVirtualCamera _vCam;

    //[SerializeField] private GameObject _karakterPaketi;

    void Start()
    {
        _vCam = GetComponent<CinemachineVirtualCamera>();

    }

    public void HedefDegistir()
    {
        _vCam.Follow = GameObject.FindGameObjectWithTag("AtilanBuket").transform;
        _vCam.LookAt = GameObject.FindGameObjectWithTag("AtilanBuket").transform;
    }

    public void KameraResetle()
    {
        _vCam.Follow = GameObject.FindGameObjectWithTag("KarakterPaketi").transform;
        _vCam.LookAt = GameObject.FindGameObjectWithTag("KarakterPaketi").transform;
    }
}
