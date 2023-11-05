public interface IDialogMessage
{

    string Message { get; }
    int ActorId { get; }

    public string GetInterpolatedMessage(GameState gameState)
    {
        return string.Format(Message, gameState.booksToFind);
    }

    public bool UpdateGameState(GameState gameState)
    {
        return false;
    }
}