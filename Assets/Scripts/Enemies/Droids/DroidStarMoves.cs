using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidStarMoves : EnemyMovements
{
    [SerializeField]
    private float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        RotateLeft(rotationSpeed);
        GoFoward();
    }
}
