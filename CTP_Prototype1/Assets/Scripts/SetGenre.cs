﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGenre : MonoBehaviour
{
    public Text dropdownMenu;
    public GameObject genrepicker;
    public static bool isSet;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isSet = false;
        //dropdownMenu = GameObject.FindGameObjectWithTag("Dropdown").GetComponent<Text>();
        //genrepicker = GameObject.FindGameObjectWithTag("genrepicker");

    }

    // Update is called once per frame
  public void selectGenre()
    {
        animator = GetComponent<Animator>();
        Dance.genre = dropdownMenu.text;
        genrepicker.SetActive(false);
        isSet = true;
        Dance.isPlaying = true;
        Debug.Log(Dance.songTime);
        Dance.timerIsActive = true;
        Debug.Log(Dance.genre);
        
    }
}
