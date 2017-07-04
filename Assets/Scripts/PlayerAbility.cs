using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour {

    public Renderer rend;

	public void Pink()
    {
        rend.material.color = new Color(255, 192, 203);
    }

    public void Yellow()
    {
        rend.material.color = Color.yellow;
    }

    public void Red()
    {
        rend.material.color = Color.red;
    }

    public void Blue()
    {
        rend.material.color = Color.blue;
    }
}
