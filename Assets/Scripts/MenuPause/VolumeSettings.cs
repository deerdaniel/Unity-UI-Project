using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
	[SerializeField] private Slider audioSlider;

	private void Update()
	{
		audio.volume = audioSlider.value;
	}
}
