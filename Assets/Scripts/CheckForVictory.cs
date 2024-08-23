using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CheckForVictory : MonoBehaviour
{
    public List<Building> buildings;

    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;
    public Button StartGameButton;
    private bool _lose;
    public bool GameMode = true;

    private void Start()
    {
        _lose = false;
    }

    private void LateUpdate()
    {
        if (buildings.Count >= 1)
        {
            if (StartGameButton)
            {
                StartGameButton.gameObject.SetActive(true);
            }

            GameMode = true;
        }
        else
        {
            if (StartGameButton)
            {
                StartGameButton.gameObject.SetActive(false);
            }
        }

        if (GameMode)
        {
            if (_lose)
            {
                Time.timeScale = 0.01f;
            }

            if (buildings.Count <= 0)
            {
                Wining();
            }
        }
    }

    private void Wining()
    {
        panelWin.transform.DOScale(1, 0.01f);
        Time.timeScale = 0.01f;
    }

    public void Lose()
    {
        _lose = true;
        panelLose.transform.DOScale(1, 0.01f);
    }
}