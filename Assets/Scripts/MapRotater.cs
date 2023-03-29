using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRotater : MonoBehaviour
{
//     public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>()
//     {
//         {"Overworld", "The big bad world", CanTravel = true}, {"Construction", "The construction area", CanTravel = false};
//     }

//     public static string GetRouteInfo(string, destination)
//     {
//         public static string GetRouteInfo(string, destination)
//         {
//             return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
//         }
//     }

//     public static bool CanNavigate(string, destination)
//     {
//         return RouteInformation.ContainsKey(destination) ? RouteInformation[destination].CanTravel : false;
//     }
//     public static void NavigateTo(string, destination)
//     {

//     }
//     public struct Route
//     {
//         public string RouteDescription;
//         public bool CanTravel;
//     }


    private float EnemyCount;
    private float enemyDead;

    void Start()
    {
        EnemyCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Collider2D>().CompareTag("enemy"))
        {
            EnemyCount += 1;
            enemyDead = 0;
        }
    }

    public void EnemyKilled()
    {
        enemyDead += 1;
        Debug.Log(enemyDead);
    }
}