using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;



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

    //Score Variables
    private int score = 0; //Player's score
    private int scoreGain = 1; //How much score is gained per correct guess
    public TMP_Text scoreUI;

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
            //click.Play(); temp commented out as it being null broke everything! needs to be uncommented when we have sounds.
            Cancheck = true;
            CanLoad = true;
            //Button.CanflashRed = true;//debug
            // test = Button.CanflashRed;//debug
            Debug.Log(inputtedText.text);
            //Check for win!
            //If player guess == computer's number...
            string strSelectedNo = selectedNo.ToString(); //Converts to string as we cant compare int and string
            if (inputtedText.text == strSelectedNo)
            {
                maxVal += 1;
                selectedNo = Random.Range(minVal, maxVal);
                question.SetText("Pick a number between " + minVal + " and " + (maxVal - 1));
                //Increase score, increment score gain and update UI text
                score += scoreGain; 
                scoreGain++;
                scoreUI.SetText("Score: " + score);
            }
            else
            {
                SceneManager.LoadScene("menu");
            }
        }
    }   
    private void Start()
    {
        Button = GameObject.Find("Button").GetComponent<buttonFlash>();//finds flas script
       //Debug.Log (Button);
        Button.GetComponent<buttonFlash>();
        selectedNo = Random.Range(minVal, maxVal);

    }
    void Awake()
    {
        selectedNo = Random.Range(minVal, maxVal);
        //Debug.Log(selectedNo);
        question.SetText("Pick a number between " + minVal + " and " + (maxVal-1)); //(maxVal-1) as i believe random range is non inclusive of max number
        scoreUI.SetText("Score: " + score);
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
