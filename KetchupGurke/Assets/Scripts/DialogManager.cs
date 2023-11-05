using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    public TMP_Text actorNameText;

    public TMP_Text talkingText;

    public RectTransform backgroundBox;

    private bool _isActive;
    public bool IsActive { get => _isActive; private set => _isActive = value; }

    private IDialogMessage _currentMessage;
    public IDialogMessage CurrentDialogMessage { get => _currentMessage; private set => _currentMessage = value; }

    private IDialog _currentDialog;
    public IDialog CurrentDialog { get => _currentDialog; private set => _currentDialog = value; }

    private int currentDialogMessageIndex = 0;

    private void DisplayMessage(GameState gameState)
    {
        CurrentDialogMessage = CurrentDialog.Messages[currentDialogMessageIndex];
        talkingText.text = CurrentDialogMessage.GetInterpolatedMessage(gameState);
        actorNameText.text = CurrentDialog.Actors[CurrentDialogMessage.ActorId].name;
        LeanTween.alphaText(talkingText.rectTransform, 0.0f, 0f);
        LeanTween.alphaText(talkingText.rectTransform, 1.0f, 0.5f);
    }

    public void OpenDialog(IDialog dialog, GameState gameState)
    {
        CurrentDialog = dialog;
        currentDialogMessageIndex = 0;
        IsActive = true;

        Debug.Log("Started conversation. Messages: " + dialog.Messages);
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
        DisplayMessage(gameState);
    }

    public void NextMessage(GameState gameState)
    {
        currentDialogMessageIndex++;
        if (currentDialogMessageIndex < CurrentDialog.Messages.Count)
        {
            DisplayMessage(gameState);
        }
        else
        {
            IsActive = false;
            Debug.Log("Conversation finished!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        }
    }

    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
        IsActive = false;
    }

}
