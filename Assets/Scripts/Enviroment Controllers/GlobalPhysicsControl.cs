using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPhysicsControl : MonoBehaviour
{
    [SerializeField]
    private float globalSpeedMultiplyer = 1;

    void Update()
    {
        GlobalVariables.globalSpeed = globalSpeedMultiplyer;
    }
}
