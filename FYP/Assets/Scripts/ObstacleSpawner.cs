using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] __SpawnPoints;

    public GameObject[] __FoodPrefabs;

    public GameObject __ApplePrefab;

    public float __TimeBetweenWaves = 2f;

    public int __ObstacleCount = 4;

    private float __TimeToSpawn = 1f;

    private int __NoOfWavesSinceSpeedIncrease = 0;


    
    void Update()
    {

        if (Time.time >= __TimeToSpawn)
        {
            SpawnFood();
            __TimeToSpawn = Time.time + __TimeBetweenWaves;
        }

        if (__NoOfWavesSinceSpeedIncrease >= 5 && __TimeBetweenWaves > 0.6f)
        {
            __TimeBetweenWaves -= 0.2f;
            __NoOfWavesSinceSpeedIncrease = 0;
        }

    }

    void SpawnFood()
    {
        IEnumerable<int> _RandomSpawnIndexList = FisherShuffle.CreateShuffledList(__SpawnPoints.Length);

        IEnumerable<int> _IndexesToSpawnSugaryFood = _RandomSpawnIndexList.Take(__ObstacleCount);
        int _IndexToSpawnApple = _IndexesToSpawnSugaryFood.Take(1).FirstOrDefault();
        for (int i = 0; i < __SpawnPoints.Length; i++)
        {
            if (_IndexesToSpawnSugaryFood.Contains(i))
            {
                if (i == _IndexToSpawnApple)
                {
                    Instantiate(__ApplePrefab, __SpawnPoints[i].position, Quaternion.identity);
                }
                else
                {
		            int _RandomFoodPrefabIndex = Random.Range(0, __FoodPrefabs.Length);
                    Instantiate(__FoodPrefabs[_RandomFoodPrefabIndex ], __SpawnPoints[i].position, Quaternion.identity);
                }
            }
        }
        __NoOfWavesSinceSpeedIncrease++;
        
    }
}
