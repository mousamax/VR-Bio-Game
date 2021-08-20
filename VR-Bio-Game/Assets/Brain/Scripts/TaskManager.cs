using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    // private Dictionary<string, string> Tasks = new Dictionary<string, string>(){
    //     {"Immune", "Immune Task"},
    //     {"Respiration", "Respiration Task"},
    //     {"Digestive", "Digestive Task"},
    // };

    private Task[] _tasks = new[] {
         new Task("Immune", "Immune Task"),
         new Task("Respiration", "Respiration Task"),
         new Task("Digestive", "Digestive Task")
        };

    static public Task[] _activeTasks = new Task[3];

    // Start is called before the first frame update
    void Start()
    {
        _activeTasks[0] = _tasks[0];
        Debug.Log(_activeTasks[0].taskTag);
        _activeTasks[1] = _tasks[1];
        _activeTasks[2] = _tasks[2];
    }
}
