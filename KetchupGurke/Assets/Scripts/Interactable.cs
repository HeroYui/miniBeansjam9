using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable : MonoBehaviour
{
    public InputActionAsset playerInputAction;

    private Rigidbody2D rigidbody2d;

    private bool canInteract;

    private Collider2D playerCollider;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        var playerActionMap = playerInputAction.FindActionMap("Player");
        playerActionMap.Enable();

        playerActionMap.FindAction("Interact").performed += OnInteract;
    }

    void OnDisable()
    {
        playerInputAction.FindActionMap("Player").Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (canInteract)
        {
            Debug.Log("CanInteract");
            var ptf = playerCollider.transform;
            // FXIME: Wie bekomme ich den aktuellen bewegungsvektor des players?
            // FIXME: alternative - wie kann ich die rotation des players bekommen, damit ich weiß, wo er hinguckt?
            var raycasthit = Physics2D.Raycast(ptf.position, ptf.right);
            if (raycasthit.rigidbody == rigidbody2d)
            {
                Debug.Log("Jo, ich bin ein Stein");
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        canInteract = true;
        playerCollider = collider2D;
    }

    void OnTriggerExit2D()
    {
        canInteract = false;
        playerCollider = null;
    }

}
