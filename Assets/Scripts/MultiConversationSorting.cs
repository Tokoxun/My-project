using UnityEngine;

public class MultiConversationSorting : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x - pos1.position.x < pos2.position.x - pos1.position.x)
        {
            Debug.Log("near mayor");
            pos2.GetComponent<MessagingClientReceiver>().enabled = false;
            transform.GetComponent<MessagingClientReceiver>().enabled = true;
        }
        if(pos2.position.x - pos1.position.x > transform.position.x - pos1.position.x)
        {
            Debug.Log("near shopkeeper");
            transform.GetComponent<MessagingClientReceiver>().enabled = false;
            pos2.GetComponent<MessagingClientReceiver>().enabled = true;
        }
    }
}
