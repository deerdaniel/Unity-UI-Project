using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Button playButton;
	[SerializeField] private Button optionsButton;
	[SerializeField] private Button rankingButton;
	[SerializeField] private Button exitButton;

	[SerializeField] private string gameplaySceneName;
	[SerializeField] private CanvasRenderer rankingCanvas;
	[SerializeField] private CanvasRenderer optionsCanvas;

	private void Awake()
	{
		playButton.onClick.AddListener(loadGameplay);
		exitButton.onClick.AddListener(quit);
		rankingButton.onClick.AddListener(delegate { ChangeCanvas(rankingCanvas); });
		optionsButton.onClick.AddListener(delegate { ChangeCanvas(optionsCanvas); });

	}
	private void loadGameplay()
	{	
		SceneManager.LoadScene(gameplaySceneName);
	}

	private void ChangeCanvas(CanvasRenderer canvasRenderer)
	{
		canvasRenderer.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}

	private void quit()
	{
		Application.Quit();
	}
}

