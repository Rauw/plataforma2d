using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text coinsText, livesText;
    [SerializeField] private GameObject panelGameOver;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateCoinsText();
        UpdatelivesText();
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

    public void RestartButton()
    {
        GameManager.instance.gameData.totalLives = 3;
        GameManager.instance.gameData.totalCoins = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void ActivePanelGameOver()
    {
        panelGameOver.SetActive(true);
    }
}
