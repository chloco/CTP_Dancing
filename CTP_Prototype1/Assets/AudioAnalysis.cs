﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalysis : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource.time >= 128f && audioSource.time < 129f)
        {
            float[] curSpectrum = new float[1024];
            audioSource.GetSpectrumData(curSpectrum, 0, FFTWindow.BlackmanHarris);

            float targetFrequency = 234f;
            float hertzPerBin = (float)AudioSettings.outputSampleRate / 2f / 1024;
            int targetIndex = targetFrequency / hertzPerBin;

            string outString = "";
            for (int i = targetIndex - 3; i <= targetIndex + 3; i++)
            {
                outString += string.Format("| Bin {0} : {1}Hz : {2} |   ", i, i * hertzPerBin, curSpectrum[i]);
            }

            Debug.Log(outString);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
