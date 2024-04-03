using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public Animator EnemyAnimator;

    public void PlayAnimation(string animationName)
    {
        EnemyAnimator.Play(animationName);


    }
}
