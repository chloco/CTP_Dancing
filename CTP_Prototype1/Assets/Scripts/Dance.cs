﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RhythmTool;
using System.Linq;
using System;

public class Dance : MonoBehaviour
{
    public static string genre;
    public static float time;
    Animator anim;
    AudioSource source;

    public static int DanceSelect;
    int currentDance;
    public GameObject bodyPart;
    public GameObject mainCamera;
    public GameObject foot;
    public GameObject player;
    public GameObject hips;
    public static int bpm;
    public static bool isPlaying = false;
    Transform lookAt;
    bool first;

    public RhythmAnalyzer analyzer;
    //public Beat;
    RhythmData myRhythmData;
    private float prevTime;

    private List<Beat> beats;

    Track<Value> segmentTrack;
    BeatTracker beatTracker;
    bool once;
    public static bool timerIsActive;
    public static float songTime;
    public static bool reset;
    Track<Beat> beatTrack;
    public static bool complete = false;
    public static Transform startPosition;
    public RhythmEventProvider eventProvider;

    public RhythmPlayer myRhythmPlayer;
    public static Transform currentPos;
    float transitionTime;
    public static bool danceCamera;
    //public void onSegment(Value);
    bool go;


    // Start is called before the first frame update
    void Start()
    {
        time = 0.5f;
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        analyzer = GetComponent<RhythmAnalyzer>();
        //rhythmData = GetComponent<RhythmData>();
        beatTracker = GetComponent<BeatTracker>();
        myRhythmPlayer = GetComponent<RhythmPlayer>();
        //eventProvider = myRhythmPlayer.targets[0];
        //eventProvider.Register<Value>(onSegment);
        startPosition = mainCamera.transform;
   
    }

    private void onSegment(Value segment)
    {
        Debug.Log("A segment occurred at " + segment.timestamp);

    }
    void Awake()
    {
        beats = new List<Beat>();
        eventProvider.Register<Value>(onSegment, "Segments");
    }


    // Update is called once per frame
    public void GetBeats()
    {
        //List<Value> segments = new List<Value>();
        myRhythmPlayer.rhythmData = myRhythmData;
        //segmentTrack = myRhythmData.GetTrack<Value>("Segments");
        ////= rhythmData.GetTrack<Value>("Segments");               
        //segmentTrack.GetFeatures(segments, 0, source.clip.length);


        //bool isEmpty = !segments.Any();
        //      if (isEmpty)
        //      {
        //          Debug.Log("I have nothing!");
        //      }
        //      else
        //      {
        //          Debug.Log("I have stuff!");
        //      }


        beatTrack = myRhythmData.GetTrack<Beat>();
        //Group beats by rounded BPM
        Dictionary<int, List<Beat>> beatsByBPM = new Dictionary<int, List<Beat>>();

        for (int i = 0; i < beatTrack.count; i++)
        {
            Beat beat = beatTrack[i];

            int bpm = Mathf.RoundToInt(beat.bpm);

            if (!beatsByBPM.ContainsKey(bpm))
                beatsByBPM.Add(bpm, new List<Beat>());

            beatsByBPM[bpm].Add(beat);
        }

        //Find group with most beats
        List<Beat> beats = beatsByBPM.Values.First();
        int count = beats.Count;

        foreach (var value in beatsByBPM.Values)
        {
            if (value.Count > count)
            {
                count = value.Count;
                beats = value;
            }
        }

        //Find the average BPM
        float averageBPM = beats.Sum(b => b.bpm) / count;
        float averageBeatLength = 60 / averageBPM;

        //Find the most common offset rounded to x decimals
        Dictionary<float, int> offsetCount = new Dictionary<float, int>();
        int decimals = 3;

        foreach (var beat in beats)
        {
            float offset = (float)Math.Round(beat.timestamp % averageBeatLength, decimals);

            if (offsetCount.ContainsKey(offset))
                offsetCount[offset]++;
            else
                offsetCount.Add(offset, 1);
        }

        int n = 0;
        float bestOffset = 0;

        foreach (var item in offsetCount)
        {
            if (item.Value > n)
            {
                n = item.Value;
                bestOffset = item.Key;
            }
        }

        Debug.Log("Average BPM: " + averageBPM);
        //Debug.Log("Best offset: " + bestOffset);
        bpm = (int)averageBPM;
        anim.SetFloat("BPM", bpm);

        anim.SetBool("MusicIsPlaying", true);
        complete = true;
        beatTrack = null;
    }

    
    IEnumerator swapCam()
    {
        if (danceCamera)
        {

            cameraControl.view = (int)UnityEngine.Random.Range(1f, 5.0f);
            Debug.Log((bpm / 2));
            yield return new WaitForSeconds((bpm / 10) / 3);
            go = false;
        }
    }

    IEnumerator waitForCam()
    {

        if(first)
        {
           cameraControl.view = 1;
            yield return new WaitForSeconds(3f);
            StartCoroutine(swapCam());
        }
        

    }

    public void endSong()
    {
        danceCamera = false;
        anim.SetBool("MusicIsPlaying", false);
        bpm = 0;
        timerIsActive = false;
    }

    void Update()
    {

        //myRhythmPlayer.SongEnded += endSong;

        
       if(songTime <=0)
        {
            songTime = 0;

            danceCamera = false;

            anim.SetBool("MusicIsPlaying", false);
            anim.SetBool("idle", true);
            isPlaying = false;
            cameraControl.view = 0;
        }


        if (hips.transform.rotation.y >= 130 && hips.transform.rotation.y <= 270)
        {
            Debug.Log("backward.");
        }




        float timeS = source.time;

        beats.Clear();

        //myRhythmData.GetFeatures<Beat>(beats, prevTime, time);

        //foreach(Beat beat in beats)
        //{
        //    cameraControl.view = (int)UnityEngine.Random.Range(0f, 3.0f);
        //}
      
        
            if (SetGenre.isSet)
            {   
                complete = false;
                isPlaying = true;
                myRhythmData = null;
                myRhythmData = analyzer.Analyze(source.clip);
                Debug.Log(source.clip.name);
                

                //Debug.Log("PLAY THE SONGS DUDE");
                source.Play();
                SetGenre.isSet = false;

            }
            
            if(analyzer.initialized && !complete)
            {
                GetBeats();
            }

            if (Dance.isPlaying)
            {
                if (danceCamera && !go && !first)
                {
                    first = true;

                    StartCoroutine(waitForCam());
                    go = true;

                }
                else if (danceCamera && !go)
                {
                    go = true;
                    StartCoroutine(waitForCam());
                }
                else if (!danceCamera)
                {
                    cameraControl.view = 0;
                }

                if (songTime > 0)
                {
                    songTime -= Time.deltaTime;
                    Debug.Log(songTime);
                }
                else
                {
                    //currentPos = mainCamera.transform;
                    //lookAt = player.transform;
                    //Quaternion rotation = mainCamera.transform.rotation;
                    //mainCamera.transform.position = Vector3.Lerp(currentPos.position, startPosition.position, Time.deltaTime * 2);
                    //mainCamera.transform.LookAt(lookAt.position);
                    songTime = 0;
                    
                    danceCamera = false;
                    
               
                    isPlaying = false;
                    
                    ///////mainCamera.transform.position
                    ///
                }

                //onSegment(segments.);
                danceCamera = true;
                time -= Time.fixedDeltaTime;
                    if (source.clip.name.Contains("Macarena") || source.clip.name.Contains("macarena"))
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
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 16.0f);
                                anim.SetFloat("BPM", bpm/2);
                                break;
                                case "Hip-Hop":
                                    anim.SetInteger("Genre", (int)Genres.HipHop);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 33.0f);
                                    break;
                                case "Pop":
                                    anim.SetInteger("Genre", (int)Genres.Pop);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 25.0f);
                                    break;
                                case "RnB":
                                    anim.SetInteger("Genre", (int)Genres.RnB);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 28.0f);
                                    break;
                                case "Techno":
                                    anim.SetInteger("Genre", (int)Genres.Techno);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 24.0f);
                                    break;
                                case "Rock":
                                    anim.SetInteger("Genre", (int)Genres.Rock);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 17.0f);
                                    anim.SetFloat("BPM", bpm);
                                    break;
                                case "Disco":
                                    anim.SetInteger("Genre", (int)Genres.Disco);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 19.0f);
                                    anim.SetFloat("BPM", bpm);
                                    break;
                                case "Alternative":
                                    anim.SetInteger("Genre", (int)Genres.Alternative);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 22.0f);
                                    break;
                                case "Rap":
                                    anim.SetInteger("Genre", (int)Genres.Rap);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 27.0f);
                                    //anim.SetFloat("BPM", bpm);
                                    break;
                                case "80sPop":
                                    anim.SetInteger("Genre", (int)Genres.EightiesPop);
                                    Dance.DanceSelect = (int)UnityEngine.Random.Range(0f, 9.0f);
                                    break;
                            }
                        }
                        rotate.cameraSpeed = -rotate.cameraSpeed;
                        //time = 5;
                        anim.SetInteger("DanceSelection", DanceSelect);
                        currentDance = DanceSelect;
                        float temp = anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex("Dance")).length;
                        //anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex("Dance")).normalizedTime = 0.5f;
                        time = UnityEngine.Random.Range(0f, temp);

                        //Debug.Log("Change Moves" + DanceSelect);
                        //Debug.Log(time);
                    }
                    
                }
                else
                {
                if(anim.GetBool("MusicIsPlaying") == true)
                {
                    anim.SetBool("MusicIsPlaying", false);
                    bpm = 0;
                }
                    
                }
            

            prevTime = timeS;
        
        }
}

//public 
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