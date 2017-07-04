using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityProperties : MonoBehaviour {

    public KeyCode abilityKey;
    public Sprite abilityIcon;
    public MonoBehaviour abilityScript;
    public float abilityCooldown;
    public string abilityMethodName;

    [HideInInspector]
    public float currentAbilityCooldown;

    Image[] abilityImageComponent;
    Image[] windupImageComponent;
    Text[] abilityKeyTexts;

    AbilityCanvasScript canvasScript;


    private void OnEnable()
    {
        abilityImageComponent = FindObjectOfType<AbilityCanvasScript>().abilityImageComponent;
        windupImageComponent = FindObjectOfType<AbilityCanvasScript>().windupImageComponent;
        abilityKeyTexts = FindObjectOfType<AbilityCanvasScript>().abilityKeyTexts;
    }

    private void Update()
    {
        currentAbilityCooldown -= Time.deltaTime;
    }

    public void UseAbility(int abilityIndex)
    {
        if (currentAbilityCooldown <= 0)
        {
            currentAbilityCooldown = abilityCooldown;
            abilityScript.SendMessage(abilityMethodName);
        }
    }
}
