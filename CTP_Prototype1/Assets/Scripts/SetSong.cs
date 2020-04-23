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
        
        GameObject player = GameObject.Find("Player");
        AudioSource source = player.GetComponent<AudioSource>();
        player.GetComponent<Animator>().SetBool("MusicIsPlaying", false);
        player.GetComponent<Animator>().SetFloat("BPM", 0);
        source.clip = theSong;
        Dance.time = 0f;
        GenrePicker.SetActive(true);
    }
}
