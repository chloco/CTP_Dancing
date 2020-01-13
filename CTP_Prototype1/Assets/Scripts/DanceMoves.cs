using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DanceMoves : MonoBehaviour
{
    public AnimationClip[] animations;
    public string genre;
    public Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
        animation.clip = animations[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            float time = animation.clip.length;
            
            time = 0.5f * Time.deltaTime;
            if (time == 0)
            {
            animation.clip = animations[Random.Range(0, animations.Length)];
            animation.Play();
                time = animation.clip.length;
            }
        }


    }
}
