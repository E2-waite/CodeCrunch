using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad Instance;
    void Awake()
    {
        if(Instance)
                 DestroyImmediate(gameObject);
             else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}
