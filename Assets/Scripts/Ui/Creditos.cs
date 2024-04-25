using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Creditos : MonoBehaviour
{
    private Vector2 position;
    [SerializeField]
    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GoUp();
    }

    protected void GoUp()
    {
        position.y += speed * Time.deltaTime * GlobalVariables.globalSpeed;
        transform.position = position;
    }

    public void Sair_Game_Over()
    {
        SceneManager.LoadScene(0);
    }
}
