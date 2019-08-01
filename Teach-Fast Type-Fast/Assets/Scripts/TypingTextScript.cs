using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypingTextScript : MonoBehaviour
{
    public TextMeshProUGUI thisTextsTextComponent;
    public TextMeshProUGUI statsBar;
    public string theActualText;
    int character;
    string currentLetter;
    string[] letters = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "z", "x", "c", "v", "b", "n", "m", ",", "." };
    float numberOfMistakes;
    float theActualTextLength;
    int keysPressed;
    // Start is called before the first frame update
    void Start()
    {
        theActualText = thisTextsTextComponent.text;
        currentLetter = theActualText[character].ToString();
        theActualTextLength = theActualText.Length;
        AddMark();
        UnHighlight();
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

        statsBar.text = $"You are currently typing at {wPM()} Words Per Minute. Your current accuracy is {acuracy()}%"  ;

    }

    public void PressedTheRightKey()
    {
        if (currentLetter == "space")
        {
            theActualText = theActualText.Remove(character, 1);
            theActualText = theActualText.Insert(character, "_");
        }
        theActualText = theActualText.Replace("<mark=#9D9D9D00>", "<color=green>");
        theActualText = theActualText.Replace("<mark=#9D9D9D40>", "<color=green>");
        theActualText = theActualText.Replace("</mark>","</color>");
        character = character + 6;
        AddMark();
        thisTextsTextComponent.text = theActualText;
        keysPressed++;
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

        for (int i = 0; letters.Length > i; i++)
        {
            if (Input.GetKeyDown(letters[i].ToString()))
            {
                theActualText = theActualText.Remove(character, 1);
                theActualText = theActualText.Insert(character, letters[i].ToString());
                theActualText = theActualText.Replace("<mark=#9D9D9D00>", "<color=red>");
                theActualText = theActualText.Replace("<mark=#9D9D9D40>", "<color=red>");
                theActualText = theActualText.Replace("</mark>", "</color>");
                character = character + 4;
                Debug.Log(theActualText[character]);
                AddMark();
                thisTextsTextComponent.text = theActualText;
                numberOfMistakes++;
                keysPressed++;
                if (theActualText.Length > character)
                {
                    currentLetter = theActualText[character].ToString();
                }
                else
                {
                    Finish();
                }

            }
        }
        if (Input.GetKeyDown("space"))
        {
            theActualText = theActualText.Remove(character, 1);
            theActualText = theActualText.Insert(character, "_");
            theActualText = theActualText.Replace("<mark=#9D9D9D00>", "<color=red>");
            theActualText = theActualText.Replace("<mark=#9D9D9D40>", "<color=red>");
            theActualText = theActualText.Replace("</mark>", "</color>");
            character = character + 4;
            Debug.Log(theActualText[character]);
            AddMark();
            thisTextsTextComponent.text = theActualText;
            numberOfMistakes++;
            keysPressed++;
            if (theActualText.Length > character)
            {
                currentLetter = theActualText[character].ToString();
            }
            else
            {
                Finish();
            }
        }



    }

    public void Finish()
    {
        Debug.Log(acuracy() + "%");
        Debug.Log(wPM() + " Words per Minute");
    }

    void Highlight()
    {
        theActualText = theActualText.Replace("<mark=#9D9D9D00>", "<mark=#9D9D9D40>");
        thisTextsTextComponent.text = theActualText;
        Invoke("UnHighlight", 0.2f);
    }

    void UnHighlight()
    {
        theActualText = theActualText.Replace("<mark=#9D9D9D40>","<mark=#9D9D9D00>");
        thisTextsTextComponent.text = theActualText;
        Invoke("Highlight",0.2f);
    }

    void AddMark()
    {
        Debug.Log(theActualText[character]);
        theActualText = theActualText.Insert(character, "<mark=#9D9D9D40>");
        character = character + 16;
        theActualText = theActualText.Insert(character + 1, "</mark>");
        thisTextsTextComponent.text = theActualText;
    }
    public float thing;

    public int wPM()
    {
        return (int)((keysPressed / 5) / (Time.time / 60));
    }

    public int acuracy()
    {
        if (keysPressed == 0)
        {
            return (100);
        }
        return (int)(100 * ((keysPressed - numberOfMistakes) / keysPressed));
    }

    public void SetLevel(int level)
    {

    }


}

