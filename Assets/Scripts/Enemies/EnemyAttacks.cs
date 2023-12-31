using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    // Estes m�todos dever�o ser utilizados como heran�a por outros scripts mais especializados:

    protected void LaserAttack(GameObject prefab)
    {
        Instantiate(prefab, transform);
    }

    protected void TripleShot(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
