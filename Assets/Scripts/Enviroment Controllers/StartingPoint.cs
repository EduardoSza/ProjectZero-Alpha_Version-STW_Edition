using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject userObject;

    // Start is called before the first frame update
    void Update()
    {
        if (userObject == null)
        {
            Destroy(gameObject);
        }
    }
}
