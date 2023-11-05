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
        TriggerActor = "Stone";
        Actors = new List<DialogActor>
        {
            new() { name = "Fuchsi" }
        };
        Messages = new List<IDialogMessage>()
        {
            new FuchsiErmutigtMiaDialogMessage1(),
            new FuchsiErmutigtMiaDialogMessage2(),
            new FuchsiErmutigtMiaDialogMessage3(),
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
        Message = "Mia, hör zu. Wir sind in einer beunruhigenden Situation, das ist wahr, aber du hast die Fähigkeit, dich und deine Familie zu beschützen.";
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
        Message = "Hier ist der Plan: Du bleibst leise, versteckst dich und beobachtest weiterhin den Einbrecher. Aber wir dürfen nicht vergessen, dass deine Eltern die ersten sind, die von der Bedrohung erfahren sollten.";
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
        Message = "Glaub mir, sie werden alles tun, um uns sicher zu halten. Also, wenn du kannst, schleiche dich in ihr Zimmer und wecke sie. Aber pass auf, nicht gesehen zu werden.";
        ActorId = 0;
    }

    public bool UpdateGameState(GameState gameState)
    {
        gameState.initialDialogDone = true;
        return true;
    }

}
