using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Estas variaveis impedem que o player saia das bordas da câmera:
    public float yMinBorder = -4.6f;
    public float yMaxBorder = 4.6f;
    public float xMinBorder = 5.5f;
    public float xMaxBorder = 23f;

    // Esta variavel contem o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    private PlayerAttributes playerAttributes;
    [SerializeField]
    private WavesSystem wavesSystem;

    [SerializeField]
    private Rigidbody2D rig;

    public float deltaX, deltaY;

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
            // If StartFlag is on, the first wave may start:
            wavesSystem.enabled = true;

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        break;
                    case TouchPhase.Moved:
                        rig.MovePosition(new Vector2((touchPos.x - deltaX), (touchPos.y - deltaY)));
                        break;
                    case TouchPhase.Ended:
                        rig.velocity = Vector2.zero;
                        break;
                }
            }

            AllowHorizontalMovement();
            AllowVerticalMovement();
        }
    }

    // Permite as movimentacoes para cima e para baixo:
    private void AllowVerticalMovement()
    {
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 position = this.transform.position;
        position.y += moveVertical * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        position.y = Mathf.Clamp(position.y, yMinBorder, yMaxBorder);

        this.transform.position = position;

    }


    // Permite as movimentacoes para esquerda e para direita:
    private void AllowHorizontalMovement()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        //moveHorizontal = NormalizeMoves(moveHorizontal);

        Vector2 position = this.transform.position;
        position.x += moveHorizontal * playerAttributes.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        position.x = Mathf.Clamp(position.x, xMinBorder, xMaxBorder);

        this.transform.position = position;
       
    }
}
