using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUndeadFlag : MonoBehaviour
{
    [SerializeField]
    private GameObject[] flipPoints;

    // Update is called once per frame
    void Update()
    {
        if (flipPoints[1] == null)
        {
            Destroy(flipPoints[0]);
        }
    }
}
