using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DanceMoves : MonoBehaviour
{
    public AnimationClip[] animations;
    public static string genre;
    public Animation animation;
    public static float time; // Start is called before the first frame update
    public AudioSource source;
    void Start()
    {
        animation = GetComponent<Animation>();
        animation.clip = animations[10];
        source = GetComponent<AudioSource>();
        //animation.Play();;
    }

    // Update is called once per frame
    void Update()
    {
        animation.Play();
        if(SetGenre.isSet)
        {
            source.Play();
        }
        
        while (GetComponent<AudioSource>().isPlaying)
        {
            time = 3f;

            time -= 0.1f * Time.deltaTime;
            if (time <= 0)
            {
                animation.clip = animations[Random.Range(0, animations.Length)];
                animation.Play();
                time = animation.clip.length;

            }

        }


    }
}
