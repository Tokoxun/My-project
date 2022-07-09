// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MySingletonManager2 : MonoBehaviour
// {
//     //static singleton property
//     public static MySingletonManager Instance
//     {
//         get; private set;
//     }
//     // public property for manager
//     public string MyTestProperty = "Hello World";
    
//     // Start is called before the first frame update
//     void Awake()
//     {
//         //First we check if there are any other instances conflicting
//         if(Instance != null && Instance != this)
//         {
//             //Destroy other instances if they are not the same
//             Destroy(gameObject);
//         }

//         //Save our singleton instance
//         Instance = this;
//         //Make sure the instance is not destroyed between scenes(this is optional)
//         DontDestroyOnLoad(gameObject);
//     }

//     // public method for manager
//     public void DoSomethingAwesome()
//     {
        
//     }
// }
