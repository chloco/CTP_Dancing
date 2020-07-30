using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverRecord : MonoBehaviour
{
    bool hovered;

    float hoverHeight;
    float idleHeight;
    Animator anim;
    private void OnMouseOver()
    {
        if(!hovered)
        {
            hovered = true;
            StartCoroutine("doHover");
        }
    }
    private void OnMouseExit()
    {
        if(hovered)
        {
            hovered = false;
            StartCoroutine("unHover");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hovered = false;
        hoverHeight = this.transform.position.y + 10;
        idleHeight = this.transform.position.y;
        anim = GetComponent<Animator>();
    }

    IEnumerator doHover()
    {
        //anim[0].speed = 1;
        //Debug.Log(this.gameObject.name + "UP");
        //anim.Play(/*this.gameObject.name + "UP"*/);
        anim.SetInteger("1", 1);
        yield return new WaitForSeconds(0.1f);
        //yield return new WaitForSeconds(0.1f);
        //if (this.transform.position.y <= hoverHeight)
        //{
        //    this.transform.Translate((new Vector3(5,0,0) * Time.deltaTime * 10));   
        //}

        
    }

    IEnumerator unHover()
    {
        //yield return new WaitForSeconds(0.1f);
        //if (this.transform.position.y >= idleHeight)
        //{
        //    this.transform.Translate(new Vector3(-5,0,0) * Time.deltaTime * 10);
        //}
        //anim[this.gameObject.name + "HOVER"].speed = -1;
        anim.Play(/*this.gameObject.name + "HOVER"*/);
        yield return new WaitForSeconds(0.2f);
    }
    // Update is called once per frame
    void Update()
    {
       
       
    }
}
