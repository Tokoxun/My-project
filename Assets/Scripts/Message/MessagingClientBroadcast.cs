using UnityEngine;

public class MessagingClientBroadcast : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "ShopkeepConversation")
        {
            var receiver = GetComponent<MessagingClientReceiverMayorAndShopkeep>();
            receiver.ThePlayerIsTryingSomething();
        }
        else if (col.collider.tag == "MayorConversation")
        {
            var receiverM = GetComponent<MessagingClientReceiverMayorAndShopkeep>();
            receiverM.ThePlayerIsTryingToLeave();
        }
    }


}
