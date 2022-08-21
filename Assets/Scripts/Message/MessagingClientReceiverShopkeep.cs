using UnityEngine;

public class MessagingClientReceiverShopkeep : MonoBehaviour
{
    // void Start()
    // {
    //     MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    // }

    public void ThePlayerIsTryingSomething()
    {
       var dialogS = GetComponent<ConversationComponent>();
       if (dialogS != null)
       {
           if (dialogS.CustomConversationUtility != null && dialogS.CustomConversationUtility.Length > 0)
            {
               var conversationS = dialogS.CustomConversationUtility[0];
                if (conversationS != null)
                {
                    Debug.Log("conversation");
                    ConversationManager.Instance.StartConversation(conversationS);
                }
            }
        }
    }

    // void OnDestroy()
    // {
    //     if (MessagingManager.Instance != null)
    //     {
    //         MessagingManager.Instance.UnSubscribe(ThePlayerIsTryingToLeave);
    //     }
    // }

}
