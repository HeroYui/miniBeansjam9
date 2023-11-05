using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ThiefController : MonoBehaviour
{
    public float speed = 1.0f;

    public float inspectTime = 10.0f;

    private GameManger gameManager;

    private Rigidbody2D rigidbody2d;

    private InteractionColliderController interactionColliderController;

    private InteractionCollider interactionCollider;

    private List<Vector3> path;

    private int currentTargetPosIndex = 0;

    private bool isTurning = false;

    private bool isInspecting = false;

    IEnumerator Turn()
    {
        isTurning = true;
        var nextTarget = path[currentTargetPosIndex];
        var tpf = transform.position;
        var nextMovementDir = nextTarget - tpf;
        interactionColliderController.FacingAngle = Vector2.SignedAngle(transform.right, nextMovementDir);
        yield return new WaitForSeconds(.2f);
        isTurning = false;
    }

    IEnumerator Inspect(GameObject otherGameObject)
    {
        isInspecting = true;

        // entferne Tag, damit wir nicht nochmal kollidieren
        var originalGameObjectTag = otherGameObject.tag;
        otherGameObject.tag = otherGameObject.CompareTag("MiaAndThief") ? "Mia" : "Untagged";
        
        // TODO aus dem collider rausholen, wo sich das game object befindet und dann da hindrehen -> oriiginales heading speichern
        Debug.Log("Inspecting Time!");
        yield return new WaitForSeconds(inspectTime);
        // TODO zurückdrehen
        isInspecting = false;

        // Tag wieder dazumachen, damit wir später nochmal damit kollidieren
        yield return new WaitForSeconds(10.0f);
        otherGameObject.tag = originalGameObjectTag;
    }

    void Awake()
    {
        gameManager = FindObjectOfType<GameManger>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        interactionColliderController = GetComponentInChildren<InteractionColliderController>();
        interactionCollider = GetComponentInChildren<InteractionCollider>();

        path = new List<Vector3>();
        var lineRenderer = GetComponentInChildren<LineRenderer>();
        Vector3[] vector3 = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(vector3);
        foreach (var pathPoint in vector3)
        {
            path.Add(pathPoint);
        }
    }

    void FixedUpdate()
    {
        var collidedGameObjects = interactionCollider.collidedGameObjects;
        if (collidedGameObjects.Any(c => c.CompareTag("Player")))
        {
            Debug.Log("Collided with player.");
        }

        if (isTurning || isInspecting || gameManager.IsConversationInProgress)
        {
            return;
        }

        var coll = collidedGameObjects.FirstOrDefault(c => c.CompareTag("Thief") || c.CompareTag("MiaAndThief"));
        if (coll != null)
        {
            StartCoroutine(Inspect(coll));
        }

        var step = speed * Time.deltaTime;
        var tpf = transform.position;
        var nextTarget = path[currentTargetPosIndex];

        // FIXME warum bremsen wir vor kurven?
        rigidbody2d.MovePosition(Vector3.MoveTowards(tpf, nextTarget, step));
        if (Vector2.Distance(nextTarget, tpf) < 0.1f)
        {
            currentTargetPosIndex = path.Count - 1 > currentTargetPosIndex ? currentTargetPosIndex + 1 : 0;
            StartCoroutine(Turn());
        }
    }
}
