using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{

    public GameObject[] roadPrefabs;
    public float zSpawn = 0;
    public float roadLeanght = 145.4f;
    public int numberOfRoads = 3;
    public int safeZone = 100;

    private List<GameObject> activeRoads = new List<GameObject> ();
    public Transform carTransform;

    private void Start()
    {
        for(int i = 0; i < numberOfRoads; i++)
        {
            if(i == 0)
            {
                SpawnRoard(0);
            }
            else
            {
                SpawnRoard(Random.Range(0, roadPrefabs.Length));
            }
            
        }

    }

    private void Update()
    {
        if (carTransform.position.z - safeZone > zSpawn - (numberOfRoads * roadLeanght))
        {
            SpawnRoard(Random.Range(0, roadPrefabs.Length));
            DeleteRoad();
        }
    }

    public void SpawnRoard(int roadIndex)
    {
        GameObject road =  Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation);
        activeRoads.Add(road);
        zSpawn += roadLeanght;
    }

    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}
