using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] private int hitPoints = 2;

    public void TakeDamage(int dmg) {
        hitPoints -= dmg;

        if(hitPoints <= 0){
            EnnemySpawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
        }


    }


}
