using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Esta vari�vel cont�m o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    private PlayerAttributes playerAttributes;

    // A bool startFlag � respons�vel por detectar se o jogador alcan�ou o Starting Point, 
    // significando que o jogo j� come�ou e/ou que agora voc� pode movimentar o personagem:
    [SerializeField]
    private bool startFlag = false;

    // Get e Set para encapsulamento da vari�vel "startFlag":
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
        // Enquanto o Starting Point n�o � encontrado, a nave mover� infinitamente para a direita:
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

    // Permite as movimenta���es para cima e para baixo:
    private void AllowVerticalMovement()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 position = this.transform.position;
        position.y += moveVertical * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }

    // Permite as movimenta���es para esquerda e para direita:
    private void AllowHorizontalMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 position = this.transform.position;
        position.x += moveHorizontal * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }
}
