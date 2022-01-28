using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{

    public CinemachineVirtualCamera cmVcam;

    public void SetCameraForFinal()
    {
        GetComponent<CinemachineBrain>().enabled = false;
        GetComponent<CinemachineBrain>().enabled = true;
        cmVcam.LookAt = GameObject.FindGameObjectWithTag("AtilanBuket").transform;
        cmVcam.Follow = GameObject.FindGameObjectWithTag("AtilanBuket").transform;

    }

    public void SetCameraForStart()
    {
        GetComponent<CinemachineBrain>().enabled = false;
        GetComponent<CinemachineBrain>().enabled = true;
        cmVcam.LookAt = GameObject.FindGameObjectWithTag("KarakterPaketi").transform;
        cmVcam.Follow = GameObject.FindGameObjectWithTag("KarakterPaketi").transform;

    }

}
