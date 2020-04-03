using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loudness : MonoBehaviour
{
    public GameObject player;
     AudioSource audioSource;
    float updateStep = 2f;
    int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;
    Animator anim;
    private float currWeight;
    private float clipLoudness;
    private float[] clipSampleData;
    public float smoothTime;
    private float yVelocity = 0.0F;


    private void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
        anim = player.GetComponent<Animator>();

    }

    // Use this for initialization
    void Awake()
    {

        //if (!audioSource)
        //{
        //    Debug.LogError(GetType() + ".Awake: there was no audioSource set.");
        //}
        clipSampleData = new float[sampleDataLength];

    }

    // Update is called once per frame
    void Update()
    {
        
        currWeight = anim.GetLayerWeight(anim.GetLayerIndex("Dance"));
        Debug.Log(currentUpdateTime);
        if(player.GetComponent<AudioSource>().isPlaying)
        {
            currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
                //float startWeight = Mathf.SmoothDamp(currWeight, clipLoudness * 3, ref yVelocity, smoothTime);
                //anim.SetLayerWeight(anim.GetLayerIndex("Dance"), startWeight);
        }
            
            Debug.Log(clipLoudness * 2);
        }
        

    }
}
