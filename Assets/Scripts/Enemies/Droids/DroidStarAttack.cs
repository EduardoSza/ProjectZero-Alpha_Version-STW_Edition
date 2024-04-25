using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidStarAttack : EnemyAttacks
{
    [SerializeField]
    private PlayerDetector playerDetector;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float timeBeforeAttack;

    private bool isAttacking = false;

    private void Update()
    {
        if (playerDetector.detectedFlag == true && !isAttacking)
        {
            StartCoroutine(ShotAttackProcess());
        }
    }

    IEnumerator ShotAttackProcess()
    {
        isAttacking = true;
        oneSimpleShot(prefab);
        yield return new WaitForSeconds(timeBeforeAttack);
        isAttacking = false;
    }
}
