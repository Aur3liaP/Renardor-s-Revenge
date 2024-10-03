using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 4f;

    private Transform target;
    private int pathIndex = 0;
    private void Start(){
        target = LevelManager2.main.path[pathIndex];
    }
    private void Update(){
        if (Vector2.Distance(target.position, transform.position) <= 0.1f){
            pathIndex++;
            

            if(pathIndex == LevelManager2.main.path.Length){
                Destroy(gameObject);
                return;
            } else {
                target = LevelManager2.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate(){
         Vector2 direction = (target.position - transform.position);
        float distance = direction.magnitude;
        Vector2 velocity = direction * (moveSpeed / distance);
        rb.velocity = velocity;
    }
}
