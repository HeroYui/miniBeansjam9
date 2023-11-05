using System.Collections.Generic;

[System.Serializable]
public class EineSpannungsgeladeneBegegnung : IDialog
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
    }

    public EineSpannungsgeladeneBegegnung()
    {
        TriggerActor = "SteckdoseInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Steckdose" }
        };
        Messages = new List<IDialogMessage>()
        {
            new EineSpannungsgeladeneBegegnung1(),
            new EineSpannungsgeladeneBegegnung2()
        };
        IsCurrentDialog = true;
    }

}


[System.Serializable]
public class EineSpannungsgeladeneBegegnung1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public EineSpannungsgeladeneBegegnung1()
    {
        Message = "Hallo Mia, hallo Fuchsi. Schön euch zu sehen. Seit ihr wieder da um die Abenteuer der Froschprinzessin Quarkini weiterzulesen?";
        ActorId = 1;
    }

}


[System.Serializable]
public class EineSpannungsgeladeneBegegnung2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public EineSpannungsgeladeneBegegnung2()
    {
        Message = "Liebes Bücherregal, schau mal, wir müssen dringend ins Schlafzimmer unserer Eltern. Kannst du nicht einen kleinen Schritt zur Seite machen, damit wir vorbeikommen?";
        ActorId = 0;
    }

}