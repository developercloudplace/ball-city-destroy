using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Start()
    {
        target = FindObjectOfType<DirectionPointer>().transform;
        target = FindObjectOfType<DirectionPointer>().transform;
        target = FindObjectOfType<DirectionPointer>().transform;
        target = FindObjectOfType<DirectionPointer>().transform;
    }

    private void Update()
    {
        if (target)
        {
            transform.position = target.position;
        }
    }
}