using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Nesta vari�vel fica prefab, que � um game object pr�-pronto,
    // o qual pode ser reutilizado quantas vezes o dev quiser:
    [SerializeField]
    private GameObject Prefab1;

    [SerializeField]
    private GameObject Prefab2;

    // Esta vari�vel cont�m o script que controla os atributos principais e o sistema de vida/morte do player
    public PlayerAttributes playerAttributes;

    public PlayerMovements playerMovements;

    public PlayerAnimationsControl playerAnimations;

    public bool shootedNow = false;

    public float timeBeforeAttack = 0;

    public bool parryFlag = false;

    public bool firstSuperFlag = false;

    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Z) || (Input.touchCount > 0)) 
            && shootedNow == false && parryFlag == false && playerAnimations.isRolling == false && playerMovements.StartFlag == true)
        {
            StartCoroutine(ShotAttackProcess());
        }

        //if (shootedNow == false && parryFlag == false && playerAnimations.isRolling == false && playerMovements.StartFlag == true)
        //{
        //    StartCoroutine(ShotAttackProcess());
        //}
    }

    // Este ataque instancia um um tiro na posi��o do game object ao qual este script est� atrelado:
    public void ShotAttack(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    IEnumerator ShotAttackProcess()
    {
        ShotAttack(Prefab1);
        shootedNow = true;
        yield return new WaitForSeconds(timeBeforeAttack);
        shootedNow = false;
    }

    // Este ataque instancia um um tiro na posi��o do game object ao qual este script est� atrelado:
    void SuperShotAttack(GameObject prefab)
    {
        if (firstSuperFlag == false)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            firstSuperFlag = true;
        }
    }

    public void ParryCounter()
    {
        parryFlag = true;

        SuperShotAttack(Prefab2);

        parryFlag = false;
    }
}
