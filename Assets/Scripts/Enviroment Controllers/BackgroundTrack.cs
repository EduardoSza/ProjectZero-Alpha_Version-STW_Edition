using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrack : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatWidth;

    [SerializeField]
    private BoxCollider2D boxCollider;

    void Start()
    {
        startPos = transform.position;
        repeatWidth = boxCollider.size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
