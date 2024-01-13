using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public EnemyWaveScript[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;
   

    // Update is called once per frame
    
        void Update()
        {
            if (EnemiesAlive > 0)
            {
                return;
            }

            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }

            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

            waveCountdownText.text = string.Format("{0:00.00}", countdown);
        }

        IEnumerator SpawnWave()
        {

            //PlayerStats.Rounds++;

            EnemyWaveScript wave = waves[waveIndex];

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }

            waveIndex++;

            if (waveIndex == waves.Length)
            {
                Debug.Log("thump");
                this.enabled = false;
            }
        }

        void SpawnEnemy(GameObject enemy)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            EnemiesAlive++;
        }
    }
