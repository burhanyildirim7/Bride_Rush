using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool _oyunAktif;

    public static bool _buketAtildi;

    void Start()
    {
        _oyunAktif = false;

        _buketAtildi = false;

    }


}
