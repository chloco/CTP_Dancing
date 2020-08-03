using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSong : MonoBehaviour
{
    public GameObject GenrePicker;
    // Start is called before the first frame update

    private void Start()
    {
        
    }
    public void setSong(AudioClip theSong)
    {
        SetGenre.isSet = false;
        Dance.danceCamera = false;
        Dance.isPlaying = false;
        GameObject player = GameObject.Find("Player");
        AudioSource source = player.GetComponent<AudioSource>();
        player.GetComponent<Animator>().SetBool("MusicIsPlaying", false);
        player.GetComponent<Animator>().SetBool("idle", true);
        player.GetComponent<Animator>().SetFloat("BPM", 0);
        source.clip = theSong;
        Dance.songTime = source.clip.length;
        //GameObject camera = GameObject.Find("Main Camera");
        //Dance.currentPos = camera.transform
        Dance.time = 0f;
        GenrePicker.SetActive(true);
    }
}
