using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool activePause;
    public void SwitchPause(bool active)
    {
        activePause = active;
        Time.timeScale = active ? 0 : 1;
    }
}