using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public DialogManager dialogManager;

    public List<IDialog> dialogs;

    private GameState gameState;

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
            new FuchsiErmutigtMiaDialog(),
            new EineSpannungsgeladeneBegegnung(),
            new FuchsiUndMiaFindenDasBuecherregalInEinerPrekaerenSituation(),
            new KissenburgDrama(),
        };
    }

}