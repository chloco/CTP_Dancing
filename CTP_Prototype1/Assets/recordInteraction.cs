using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recordInteraction : MonoBehaviour
{
    bool hovered;

    private void OnMouseExit()
    {
        if (hovered)
        {
            hovered = false;
            StartCoroutine("unHover");
        }
        Debug.Log("on");
    }

    private void OnMouseOver()
    {
        if (!hovered)
        {
            hovered = true;
        }
        Debug.Log("off");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
