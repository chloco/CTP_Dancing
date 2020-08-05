using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseManager : MonoBehaviour
{
    GameObject player;
    AudioSource source;
    public GameObject GenrePicker;
    public AudioClip[] songs;
    // Start is called before the  frame update
    void Start()
    {
        player = GameObject.Find("Player");
        source = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo; 

        if(Physics.Raycast(ray, out hitInfo))
        { 
            if(hitInfo.collider.name.Contains("Record"))
            {
                if (Input.GetMouseButtonDown(0))
            {
                    HoverRecord.selected = true;
                    SetGenre.isSet = false;
                    Dance.danceCamera = false;
                    Dance.isPlaying = false;
                    player.GetComponent<Animator>().SetBool("MusicIsPlaying", false);
                    player.GetComponent<Animator>().SetBool("idle", true);
                    //player.GetComponent<Animator>().SetFloat("BPM", 0);
                    player.GetComponent<Animator>().speed = 1;
                    
                    
                    //GameObject camera = GameObject.Find("Main Camera");
                    //Dance.currentPos = camera.transform
                    Dance.time = 0f;
                    GenrePicker.SetActive(true);
                    switch (hitInfo.collider.name)
                {
                    case "Record1":
                        //hitInfo.collider.GetComponent<HoverRecord>
                        source.clip = songs[0];
                        Dance.songTime = source.clip.length;
                        Debug.Log("hit1");
                        break;
                    case "Record2":
                        source.clip = songs[1];
                        Dance.songTime = source.clip.length;
                            break;
                    case "Record3":
                        source.clip = songs[2];
                            Dance.songTime = source.clip.length;
                            break;
                    case "Record4":
                        source.clip = songs[3];
                            Dance.songTime = source.clip.length;
                            break;
                    case "Record5":
                        source.clip = songs[4];
                            Dance.songTime = source.clip.length;
                            break;
                    case "Record6":
                        source.clip = songs[5];
                        break;
                    case "Record7":
                        source.clip = songs[6];
                        break;
                    case "Record8":
                        source.clip = songs[7];
                        break;
                }
                
                //Dance.songTime = source.clip.length;
                Debug.Log("hit2");


            }
            }
            
                //Debug.Log("Mouse is over: " + hitInfo.collider.name);
            GameObject hitObject = hitInfo.transform.root.gameObject;

            

        }
    }
}
