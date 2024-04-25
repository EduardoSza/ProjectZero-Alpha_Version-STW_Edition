using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Estas variaveis impedem que o player saia das bordas da câmera:
    public float yMin = -4.6f;
    public float yMax = 4.6f;
    public float xMin = 5.5f;
    public float xMax = 21f;

    // Esta variavel contem o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    private PlayerAttributes playerAttributes;

    [SerializeField]
    private Joystick joystick;

    // A bool startFlag e responsavel por detectar se o jogador alcancou o Starting Point, 
    // significando que o jogo ja comecou e/ou que agora voce pode movimentar o personagem:
    [SerializeField]
    private bool startFlag = false;

    // Get e Set para encapsulamento da variavel "startFlag":
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
        // Enquanto o Starting Point nao e encontrado, a nave movera infinitamente para a direita:
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

    private int NormalizeMoves(float value)
    {
        if (value > 0)
        {
            return 1;
        }
        else if (value < 0)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    // Permite as movimentacoes para cima e para baixo:
    private void AllowVerticalMovement()
    {
        float moveVertical = Input.GetAxis("Vertical") + joystick.Vertical;

        Vector2 position = this.transform.position;
        position.y += moveVertical * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        position.y = Mathf.Clamp(position.y, yMin, yMax);

        this.transform.position = position;

    }


    // Permite as movimentacoes para esquerda e para direita:
    private void AllowHorizontalMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") + joystick.Horizontal;
        //moveHorizontal = NormalizeMoves(moveHorizontal);

        Vector2 position = this.transform.position;
        position.x += moveHorizontal * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        position.x = Mathf.Clamp(position.x, xMin, xMax);

        this.transform.position = position;
       
    }
}
