using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;

    public InputActionAsset playerInputAction;

    private GameManger gameManager;

    private InputAction moveAction;

    private Rigidbody2D rigidbody2d;

    private InteractionColliderController colliderController;

    private InteractionCollider interactionCollider;

    void OnEnable()
    {
        var playerActionMap = playerInputAction.FindActionMap("Player");
        playerActionMap.Enable();
        playerActionMap.FindAction("Talk").performed += OnTalk;
    }

    void OnDisable()
    {
        var playerActionMap = playerInputAction.FindActionMap("Player");
        playerActionMap.Disable();
        playerActionMap.FindAction("Talk").performed -= OnTalk;
    }

    void Awake()
    {
        moveAction = playerInputAction.FindActionMap("Player").FindAction("Move");
        rigidbody2d = GetComponent<Rigidbody2D>();
        colliderController = GetComponentInChildren<InteractionColliderController>();
        interactionCollider = GetComponentInChildren<InteractionCollider>();
        gameManager = FindObjectOfType<GameManger>();
    }

    void FixedUpdate()
    {
        if (gameManager.IsConversationInProgress)
            return;

        var movementVector = Time.deltaTime * speed * moveAction.ReadValue<Vector2>().normalized;
        if (movementVector.magnitude > 0)
        {
            rigidbody2d.MovePosition(transform.position + (Vector3)movementVector);
            colliderController.FacingAngle = Vector2.SignedAngle(transform.right, movementVector);
        }
    }

    void OnTalk(InputAction.CallbackContext callbackContext)
    {
        if (!gameManager.IsConversationInProgress)
        {
            var collidedGameObjects = interactionCollider.collidedGameObjects;
            foreach (var gameObject in collidedGameObjects)
            {
                gameManager.StartDialogWith(gameObject);
            }
        }
        else
        {
            gameManager.AdvanceCurrentDialog();
        }
    }

}
