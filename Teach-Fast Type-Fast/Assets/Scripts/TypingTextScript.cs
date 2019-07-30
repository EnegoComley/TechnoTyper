using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingTextScript : MonoBehaviour
{
    public Text thisTextsTextComponent;
    string theActualText;
    int character;
    string currentLetter;
    string[] letters = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "z", "x", "c", "v", "b", "n", "m", ",", "." };
    public float acuracy;
    float numberOfMistakes;
    float theActualTextLength;
    public float wPM;
    // Start is called before the first frame update
    void Start()
    {
        theActualText = thisTextsTextComponent.text;
        currentLetter = theActualText[character].ToString();
        theActualTextLength = theActualText.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (currentLetter.ToString() == " ")
            {
                currentLetter = "space";
            } 
            if (Input.GetKey(currentLetter.ToString()))
            {
                PressedTheRightKey();
            }
            else
            {
                PressedTheWrongKey();
            }
            
        }
    }

    public void PressedTheRightKey()
    {
        theActualText = theActualText.Insert(character, "<color=green>");
        character = character + 14;
        theActualText = theActualText.Insert(character, "</color>");
        character = character + 8;
        thisTextsTextComponent.text = theActualText;
        if (theActualText.Length > character)
        {
            currentLetter = theActualText[character].ToString();
        }
        else
        {
            Finish();
        }

        
    }

    public void PressedTheWrongKey()
    {
        theActualText = theActualText.Insert(character, "<color=red>");
        character = character + 11;
        for (int i = 0; letters.Length > i; i++)
        {
            if (Input.GetKeyDown(letters[i].ToString()))
            {
                theActualText = theActualText.Remove(character, 1);
                theActualText = theActualText.Insert(character, letters[i].ToString());
                character++;
                
            }
        }
        theActualText = theActualText.Insert(character, "</color>");
        character = character + 8;
        thisTextsTextComponent.text = theActualText;
        numberOfMistakes++;
       
        if (theActualText.Length > character)
        {
            currentLetter = theActualText[character].ToString();
        }
        else
        {
            Finish();
        }

    }
    
    public void Finish()
    {
        acuracy = 100*((theActualTextLength - numberOfMistakes) / theActualTextLength);
        Debug.Log(acuracy + "%");
        wPM = ((theActualTextLength/5)/(Time.time/ 60));
        Debug.Log(wPM + " Words per Minute");
    }
}
