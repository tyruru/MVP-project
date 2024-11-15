using System.Collections;
using UnityEngine;

public class StaticCoroutine : MonoBehaviour
{
    private static StaticCoroutine _instance;

    public static StaticCoroutine Instance
    {
        get
        {
            if (_instance == null)
            {
                // Создаем объект при первом обращении к Instance
                GameObject runnerObject = new GameObject("StaticCoroutine");
                _instance = runnerObject.AddComponent<StaticCoroutine>();
                DontDestroyOnLoad(runnerObject);
            }
            return _instance;
        }
    }  
}