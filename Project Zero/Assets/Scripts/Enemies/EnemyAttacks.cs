using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{

    protected void LaserAttack(GameObject prefab)
    {
        Instantiate(prefab, transform);
    }

    protected void TripleShot(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
