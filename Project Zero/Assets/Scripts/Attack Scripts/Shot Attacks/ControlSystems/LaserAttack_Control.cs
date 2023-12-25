using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack_Control : MonoBehaviour
{
    [SerializeField]
    private float timeOfDeath;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeOfDeath);
    }
}
