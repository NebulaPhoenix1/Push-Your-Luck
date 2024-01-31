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
    public void GetIntFromInput()
       
    {
        string Input = inputtedText.text ;
        PlayerNumb = int.Parse(Input);
        Debug.Log(PlayerNumb);

    }
    /*public void OnButtonPress ()
    //{
        
        click.Play();
        Cancheck = true;
        CanLoad = true;
    }*/
    private void Start()
    {
        

    }
   

    void Awake()
    {
        selectedNo = Random.Range(minVal, maxVal);
        //Debug.Log(selectedNo);
        question.SetText("Pick a number between " + minVal + " and " + (maxVal-1)); //(maxVal-1) as i believe random range is non inclusive of max number

    }
    

    void Update()
    {
        if((PlayerNumb ==selectedNo)&& Cancheck == true)
        {
            Cancheck = false;
          buttonFlash.flash = true;
          selectedNo = Random.Range(minVal, maxVal);
            //Debug.Log(selectedNo);
            question.SetText("Pick a number between " + minVal + " and " + (maxVal - 1)); //(maxVal-1) as i believe random ran
          

        } 
        else
        {
            Cancheck = false;
            //buttonflash loop
            if(!click.isPlaying && CanLoad)
            {
              SceneManager.LoadScene("currentscene");//change to scene

            }
              

        }
    }
   
}
