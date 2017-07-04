using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public void GlobalSwitchSceneNow(string nextScene)
    {
        GlobalSceneManager.SwitchScene(nextScene);
    }
}
