using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string[] DigestionTutorialScripts = new string[] 
    {
        "Hi",
        "This is the stomach.",
        "In this system you will digest the food mechanically and chemically ",
        "The mechanically digested food will be transformed into 3 types: Protein, Carbs and Fats",
        "In order to digest the food mechanically, You need to pickup the hammer and smash the incoming food !",
        "Regarding the chemical digestion, you will need to throw the Carbs and Fats into the stomach",
        "However, Protein should not be throwed into the stomach",
        "To digest the Protein chemically, Pepsin enzyme is required",
        "You can shoot Pepsin from the gun. The gun contains 8 rounds of Pepsin",
        "In order to reload the gun, drop the empty magazine from the gun by pressing \"B\" ",
        "You can pickup a new Pepsin magazine from the shelf on your right. But Pepsin needs to be activated using HCL first",
        "You can find HCl running through a pipe on your left",
        "To activate the Pepsin, pick it from the shelf on your right and put it under the HCL stream on your left",
        "Now, put the Pepsin magazine into the gun and shoot some Protein!",
        "The gun is already loaded at first"
    };
    new void Start()
    {
        base.Start();
        TutorialScripts = DigestionTutorialScripts;
    }
    new void Update()
    {
        base.Update();
    }

    public override void TutorialSkip()
    {
        base.TutorialSkip();

        // remove the next line override the method however you want
        Debug.Log("Digestion Tutorial");
    }
    public override void TutorialNext()
    {
        base.TutorialNext();
    }
}