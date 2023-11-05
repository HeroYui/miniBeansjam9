using System.Collections.Generic;

[System.Serializable]
public class Beziehungsprobleme : IDialog
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

    public Beziehungsprobleme()
    {
        TriggerActor = "EsstischInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
        };
        Messages = new List<IDialogMessage>()
        {
            new Beziehungsprobleme1()
        };
        IsCurrentDialog = true;
    }

}


[System.Serializable]
public class Beziehungsprobleme1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public Beziehungsprobleme1()
    {
        Message = "Seit die Beziehung zwischen Quietschie dem Stuhl und dem Esstisch auseinandergeschoben wurde sind beide Beledigte Leberwürste und Stumm.";
        ActorId = 0;
    }

}
