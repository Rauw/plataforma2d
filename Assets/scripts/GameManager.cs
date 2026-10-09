using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public GameData gameData;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            gameData = new GameData();
            gameData.totalCoins = 0;
            gameData.totalLives = 3;
            
            
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
