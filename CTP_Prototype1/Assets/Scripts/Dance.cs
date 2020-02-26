using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    public static string genre;
    public static float time;
    Animator anim;
    AudioSource source;
    public static int DanceSelect;
    int currentDance;
    public GameObject bodyPart;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.5f;
        anim = GetComponent<Animator>();
       source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetBool("TEST"))
        {


        }
        else
        {


            if (SetGenre.isSet)
            {
                //animator.SetInteger("BPM", 0);
                Debug.Log("PLAY THE SONGS DUDE");
                source.Play();
                int bpm = UniBpmAnalyzer.AnalyzeBpm(source.clip);
                anim.SetFloat("BPM", bpm / 2);
                //anim.speed = bpm / 2;
                SetGenre.isSet = false;
                time = 0;
            }

            if (GetComponent<AudioSource>().isPlaying)
            {
                anim.SetBool("MusicIsPlaying", true);

                time -= Time.fixedDeltaTime;
                Debug.Log(time);
                if (time <= 0)
                {
                    while (DanceSelect == currentDance)
                    {
                        switch (Dance.genre)
                        {
                            case "Reggae":
                                anim.SetInteger("Genre", (int)Genres.Reggae);
                                Dance.DanceSelect = (int)Random.Range(1f, 7.0f);
                                break;
                            case "Hip-Hop":
                                anim.SetInteger("Genre", (int)Genres.HipHop);
                                Dance.DanceSelect = (int)Random.Range(1f, 10.0f);
                                break;
                            case "Pop":
                                anim.SetInteger("Genre", (int)Genres.Pop);
                                Dance.DanceSelect = (int)Random.Range(1f, 9.0f);
                                break;
                            case "RnB":
                                anim.SetInteger("Genre", (int)Genres.RnB);
                                Dance.DanceSelect = (int)Random.Range(1f, 7.0f);
                                break;
                            case "Techno":
                                anim.SetInteger("Genre", (int)Genres.Techno);
                                Dance.DanceSelect = (int)Random.Range(1f, 2.0f);
                                break;
                            case "Rock":
                                anim.SetInteger("Genre", (int)Genres.Rock);
                                break;
                            case "Disco":
                                anim.SetInteger("Genre", (int)Genres.Disco);
                                break;
                            case "Alternative":
                                anim.SetInteger("Genre", (int)Genres.Alternative);
                                break;
                        }
                    }
                    time = anim.GetCurrentAnimatorStateInfo(0).length;
                    //time = 5;
                    anim.SetInteger("DanceSelection", DanceSelect);
                    currentDance = DanceSelect;
                    //player.transform.position = bodyPart.transform.position;
                }

                Debug.Log(DanceSelect);
            }
            else
            {
                anim.SetBool("MusicIsPlaying", true);
            }
        }
    }
}

public enum Genres
{
    Reggae,
    HipHop,
    Pop,
    RnB,
    Techno,
    Rock,
    Disco,
    Alternative
}