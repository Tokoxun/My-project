using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTrigger : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject SpawnType;
    private GameObject SelectedPoint;

    public void RandomPoints()
    {
        int PointToSpawn = Random.Range(0, SpawnPoints.Length);
        SelectedPoint = SpawnPoints[PointToSpawn];
        Instantiate(SpawnType, SelectedPoint.transform.position, SelectedPoint.transform.rotation);
        SelectedPoint.SetActive(false);
    }
}
