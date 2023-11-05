using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject objectToDisable;

    void Start()
    {
        objectToDisable.SetActive(false);
    }

}
