using System.Collections.Generic;

[System.Serializable]
public class Epilog :  IDialog
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
        IsCurrentDialog = gameState.kapitelEpilog;
    }

    public Epilog()
    {
        TriggerActor = "EpilogInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Mia" },
            new DialogActor() { name = "Papa" }
        };
        Messages = new List<IDialogMessage>()
        {
            new Epilog1(),
            new Epilog2()
        };
        IsCurrentDialog = false;
    }

}


[System.Serializable]
public class Epilog1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public Epilog1()
    {
        Message = "Die Polizei hat den Einbrecher dank deiner Hilfe schnappen können, meine kleine Prinzessin. Wir feiern deine Tapferkeit mit einem Eis und einem Tag im Zoo.";
        ActorId = 1;
    }

}


[System.Serializable]
public class Epilog2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public Epilog2()
    {
        Message = "Au ja mal schauen was die Tiere so zu erzählen haben...";
        ActorId = 0;
    }   public bool UpdateGameState(GameState gameState)
    {
        //ToDo Credits
        return true;
    }
}
