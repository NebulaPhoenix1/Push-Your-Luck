using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFlash : MonoBehaviour
{
    public bool flash = false;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.NormalColor;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (flash == true)
        {
            StartCoroutine(Flash);
        }
    }
    private IEnumerator Flash()
    {
        Color normalColor = button.colors.normalColor;
        Color flashColor = Color.green;

        for (int i = 0; i < 5; i++)
        {
            // Flash the button with the new color
            button.image.color = flashColor;
            yield return new WaitForSeconds(0.2f);

            // Return the button to its normal color
            button.image.color = normalColor;
            yield return new WaitForSeconds(0.2f);
        }



    }

}
