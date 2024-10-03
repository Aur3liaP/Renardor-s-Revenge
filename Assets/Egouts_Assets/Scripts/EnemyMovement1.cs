using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    private void Start(){
        target = LevelManager1.main.path[pathIndex];
    }
    private void Update(){
        if (Vector2.Distance(target.position, transform.position) <= 0.1f){
            pathIndex++;
            

            if(pathIndex == LevelManager1.main.path.Length){
                EnemySpawner1.onEnemyDestroy.Invoke(); 
                Destroy(gameObject);
                return;
            } else {
                target = LevelManager1.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate(){

  Vector2 direction = (target.position - transform.position);
        float distance = direction.magnitude;
        Vector2 velocity = direction * (moveSpeed / distance);
        rb.velocity = velocity;


        // if(Vector2.Distance(transform.position, target.position) > 0.1f){
        // Vector2 direction = (target.position - transform.position);

        // rb.velocity = (direction * moveSpeed).normalized;
    }
}
