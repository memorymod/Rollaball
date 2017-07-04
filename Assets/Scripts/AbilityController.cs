using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : MonoBehaviour {
    
    [HideInInspector]
    public List<PlayerAbilityProperties> currentAbilityProperties;
    [HideInInspector]
    public PlayerAbilityProperties[] abilityProperties;
    public List<string> currentAbilities;
    public Transform abilityHolder;

    Image[] abilityImageComponent;
    Image[] windupImageComponent;
    Text[] abilityKeyTexts;

    AbilityCanvasScript canvasScript;

    private void OnEnable()
    {
        abilityProperties = abilityHolder.GetComponentsInChildren<PlayerAbilityProperties>();
        
        abilityImageComponent = FindObjectOfType<AbilityCanvasScript>().abilityImageComponent;
        windupImageComponent = FindObjectOfType<AbilityCanvasScript>().windupImageComponent;
        abilityKeyTexts = FindObjectOfType<AbilityCanvasScript>().abilityKeyTexts;
        

        for (int i4 = 0; i4 < abilityProperties.Length; i4++)
        {
            if (currentAbilities.Contains(abilityProperties[i4].transform.name))
                currentAbilityProperties.Add(abilityProperties[i4]);
        }

        for (int i3 = 0; i3 < abilityProperties.Length; i3++)
        {
            abilityImageComponent[i3].transform.parent.gameObject.SetActive(true);

            if (i3 > currentAbilities.Count - 1)
            {
                abilityImageComponent[i3].transform.parent.gameObject.SetActive(false);
            }
        }
        
        for (int i2 = 0; i2 < currentAbilityProperties.Count; i2++)
        {
            abilityImageComponent[i2].overrideSprite = currentAbilityProperties[i2].abilityIcon;
        }

        for (int i = 0; i < currentAbilityProperties.Count; i++)
        {
            abilityKeyTexts[i].text = currentAbilityProperties[i].abilityKey.ToString();
        }
    }

    private void Update()
    {
        for (int i = 0; i < currentAbilities.Count; i++)
        {
            if (Input.GetKeyDown(currentAbilityProperties[i].abilityKey))
            {
                currentAbilityProperties[i].UseAbility(i);
            }
        }

        for (int i2 = 0; i2 < currentAbilities.Count; i2++)
        {
            windupImageComponent[i2].fillAmount = currentAbilityProperties[i2].currentAbilityCooldown / currentAbilityProperties[i2].abilityCooldown;
        }
    }
}
