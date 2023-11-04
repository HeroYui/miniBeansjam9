using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;

    public InputActionAsset playerInputAction;

    private InputAction moveAction;

    private Rigidbody2D rigidbody2d;

    private ColldierController colldierController;

    void OnEnable()
    {
        playerInputAction.FindActionMap("Player").Enable();
    }

    void OnDisable()
    {
        playerInputAction.FindActionMap("Player").Disable();
    }

    void Awake()
    {
        moveAction = playerInputAction.FindActionMap("Player").FindAction("Move");
        rigidbody2d = GetComponent<Rigidbody2D>();
        colldierController = GetComponentInChildren<ColldierController>();
    }

    void FixedUpdate()
    {
        var movementVector = Time.deltaTime * speed * moveAction.ReadValue<Vector2>().normalized;
        if (movementVector.magnitude > 0)
        {
            rigidbody2d.MovePosition(transform.position + (Vector3)movementVector);
            colldierController.FacingAngle = Vector2.SignedAngle(transform.right, movementVector);
        }
    }

}
