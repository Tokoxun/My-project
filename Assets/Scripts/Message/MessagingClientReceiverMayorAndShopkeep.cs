using UnityEngine;

public class MessagingClientReceiverMayorAndShopkeep : MonoBehaviour
{
    // void Start()
    // {
    //     MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    // }

    public void ThePlayerIsTryingToLeave()
    {
       var dialog = GetComponent<ConversationComponent>();
       if (dialog != null)
       {
           if (dialog.CustomConversationUtility != null && dialog.CustomConversationUtility.Length > 0)
            {
               var conversation = dialog.CustomConversationUtility[0];
                if (conversation != null)
                {
                    Debug.Log("conversation");
                    ConversationManager.Instance.StartConversation(conversation);
                }
            }
        }
    }

    public void ThePlayerIsTryingSomething()
    {
       var dialogS = GetComponent<ConversationComponent>();
       if (dialogS != null)
       {
           if (dialogS.CustomConversationUtility != null && dialogS.CustomConversationUtility.Length > 0)
            {
               var conversationS = dialogS.CustomConversationUtility[1];
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
