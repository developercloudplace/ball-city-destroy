using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TakeDamage : MonoBehaviour
{
    private Building _building;
    private Camera _camera;
    
    private void Start()
    {
        _building = GetComponent<Building>();
        _camera = Camera.main;
    }

    public UnityEvent damageEvent;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponent<DirectionPointer>()) return;
        _camera.transform.DOShakePosition(1, 1);
        damageEvent.Invoke();
        _building.ClearList();
        Destroy(gameObject, 0.1f);
    }
}