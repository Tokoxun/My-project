using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingReceiver : MonoBehaviour
{
    public void MessagePlayer()
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
}
