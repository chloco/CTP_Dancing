using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mini "engine" for analyzing spectrum data
/// Feel free to get fancy in here for more accurate visualizations!
/// </summary>
public class AudioSpectrum : MonoBehaviour
{
      
    private void Update()
    {
        // get the data
        AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.BlackmanHarris);

        // assign spectrum value
        // this "engine" focuses on the simplicity of other classes only..
        // ..needing to retrieve one value (spectrumValue)
        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0)
        {
            spectrumValue = m_audioSpectrum[0] * 100;
        }
    }

    private void Start()
    {
        /// initialize buffer
        m_audioSpectrum = new float[128];
    }

    // This value served to AudioSyncer for beat extraction
    public static float spectrumValue { get; private set; }

    // Unity fills this up for us
    private float[] m_audioSpectrum;

     

    //float Loudness()
    //{   float nSamples = 1024;
    //    float fMax;
    //    float fLow;
    //    float fHigh;

    //    //fLow = Mathf.Clamp(fLow, 20, fMax); // limit low...
    //    //fHigh = Mathf.Clamp(fHigh, fLow, fMax); // and high frequencies
    //    //var n1: int = Mathf.Floor(fLow * nSamples / fMax);
    //    //var n2: int = Mathf.Floor(fHigh * nSamples / fMax);
    //    //var sum: float = 0;

    //    //for (var i = n1; i < n2; i++)
    //    //{
    //    //    sum += m_audioSpectrum[i];
    //    //}
    //    //return sum / (n2 - n1);
    //}
}
