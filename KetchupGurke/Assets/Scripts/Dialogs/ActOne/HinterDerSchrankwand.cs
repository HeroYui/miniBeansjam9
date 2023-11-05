using System.Collections.Generic

    [System.Serializable]
public class HinterDerSchrankwand : IDialog
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

    public HinterDerSchrankwand()
    {
        TriggerActor = "BuecherregalInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Schrank" }
        };
        Messages = new List<IDialogMessage>()
        {
            new HinterDerSchrankwand1(),
            new HinterDerSchrankwand2(),
            new HinterDerSchrankwand3()
        };
        IsCurrentDialog = true;
    }

}


[System.Serializable]
public class HinterDerSchrankwand1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public HinterDerSchrankwand1()
    {
        Message = "Aaach ja der Schrank ist immer ein gutes Versteck.";
        ActorId = 0;
    }

}


[System.Serializable]
public class HinterDerSchrankwand2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public HinterDerSchrankwand2()
    {
        Message = "Verstecken, argh...noch mehr Gerümpel.";
        ActorId = 1;
    }

}

[System.Serializable]
public class HinterDerSchrankwand3 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public HinterDerSchrankwand3()
    {
        Message = "Nein Schrank heute nicht, wir sind auf wichtiger Mission.";
        ActorId = 1;
    }
}