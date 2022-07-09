// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class MySingletonManager : MonoBehaviour
// {
//     //static singleton property
//     public static MySingletonManager Instance
//     {
//         get; private set;
//     }
//     // public property for manager
//     public string MyTestProperty = "Hello World";

//     void Awake()
//     {
//         // Save our current singleton instance
//         Instance = this;
//     }
//     // public method for manager

//     public void DoSomethingAwesome()
//     {}
// }

// The preceding code is just a very basic singleton implementation,
// which you can attach to any GameObject in the scene.
//Then, you can access the properties and functions within the singleton script
//by simply calling the following method from anywhere within your project:

  //Set the public property of the singleton 
  // MySingletonManager.Instance.MyTestProperty = "World Hello"; 
 
  // Run the public method from the singleton 
  // MySingletonManager.Instance.DoSomethingAwesome();


