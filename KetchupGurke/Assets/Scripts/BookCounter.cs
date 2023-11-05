using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookCounter : MonoBehaviour
{
    
    private TMP_Text bookCounter;

    void Awake()
    {
        bookCounter = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateBookCounter(int newBookCounter)
    {
        bookCounter.text = string.Format("{0}",newBookCounter);
    }

}
