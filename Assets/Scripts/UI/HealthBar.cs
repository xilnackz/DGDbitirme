using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public AttributesManager atm;
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	
	private void Start() 
	{
		
	    SetMaxHealth();	
	}

	private void Update() 
	{
		SetHealth();	
	}
	public void SetMaxHealth()
	{
		slider.maxValue = atm.health;
		slider.value = atm.health;

		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth()
	{
		slider.value = atm.health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
