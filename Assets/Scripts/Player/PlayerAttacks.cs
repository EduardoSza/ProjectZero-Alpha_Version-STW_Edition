using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Nesta variável fica prefab, que é um game object pré-pronto,
    // o qual pode ser reutilizado quantas vezes o dev quiser:
    [SerializeField]
    private GameObject Prefab1;

    [SerializeField]
    private GameObject Prefab2;

    // Esta variável contêm o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    public PlayerAttributes playerAttributes;

    public bool parryFlag = false;

    public bool firstSuperFlag = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Z) && parryFlag == false)
        {
            ShotAttack(Prefab1);
        }
    }

    // Este ataque instancia um um tiro na posição do game object ao qual este script está atrelado:
    void ShotAttack(GameObject prefab)
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    // Este ataque instancia um um tiro na posição do game object ao qual este script está atrelado:
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
