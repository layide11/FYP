using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform[] __SpawnPoints;

    public GameObject[] __FoodPrefabs;

    public float __TimeBetweenWaves = 1f;

    public int __ObstacleCount = 4;

    private float __TimeToSpawn = 1f;

    void Update()
    {

        if (Time.time >= __TimeToSpawn)
        {
            SpawnBlocks();
            __TimeToSpawn = Time.time + __TimeBetweenWaves;
        }

    }

    void SpawnBlocks()
    {
        //possible to extennd for levels yay!!
        IEnumerable<int> _RandomSpawnIndexList = FisherShuffle.CreateShuffledList(__SpawnPoints.Length);

        IEnumerable<int> _SkippedSpwanIndexs = _RandomSpawnIndexList.Take(__SpawnPoints.Length - __ObstacleCount);
        
        for (int i = 0; i < __SpawnPoints.Length; i++)
        {
            if (!_SkippedSpwanIndexs.Contains(i))
            {
		        int _RandomFoodPrefabIndex = Random.Range(0, __FoodPrefabs.Length);
                Instantiate(__FoodPrefabs[_RandomFoodPrefabIndex ], __SpawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
