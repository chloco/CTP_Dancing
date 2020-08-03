using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverRecord : MonoBehaviour
{
    bool hovered;

    Animator anim;
    public AudioClip theSong;
    public GameObject GenrePicker;

    private void OnMouseExit()
    {
        if(hovered)
        {
            hovered = false;
            StartCoroutine("unHover");
        }
    }

    private void OnMouseOver()
    {
        if (!hovered)
        {
            hovered = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hovered = false;
        
        anim = GetComponent<Animator>();
    }

    IEnumerator doHover()
    {
        //anim[0].speed = 1;
        //Debug.Log(this.gameObject.name + "UP");
        //anim.Play(/*this.gameObject.name + "UP"*/);
     
        anim.SetInteger("state", 1);
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
        anim.SetInteger("state", 2);
        //anim[this.gameObject.name + "HOVER"].speed = -1;
        //anim.Play(/*this.gameObject.name + "HOVER"*/);
        yield return new WaitForSeconds(1f);
        anim.SetInteger("state", 0);
    }
    // Update is called once per frame
    void Update()
    {
        if(hovered)
        {
        
            anim.SetInteger("state", 1);     
        }

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if(Physics.Raycast(ray, out hit))
        //{
        //    switch(hit.transform.name)
        //    {
        //        case "Record1":

        //            SetGenre.isSet = false;

        //            GameObject player = GameObject.Find("Player");
        //            AudioSource source = player.GetComponent<AudioSource>();
        //            player.GetComponent<Animator>().SetBool("MusicIsPlaying", false);
        //            player.GetComponent<Animator>().SetFloat("BPM", 0);
        //            source.clip = theSong;
        //            GameObject camera = GameObject.Find("Main Camera");
        //            Dance.currentPos = camera.transform;
        //            Dance.songTime = theSong.length;
        //            Dance.time = 0f;
        //            GenrePicker.SetActive(true);
        //            break;
        //        case "Record2":
        //            break;
        //        case "Record3":
        //            break;
        //        case "Record4":
        //            break;
        //        case "Record5":
        //            break;
        //        case "Record6":
        //            break;
        //        case "Record7":
        //            break;
        //        case "Record8":
        //            break;
        //    }
        //}
       
    }
}
