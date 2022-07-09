using UnityEngine;
using UnityEditor;
public class CustomConversationUtility : MonoBehaviour{
    [MenuItem("Assets/Create/CustomConversationUtility")]
    public static void CreateAsset() 
  { 
    //Create a new instance of our scriptable object 
    Conversation CustomConversationUtility = 
    ScriptableObject.CreateInstance<Conversation>(); 
 
    //Create a .asset file for our new object and save it 
    AssetDatabase.CreateAsset(CustomConversationUtility, 
      "Assets/CustomConversationUtility.asset"); 
    AssetDatabase.SaveAssets(); 
 
    //Now switch the inspector to our new object 
    EditorUtility.FocusProjectWindow(); 
    Selection.activeObject = CustomConversationUtility; 
  } 
}

