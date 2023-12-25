using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // Nesta vari�vel fica prefab, que � um game object pr�-pronto,
    // o qual pode ser reutilizado quantas vezes o dev quiser:
    [SerializeField]
    private GameObject Prefab;

    // Esta vari�vel cont�m o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    public PlayerAttributes playerAttributes;

    void Update()
    {
        ShotAttack(Prefab);
    }

    // Este ataque instancia um um tiro na posi��o do game object ao qual este script est� atrelado:
    void ShotAttack(GameObject prefab)
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
