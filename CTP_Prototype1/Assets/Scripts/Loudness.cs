using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loudness : MonoBehaviour
{
    public GameObject player;
     AudioSource audioSource;
    float updateStep = 4f;
    int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;
    Animator anim;
    private float currWeight;
    private float clipLoudness;
    private float[] clipSampleData;
    float smoothTime = 1f;
    //private float yVelocity = 0.0F;
    private float weightValue;
    private float multiplyValue;
    bool lerp = true;


    private void Start()
    {
        audioSource = player.GetComponent<AudioSource>();
        anim = player.GetComponent<Animator>();
        weightValue = anim.GetLayerWeight(1);
        lerp = true;
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

        if (Dance.isPlaying)
        {

            if (weightValue == multiplyValue)
            {
                lerp = true;
            }

            if (lerp)
            {   
                
                audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
                clipLoudness = 0f;
                multiplyValue = 0f;
                foreach (var sample in clipSampleData)
                {
                    clipLoudness += Mathf.Abs(sample);
                }
                clipLoudness /= sampleDataLength;

                multiplyValue = clipLoudness * 5;
                //StartCoroutine(Dolerp());
                   
            }


            //if (weightValue > 1) weightValue = 1;
            //if (weightValue < 0) weightValue = 0;
            StartCoroutine(Dolerp());
            
        }
        Debug.Log(multiplyValue);
    }
   
    IEnumerator Dolerp()
    {
        weightValue = Mathf.Lerp(weightValue, multiplyValue, smoothTime * Time.deltaTime);
        anim.SetLayerWeight(anim.GetLayerIndex("Dance"), weightValue);       
       yield return new WaitForSeconds(5f);
        //lerp = false; 
    }
}

