using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    public InputActionAsset inputActions;

    public TMP_Text actorNameText;

    public TMP_Text talkingText;

    public RectTransform backgroundBox;

    public bool isActive = false;

    private List<Message> currentMessages;

    private List<Actor> currentActors;

    private int activeMessage = 0;

    private void DisplayMessage()
    {
        var messageToDisplay = currentMessages[activeMessage];
        talkingText.text = messageToDisplay.message;
        actorNameText.text = currentActors[messageToDisplay.actorId].name;
    }

    public void OpenDialog(List<Message> messages, List<Actor> actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        Debug.Log("Started conversation. Messages: " + messages);
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        DisplayMessage();
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Count)
        {
            DisplayMessage();
        }
        else
        {
            isActive = false;
            Debug.Log("Conversation finished!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        }
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

}
