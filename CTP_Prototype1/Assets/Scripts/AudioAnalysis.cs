﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalysis : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip targetBPM;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        targetBPM = audioSource.clip;
        //animator.SetInteger("BPM", 0);
        //int bpm = UniBpmAnalyzer.AnalyzeBpm(targetBPM);
        //Debug.Log("BPM is " + bpm);
        //animator.SetInteger("BPM", bpm);
        animator.SetBool("MusicIsPlaying", false);
    }

    void Update()
    {
            float[] curSpectrum = new float[1024];
            audioSource.GetSpectrumData(curSpectrum, 0, FFTWindow.BlackmanHarris);

            float targetFrequency = 234f;
            float hertzPerBin = (float)AudioSettings.outputSampleRate / 2f / 1024;
            int targetIndex = (int)(targetFrequency / hertzPerBin);

            string outString = "";
            for (int i = targetIndex - 3; i <= targetIndex + 3; i++)
            {
            outString += string.Format("| Bin {0} : {1}Hz : {2} |   ", i, i * hertzPerBin, curSpectrum[i]);
        }

        //Debug.Log(outString);

    }
}
