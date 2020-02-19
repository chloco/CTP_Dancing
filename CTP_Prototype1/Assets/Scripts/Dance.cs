using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{
    float time;
    Animator anim;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.5f;
        anim = GetComponent<Animator>();
       source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            anim.SetBool("MusicIsPlaying", true);


            time -= Time.fixedDeltaTime;
            if (time <= 0)
            {
                time = anim.GetCurrentAnimatorStateInfo(1).length;
            }
        }
        else
        {
            anim.SetBool("MusicIsPlaying", false);
        }
    }

}
