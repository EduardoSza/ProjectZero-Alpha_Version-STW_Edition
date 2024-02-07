using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAttributes : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AllowMovingToLeft();
    }

    // Permite movimentação constante para a esquerda:
    private void AllowMovingToLeft()
    {
        Vector2 position = this.transform.position;
        position.x -= speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }

    // Permite movimentação constante para a direita:
    private void AllowMovingToRight()
    {
        Vector2 position = this.transform.position;
        position.x += speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }
}
