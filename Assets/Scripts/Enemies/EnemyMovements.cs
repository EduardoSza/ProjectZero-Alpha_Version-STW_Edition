using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    // Esta variável contêm o script que controla os atributos principais e o sistema de vida/morte do inimigo:
    [SerializeField]
    private EnemyAttributes enemy;

    // Esta variável guardará a posição atual do inimigo a utilizando:
    private Vector2 position;

    // Os atributos abaixo servem para as movimentações baseadas em seno e cosseno
    // possam ser feitas corretamente:
    private float initialPositionY;
    private float initialPositionX;
    [SerializeField]
    private float amplitude = 1;
    [SerializeField]
    private float frequency = 1;
    [SerializeField]
    private bool inverseFlow = false;

    // A startFlag faz com que um inimigo faça alguma coisa apenas quando a "StartingPoint" flag for encontrada:
    [SerializeField]
    private bool startFlag = false;

    public bool StartFlag
    {
        get
        {
            return startFlag;
        }

        set
        {
            startFlag = value;
        }
    }

    void Awake()
    {
        enemy = GetComponent<EnemyAttributes>();
    }

    void Start()
    {
        position = this.transform.position;
        initialPositionY = position.y;
        initialPositionX = position.x;
    }

    // Estes métodos deverão ser utilizados como herança por outros scripts mais especializados:

    // - Movimento que faz o inimigo se mover apenas para frente:
    public void GoFoward()
    {
        position.x += -enemy.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }

    // - Movimento que faz o inimigo se mover apenas para frente:
    public void GoBackward()
    {
        position.x += enemy.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        this.transform.position = position;
    }

    // - Movimento que faz o inimigo se movimentar ondas, de acordo com a fórmula "sen(x)":
    protected void SineWaves()
    {
        position.x += -enemy.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        float sin = Mathf.Sin(position.x * frequency) * amplitude;

        if (inverseFlow == true)
        {
            sin *= -1;
        }

        position.y = initialPositionY + sin;

        transform.position = position;
    }

    // - Movimento que faz o inimigo se movimentar ondas, de acordo com a fórmula "cos(y)":
    protected void CossineWaves()
    {
        position.y += -enemy.Speed * Time.deltaTime * GlobalVariables.globalSpeed;
        float cos = Mathf.Cos(position.y * frequency) * amplitude;

        if (inverseFlow == true)
        {
            cos *= -1;
        }

        position.x = initialPositionX + cos;

        transform.position = position;
    }
}
