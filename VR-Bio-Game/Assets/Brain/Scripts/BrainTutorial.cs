using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************************************
this script is used to simplify the Tutorial process to make the gameplay more descriptive.
all what you need is to add statements that describe your scene mechanics or any gameplay tip you want.
then you can override the TutorialSkip to activate spawners or any script you have disactivated
*********************************************************************************/

public class BrainTutorial : Tutorial
{
    [HideInInspector]
    //  Remove those strings and add strings that describes your scene mechanics
    //  like what should the player do in your scene
    //  or how can he play? how can he increase the state that is related to your scene
    //  [Note]: try writing each statement you add at the text in the Tutorial Tablet 
    //          to make sure that it fits the text box size
    public string[] BrainTutorialScripts = new string[] {
        "You can Watch Activities on screen",
        "Leave this tablet and Press X to display control Tablet",
        "Start?"
    };
    private string[] ExercisesEventScripts = new string[] {
        "Playing ice hockey as rookie",
        "Morning exercise is beneficial, but it requires you to organise your breathing process",
        "Your muscles rely on haemoglobin to transport oxygen",
        "You must visit the the Lungs Room"
    };
    private string[] TrafficJamEventScripts = new string[] {
        "It appears that you are trapped in traffic",
        "Car exhaust makes it difficult to breathe and causes germs to grow in your body",
        "You must go to the Veins and fight them"
    };
    private string[] EatProklyEventScripts = new string[] {
        "Prokly isn't tasty,",
        "but it's highly healthy",
        "It improves the function of your immune system,",
        "but it sounds like you've eaten a lot and need to digest the meal",
        "You should go to the Stomach Room"
    };
    private static bool isUsedBefore = false;

    private int CurrentEventIndex = 0;
    private int CurrentActiveEvent = -1;
    new void Start()
    {
        base.Start();
        TutorialScripts = new string[] {
        "This is the Brain Room, you can consider it as the looby",
        "You can Watch Activities on screen",
        "Leave this tablet and Press X to display control Tablet",
        "You can also watch the three state on control tablets",
        "Start?"
    };
        CurrentActiveEvent = (int)EventManager._eventManager.GetCurrentEvent();

    }
    new void Update()
    {
        base.Update();
        if (!OnTutorialMode)
        {
            if (CurrentActiveEvent != (int)EventManager._eventManager.GetCurrentEvent())
            { CurrentEventIndex = 0; CurrentActiveEvent = (int)EventManager._eventManager.GetCurrentEvent(); }

            switch (CurrentActiveEvent)
            {
                case 0:
                    CurrentEventIndex = Mathf.Min(CurrentEventIndex, ExercisesEventScripts.Length - 1);
                    TutorialTablet.GetComponent<TutorialTablet>().ChangeScript(ExercisesEventScripts[CurrentEventIndex]);
                    break;
                case 1:
                    CurrentEventIndex = Mathf.Min(CurrentEventIndex, TrafficJamEventScripts.Length - 1);
                    TutorialTablet.GetComponent<TutorialTablet>().ChangeScript(TrafficJamEventScripts[CurrentEventIndex]);
                    break;
                case 2:
                    CurrentEventIndex = Mathf.Min(CurrentEventIndex, EatProklyEventScripts.Length - 1);
                    TutorialTablet.GetComponent<TutorialTablet>().ChangeScript(EatProklyEventScripts[CurrentEventIndex]);
                    break;
            }
        }
        else if (OnTutorialMode && TutorialScripts[TutorialIndex] == "Leave this tablet and Press X to display control Tablet")
        {
            if (LeftHand != null && LeftHand.GetComponent<TabletVisibilty>() != null)
                LeftHand.GetComponent<TabletVisibilty>().enabled = true;
        }
        if (isUsedBefore && !LeftHand.GetComponent<TabletVisibilty>().enabled)
        {
            LeftHand.GetComponent<TabletVisibilty>().enabled = true;
        }
    }
    public override void TutorialSkip()
    {
        base.TutorialSkip();

        if (LeftHand != null && LeftHand.GetComponent<TabletVisibilty>() != null)
            LeftHand.GetComponent<TabletVisibilty>().enabled = true;

        isUsedBefore = true;
    }
    public override void TutorialNext()
    {
        base.TutorialNext();
        if (!OnTutorialMode)
            CurrentEventIndex++;
    }
}
