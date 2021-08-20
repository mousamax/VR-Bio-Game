using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenPointer : MonoBehaviour
{
    public enum State
    {
        first = 0,
        second = 1,
        third = 2
    }

    public State _state = State.first;
    private RectTransform _rectTransform;
    Vector3[] positionArray = new[] { new Vector3(0f, 2f, -0.1f), new Vector3(0f, 0f, -0.1f), new Vector3(0f, -2f, -0.1f) };

    public TextMeshProUGUI taskText0;
    public TextMeshProUGUI taskText1;
    public TextMeshProUGUI taskText2;
    public TextMeshProUGUI description;
    public GameObject taskMenu;
    void Start()
    {
        _rectTransform = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rectTransform.localPosition = positionArray[(int)_state];
        taskText0.text = TaskManager._activeTasks[0].taskTag;
        taskText1.text = TaskManager._activeTasks[1].taskTag;
        taskText2.text = TaskManager._activeTasks[2].taskTag;
        // Debug.Log((int)_state);
    }

    public void pointDown()
    {
        if ((int)_state + 1 <= 2)
        {
            _state += 1;
        }
    }
    public void pointUp()
    {
        if ((int)_state - 1 >= 0)
        {
            _state -= 1;
        }
    }
    public void pointRight()
    {
        taskMenu.SetActive(false);
        gameObject.SetActive(false);
        description.text = TaskManager._activeTasks[(int)_state].taskDescription;
        description.gameObject.SetActive(true);
    }
    public void pointLeft()
    {
        taskMenu.SetActive(true);
        gameObject.SetActive(true);
        description.text = "";
        description.gameObject.SetActive(false);
    }
    public void Enter()
    {
        Debug.Log("Task " + ((int)_state + 1) + " Selected");
    }



}
