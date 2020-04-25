using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = player.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if(anim.GetBool("MusicIsPlaying"))
        {
            if (Physics.Raycast(ray, out hitInfo))
          {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            if (hitInfo.collider.tag == "BackwardWall")
            {
                anim.SetInteger("DirectionFacing", 2);
            }
            if (hitInfo.collider.tag == "FrontWall")
            {
                anim.SetInteger("DirectionFacing", 0);
            }
            if (hitInfo.collider.tag == "LeftWall")
            {
                anim.SetInteger("DirectionFacing", 1);
            }
            if (hitInfo.collider.tag == "RightWall")
            {
                anim.SetInteger("DirectionFacing", 3);
            }
        }
              else
             {
              Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.green);
             }
        }
        

    }
}
