using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Nesta variável fica prefab, que é um game object pré-pronto,
    // o qual pode ser reutilizado quantas vezes o dev quiser:
    [SerializeField]
    private GameObject Prefab;

    // Esta variável contêm o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    public PlayerAttributes playerAttributes;

    void Update()
    {
        ShotAttack(Prefab);
    }

    // Este ataque instancia um um tiro na posição do game object ao qual este script está atrelado:
    void ShotAttack(GameObject prefab)
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
