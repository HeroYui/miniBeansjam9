using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ThiefController : MonoBehaviour
{
    public float speed = 1.0f;

    public float inspectTime = 0.5f;

    private InteractionColliderController interactionColliderController;

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

    IEnumerator Inspect(Collider2D collider2D)
    {
        isInspecting = true;
        // TODO aus dem collider rausholen, wo sich das game object befindet und dann da hindrehen -> oriiginales heading speichern
        yield return new WaitForSeconds(inspectTime);
        // TODO zurückdrehen
        isInspecting = false;
    }

    void Awake()
    {
        interactionColliderController = GetComponentInChildren<InteractionColliderController>();
        path = new List<Vector3>();
        var lineRenderer = GetComponentInChildren<LineRenderer>();
        Vector3[] vector3 = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(vector3);
        foreach (var pathPoint in vector3)
        {
            path.Add(pathPoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurning || isInspecting)
        {
            return;
        }
        var step = speed * Time.deltaTime;
        var tpf = transform.position;
        var nextTarget = path[currentTargetPosIndex];

        transform.position = Vector3.MoveTowards(tpf, nextTarget, step);
        if (Vector3.Distance(nextTarget, tpf) < 0.1f)
        {
            currentTargetPosIndex = path.Count - 1 > currentTargetPosIndex ? currentTargetPosIndex + 1 : 0;
            StartCoroutine(Turn());
        }
    }
}
