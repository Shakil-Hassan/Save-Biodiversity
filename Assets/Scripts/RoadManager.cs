using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private GameObject[] roadPrefabs;
    [SerializeField] private float roadLength = 145.4f;
    [SerializeField] private int numberOfRoads = 3;
    [SerializeField] private int safeZone = 100;
    [SerializeField] private Transform carTransform;

    private List<GameObject> activeRoads = new List<GameObject>();
    private float zSpawn = 0;

    private void Start()
    {
        SpawnRoad(0); // Spawn the initial road
        for (int i = 1; i < numberOfRoads; i++)
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length)); // Spawn the rest of the roads randomly
        }
    }

    private void Update()
    {
        if (carTransform.position.z - safeZone > zSpawn - (numberOfRoads * roadLength))
        {
            SpawnRoad(Random.Range(0, roadPrefabs.Length)); // Spawn a new road
            DeleteRoad(); // Delete the oldest road
        }
    }

    private void SpawnRoad(int roadIndex)
    {
        GameObject road = Instantiate(roadPrefabs[roadIndex], transform.forward * zSpawn, transform.rotation);
        activeRoads.Add(road);
        zSpawn += roadLength;
    }

    private void DeleteRoad()
    {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
}