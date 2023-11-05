using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public DialogManager dialogManager;

    public BookCounter bookCounter;

    public List<IDialog> dialogs;

    private GameState gameState;

    private bool firstDialogWasShown = false;

    public bool IsConversationInProgress
    {
        get => dialogManager.IsActive;
    }

    private void UpdateGameState()
    {
        var wasUpdated = dialogManager.CurrentDialogMessage.UpdateGameState(gameState);
        if (wasUpdated)
        {
            foreach (var dialog in dialogs)
            {
                dialog.UpdateIsCurrentDialog(gameState);
            }
            bookCounter.UpdateBookCounter(gameState.booksToFind);
        }
    }

    public void StartDialogWith(GameObject gameObject)
    {
        var triggerActor = gameObject.name;
        var currentDialog = dialogs.FirstOrDefault(d => d.TriggerActor == triggerActor && d.IsCurrentDialog);
        if (currentDialog != null)
        {
            dialogManager.OpenDialog(currentDialog, gameState);
            UpdateGameState();
        }
    }

    public void AdvanceCurrentDialog()
    {
        dialogManager.NextMessage(gameState);
        UpdateGameState();
    }

    void Awake()
    {
        gameState = new GameState();
        dialogs = new List<IDialog>() {
            new FuchsiErmutigtMiaDialog(),//Prolog
            new EineSpannungsgeladeneBegegnung(),//Akt1
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation(),
            new KissenburgDrama(),
            new DieLeidenDesStuhls(),
            new HinterDerSchrankwand(),
            new Beziehungsprobleme(),
            new BuecherregalVsPhilosophie(),//Akt2
            new WoKommtDasDennHer(),
            new UnbequemesSofa(),
            new StuehleSindKeineGutenVerstecke(),
            new KlappeZuSchrankTot(),
            new Bergsteigen(),
            new Epilog()
        };
    }

    void FixedUpdate()
    {
        if (!firstDialogWasShown)
        {
            firstDialogWasShown = true;
            var currentDialog = dialogs[0];
            dialogManager.OpenDialog(currentDialog, gameState);
            UpdateGameState();
        }
    }

}