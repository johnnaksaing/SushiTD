using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    int waveIndex = 0;
    
    public float timeBetweenWaves = 3f;
    float countdown = 2f;

    public Text waveCountdownText;
    
    
    
    private void Update()
    {
        if (countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave() 
    {
        waveIndex++; 
        for (int i = 0; i < waveIndex; i++) 
        {
            SpawnEnemy();

            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy() 
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
