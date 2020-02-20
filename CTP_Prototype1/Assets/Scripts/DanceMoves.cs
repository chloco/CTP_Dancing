﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DanceMoves : MonoBehaviour
{
    public AnimationClip[] animations;
    public static string genre;
    public Animation animation;
    public static float time = 3f; // Start is called before the first frame update
    public AudioSource source;
    public AnimatorOverrideController animationsOverride;
    void Start()
    {
        time = 0.5f;
        animation = GetComponent<Animation>();
        animation.clip = animations[10];
        source = GetComponent<AudioSource>();
        animation.Play();
        Animator animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(SetGenre.isSet)
        //{
        //    source.Play();
        //}
        animation.Play();
  
        
        if (GetComponent<AudioSource>().isPlaying)
        {
            time -= Time.fixedDeltaTime;
            if (time <= 0)
            {
                animation.clip = animations[Random.Range(0, animations.Length - 1)];
                animation.Play(); 
                time = animation.clip.length;
            }
        }
    }
}

