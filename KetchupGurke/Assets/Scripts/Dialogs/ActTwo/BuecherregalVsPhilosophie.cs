using System.Collections.Generic;

[System.Serializable]
public class BuecherregalVsPhilosophie : IDialog
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
        IsCurrentDialog = gameState.talkedToBuecherRegalForTheFirstTime && gameState.booksToFind>0;
    }

    public BuecherregalVsPhilosophie()
    {
        TriggerActor = "BuecherregalInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Bücherregal" }
        };
        Messages = new List<IDialogMessage>()
        {
            new BuecherregalVsPhilosophie1()
        };
        IsCurrentDialog = false;
    }

}


[System.Serializable]
public class BuecherregalVsPhilosophie1 : IDialogMessage
{
    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public BuecherregalVsPhilosophie1()
    {
        Message = "Hallo Mia, hallo Fuchsi. Schön euch zu sehen. Seit ihr wieder da um die Abenteuer der Froschprinzessin Quarkini weiterzulesen?";
        ActorId = 1;
    }
}