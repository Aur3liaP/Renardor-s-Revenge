using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultScalingFactor = 0.75f;
    [SerializeField] private float maxWaves = 5;
    [SerializeField] private float enemiesToLoose = 3;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    [Header("Scene")]
    [SerializeField] private string sceneWinName;
    [SerializeField] private string sceneLooseName;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    private int enemiesReachedEnd = 0;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
            EndGameWin(sceneWinName);
        }

        if (enemiesReachedEnd >= enemiesToLoose)
        {
            EndGameLoose(sceneLooseName);
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = baseEnemies;
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private void EndGameWin(string sceneWinName)
    {
        if (enemiesAlive == 0 && currentWave > maxWaves)
        {
            Debug.Log("Changement de scène vers : " + sceneWinName);
            SceneManager.LoadScene(sceneWinName);
        }
    }

    public void EnemyReachedEnd()
    {
        enemiesReachedEnd++;
        Debug.Log("Enemy reached end. Total reached: " + enemiesReachedEnd);
    }

    private void EndGameLoose(string sceneLooseName)
    {
        Debug.Log("Changement de scène vers : " + sceneLooseName);
        SceneManager.LoadScene(sceneLooseName);
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, 0.75f));
    }
}