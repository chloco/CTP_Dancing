using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGenre : MonoBehaviour
{
    public Text dropdownMenu;
    DanceMoves dancemoves;
    public GameObject genrepicker;
    public bool isSet;
    // Start is called before the first frame update
    void Start()
    {
        dropdownMenu = GameObject.FindGameObjectWithTag("Dropdown").GetComponent<Text>();
        genrepicker = GameObject.FindGameObjectWithTag("genrepicker");
    }

    // Update is called once per frame
  public void selectGenre()
    {
        dancemoves.genre = dropdownMenu.text;
        genrepicker.SetActive(false);
        isSet = true;

    }
}
