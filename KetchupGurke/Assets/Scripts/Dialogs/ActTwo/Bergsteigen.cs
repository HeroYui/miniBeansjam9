using System.Collections.Generic;

[System.Serializable]
public class Bergsteigen : IDialog
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
        IsCurrentDialog = gameState.talkedToBuecherRegalForTheFirstTime && gameState.booksToFind <= 0;
    }

    public Bergsteigen()
    {
        TriggerActor = "BuecherregalInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Bücherregal" },
            new DialogActor() { name = "Mia" },
            new DialogActor() { name = "Papa" }
        };
        Messages = new List<IDialogMessage>()
        {
            new Bergsteigen1(),
            new Bergsteigen2(),
            new BergsteigenEpilog1(),
            new BergsteigenEpilog2(),
            new BergsteigenEpilog3()
        };
        IsCurrentDialog = false;
    }

}


[System.Serializable]
public class Bergsteigen1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public Bergsteigen1()
    {
        Message = "Aaaah, ich fühle mich so frei. Leicht wie ein leeres Bücherregal!";
        ActorId = 1;
    }

}

[System.Serializable]
public class Bergsteigen2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public Bergsteigen2()
    {
        Message = "Schnell Mia, klettern wir durch das Regal zu Mama und Papa und öffnen die Tür!";
        ActorId = 0;
    }

    public bool UpdateGameState(GameState gameState)
    {
        gameState.kapitelEpilog = true;
        return true;
    }
}

[System.Serializable]
public class BergsteigenEpilog1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public BergsteigenEpilog1()
    {
        Message = "Als Mama und Papa von dem Einbruch erfuren, waren sie heil froh, dass uns nichts passiert ist. Außerdem riefen sie die Polizei, die dank deiner Hilfe den Einbrecher direkt schnappen konnte, meine kleine Prinzessein! Wir werden deine Tapferkeit mit einem Eis und einem Tag im Zoo.";
        ActorId = 3;
    }

}


[System.Serializable]
public class BergsteigenEpilog2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public BergsteigenEpilog2()
    {
        Message = "Au ja! Mal schauen, was die Tiere so zu erzählen haben...";
        ActorId = 2;
    }

}

[System.Serializable]
public class BergsteigenEpilog3 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public BergsteigenEpilog3()
    {
        Message = "";
        ActorId = 2;
    }
    public bool UpdateGameState(GameState gameState)
    {
        gameState.epilogDurch = true;
        return true;
    }

}
