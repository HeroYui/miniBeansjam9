using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class InteractionCollider : MonoBehaviour
{
    public HashSet<GameObject> collidedGameObjects;


    void Awake()
    {
        collidedGameObjects = new HashSet<GameObject>(10);
    }
    
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        collidedGameObjects.Add(collider2D.gameObject);
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        collidedGameObjects.Remove(collider2D.gameObject);
    }

}
