using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Variável que armazena um script do tipo "PlayerAttributes":
    [SerializeField]
    private PlayerAttributes player;

    [SerializeField]
    private bool startFlag = false;

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
        if(startFlag == false)
        {
            Vector2 position = this.transform.position;
            position.x += player.Speed * Time.deltaTime;
            this.transform.position = position;
        }
        else
        {
            AllowHorizontalMovement();
            AllowVerticalMovement();
        }
    }

    private void AllowVerticalMovement()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 position = this.transform.position;
        position.y += moveVertical * player.Speed * Time.deltaTime;
        this.transform.position = position;
    }

    private void AllowHorizontalMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 position = this.transform.position;
        position.x += moveHorizontal * player.Speed * Time.deltaTime;
        this.transform.position = position;
    }
}
