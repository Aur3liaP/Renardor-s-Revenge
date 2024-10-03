using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner2 : MonoBehaviour {

[Header("References")]
[SerializeField] private GameObject[] enemyPrefabs;

[Header("Attributes")]
[SerializeField] private int baseEnemies = 8;

[SerializeField] private float enemiesPerSecond = 0.5f;

[SerializeField] private float timeBetweenWave = 5f;
[SerializeField] private float difficultyScalingFactor = 0.75f;

[Header("Events")]
public static UnityEvent onEnemyDestroy = new UnityEvent();

private int currentWave = 1;
private float timeSinceLastSpawn;
private int enemiesAlive;
private int enemiesLeftToSpawn;
private bool isSpawning = false ;


private void Awake(){
    onEnemyDestroy.AddListener(EnemyDestroyed);
}

private void Start(){
StartWave();
}
private void Update(){
    if (!isSpawning) return;
    timeSinceLastSpawn += Time.deltaTime;

    if (timeSinceLastSpawn >= (1f/enemiesPerSecond) && enemiesLeftToSpawn > 0){
        
        SpawnEnemy();
        enemiesLeftToSpawn--;
        enemiesAlive++;
        timeSinceLastSpawn = 0f;
    }
}

private void EnemyDestroyed(){
    enemiesAlive--;
}

private void StartWave() {
    isSpawning = true;
    enemiesLeftToSpawn = EnemiesPerWave();
}

private void SpawnEnemy(){
    Debug.Log("Spawn Enemy");
    GameObject prefabToSpawn = enemyPrefabs[0];
    Instantiate(prefabToSpawn, LevelManager2.main.StartPoint.position, Quaternion.identity);
}
private int EnemiesPerWave(){
    return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
}
 
}
