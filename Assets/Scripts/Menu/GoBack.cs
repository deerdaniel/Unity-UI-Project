using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoBack : MonoBehaviour
{
	[SerializeField] private Button backButton;
	[SerializeField] private string sceneName = "MainMenu";
	void Awake()
    {
		backButton.onClick.AddListener(Back);
	}
	private void Back()
	{
		SceneManager.LoadScene(sceneName);
	}
}
