using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationsControl : MonoBehaviour
{
    // Variável que armazena o Box Collider do persongem:
    [SerializeField]
    private BoxCollider2D boxCollider;

    // Variável que armazena o Animator do personagem:
    [SerializeField]
    private Animator anim;

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

    IEnumerator BarrelRoll()
    {
        anim.SetBool("doBarrelRoll", true);

        yield return new WaitForSeconds(barrelTime);

        anim.SetBool("doBarrelRoll", false);
    }
}
