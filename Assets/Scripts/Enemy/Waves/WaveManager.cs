using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Enemy Prefab")]
    [SerializeField] private GameObject enemyPrefab;

    [Header("Enemy stat multipliers")]
    [SerializeField] private float enemyAttackMultiplier; //5
    [SerializeField] private float enemyHealthMultiplier; //2
    [SerializeField] private float enemyVelocityMultiplier; //0.2
    

    private float clock = 0;


    [Header("Waves")]
    [SerializeField] private float timeBetweenWaves; //Este sera fijo
    private float timeToNextWave;

    [Header("Enemy spawn amount")]
    [SerializeField] private int enemySpawnBaseAmount; //Este ira aumentando cada minuto
    [SerializeField] private float enemySpawnAmountIncrease;
    private int enemySpawnAmount;

    [Header("Time for spawn change")]
    [SerializeField] private float timeBetweenSpawnChange;
    private float timeToSpawnChange = 0;

    [Header("Spawners")]
    [SerializeField] private List<GameObject> spawnPoints;
    private List<Vector3> possibleSpawns = new List<Vector3>();
    [SerializeField] private int possibleSpawnBaseMaxAmount;
    [SerializeField] private float possibleSpawnMaxAmountIncrcease;
    private int possibleSpawnMaxAmount;

    [Header("Players")]
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToNextWave = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        timeToNextWave -= Time.deltaTime;
        timeToSpawnChange -= Time.deltaTime;

        if (timeToNextWave <= 0)
        {
            SpawnEnemyWave();
            timeToNextWave = timeBetweenWaves;
        }


        if (timeToSpawnChange <= 0)
        {
            ChangePossibleSpawns();
            ChangeSpawnAmount();
            timeToSpawnChange = timeBetweenSpawnChange;
        }
    }

    private void ChangePossibleSpawns()
    {
        possibleSpawns.Clear();

        int possibleSpawnAmount = (possibleSpawnMaxAmount <= spawnPoints.Count) ? possibleSpawnMaxAmount : spawnPoints.Count;

        while (possibleSpawns.Count < possibleSpawnAmount)
        {
            Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;
            spawnPoint.y = 1;

            if (!possibleSpawns.Contains(spawnPoint))
            {
                possibleSpawns.Add(spawnPoint);
            }

        }
    }


    private void ChangeSpawnAmount()
    {
        float clockMinute = Mathf.Floor(clock / 60);

        enemySpawnAmount = Mathf.FloorToInt(possibleSpawnBaseMaxAmount + possibleSpawnMaxAmountIncrcease * clockMinute);
        possibleSpawnMaxAmount =  Mathf.FloorToInt(possibleSpawnBaseMaxAmount + possibleSpawnMaxAmountIncrcease * clockMinute);

    }


    private IEnumerator SpawnEnemyWave()
    {
        //Bucle para todos los enemigos para spawnear
        for (int i=0; i<enemySpawnAmount; i++)
        {
            //Elegir punto de spawn
            int spanwIndex = Random.Range(0,possibleSpawns.Count);

            //Spawnearlo con esa posicion
            SpawnEnemy(possibleSpawns[spanwIndex]);

            yield return new WaitForSeconds(1);
        }
        
    }




    private void SpawnEnemy(Vector3 position)
    {
        GameObject enemy = Instantiate(enemyPrefab);

        //Position
        enemy.transform.position = position;

        //Stats
        EnemyStats enemyStats = enemy.GetComponent<EnemyStats>();

        float clockMinute = Mathf.Floor(clock / 60);

        enemyStats.SetStats(
            enemyStats.Health + enemyHealthMultiplier * clockMinute,
            enemyStats.BaseAttack + enemyAttackMultiplier * clockMinute,
            enemyStats.BaseVelocity + enemyVelocityMultiplier * clockMinute
        );

        //Assign players
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.player1 = player1;
        enemyMovement.player2 = player2;

    }
}
