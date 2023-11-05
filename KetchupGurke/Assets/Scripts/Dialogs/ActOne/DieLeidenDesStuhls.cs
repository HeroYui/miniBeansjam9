using System.Collections.Generic;

[System.Serializable]
public class DieLeidenDesStuhls : IDialog
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

    public DieLeidenDesStuhls()
    {
        TriggerActor = "Stuhl1InteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Knarzi" }
        };
        Messages = new List<IDialogMessage>()
        {
            new DieLeidenDesStuhls1(),
            new DieLeidenDesStuhls2()
        };
        IsCurrentDialog = true;
    }

}


[System.Serializable]
public class DieLeidenDesStuhls1 : IDialogMessage
{
    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public DieLeidenDesStuhls1()
    {
        Message = "Ich bin voll belastet...ständig sitzen Leute auf mir drauf. Vor allem die Glitzersteinchen auf Tante Valentinas Hose lassen mich danach immer so zerdellt aussehen. Etwas wie der Mond.";
        ActorId = 1;
    }
}


[System.Serializable]
public class DieLeidenDesStuhls2 : IDialogMessage
{
    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public DieLeidenDesStuhls2()
    {
        Message = "Ich glaube nicht, dass und Knarzi der Stuhl helfen kann zu Mama und Papa zu kommen.";
        ActorId = 0;
    }
}