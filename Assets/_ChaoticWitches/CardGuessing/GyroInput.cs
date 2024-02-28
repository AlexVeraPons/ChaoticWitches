using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GyroInput : MonoBehaviour
{
    public UnityEvent OnRightTilt;
    public UnityEvent OnLeftTilt;

    [SerializeField] private float threshold = 0.5f; // Define threshold for right/left tilt it determines the velocity of the tilt needed
    private Image _image;
    [SerializeField] private Color _rightTiltColor;
    [SerializeField] private Color _leftTiltColor;
    private Color _defaultColor;
    [SerializeField] private float _timeToConfirm = 1f;
    [SerializeField] private float _currentTime = 0f;
    private float _lastZAngleX;

    private bool _shouldBeProcessing = false;

    private void Awake()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }

        _image = GetComponent<Image>();
        _defaultColor = _image.color;
    }

    void Start()
    {
        _defaultColor = _image.color;
        StartCoroutine(StartProcessing());
    }

    private IEnumerator StartProcessing()
    {
        yield return new WaitForSeconds(1f);
        _shouldBeProcessing = true;
    }

    void Update()
    {
        ProcessGyroInput();
        PrintGyroInput();
    }

    private void PrintGyroInput()
    {
        if (Input.gyro.enabled)
        {
        }
    }

    void ProcessGyroInput()
    {

        if (Input.gyro.enabled)
        {
            // Calculate the angular velocity (difference in tilt angle divided by deltaTime)
            float angularVelocityX = (Input.gyro.attitude.x - _lastZAngleX) / Time.deltaTime;
            _lastZAngleX = Input.gyro.attitude.x;

            // Update the _lastXAngle for the next frame
            Debug.Log("Angular Velocity X: " + angularVelocityX);


            if (!_shouldBeProcessing) { return; }
            if (angularVelocityX > threshold)
            {
                _image.color = _leftTiltColor;
                OnLeftTilt.Invoke();
                _shouldBeProcessing = false;
            }
            else if (angularVelocityX < -threshold)
            {
                _image.color = _rightTiltColor;
                OnRightTilt.Invoke();
                _shouldBeProcessing = false;
            }
            else
            {
                _image.color = _defaultColor;
            }

        }

    }
}