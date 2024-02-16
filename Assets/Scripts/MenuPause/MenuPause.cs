using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
	[SerializeField] private Button continueButton;
	[SerializeField] private Button exitGameButton;
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
	}
	private void Awake()
	{
		continueButton.onClick.AddListener(contiuneGame);
		exitGameButton.onClick.AddListener(Quit);
	}
	private void pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    private void contiuneGame()
    {
		PausePanel.SetActive(false);
		Time.timeScale = 1;
    }
	public void Quit()
	{
		Application.Quit();
	}
}
