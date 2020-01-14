using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSong : MonoBehaviour
{

    // Start is called before the first frame update

    private void Start()
    {
        
    }
    public void setSong(AudioClip theSong)
    {
        GameObject player = GameObject.Find("Player");
        //Animator animator = player.GetComponent<Animator>();
        //animator.SetInteger("BPM", 0);
        AudioSource source = player.GetComponent<AudioSource>();
        source.clip = theSong;
        DanceMoves.time = 0f;
        source.Play();
        int bpm = UniBpmAnalyzer.AnalyzeBpm(source.clip);
        Debug.Log("BPM is " + bpm);
        //animator.SetInteger("BPM", bpm);
    }

}
