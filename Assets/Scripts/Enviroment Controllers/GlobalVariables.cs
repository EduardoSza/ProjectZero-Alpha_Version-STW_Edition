using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static float globalSpeed = 1;
    public static bool waveIsFinished = false;
    public static int gameScore = 0;

    public int gsc = 0;

    void Update()
    {
        gsc = gameScore;
    }
}
