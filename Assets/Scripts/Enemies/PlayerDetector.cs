using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    private float castRadius;
    [SerializeField]
    private float castDistance;
    [SerializeField]
    private LayerMask playerLayer;

    public bool detectedFlag;

    void Update()
    {
        if (Physics2D.CircleCast(this.transform.position, castRadius, transform.up, castDistance, playerLayer))
        {
            detectedFlag = true;
        }
        else
        {
            detectedFlag = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position - transform.up * castDistance, castRadius);
    }
}
