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
        GenrePicker.SetActive(true);
        GameObject player = GameObject.Find("Player");
        Animator animator = player.GetComponent<Animator>();
        if(SetGenre.isSet)
        {
            
            //animator.SetInteger("BPM", 0);
            AudioSource source = player.GetComponent<AudioSource>();
            source.clip = theSong;
            DanceMoves.time = 0f;
            source.Play();
            int bpm = UniBpmAnalyzer.AnalyzeBpm(source.clip);
            animator.SetInteger("BPM", bpm);
            animator.speed = bpm / 2;
            switch (Dance.genre)
            {
                case "Reggae":
                    animator.SetInteger("Genre", (int)Genres.Reggae);
                    Dance.DanceSelect = (int)Random.Range(0f, 7.0f);
                    break;
                case "Hip-Hop":
                    animator.SetInteger("Genre", (int)Genres.HipHop);
                    Dance.DanceSelect = (int)Random.Range(0f, 7.0f);
                    break;
                case "Pop":
                    animator.SetInteger("Genre", (int)Genres.Pop);
                    Dance.DanceSelect = (int)Random.Range(0, 8.0f);
                    break;
                case "RnB":
                    animator.SetInteger("Genre", (int)Genres.RnB);
                    Dance.DanceSelect = (int)Random.Range(0, 7.0f);
                    break;
                case "Techno":
                    animator.SetInteger("Genre", (int)Genres.Techno);
                    Dance.DanceSelect = (int)Random.Range(0, 2.0f);
                    break;
                case "Rock":
                    animator.SetInteger("Genre", (int)Genres.Rock);
                    break;
                case "Disco":
                    animator.SetInteger("Genre", (int)Genres.Disco);
                    break;
                case "Alternative":
                    animator.SetInteger("Genre", (int)Genres.Alternative);
                    break;
            }
        }
    }
}
