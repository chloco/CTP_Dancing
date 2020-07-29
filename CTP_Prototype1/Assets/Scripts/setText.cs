using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class setText : MonoBehaviour
{
    public GameObject recordText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        recordText.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
