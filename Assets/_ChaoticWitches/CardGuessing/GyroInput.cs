using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GyroInput : MonoBehaviour
{
    public UnityEvent OnRightTilt;
    public UnityEvent OnLeftTilt;

    [SerializeField] private float threshold = 0.5f; // Define threshold for right/left tilt
    [SerializeField] private float _maxAngleToRotate = 60f;
    private Image _image;
    [SerializeField] private Color _rightTiltColor;
    [SerializeField] private Color _leftTiltColor;
    private Color _defaultColor;
    [SerializeField] private float _timeToConfirm = 1f;
    [SerializeField] private float _currentTime = 0f;
    private float startingAngle = 0f;
    private float currentAngle => Mathf.Abs(startingAngle - transform.rotation.z) * 180;
    private float _timeToWait = 1f;
    private float _currentTimeToWait = 0f;



    private void Awake()
    {
        _image = GetComponent<Image>();
        _defaultColor = _image.color;
    }

    void Start()
    {
        startingAngle = transform.rotation.z;
        StartCoroutine(WaitForNextInput());
    }

    void Update()
    {
        ProcessAccelerometerInput();
    }

    void ProcessAccelerometerInput()
    {
        Vector3 accelerometerInput = Input.acceleration;
        float difference = accelerometerInput.x;

        if (_timeToWait >= _currentTimeToWait)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _image.color = _defaultColor;
            Debug.Log("Waiting for next input" + _currentTimeToWait + " " + _timeToWait);
            return;
        }

        if (difference >= 0)
        {
            _image.color = Color.Lerp(_defaultColor, _rightTiltColor, currentAngle / _maxAngleToRotate);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, -_maxAngleToRotate, difference));

            if (difference >= threshold)
            {
                _currentTime += Time.deltaTime;
                if (_currentTime >= _timeToConfirm)
                {
                    OnRightTilt.Invoke();
                    _currentTime = 0;
                    StartCoroutine(WaitForNextInput());
                }
                else
                {
                    _currentTime = 0;
                }
            }
        }
        else
        {
            _image.color = Color.Lerp(_defaultColor, _leftTiltColor, currentAngle / _maxAngleToRotate);
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, _maxAngleToRotate, Mathf.Abs(difference)));
            if (Mathf.Abs(difference) >= threshold)
            {
                _currentTime += Time.deltaTime;
                if (_currentTime >= _timeToConfirm)
                {
                    OnLeftTilt.Invoke();
                    _currentTime = 0;
                    StartCoroutine(WaitForNextInput());
                }
                else
                {
                    _currentTime = 0;


                }
            }
        }
    }

    private IEnumerator WaitForNextInput()
    {
        _currentTimeToWait = 0;
        do
        {
            _currentTimeToWait += Time.deltaTime;
            yield return null;
        }
        while (_currentTimeToWait <= _timeToWait);
    }
}