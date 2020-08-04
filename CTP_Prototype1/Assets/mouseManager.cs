using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo; 

        if(Physics.Raycast(ray, out hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch(hitInfo.collider.name)
                {
                    case "Record1":


                        break;
                    case "Record2":
                        break;
                    case "Record3":
                        break;
                    case "Record4":
                        break;
                    case "Record5":
                        break;
                    case "Record6":
                        break;
                    case "Record7":
                        break;
                    case "Record8":
                        break;
                }
            }
                Debug.Log("Mouse is over: " + hitInfo.collider.name);
            GameObject hitObject = hitInfo.transform.root.gameObject;

            

        }
    }
}
