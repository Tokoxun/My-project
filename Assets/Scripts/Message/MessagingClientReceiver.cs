using UnityEngine;

public class MessagingClientReceiver : MonoBehaviour
{
    void Start()
    {
        MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    }

    void ThePlayerIsTryingToLeave()
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

    void OnDestroy()
    {
        if (MessagingManager.Instance != null)
        {
            MessagingManager.Instance.UnSubscribe(ThePlayerIsTryingToLeave);
        }
    }
    
}
