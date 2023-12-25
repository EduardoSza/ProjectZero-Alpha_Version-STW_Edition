using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float parallaxSpeed;
    [SerializeField]
    private Transform cameraTransform;

    private float imageLength;
    private float initialPos;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position.x;
        imageLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distance = cameraTransform.position.x * parallaxSpeed;

        transform.position = new Vector3(initialPos + distance, transform.position.y, transform.position.z);

        if (cameraTransform.position.x > initialPos + imageLength / 2)
        {
            initialPos += imageLength * Time.deltaTime;
        }
        else if (cameraTransform.position.x < initialPos - imageLength / 2)
        {
            initialPos -= imageLength * Time.deltaTime;
        }
    }
}









