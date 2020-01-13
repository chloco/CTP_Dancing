using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGenre : MonoBehaviour
{
    public Text dropdownMenu;
    public GameObject genrepicker;
    public static bool isSet = false;
    // Start is called before the first frame update
    void Start()
    {
        //dropdownMenu = GameObject.FindGameObjectWithTag("Dropdown").GetComponent<Text>();
        //genrepicker = GameObject.FindGameObjectWithTag("genrepicker");
    }

    // Update is called once per frame
  public void selectGenre()
    {
        DanceMoves.genre= dropdownMenu.text;
        genrepicker.SetActive(false);
        isSet = true;

    }
}
