using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    public bool showOnStart;
    public bool enableOnTakingDamage = true;
    public Slider[] healthBar;
    private int maxValue;
    

    private void Start()
    {
        if (healthBar.Length == 0)
        {
            healthBar = GetComponentsInChildren<Slider>();
        }
    }

    public void InitializeHPBar(int newMaxValue)
    {
        maxValue = newMaxValue;
        foreach (Slider slider in healthBar)
        {
            slider.maxValue = maxValue;
            slider.value = maxValue;
            if (showOnStart)
            {
                slider.gameObject.SetActive(true);
            }
            else
            {
                HideHealthBar();
            }
        }
    }

    public void UpdateHealthBar(float newValue)
    {
        foreach (Slider slider in healthBar)
        {
            if (newValue <= slider.maxValue)
            {
                if (!slider.gameObject.activeSelf && enableOnTakingDamage)
                {
                    slider.gameObject.SetActive(true);
                }
                slider.value = newValue;

            }
        }
    }
    
    public void HideHealthBar()
    {
        foreach (Slider slider in healthBar)
        {
            slider.gameObject.SetActive(false);
        }
    }
}
