using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAttack_Control : MonoBehaviour
{
    [SerializeField]
    private float timeOfDeath;

 
    void Update()
    {
        // Faz com que o laser seja destruído depois de um certo tempo:
        Destroy(gameObject, timeOfDeath);
    }
}
