using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class RabbitMovement : EnemyMovements
{
    [SerializeField]
    private EnemyCollision_Control enemyCollision_Control;
    [SerializeField]
    private GameObject E_Shield;
    private int maximumLife;

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private bool thisTurnedAround = false;

    [SerializeField]
    private bool flipFlag = false;

    public bool beganFlag = false;

    [SerializeField]
    private GameObject flipPoint1;
    [SerializeField]
    private GameObject flipPoint2;

    // Update is called once per frame
    void Update()
    {
        if (beganFlag == false)
        {
            enemyCollision_Control.E_ShieldFlag = true;
            maximumLife = ProtectedEnemyAttributes.LifePoints;
            beganFlag = true;
        }
        
        if (ProtectedEnemyAttributes.LifePoints == maximumLife / 4)
        {
            E_Shield.SetActive(false);
            enemyCollision_Control.E_ShieldFlag = false;
        }

        SineWaves();

        AllowFlip();

        if (flipFlag == true)
        {
            flipPoint1.SetActive(true); //The GameObject FlipPoint1 must be deactivated in the hierarchy in the beginning.
        }
    }

    private void AllowFlip()
    {
        // Flipping:
        if (ProtectedEnemyAttributes.Speed > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (ProtectedEnemyAttributes.Speed < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FlipPoint"))
        {
            if (flipFlag == false)
            {
                flipFlag = true;
                thisTurnedAround = true;
            }

            if (thisTurnedAround == true)
            {
                anim.Play("turnAround");
                thisTurnedAround = false;
                flipFlag = false;
                flipPoint1.SetActive(true); //The GameObject FlipPoint1 must be deactivated in the hierarchy in the beginning.
            }
            
            ProtectedEnemyAttributes.Speed *= -1;
        }
    }
}
