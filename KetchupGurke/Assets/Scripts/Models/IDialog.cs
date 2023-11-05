using System.Collections.Generic;


public interface IDialog
{

    public string TriggerActor { get; }

    public bool IsCurrentDialog { get; }

    List<DialogActor> Actors { get; }

    List<IDialogMessage> Messages { get; }

    public void UpdateIsCurrentDialog(GameState gameState);

}
