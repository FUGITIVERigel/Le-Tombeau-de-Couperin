using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] float detectionRadius;
    [SerializeField] LayerMask groundLayer;
    public bool isGround
    {
        get
        {
           return Physics2D.OverlapCircle(transform.position,detectionRadius,groundLayer);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
