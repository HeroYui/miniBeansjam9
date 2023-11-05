using System.Collections.Generic;

[System.Serializable]
public class WoKommtDasDennHer : IDialog
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
        IsCurrentDialog = gameState.talkedToBuecherRegalForTheFirstTime&&!gameState.SofaBooks;
    }

    public WoKommtDasDennHer()
    {
        TriggerActor = "SofaInteractableObject";
        Actors = new List<DialogActor>
        {
            new DialogActor() { name = "Fuchsi" },
            new DialogActor() { name = "Sofa" }
        };
        Messages = new List<IDialogMessage>()
        {
            new WoKommtDasDennHer1(),
            new WoKommtDasDennHer2(),
            new WoKommtDasDennHer3(),
            new WoKommtDasDennHer4(),
            new WoKommtDasDennHer5(),
            new WoKommtDasDennHer6(),
            new WoKommtDasDennHer7()
        };
        IsCurrentDialog = false;
    }

}


[System.Serializable]
public class WoKommtDasDennHer1 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public WoKommtDasDennHer1()
    {
        Message = "Hey, Sofa! Wir müssen Bücher aus dem Regal verstecken, damit der Einbrecher sie nicht sieht.";
        ActorId = 0;
    }

}


[System.Serializable]
public class WoKommtDasDennHer2 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public WoKommtDasDennHer2()
    {
        Message = "~Hmmm~ Fuchsi, das ist spannend! Aber bevor wir das machen, die Krümmel pieksen immer so kannst du mal meine ritzen sauber machen?";
        ActorId = 1;
    }

}

[System.Serializable]
public class WoKommtDasDennHer3 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public WoKommtDasDennHer3()
    {
        Message = "Machen wir während wir die Bücher in deine Ritzen schieben.";
        ActorId = 0;
    }
}

[System.Serializable]
public class WoKommtDasDennHer4 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public WoKommtDasDennHer4()
    {
        Message = "Oh. Was haben wir denn da? Rex der Stegosaurus, das Reittier von Prinzessin Quarkini. Wie kommt der denn hier hin?";
        ActorId = 0;
    }
}

[System.Serializable]
public class WoKommtDasDennHer5 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public WoKommtDasDennHer5()
    {
        Message = "~Hmmm~ ich fühle mich so voll und echt ungemütlich.";
        ActorId = 1;
    }
    public bool UpdateGameState(GameState gameState)
    {
        gameState.booksToFind -= 3;
        gameState.SofaBooks = true;
        return true;
    }
}

[System.Serializable]
public class WoKommtDasDennHer6 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public WoKommtDasDennHer6()
    {
        Message = "Kein wunder du bist ja auch mit 3 Büchern gefüllt. Keine Angst später Räumen wir die wieder auf. Jetzt fehlen noch $BooksToFind Bücher";
        ActorId = 0;
    }
}

[System.Serializable]
public class WoKommtDasDennHer7 : IDialogMessage
{

    private string _message;
    public string Message { get => _message; set => _message = value; }

    private int _actorId;
    public int ActorId { get => _actorId; set => _actorId = value; }

    public WoKommtDasDennHer7()
    {
        Message = "~Hmmm~ Das sagt ihr immer....";
        ActorId = 0;
    }
}