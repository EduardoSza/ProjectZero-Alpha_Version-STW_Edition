using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Esta variável contêm o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    private PlayerAttributes playerAttributes;

    // A bool startFlag é responsável por detectar se o jogador alcançou o Starting Point, 
    // significando que o jogo já começou e/ou que agora você pode movimentar o personagem:
    [SerializeField]
    private bool startFlag = false;

    // Get e Set para encapsulamento da variável "startFlag":
    public bool StartFlag {
        get 
        { 
            return startFlag; 
        } 

        set 
        {  
            startFlag = value; 
        } 
    }

    void Update()
    {
        // Enquanto o Starting Point não é encontrado, a nave moverá infinitamente para a direita:
        if(startFlag == false)
        {
            Vector2 position = this.transform.position;
            position.x += playerAttributes.Speed * Time.deltaTime;
            this.transform.position = position;
        }
        else
        {
            AllowHorizontalMovement();
            AllowVerticalMovement();
        }
    }

    // Permite as movimentaçções para cima e para baixo:
    private void AllowVerticalMovement()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 position = this.transform.position;
        position.y += moveVertical * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }

    // Permite as movimentaçções para esquerda e para direita:
    private void AllowHorizontalMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 position = this.transform.position;
        position.x += moveHorizontal * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }
}
