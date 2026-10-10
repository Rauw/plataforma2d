using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] private Text coinsText, livesText;
    [SerializeField] private GameObject panelGameOver, panelWin, panelpause;
    [SerializeField] private AudioClip musica;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        UpdateCoinsText();
        UpdatelivesText();
        audiomanager.instance.PlayMusic(musica);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCoinsText()
    {
        coinsText.text = "X" + GameManager.instance.gameData.totalCoins.ToString();
    }
    
    public void UpdatelivesText()
    {
        livesText.text = "X" + GameManager.instance.gameData.totalLives.ToString();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        
    }
    public void continueButton()
    {
        panelpause.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        GameManager.instance.gameData.totalLives = 3;
        GameManager.instance.gameData.totalCoins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextlevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
        // SceneManager.LoadScene(NextLevelName);
    }
    
    public void ActivePanelGameOver()
    {
        panelGameOver.SetActive(true);
    }

    public void finishlevel()
    {
        panelWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void ActivePanelpause()
    {
        panelpause.SetActive(true);
        Time.timeScale = 0;
    }
}
