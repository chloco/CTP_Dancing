using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RhythmTool;
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

    public RhythmAnalyzer analyzer;
    public Beat
    public RhythmData rhythmData;
    private float prevTime;
    private List<Beat> beats;

    void Awake()
    {
        beats = new List<Beat>();
    }

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
        float timeS = source.time;

        beats.Clear();

        if (anim.GetBool("TEST"))
        {
            //play test animation

        }
        else
        {
            if (SetGenre.isSet)
            {
             
                Debug.Log("PLAY THE SONGS DUDE");
          
                rhythmData = analyzer.Analyze(source.clip);
                
            }
            if(analyzer.initialized)
            {
                source.Play();
                Track<Beat> track = rhythmData.GetTrack<Beat>();
                //Track<Beat> track = RhythmTool.trackBeat();
                SetGenre.isSet = false;
            }
            rhythmData.GetFeatures<Beat>(beats, prevTime, timeS);

            private void OnBeat(Beat beat)
            {
                bpm = Mathf.Round(beat.bpm * 10) / 10;
            }
            foreach (Beat beat in beats)
            {
              
                bpm = (int)beat.bpm;
                anim.SetFloat("BPM", bpm);
            }

            if (Dance.isPlaying)
            {
                anim.SetBool("MusicIsPlaying", true);

                time -= Time.fixedDeltaTime;
                if(source.clip.name.Contains("Macarena") || source.clip.name.Contains("macarena"))
                {
                    anim.SetInteger("SpecialSongNum", 1);
                }
             
                else if (time <= 0)
                {
                    while (DanceSelect == currentDance)
                    {
                        switch (Dance.genre)
                        {
                            case "Reggae":
                                anim.SetInteger("Genre", (int)Genres.Reggae);
                                Dance.DanceSelect = (int)Random.Range(0f, 16.0f);
                                break;
                            case "Hip-Hop":
                                anim.SetInteger("Genre", (int)Genres.HipHop);
                                Dance.DanceSelect = (int)Random.Range(0f, 33.0f);
                                break;
                            case "Pop":
                                anim.SetInteger("Genre", (int)Genres.Pop);
                                Dance.DanceSelect = (int)Random.Range(0f, 25.0f);
                                break;
                            case "RnB":
                                anim.SetInteger("Genre", (int)Genres.RnB);
                                Dance.DanceSelect = (int)Random.Range(0f, 28.0f);
                                break;
                            case "Techno":
                                anim.SetInteger("Genre", (int)Genres.Techno);
                                Dance.DanceSelect = (int)Random.Range(0f, 24.0f);
                                break;
                            case "Rock":
                                anim.SetInteger("Genre", (int)Genres.Rock);
                                Dance.DanceSelect = (int)Random.Range(0f, 17.0f);
                                anim.SetFloat("BPM", bpm);
                                break;
                            case "Disco":
                                anim.SetInteger("Genre", (int)Genres.Disco);
                                Dance.DanceSelect = (int)Random.Range(0f, 19.0f);
                                anim.SetFloat("BPM", bpm);
                                break;
                            case "Alternative":
                                anim.SetInteger("Genre", (int)Genres.Alternative);
                                Dance.DanceSelect = (int)Random.Range(0f, 22.0f);
                                break;
                            case "Rap":
                                anim.SetInteger("Genre", (int)Genres.Rap);
                                Dance.DanceSelect = (int)Random.Range(0f, 27.0f);
                                //anim.SetFloat("BPM", bpm);
                                break;
                            case "80sPop":
                                anim.SetInteger("Genre", (int)Genres.EightiesPop);
                                Dance.DanceSelect = (int)Random.Range(0f, 9.0f);
                                break;
                        }
                    }

                    //time = 5;
                    anim.SetInteger("DanceSelection", DanceSelect);
                    currentDance = DanceSelect;
                    float temp = anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex("Dance")).length;
                    //anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex("Dance")).normalizedTime = 0.5f;
                    time = Random.Range(0f, temp);

                    Debug.Log("Change Moves" + DanceSelect);
                    Debug.Log(time);

                }


            }
            else
            {
                anim.SetBool("MusicIsPlaying", false);
                bpm = 0;
            }
        }

        prevTime = timeS;
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