using System.Collections;
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
    Animator animator;
    void Start()
    {
        time = 0.5f;
        animation = GetComponent<Animation>();
        animation.clip = animations[10];
        source = GetComponent<AudioSource>();
        animation.Play();
        animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(SetGenre.isSet)
        //{
        //    source.Play();
        //}
        animation.Play();
        Debug.Log(SetGenre.isSet);

        if (SetGenre.isSet)
        {
            //animator.SetInteger("BPM", 0);
            Debug.Log("PLAY THE SONGS DUDE");
            source.Play();
            int bpm = UniBpmAnalyzer.AnalyzeBpm(source.clip);
            animator.SetInteger("BPM", bpm);
            animator.speed = bpm / 2;
            switch (Dance.genre)
            {
                case "Reggae":
                    animator.SetInteger("Genre", (int)Genres.Reggae);
                    break;
                case "Hip-Hop":
                    animator.SetInteger("Genre", (int)Genres.HipHop);
                    break;
                case "Pop":
                    animator.SetInteger("Genre", (int)Genres.Pop);
                    break;
                case "RnB":
                    animator.SetInteger("Genre", (int)Genres.RnB);
                    break;
                case "Techno":
                    animator.SetInteger("Genre", (int)Genres.Techno);
                    break;
                case "Rock":
                    animator.SetInteger("Genre", (int)Genres.Rock);
                    break;
                case "Disco":
                    animator.SetInteger("Genre", (int)Genres.Disco);
                    break;
                case "Alternative":
                    animator.SetInteger("Genre", (int)Genres.Alternative);
                    break;
            }
            SetGenre.isSet = false;
        }


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

