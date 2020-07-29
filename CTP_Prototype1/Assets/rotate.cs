using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public static int cameraSpeed = 2;
    GameObject player;
    public Transform startPosition;
 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Animator>().GetBool("MusicIsPlaying") == true)
        {
            transform.Rotate(0, (cameraSpeed * (Dance.bpm / 10)) * Time.deltaTime, 0);
        }
        else
        {
            //   if (transform.rotation != startPosition.rotation)
            //   {
            //       transform.eulerAngles = new Vector3( 0.0f,
            //Mathf.LerpAngle(transform.rotation.y, 0, Time.deltaTime), 0.0f);
            //   }


            //transform.position = startPosition.position;
            //transform.eulerAngles = new Vector3(startPosition.rotation.x, startPosition.rotation.y, startPosition.rotation.z);

            //transform.rotation(rotation);
        }
    }
}
