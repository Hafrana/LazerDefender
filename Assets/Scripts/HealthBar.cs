using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour 
{

	private float fillAmount;
	private Slider slider;

	public float MaxValue { get; set;}

	public float Value
	{
		set
		{
			slider.value = value/MaxValue;
		}
	}

	void Awake () 
	{
		slider = gameObject.GetComponent<Slider>();
	}
}
