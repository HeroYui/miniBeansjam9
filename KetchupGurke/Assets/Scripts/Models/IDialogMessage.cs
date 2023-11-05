public interface IDialogMessage
{

    string Message { get; }
    int ActorId { get; }

    public string GetInterpolatedMessage(GameState gameState)
    {
        return string.Format(Message, gameState);
    }

    public bool UpdateGameState(GameState gameState)
    {
        return false;
    }

}