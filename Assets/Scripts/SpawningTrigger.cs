using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningTrigger : MonoBehaviour
{
    public GameObject[] SpawnPoints;
    public GameObject SpawnType;
    private int NumOfSpawn = 2;
    private float PortalUpTime = 2f;
    private float PortalCooldown;
    public bool SpawnStarted = false;
    private GameObject SelectedPoint;

    public void RandomPoints()
    {
        int PointToSpawn = Random.Range(0, SpawnPoints.Length);
        SelectedPoint = SpawnPoints[PointToSpawn];
        Instantiate(SpawnType, SelectedPoint.transform.position, SelectedPoint.transform.rotation);
        NumOfSpawn -= 1;
        SelectedPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SpawnStarted)
        {
            PortalCooldown += Time.deltaTime;
            if(PortalCooldown >= PortalUpTime && NumOfSpawn >= 1)
            {
                RandomPoints();
            }
        }
    }
}
