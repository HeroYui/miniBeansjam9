using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;

    public InputActionAsset playerInputAction;

    private InputAction moveAction;

    private Rigidbody2D rigidbody2d;

    private ColliderController colliderController;

    private InteractionCollider interactionCollider;

    void OnEnable()
    {
        var playerActionMap = playerInputAction.FindActionMap("Player");
        playerActionMap.Enable();
        playerActionMap.FindAction("Interact").performed += OnInteract;
    }

    void OnDisable()
    {
        var playerActionMap = playerInputAction.FindActionMap("Player");
        playerActionMap.Disable();
        playerActionMap.FindAction("Interact").performed -= OnInteract;
    }

    void Awake()
    {
        moveAction = playerInputAction.FindActionMap("Player").FindAction("Move");
        rigidbody2d = GetComponent<Rigidbody2D>();
        colliderController = GetComponentInChildren<ColliderController>();
        interactionCollider = GetComponentInChildren<InteractionCollider>();
    }

    void FixedUpdate()
    {
        var movementVector = Time.deltaTime * speed * moveAction.ReadValue<Vector2>().normalized;
        if (movementVector.magnitude > 0)
        {
            rigidbody2d.MovePosition(transform.position + (Vector3)movementVector);
            colliderController.FacingAngle = Vector2.SignedAngle(transform.right, movementVector);
        }
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        var collidedGameObjects = interactionCollider.collidedGameObjects;
        foreach (var gameObject in collidedGameObjects)
        {
            gameObject.GetComponent<Interactable>().Interact();
        }
    }

}
