using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

  public static GameManagerScript Instance;
  private GameObject hudCanvas;
  private GameObject player;
  private GameObject timerDisplay;
  private GameObject scoreDisplay;
  private GameObject highScoreDisplay;
  private GameObject levelDisplay;
  private GameObject startMenu;
  private GameObject startMenuText;
  private GameObject modeText;
  private GameObject startHelpText;
  private GameObject pauseMenu;
  private GameObject pauseMenuText;
  private bool gameIsRunning; // True means the actual game play is running
  private bool gameIsPaused; // True means the actual game play is presumably running, but it is paused
  private bool gameEnded; // True means a round was played but we're not yet back to start screen
  public float timeRemaining;
  public int score;
  public int highScore;
  public int level;
  public bool ascended;
  public bool descended;
  public bool fastmode;

  // Start is called before the first frame update
  void Start()
  {
    // Moved stuff to Awake()
    // Debug.Log("Start in GameManagerScript");
    // Debug.Log("Game running = " + gameIsRunning.ToString());
    // Debug.Log("Game ended = " + gameEnded.ToString());
    // Debug.Log("Time remaining = " + timeRemaining.ToString());

  }

  void Awake()
  {
    // Debug.Log("AWOKE!");
    // Debug.Log("Game running = " + gameIsRunning.ToString());

    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);

    startMenu = GameObject.Find("StartMenu");
    pauseMenu = GameObject.Find("PauseMenu");
    hudCanvas = GameObject.Find("HUDCanvas");
    player = GameObject.Find("Player");
    highScore = 0;
    timerDisplay = GameObject.Find("TMP Timer");
    levelDisplay = GameObject.Find("TMP Level");
    scoreDisplay = GameObject.Find("TMP Score");
    highScoreDisplay = GameObject.Find("TMP HighScore");
    startMenuText = GameObject.Find("StartMenuText");
    modeText = GameObject.Find("ModeText");
    startHelpText = GameObject.Find("StartHelpText");
    pauseMenuText = GameObject.Find("PauseMenuText");

    DontDestroyOnLoad(startMenu);
    DontDestroyOnLoad(pauseMenu);
    DontDestroyOnLoad(hudCanvas);
    DontDestroyOnLoad(player);

    gameIsRunning = false;
    gameIsPaused = false;
    gameEnded = false;
    ascended = false;
    descended = false;
    fastmode = false;
    startMenu.GetComponent<CanvasGroup>().alpha = 1; // Show the start menu
    pauseMenu.GetComponent<CanvasGroup>().alpha = 0; // Hide the pause menu
    hudCanvas.GetComponent<CanvasGroup>().alpha = 0; // Hide the HUD
  }

  // Update is called once per frame
  void Update()
  {

    // Level transition
    if (ascended || descended)
    {
      int levelNow = SceneManager.GetActiveScene().buildIndex;
      if (level == levelNow) // Hack to wait until new level is loaded
      {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] rootObjs = scene.GetRootGameObjects();
        foreach(GameObject rootObj in rootObjs)
        {
          if (ascended && rootObj.name == "GoDown")
          {
            // Place player right of stairs after descending
            Vector3 stairPos = rootObj.transform.localPosition;
            Vector3 enterPos = new Vector3(stairPos.x - 0.2F, stairPos.y, stairPos.z);
            player.transform.localPosition = enterPos;
            player.GetComponent<PlayerScript>().FaceRight();
            break;
          }
          if (descended && rootObj.name == "GoUp")
          {
            // Place player left of stairs after ascending
            Vector3 stairPos = rootObj.transform.localPosition;
            Vector3 enterPos = new Vector3(stairPos.x + 0.2F, stairPos.y, stairPos.z);
            player.transform.localPosition = enterPos;
            player.GetComponent<PlayerScript>().FaceLeft();
            break;
          }
        }
        ascended = false;
        descended = false;
      }
    }

    // PLAYER INPUT
    // Start game
    if (Input.GetKeyDown(KeyCode.Space) || 
        Input.GetKeyDown(KeyCode.Return)) {
      if(gameEnded)
      {
        // Show message after game was played and it ended
        startMenuText.GetComponent<MenuScript>().InitGame();
        modeText.GetComponent<ModeScript>().Show();
        startHelpText.GetComponent<StartHelpScript>().Show();
        gameEnded = false;
      }
      else if(!gameIsRunning)
      {
        // Show the main start menu
        this.StartGame();
      }
    }
    // Fast mode
    if (Input.GetKeyDown(KeyCode.F) && !gameIsRunning)
    {
      // Toggle fastmode on/off if game is not running
      fastmode = !fastmode;
      Time.timeScale = fastmode ? 2.0F : 1.0F;
      modeText.GetComponent<ModeScript>().PromptFastmode(fastmode);
    }
    // Pause
    if (Input.GetKeyDown(KeyCode.P) && gameIsRunning)
    {
      // Toggle pause on/off
      if (!gameIsPaused)
      {
        Time.timeScale = 0;
        gameIsPaused = true;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 1;
      }
      else
      {
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
      }
    }

    // Timer update
    if (gameIsRunning && timeRemaining > 0)
    {
      timeRemaining -= Time.deltaTime;
      timerDisplay.GetComponent<TMPTimerScript>().DisplayTime(timeRemaining);
    } else
    {
      timeRemaining = 0;
      this.LoseGame();
    }

    // Score update
    if (gameIsRunning)
    {
      scoreDisplay.GetComponent<ScoreScript>().DisplayScore(score);
    }

    // Level update
    if (gameIsRunning)
    {
      levelDisplay.GetComponent<LevelScript>().DisplayLevel(level);
      highScoreDisplay.GetComponent<HighScoreScript>().DisplayScore(highScore);
    }

  }

  public void AddBonusTime(float timeToAdd) 
  {
    // This is not cuurently used
    timeRemaining += timeToAdd;
  }

  public void addScore(int scoreToAdd) {
    // Increase the score countet
    score += scoreToAdd;
  }

  public void WinGame()
  {
    // Called when player wins game
    if(gameIsRunning)
    {
      gameIsRunning = false;
      gameEnded = true;
      highScore = Math.Max(highScore, score);
      highScoreDisplay.GetComponent<HighScoreScript>().DisplayScore(highScore);
      player.GetComponent<PlayerScript>().EndGame();
      startMenuText.GetComponent<MenuScript>().WinGame(score, highScore); // Display winning message
      modeText.GetComponent<ModeScript>().Hide(); // Hide start menu mode prompt
      startHelpText.GetComponent<StartHelpScript>().Hide(); // Hide start menu help text
      startMenu.GetComponent<CanvasGroup>().alpha = 1; // Make message window visible
    }
  }

  public void LoseGame()
  {
    if(gameIsRunning)
    {
      gameIsRunning = false;
      gameEnded = true;
      player.GetComponent<PlayerScript>().EndGame();
      startMenuText.GetComponent<MenuScript>().LoseGame(); // Display losing message
      modeText.GetComponent<ModeScript>().Hide(); // Hide start menu mode prompt 
      startHelpText.GetComponent<StartHelpScript>().Hide(); // Hide start menu help text
      startMenu.GetComponent<CanvasGroup>().alpha = 1; // Make message window visible
    }
  }

  public void StartGame()
  {
    if(!gameIsRunning)
    {
      SceneManager.LoadScene(1); // Load the first actual scene of the game
      gameIsRunning = true;
      timeRemaining = 30;
      score = 0;
      level = 1;
      player.transform.localPosition = new Vector3(2.5F, 1.0F, 0.0F); // Place player in dungeon
      player.GetComponent<PlayerScript>().SetSpeed(fastmode ? 2.0F : 1.0F); // Adjust speed to current speed mode
      player.GetComponent<PlayerScript>().StartGame();
      startMenu.GetComponent<CanvasGroup>().alpha = 0; // Hide start menu
      pauseMenu.GetComponent<CanvasGroup>().alpha = 0; // Hide pause menu
      hudCanvas.GetComponent<CanvasGroup>().alpha = 1; // Show HUD
    }
  }

  public void LoadLowerLevel()
  {
    level = SceneManager.GetActiveScene().buildIndex + 1; // Get the current level and increase it by one
    descended = true;
    SceneManager.LoadScene(level);
  }

  public void LoadUpperLevel()
  {
    level = SceneManager.GetActiveScene().buildIndex - 1; // Get the current level and decrease it by one
    ascended = true;
    SceneManager.LoadScene(level);
  }
}
