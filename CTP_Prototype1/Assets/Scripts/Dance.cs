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
    public GameObject foot;
    public GameObject player;
    int bpm;
    public static bool isPlaying = false;

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
            //anim.SetInteger("Genre", 1);

        }
        else
        {


            if (SetGenre.isSet)
            {
                //animator.SetInteger("BPM", 0);
                Debug.Log("PLAY THE SONGS DUDE");
                source.Play();
                bpm = UniBpmAnalyzer.AnalyzeBpm(source.clip);
                //anim.SetLayerWeight(anim.GetLayerIndex("Dance"), 0.3f);
                anim.SetFloat("BPM", bpm / 2);
                //anim.speed = bpm / 2;
                SetGenre.isSet = false;
                //time = 0.5f;
            }

            if (Dance.isPlaying)
            {
                anim.SetBool("MusicIsPlaying", true);

                time -= Time.fixedDeltaTime;
                //Debug.Log(time);
                if (time <= 0)
                {
                    while (DanceSelect == currentDance)
                    {
                        switch (Dance.genre)
                        {
                            case "Reggae":
                                anim.SetInteger("Genre", (int)Genres.Reggae);
                                Dance.DanceSelect = (int)Random.Range(0f, 11.0f);
                                break;
                            case "Hip-Hop":
                                anim.SetInteger("Genre", (int)Genres.HipHop);
                                Dance.DanceSelect = (int)Random.Range(0f, 20.0f);
                                break;
                            case "Pop":
                                anim.SetInteger("Genre", (int)Genres.Pop);
                                Dance.DanceSelect = (int)Random.Range(0f, 15.0f);
                                break;
                            case "RnB":
                                anim.SetInteger("Genre", (int)Genres.RnB);
                                Dance.DanceSelect = (int)Random.Range(0f, 15.0f);
                                break;
                            case "Techno":
                                anim.SetInteger("Genre", (int)Genres.Techno);
                                Dance.DanceSelect = (int)Random.Range(0f, 13.0f);
                                break;
                            case "Rock":
                                anim.SetInteger("Genre", (int)Genres.Rock);
                                Dance.DanceSelect = (int)Random.Range(0f, 11.0f);
                                anim.SetFloat("BPM", bpm);
                                break;
                            case "Disco":
                                anim.SetInteger("Genre", (int)Genres.Disco);
                                Dance.DanceSelect = (int)Random.Range(0f, 5.0f);
                                anim.SetFloat("BPM", bpm);
                                break;
                            case "Alternative":
                                anim.SetInteger("Genre", (int)Genres.Alternative);
                                Dance.DanceSelect = (int)Random.Range(0f, 5.0f);
                                break;
                            case "Rap":
                                anim.SetInteger("Genre", (int)Genres.Rap);
                                Dance.DanceSelect = (int)Random.Range(0f, 15.0f);
                                //anim.SetFloat("BPM", bpm);
                                break;
                            case "80sPop":
                                anim.SetInteger("Genre", (int)Genres.EightiesPop);
                                Dance.DanceSelect = (int)Random.Range(0f, 1.0f);
                                break;
                        }
                    }

                    //time = 5;
                    anim.SetInteger("DanceSelection", DanceSelect);
                    currentDance = DanceSelect;
                    time = anim.GetCurrentAnimatorStateInfo(1).length;
                    //Debug.Log("Change Moves" + DanceSelect);
                    
                }


            }
            else
            {
                anim.SetBool("MusicIsPlaying", false);
                bpm = 0;
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
    Alternative,
    Rap,
    EightiesPop
}