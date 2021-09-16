using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************************************
this script is used to simplify the Tutorial process to make the gameplay more descriptive.
all what you need is to add statements that describe your scene mechanics or any gameplay tip you want.
then you can override the TutorialSkip to activate spawners or any script you have disactivated
*********************************************************************************/

public class RespirationTutorial : Tutorial
{
    [HideInInspector]
    //  Remove those strings and add strings that describes your scene mechanics
    //  like what should the player do in your scene
    //  or how can he play? how can he increase the state that is related to your scene
    //  [Note]: try writing each statement you add at the text in the Tutorial Tablet 
    //          to make sure that it fits the text box size
    public string[] RespirationTutorialScripts = new string[] {
        "Hi",
        "filter the air",
    };
    new void Start()
    {
        base.Start();
        TutorialScripts = RespirationTutorialScripts;
    }
    new void Update()
    {
        base.Update();
    }

    public override void TutorialSkip()
    {
        base.TutorialSkip();

        // remove the next line override the method however you want
        Debug.Log("Respiration Tutorial");
    }
    public override void TutorialNext()
    {
        base.TutorialNext();
    }
}
