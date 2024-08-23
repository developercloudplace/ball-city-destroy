using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnimationUI : MonoBehaviour
{
    [SerializeField] private float duration;
    private void Start()
    {
        DecreaseFade();
    }

    [SerializeField] private Image imageFade;

    public void Increase()
    {
        Enable();
        transform.DOScale(1, duration);
    }

    public void Decrease()
    {
        transform.DOScale(0, duration);
    }

    public void IncreaseFade()
    {
        imageFade.DOFade(1, duration);
    }

    public void DecreaseFade()
    {
        imageFade.DOFade(0, duration);
        Invoke(nameof(Disable), 1.1f);
    }

    private void Disable()
    {
        if (imageFade != null)
        {
            imageFade.enabled = false;
        }
    }

    private void Enable()
    {
        if(!imageFade)return;
        imageFade.enabled = true;
    }
}