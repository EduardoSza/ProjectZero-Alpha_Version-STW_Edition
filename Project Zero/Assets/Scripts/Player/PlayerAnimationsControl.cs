using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimationsControl : MonoBehaviour
{
    // Variável que armazena o Box Collider do persongem:
    [SerializeField]
    private BoxCollider2D boxCollider;

    // Variável que armazena o Animator do personagem:
    [SerializeField]
    private Animator anim;

    // Variável que aramazena o tempo em que o personagem poderá permanecer em Barrel Roll:
    [SerializeField]
    private float barrelTime;

    void Update()
    {
        // Garante que o personagem possa desviar de ataques, fazendo giros em torno do seu próprio eixo.
        if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(BarrelRoll());
        }
    }

    // O IEnumerator permite que ações acontecem apenas depois de um determinado período de tempo.
    // Neste caso, quando doBarrelRoll em anim for verdadeiro, o personagem fará a animação Barrel Roll
    // e ficará imune a danos inimigos até que WaitForSeconds acabe e doBarrelRoll se torne falso.

    // A imunidade ocorre por conta do script PlayerCollision_Control atrelado ao corpo do player.
    IEnumerator BarrelRoll()
    {
        anim.SetBool("doBarrelRoll", true);

        yield return new WaitForSeconds(barrelTime);

        anim.SetBool("doBarrelRoll", false);
    }
}
