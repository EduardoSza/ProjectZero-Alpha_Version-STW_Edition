using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoves : MonoBehaviour
{
    // Esta variável contêm o script que permite ao player se movimentar:
    [SerializeField]
    private PlayerMovements player;
    
    [SerializeField]
    private float speed;

    void Update()
    {
        // Quando o player alcançar o Starting Point, a câmera com o script CameraMoves começará a se movimentar:
        if (player.StartFlag == true)
        {
            HorizontalMoviment();
        }
    }

    // Faz com que o game object se movimente para a direita:
    private void HorizontalMoviment()
    {
        Vector3 position = this.transform.position;
        position.x += speed * Time.deltaTime;
        this.transform.position = position;
    }
}
