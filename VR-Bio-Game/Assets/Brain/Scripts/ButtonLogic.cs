using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ButtonLogic : MonoBehaviour
{
    // public TextMeshProUGUI simpleText;
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;
    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Math.Abs(value) < deadzone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        // simpleText.text = "Pressed";
        onPressed.Invoke();
        Debug.Log("Pressed");
    }
    private void Released()
    {
        _isPressed = false;
        // simpleText.text = "Released";
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
