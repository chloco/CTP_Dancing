using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public void restart()
    { 
        StartCoroutine(fadeMusic());
        
      
        //AudioSource source = player.GetComponent<AudioSource>();
        
        
        
    }

    IEnumerator fadeMusic()
    {
        Dance.danceCamera = false;
        cameraControl.view = 0;
        SetGenre.isSet = false;
        
        Dance.isPlaying = false;  
        GameObject player = GameObject.Find("Player");
        AudioSource source = player.GetComponent<AudioSource>();
        player.GetComponent<Animator>().SetBool("MusicIsPlaying", false);
        
        player.GetComponent<Animator>().SetBool("idle", true);
        while(source.volume > 0.01f)
        {
            source.volume -= Time.deltaTime / 5.0f;
            yield return null;
        }
        source.Stop();
        source.volume = 1;
    }
}