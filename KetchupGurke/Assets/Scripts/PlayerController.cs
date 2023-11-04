using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;

    public InputActionAsset playerInputAction;

    private DialogManager dialogManager;

    private InputAction moveAction;

    private Rigidbody2D rigidbody2d;

    private ColliderController colliderController;

    private InteractionCollider interactionCollider;

    void OnEnable()
    {
        var playerActionMap = playerInputAction.FindActionMap("Player");
        playerActionMap.Enable();
        playerActionMap.FindAction("Use").performed += OnUse;
        playerActionMap.FindAction("Talk").performed += OnTalk;
    }

    void OnDisable()
    {
        var playerActionMap = playerInputAction.FindActionMap("Player");
        playerActionMap.Disable();
        playerActionMap.FindAction("Use").performed -= OnUse;
        playerActionMap.FindAction("Talk").performed -= OnTalk;
    }

    void Awake()
    {
        moveAction = playerInputAction.FindActionMap("Player").FindAction("Move");
        rigidbody2d = GetComponent<Rigidbody2D>();
        colliderController = GetComponentInChildren<ColliderController>();
        interactionCollider = GetComponentInChildren<InteractionCollider>();
        dialogManager = FindObjectOfType<DialogManager>();
    }

    void FixedUpdate()
    {
        if (dialogManager.isActive)
            return;

        var movementVector = Time.deltaTime * speed * moveAction.ReadValue<Vector2>().normalized;
        if (movementVector.magnitude > 0)
        {
            rigidbody2d.MovePosition(transform.position + (Vector3)movementVector);
            colliderController.FacingAngle = Vector2.SignedAngle(transform.right, movementVector);
        }
    }

    void OnUse(InputAction.CallbackContext context)
    {
        if (dialogManager.isActive)
            return;

        var collidedGameObjects = interactionCollider.collidedGameObjects;
        foreach (var gameObject in collidedGameObjects)
        {
            if (gameObject.TryGetComponent<UsageTrigger>(out var usageTrigger))
            {
                usageTrigger.Use();
            }
        }
    }

    void OnTalk(InputAction.CallbackContext callbackContext)
    {
        if (!dialogManager.isActive)
        {
            var collidedGameObjects = interactionCollider.collidedGameObjects;
            foreach (var gameObject in collidedGameObjects)
            {
                if (gameObject.TryGetComponent<DialogTrigger>(out var dialogTrigger))
                {
                    dialogManager.OpenDialog(dialogTrigger.messages, dialogTrigger.actors);
                }
            }
        }
        else
        {
            dialogManager.NextMessage();
        }
    }

}
