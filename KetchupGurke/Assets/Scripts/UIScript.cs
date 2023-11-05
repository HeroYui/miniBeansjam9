using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject objectToDisable;

    // Start is called before the first frame update
    void Start()
    {
        objectToDisable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
