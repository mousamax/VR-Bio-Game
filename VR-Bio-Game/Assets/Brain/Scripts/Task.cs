using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string taskTag;
    public string taskDescription;

    public Task(string tag, string description)
    {
        taskTag = tag;
        taskDescription = description;
    }
}
