
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        

        Debug.Log("gamescreen loaded");

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            init();
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsInitialized { get; set; }
    public int CurrentScore { get; set; }

    private string highscorekey = "HighScore";

    public int highscore
    {
        get
        {
            return PlayerPrefs.GetInt(highscorekey, 0);
            //return highscore;
        }
        set
        {
            PlayerPrefs.SetInt(highscorekey, value);
            //PlayerPrefs.DeleteAll();
        }
    }
    private void init()
    {
        CurrentScore = 0;
        IsInitialized = false;
    }

    private const string MainMenu = "MainMenu";
    private const string GamePlay = "GamePlay";

    public void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
    }
    public void GoToGamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GamePlay);
    }
}

    //***********************************************************************************************

    