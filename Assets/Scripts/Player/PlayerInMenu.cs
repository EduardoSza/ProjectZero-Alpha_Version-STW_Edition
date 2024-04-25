using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMenu : MonoBehaviour
{
    public float speed;
    public bool startFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlag == false)
        {
            Vector2 position = this.transform.position;
            position.x += speed * Time.deltaTime;
            this.transform.position = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Starting Point é um game object vazio, dotado de apenas um collisor em trigger.
        // Quando o jogador passar pela linha de partida "Starting Point", só então o personagem poderá ser controlado:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            startFlag = true;
        }
    }
}
