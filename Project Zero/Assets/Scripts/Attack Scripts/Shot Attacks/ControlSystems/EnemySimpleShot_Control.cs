using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleShot_Control : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeOfDeath;

    public int attackPower;

    // Update is called once per frame
    void Update()
    {
        ShotDirection();
        ShotLife();
    }

    private void ShotDirection()
    {
        Vector2 position = this.transform.position;
        Vector2 direction = this.transform.right; // Obter a direção do objeto

        position += direction * -speed * Time.deltaTime; // Adicionar à posição na direção do objeto
        this.transform.position = position;
    }


    private void ShotLife()
    {
        Destroy(this.gameObject, timeOfDeath);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
