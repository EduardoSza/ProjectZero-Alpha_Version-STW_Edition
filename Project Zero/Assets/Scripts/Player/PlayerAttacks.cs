using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField]
    private GameObject Prefab;
    [SerializeField]
    public PlayerAttributes playerAttributes;

    void Update()
    {
        ShotAttack(Prefab);
    }

    void ShotAttack(GameObject prefab)
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
