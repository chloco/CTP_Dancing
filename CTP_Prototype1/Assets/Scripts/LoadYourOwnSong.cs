using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LoadYourOwnSong : MonoBehaviour
{
    string path;
    string extension;
    string songName;
    AudioSource song;
    public GameObject genrepicker;
    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();
        genrepicker = GameObject.FindGameObjectWithTag("genrepicker");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FileSelect()
    {
        path = EditorUtility.OpenFilePanel("Select a Song!", "", "wav");

        print(path);

        //Take the end of the the path and sasve it to another string
        extension = path.Substring(path.IndexOf('.') + 1);

        print(extension);
        LoadSong();
        print("Song Name: " + songName);
        //Check if the user has select the correct file
        //if (extension == "mp3" || extension == "wav" || extension == "ogg")
        //{
        //    //if correct file process file
        //    print("You have selected the correct file type congrats");

        //    LoadSong();
        //    print("Song Name: " + songName);
        //}
        ////if the user selects the wrong file type
        //else
        //{
        //    //pop up box that tells the user that they have selected the wrong file
        //    EditorUtility.DisplayDialog("Error", "Incorrect File Type Please select another", "Ok");
        //    ////Open windows Exploer 
        //    path = EditorUtility.OpenFilePanel("Select a Song", "", "");
        //}
    }

    void LoadSong()
    {
        StartCoroutine(LoadSongCoroutine());
    }

    IEnumerator LoadSongCoroutine()
    {
        WWW www = new WWW("file://" + path);
        yield return www;
        //nameName = 
        //string url = string.Format("file:///" + path);
        //WWW www = new WWW(url);
        //yield return www;

        GameObject player = GameObject.Find("Player");
        //Animator animator = player.GetComponent<Animator>();

        //animator.SetInteger("BPM", 0);
       
        song.clip = www.GetAudioClip(false,false, AudioType.WAV);
        songName = song.clip.name;
        int bpm = UniBpmAnalyzer.AnalyzeBpm(song.clip);
        Debug.Log("BPM is " + bpm);
        //animator.SetInteger("BPM", bpm);
        genrepicker.SetActive(true);
        if(genrepicker.GetComponent<SetGenre>().isSet)
        {
            song.Play();
        }
       
       
    }
}
