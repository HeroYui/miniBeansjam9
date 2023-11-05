
using System.Collections.Generic;

[System.Serializable]
public class FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation : IDialog
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

    public FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation()
    {
        TriggerActor = "BuecherregalInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Bücherregal" }
        };
        Messages = new List<IDialogMessage>()
        {
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation1(),
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation2(),
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation3(),
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation4(),
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation5(),
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation6()
        };
        IsCurrentDialog = true;
    }

}


[System.Serializable]
public class FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation1()
    {
        Message = "Hallo Mia, hallo Fuchsi. Schön euch zu sehen. Seit ihr wieder da um die Abenteuer der Froschprinzessin Quarkini weiterzulesen?";
        ActorId = 1;
    }

}


[System.Serializable]
public class FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation2()
    {
        Message = "Liebes Bücherregal, schau mal, wir müssen dringend ins Schlafzimmer unserer Eltern. Kannst du nicht einen kleinen Schritt zur Seite machen, damit wir vorbeikommen?";
        ActorId = 0;
    }

}

[System.Serializable]
public class FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation3 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation3()
    {
        Message = "Oh, tut mir leid, Fuchsi. Leider bin ich zu schwer und kann mich nicht bewegen. Ich wollte wirklich abnehmen, aber diese neuen Bücher waren einfach zu verlockend.";
        ActorId = 1;
    }
}

[System.Serializable]
public class FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation4 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation4()
    {
        Message = "Wir haben nicht die Zeit dich komplett leerzuräumen. Lass uns einfach deinen Bauch ausräumen. Dann können wir durch dich durchklettern.";
        ActorId = 0;
    }

    public bool UpdateGameState(GameState gameState)
    {
        gameState.booksToFind = 7;
        return true;
    }

}

[System.Serializable]
public class FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation5 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation5()
    {
        Message = "Das klingt nach einem guten Plan! Geht vorsichtig, und passt auf euch auf!";
        ActorId = 1;
    }
}

[System.Serializable]
public class FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation6 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation6()
    {
        Message = "{0} Bücher müssen ausm Regal verschwinden.";
        ActorId = 0;
    }

    public bool UpdateGameState(GameState gameState)
    {
        gameState.talkedToBuecherRegalForTheFirstTime = true;
        return true;
    }
}
