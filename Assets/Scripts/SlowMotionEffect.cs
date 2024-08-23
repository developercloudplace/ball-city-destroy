using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionEffect : MonoBehaviour
{
    public void StarEffect()
    {
        StartCoroutine(ShowEffect());
    }

    private static IEnumerator ShowEffect()
    {

        for (var t = 1.0f; t > 0.1f; t -= Time.deltaTime * 3f)
        {
            Time.timeScale = t;
            if (t > 0.2)
            {
                for (var t1 = 0.1f; t1 < 1f; t1 += Time.deltaTime * 3f)
                {
                    Time.timeScale = t;
                }
            }
            yield return null;
        }
        Time.timeScale = 1;

    }
}