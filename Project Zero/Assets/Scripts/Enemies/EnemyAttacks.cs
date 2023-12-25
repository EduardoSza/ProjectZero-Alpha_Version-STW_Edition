using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    // Estes métodos deverão ser utilizados como herança por outros scripts mais especializados:

    protected void LaserAttack(GameObject prefab)
    {
        Instantiate(prefab, transform);
    }

    protected void TripleShot(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
