using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetect : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    Collider[] colliders = new Collider[1];
    public bool IsGrounded =>Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, colliders, groundLayer) != 0;
    //使碰撞体显示
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
