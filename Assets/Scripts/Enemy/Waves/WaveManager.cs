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
    [SerializeField] private GameObject spawners;
    private List<Vector3> spawnPoints;
    private List<Vector3> possibleSpawns = new List<Vector3>();
    [SerializeField] private int possibleSpawnBaseMaxAmount;
    [SerializeField] private float possibleSpawnMaxAmountIncrease;
    private int possibleSpawnMaxAmount;

    [Header("Players")]
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] string tagPlayer1 = "Warrior";
    [SerializeField] string tagPlayer2 = "Wizard";

    public void OnGameStart()
    {
        this.player1 = GameObject.FindWithTag(tagPlayer1);
        this.player2 = GameObject.FindWithTag(tagPlayer2);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeToNextWave = timeBetweenWaves;

        Transform[] transforms = spawners.GetComponentsInChildren<Transform>();
        spawnPoints = new List<Vector3>(transforms.Length);
        foreach (Transform t in transforms)
        {
            spawnPoints.Add(t.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        timeToNextWave -= Time.deltaTime;
        timeToSpawnChange -= Time.deltaTime;

        if (timeToNextWave <= 0)
        {
            StartCoroutine(SpawnEnemyWave());
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
            Vector3 spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            if (!possibleSpawns.Contains(spawnPoint))
            {
                possibleSpawns.Add(spawnPoint);
            }

        }
    }


    private void ChangeSpawnAmount()
    {
        float clockMinute = Mathf.Floor(clock / 60);

        enemySpawnAmount = Mathf.FloorToInt(enemySpawnBaseAmount + enemySpawnAmountIncrease * clockMinute);
        possibleSpawnMaxAmount =  Mathf.FloorToInt(possibleSpawnBaseMaxAmount + possibleSpawnMaxAmountIncrease * clockMinute);

    }


    private IEnumerator SpawnEnemyWave()
    {
        //Bucle para todos los enemigos para spawnear
        for (int i=0; i<enemySpawnAmount; i++)
        {
            //Elegir punto de spawn
            int spanwIndex = Random.Range(0,possibleSpawns.Count);
            Vector3 spawnerPosition = possibleSpawns[spanwIndex];
            Vector3 spawnPosition = spawnerPosition + new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));

            //Spawnearlo con esa posicion
            SpawnEnemy(spawnPosition);

            yield return new WaitForSeconds(timeBetweenWaves/(2*enemySpawnAmount));
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
        enemyMovement.SetPlayers(player1, player2);
    }
}
