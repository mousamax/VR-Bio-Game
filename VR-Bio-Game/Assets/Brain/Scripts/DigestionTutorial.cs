using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*********************************************************************************
this script is used to simplify the Tutorial process to make the gameplay more descriptive.
all what you need is to add statements that describe your scene mechanics or any gameplay tip you want.
then you can override the TutorialSkip to activate spawners or any script you have disactivated
*********************************************************************************/
public class DigestionTutorial : Tutorial
{
    [HideInInspector]
    //  Remove those strings and add strings that describes your scene mechanics
    //  like what should the player do in your scene
    //  or how can he play? how can he increase the state that is related to your scene
    //  [Note]: try writing each statement you add at the text in the Tutorial Tablet in the editor 
    //          to make sure that it fits the text box size in the scene window
    public string[] DigestionTutorialScripts = new string[] {
        "Hi",
        "do stuff to food",
    };
    private static bool isTutorialDone = false;
    public Sprite[] DigestionDescriptiveImages;

    new void Start()
    {
        base.Start();
        TutorialScripts = new string[] {
        "Hi",
        "do stuff to food",
    };
    }
    new void Update()
    {
        base.Update();
        OnTutorialMode = isTutorialDone ? false : OnTutorialMode;
        if (OnTutorialMode && DigestionDescriptiveImages[TutorialIndex] != null)
        {
            DescriptiveImage.sprite = DigestionDescriptiveImages[TutorialIndex];
            DescriptiveImage.gameObject.SetActive(true);
        }
        else if (OnTutorialMode && DigestionDescriptiveImages[TutorialIndex] == null)
        {
            DescriptiveImage.gameObject.SetActive(false);
        }
        else if (!OnTutorialMode && DescriptiveImage.gameObject.activeSelf)
        {
            DescriptiveImage.gameObject.SetActive(false);
        }
    }

    public override void TutorialSkip()
    {
        base.TutorialSkip();
        isTutorialDone = true;

        // remove the next line override the method however you want
        Debug.Log("Digestion Tutorial");
    }
    public override void TutorialNext()
    {
        base.TutorialNext();
    }
}