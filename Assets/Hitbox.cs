using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Collider2D currentHitbox; // Assign the initial hitbox in the inspector
    public Collider2D crawlCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHitbox(GameObject newHitbox)
    {
        if (currentHitbox != null)
        {
            currentHitbox.enabled = false; // Disable the current hitbox
        }

        currentHitbox = newHitbox.GetComponent<Collider2D>();
        if (currentHitbox != null)
        {
            currentHitbox.enabled = true; // Enable the new hitbox
        }
    }
}
