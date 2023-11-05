
using System.Collections.Generic;

[System.Serializable]
public class UnbequemesSofa : IDialog
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
        IsCurrentDialog = gameState.SofaBooks;
    }

    public UnbequemesSofa()
    {
        TriggerActor = "SofaInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Sofa" }
        };
        Messages = new List<IDialogMessage>()
        {
            new UnbequemesSofa1(),
            new UnbequemesSofa2()
        };
        IsCurrentDialog = false;
    }

}


[System.Serializable]
public class UnbequemesSofa1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public UnbequemesSofa1()
    {
        Message = "~Hmmm~ So unbequem war ich ja noch nie...";
        ActorId = 1;
    }

}


[System.Serializable]
public class UnbequemesSofa2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public UnbequemesSofa2()
    {
        Message = "Kein wunder du bist ja auch mit 3 Büchern gefüllt. Keine Angst später Räumen wir die wieder auf. Jetzt fehlen noch {0} Bücher.";
        ActorId = 0;
    }
}