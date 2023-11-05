using System.Linq;
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

    private Animator animator;

    private enum MovementState { left, right, up, down, idle }

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
        animator = GetComponentInChildren<Animator>();
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
        UpdateAnimation(movementVector);
    }

    private void UpdateAnimation(Vector2 movementVector)
    {
        MovementState state;
        var directionX = movementVector.x;
        var directionY = movementVector.y;

        if (directionX > 0f)
        {
            state = MovementState.right;
        }
        else if (directionX < 0f)
        {
            state = MovementState.left;
        }
        else if (directionY > 0f)
        {
            state = MovementState.up;
        }
        else if (directionY < 0f)
        {
            state = MovementState.down;
        }
        else
        {
            state = MovementState.idle;
        }

        animator.SetInteger("state", (int)state);
    }

    void OnTalk(InputAction.CallbackContext callbackContext)
    {
        if (!gameManager.IsConversationInProgress)
        {
            var collidedGameObjects = interactionCollider.collidedGameObjects;
            var gameObject = collidedGameObjects.FirstOrDefault(c => c.CompareTag("Mia") || c.CompareTag("MiaAndThief"));
            if (gameObject != null)
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
