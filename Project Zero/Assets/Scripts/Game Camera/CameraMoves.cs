using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoves : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private PlayerMovements player;

    // Update is called once per frame
    void Update()
    {
        if (player.StartFlag == true)
        {
            horizontalMoviment();
        }
    }

    private void horizontalMoviment()
    {
        Vector3 position = this.transform.position;
        position.x += speed * Time.deltaTime;
        this.transform.position = position;
    }
}
