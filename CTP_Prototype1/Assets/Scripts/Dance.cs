using System.Collections;
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
    public GameObject foot;
    public GameObject player;
    public GameObject hips;
    public static int bpm;
    public static bool isPlaying = false;

    public RhythmAnalyzer analyzer;
    //public Beat;
    RhythmData myRhythmData;
    private float prevTime;

    private List<Beat> beats;
   
    Track<Value> segmentTrack;
    BeatTracker beatTracker;
    bool once;
    Track<Beat> beatTrack;
    public static bool complete = false;

    public RhythmEventProvider eventProvider;

    public RhythmPlayer myRhythmPlayer;

   
    //public void onSegment(Value);


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
        

    void Update()
    {
        if(hips.transform.rotation.y >= 130 && hips.transform.rotation.y <= 270)
        {
            Debug.Log("backward.");
        }




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
                //onSegment(segments.);
                
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
                    anim.SetBool("MusicIsPlaying", false);
                    bpm = 0;
                }
            

            prevTime = timeS;
        }
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