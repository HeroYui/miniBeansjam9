using System.Collections.Generic;

[System.Serializable]
public class FuchsiErmutigtMiaDialog : IDialog
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
        IsCurrentDialog = !gameState.initialDialogDone;
    }

    public FuchsiErmutigtMiaDialog()
    {
        TriggerActor = "MiaInteractableObject";
        Actors = new List<DialogActor>
        {
            new() { name = "Fuchsi" }
        };
        Messages = new List<IDialogMessage>()
        {
            new FuchsiErmutigtMiaDialogMessage1(),
            new FuchsiErmutigtMiaDialogMessage2(),
            new FuchsiErmutigtMiaDialogMessage3()
        };
        IsCurrentDialog = true;
    }

}


[System.Serializable]
public class FuchsiErmutigtMiaDialogMessage1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiErmutigtMiaDialogMessage1()
    {
        Message = "Mia, hör mal, wir haben 'ne schwierige Situation, aber du kannst das! Du kannst deine Familie schützen.";
        ActorId = 0;
    }

}


[System.Serializable]
public class FuchsiErmutigtMiaDialogMessage2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiErmutigtMiaDialogMessage2()
    {
        Message = "Deine Eltern müssen als Erste davon erfahren, verstehst du? Schleich dich in ihr Zimmer und weck sie auf.";
        ActorId = 0;
    }

}

[System.Serializable]
public class FuchsiErmutigtMiaDialogMessage3 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiErmutigtMiaDialogMessage3()
    {
        Message = "Aber pass auf, der Einbrecher darf uns nicht sehen. Gemeinsam schaffen wir das! Los geht's!";
        ActorId = 0;
    }

    public bool UpdateGameState(GameState gameState)
    {
        gameState.initialDialogDone = true;
        return true;
    }
}
