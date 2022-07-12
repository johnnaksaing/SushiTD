using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public float timeBetweenWaves = 3f;
    float countdown = 2f;
    private void Update()
    {
        if (countdown <= 0f) 
        {
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }
    void SpawnWave() 
    {
        Debug.Log("wave start");
        Instantiate(enemyPrefab);
    }
}
