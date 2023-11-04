using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public List<Message> messages;

    public List<Actor> actors;

}

[System.Serializable]
public class Message
{
    public int actorId;

    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
}