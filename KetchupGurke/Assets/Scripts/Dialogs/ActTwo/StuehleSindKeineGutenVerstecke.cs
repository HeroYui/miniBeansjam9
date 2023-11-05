using System.Collections.Generic;

[System.Serializable]
public class StuehleSindKeineGutenVerstecke : IDialog
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
        IsCurrentDialog = gameState.talkedToBuecherRegalForTheFirstTime;
    }

    public StuehleSindKeineGutenVerstecke()
    {
        TriggerActor = "Stuhl1InteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Knarzi" }
        };
        Messages = new List<IDialogMessage>()
        {
            new StuehleSindKeineGutenVerstecke1(),
            new StuehleSindKeineGutenVerstecke2(),
            new StuehleSindKeineGutenVerstecke3()
        };
        IsCurrentDialog = false;
    }

}


[System.Serializable]
public class StuehleSindKeineGutenVerstecke1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public StuehleSindKeineGutenVerstecke1()
    {
        Message = "Kannst du Bücher für uns verstecken, Knarzi?";
        ActorId = 0;
    }

}


[System.Serializable]
public class StuehleSindKeineGutenVerstecke2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public StuehleSindKeineGutenVerstecke2()
    {
        Message = "Na klar! Aber wehe, du pupst mich wieder an!";
        ActorId = 1;
    }

}

[System.Serializable]
public class StuehleSindKeineGutenVerstecke3 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public StuehleSindKeineGutenVerstecke3()
    {
        Message = "Hmm. Das Buch ist leider immer gut sichtbar, ob auf oder unter dem Stuhl. Kein gutes Versteck.";
        ActorId = 0;
    }
}