using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool hasGameFinished;

    [SerializeField] private float _minRotateSpeed, _maxRotateSpeed;
    private float currentRotateSpeed;

    [SerializeField] private float _minRotateTime, _maxRotateTime;
    private float rotateTime;
    private float currentRotateTime;

    private void Awake()
    {
        hasGameFinished = false;

        currentRotateTime = 0f;
        currentRotateSpeed = _minRotateSpeed + (+_maxRotateSpeed - _minRotateSpeed) * Random.Range(0, 11) * 0.1f;
        rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * Random.Range(0, 11) * 0.1f;
        currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
    }
    private void Update()
    {
        currentRotateTime += Time.deltaTime;

        if (currentRotateTime > rotateTime)
        {
            currentRotateTime = 0f;
            currentRotateSpeed = _minRotateSpeed + (_maxRotateSpeed - _minRotateSpeed) * 0.1f * Random.Range(0, 11);
            rotateTime = _minRotateTime + (_maxRotateTime - _minRotateTime) * 0.1f * Random.Range(0, 11);
            currentRotateSpeed *= Random.Range(0, 2) == 0 ? 1f : -1f;
        }
    }
    private void FixedUpdate()
    {
        if (hasGameFinished) return;
        transform.Rotate(0, 0, currentRotateSpeed * Time.fixedDeltaTime);
    }
}
