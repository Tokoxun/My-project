using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ConversationManager : Singleton<ConversationManager>
{
    //Guarantee this will always be a singleton only can't use the instructor
    protected ConversationManager() 
    {}

    // this ConversationManager.Instance.StartConversation(conversation);
    // will start a new conversation

    //Is there a conversation going on 
    bool talking = false;

    //The current line of text being displayed
    ConversationEntry currentConversationLine;

    //The canvas group for the dialog box
    public CanvasGroup dialogBox;

    //The image holder
    public Image imageHolder;

    //The text holder
    public Text textHolder;

    IEnumerator DisplayConversation(Conversation conversation)
    {
        talking = true;
        foreach(var conversationLine in conversation.ConversationLines)
        {
            currentConversationLine = conversationLine;
            textHolder.text = currentConversationLine.ConversationText;

            imageHolder.sprite = currentConversationLine.DisplayPic;
            yield return new WaitForSeconds(3);
        }
        talking = false;
    }

    void OnGUI()
    {
        if(talking)
        {
            dialogBox.alpha = 1;
            dialogBox.blocksRaycasts = true;
        }
        else
        {
            dialogBox.alpha = 0;
            dialogBox.blocksRaycasts = false;
        }
    }

    public void StartConversation(Conversation conversation)
{
    dialogBox = GameObject.Find("Dialog Box").GetComponent<CanvasGroup>();
    imageHolder = GameObject.Find("Speaker Image").GetComponent<Image>();
    textHolder = GameObject.Find("Dialog Text").GetComponent<Text>();
    //Start displying the supplied conversation
    if (!talking)
    {
        StartCoroutine(DisplayConversation(conversation));
    }
}
}
