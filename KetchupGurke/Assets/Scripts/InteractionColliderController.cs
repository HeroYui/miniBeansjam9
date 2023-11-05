using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionColliderController : MonoBehaviour
{

    private float _facingAngle;

    public float FacingAngle
    {
        get => _facingAngle;
        set
        {
            _facingAngle = value;
            ApplyFacingAngle();
        }
    }

    private void ApplyFacingAngle()
    {
        transform.rotation = Quaternion.AngleAxis(_facingAngle, Vector3.forward);
    }

}