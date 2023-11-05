using System.Collections.Generic;

[System.Serializable]
public class KissenburgDrama : IDialog
{

    private List<DialogActor> _dialogActors;
    public List<DialogActor> Actors { get => _dialogActors; private set => _dialogActors = value; }

    private List<IDialogMessage> _dialogMessages;
    public List<IDialogMessage> Messages { get => _dialogMessages; private set => _dialogMessages = value; }

    private bool _isCurrentDialog;
    public bool IsCurrentDialog { get => _isCurrentDialog; private set => _isCurrentDialog = value; }

    private string _triggerActor;
    public string TriggerActor { get => _triggerActor; private set => _triggerActor = value; }

    public void UpdateIsCurrentDialog(GameState gameState)
    {
        IsCurrentDialog = !gameState.talkedToBuecherRegalForTheFirstTime;
    }

    public KissenburgDrama()
    {
        TriggerActor = "SofaInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Sofa" }
        };
        Messages = new List<IDialogMessage>()
        {
            new KissenburgDrama1(),
            new KissenburgDrama2()
        };
        IsCurrentDialog = true;
    }

}


[System.Serializable]
public class KissenburgDrama1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public KissenburgDrama1()
    {
        Message = "~Hmmm~ Mia, es ist aber schon etwas spät, um eine Kissenburg aus mir zu bauen.";
        ActorId = 1;
    }

}


[System.Serializable]
public class KissenburgDrama2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public KissenburgDrama2()
    {
        Message = "Kissenburgen verteidigen nur gegen Fantasie-Drachen! Wir müssen weiter Mama und Papa warnen.";
        ActorId = 0;
    }
}

