using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RhythmTool;

public class AnalyzeExample : MonoBehaviour
{
    public RhythmAnalyzer analyzer;


    public RhythmData rhythmData;

    void Start()
    {
        //Start analyzing a song.
        //rhythmData = analyzer.Analyze(audioClip);

        //Find a track with Beats.
        Track<Beat> track = rhythmData.GetTrack<Beat>();
    }
}