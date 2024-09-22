using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParentControl : MonoBehaviour
{
    [SerializeField]
    private bool thisIsAWave = false;
    [SerializeField]
    private bool destroyByTime = false;
    [SerializeField]
    private float timeOfDeath;

    public int childCounter = 0;

    // Update is called once per frame
    void Update()
    {
        childCounter = transform.childCount;

        // Se este gameObject não possuir gameObjects filho, será destruído:
        if (transform.childCount == 0)
        {
            if (thisIsAWave == true)
            {
                GlobalVariables.waveIsFinished = true; 
            }
            Destroy(this.gameObject);
        }
        // Se não, passado um certo tempo, será destruído:
        else
        {
            if (destroyByTime == true)
            {
                StartCoroutine(DestroyTime());
            }
        }
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(timeOfDeath);
        Destroy(this.gameObject);
    }
}
