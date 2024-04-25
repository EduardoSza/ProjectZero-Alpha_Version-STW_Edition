using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAirshipAttacks : EnemyAttacks
{
    [SerializeField]
    private EnemyMovements enemyMovements;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float timeBeforeAttack;

    private bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            StartCoroutine(LaserAttackProcess());
        }
    }

    IEnumerator LaserAttackProcess()
    {
        isAttacking = true;
        if (enemyMovements.StartFlag == true)
        {
            oneSimpleShot(prefab);
            yield return new WaitForSeconds(timeBeforeAttack);
        }

        isAttacking = false;
    }
}
