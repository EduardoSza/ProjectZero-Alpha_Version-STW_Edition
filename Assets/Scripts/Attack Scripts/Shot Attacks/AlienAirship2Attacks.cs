using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAirship2Attacks : EnemyAttacks
{
    [SerializeField]
    private PlayerDetector playerDetector;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float timeBeforeAttack;

    private bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {
        if (playerDetector.detectedFlag == true && !isAttacking)
        {
            StartCoroutine(LaserAttackProcess());
        }
    }

    IEnumerator LaserAttackProcess()
    {
        isAttacking = true;

        oneSimpleShot(prefab);
        yield return new WaitForSeconds(timeBeforeAttack);

        isAttacking = false;
    }
}
