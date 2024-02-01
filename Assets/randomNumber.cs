using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class randomNumber : MonoBehaviour
{
    private int minVal = 1;
    private int maxVal = 3;
    private int selectedNo;//coms number
    private int PlayerNumb;
    private bool Cancheck ;
    private bool CanLoad = false ;
    public TMP_Text question;
    public TMP_InputField inputtedText;
    public AudioSource click;
    public buttonFlash Button;
    private bool test;
    public bool Canpress =  true;
     
    public void GetIntFromInput()
    {
        string Input = inputtedText.text ;
        PlayerNumb = int.Parse(Input);
        Debug.Log(PlayerNumb);

    }
    public void OnButtonPress()
    {
        if (Canpress == true)//prevents the player from pressing the button in quick seccesion
        {
            click.Play();
            Cancheck = true;
            CanLoad = true;
            //Button.CanflashRed = true;//debug
          // test = Button.CanflashRed;//debug
                                      //Debug.Log (test);
        }
    }   
    private void Start()
    {
        Button = GameObject.Find("Button").GetComponent<buttonFlash>();//finds flas script
       //Debug.Log (Button);
        Button.GetComponent<buttonFlash>();

    }
    void Awake()
    {
        selectedNo = Random.Range(minVal, maxVal);
        //Debug.Log(selectedNo);
        question.SetText("Pick a number between " + minVal + " and " + (maxVal-1)); //(maxVal-1) as i believe random range is non inclusive of max number
        
    }
    void Update()
    {
        if ((PlayerNumb == selectedNo) && Cancheck == true)//match flash green
        {
            Cancheck = false;
            Button.CanflashRed = true;//starts flash in buttonFlash script
            
            //Debug.Log(selectedNo);
            if (!click.isPlaying && CanLoad)
            {

              maxVal += maxVal + 1;
              selectedNo = Random.Range(minVal, maxVal);
              question.SetText("Pick a number between " + minVal + " and " + (maxVal - 1)); //(maxVal-1) as i believe random ran
            }
        }
        else if ((PlayerNumb! == selectedNo) && Cancheck == true)// no match flash red
        {
            Cancheck = false;
            Button.CanflashRed = true;//starts redflash in buttonFlash script
            //buttonflash loop
            if (!click.isPlaying && CanLoad)
            {
                SceneManager.LoadScene("currentscene");//change to scene

            }
        }
    }
}
