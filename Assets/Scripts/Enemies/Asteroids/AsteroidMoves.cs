using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMoves : EnemyMovements
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
