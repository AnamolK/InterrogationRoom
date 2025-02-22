using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOverBehavior : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown() {
        Debug.Log("ITEM CLICKED");
    }

    void OnMouseOver() {
        spriteRenderer.enabled = true;
        
    }

    void OnMouseExit() {
        spriteRenderer.enabled = false;
    }
}
