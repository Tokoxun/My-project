using UnityEditor;
using UnityEngine;

public class CustomConversationUtility : MonoBehaviour
{
    //Define a menu option in the editor to create the new asset
    [MenuItem("Assets/Create/CustomConversationUtility")]
    public static void CreateAsset()
    {
        //Create a new instance of our scriptable object
        Conversation CustomConversationUtility = Conversation.CreateInstance<Conversation>();

        //Create a .asset file for our new object and save it
        AssetDatabase.CreateAsset(CustomConversationUtility,
        "Assets/newCustomConversationUtility.asset");
        AssetDatabase.SaveAssets();

        //Now switch the inspector to our new project
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = CustomConversationUtility;
    }
}
