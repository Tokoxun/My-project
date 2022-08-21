using UnityEngine;

public class MessagingClientBroadcast : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "ShopkeepConversation")
        {
            var receiver = col.collider.GetComponent<MessagingClientReceiverShopkeep>();
            receiver.ThePlayerIsTryingSomething();
        }
        else if (col.collider.tag == "MayorConversation")
        {
            var receiverM = col.collider.GetComponent<MessagingClientReceiverMayor>();
            receiverM.ThePlayerIsTryingToLeave();
        }
    }


}
