using System.Collections.Generic;

[System.Serializable]
public class KlappeZuSchrankTot : IDialog
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
        IsCurrentDialog = gameState.talkedToBuecherRegalForTheFirstTime && !gameState.SchrankBooks;
    }

    public KlappeZuSchrankTot()
    {
        TriggerActor = "SchrankInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Schrank" }
        };
        Messages = new List<IDialogMessage>()
        {
            new KlappeZuSchrankTot1(),
            new KlappeZuSchrankTot2(),
            new KlappeZuSchrankTot3(),
            new KlappeZuSchrankTot4(),
            new KlappeZuSchrankTot5()
        };
        IsCurrentDialog = false;
    }

}


[System.Serializable]
public class KlappeZuSchrankTot1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public KlappeZuSchrankTot1()
    {
        Message = "Aaach ja, der Schrank ist immer ein gutes Versteck.";
        ActorId = 0;
    }

}


[System.Serializable]
public class KlappeZuSchrankTot2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public KlappeZuSchrankTot2()
    {
        Message = "Verstecken, argh...noch mehr Gerümpel.";
        ActorId = 1;
    }

}

[System.Serializable]
public class KlappeZuSchrankTot3 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public KlappeZuSchrankTot3()
    {
        Message = "Entschuldige, wir stopfen nur schnell ein paar Bücher in dich und machen dann ganz schnell die Tür zu.";
        ActorId = 0;
    }
}

[System.Serializable]
public class KlappeZuSchrankTot4 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public KlappeZuSchrankTot4()
    {
        Message = "Ihr macht waaas? Das geht doch ni..........";
        ActorId = 1;
    }

    public bool UpdateGameState(GameState gameState)
    {
        gameState.booksToFind -= 4;
        gameState.SchrankBooks = true;
        return true;
    }

}

[System.Serializable]
public class KlappeZuSchrankTot5 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public KlappeZuSchrankTot5()
    {
        Message = "Sehr gut. Jetzt fehlen noch {0} Bücher.";
        ActorId = 1;
    }
}