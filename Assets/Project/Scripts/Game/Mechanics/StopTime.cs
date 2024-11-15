using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class StopTime : MonoBehaviour
{
    public static void StopForSeconds(float seconds)
    {
        StaticCoroutine.Instance.StartCoroutine(StopTimeCoroutine(seconds));
    }

    private static IEnumerator StopTimeCoroutine(float sec)
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(sec);

        Time.timeScale = 1f;
    }

 
}
