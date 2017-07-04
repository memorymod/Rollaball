using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : MonoBehaviour {

    bool original;

    public void Start()
    {
        if (GameObject.FindGameObjectsWithTag ("Global Scene Manager").Length > 1 && !original)
        {
            Destroy(gameObject);
        }
        else
        {
            original = true;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void SwitchScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
