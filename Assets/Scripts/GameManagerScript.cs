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
  private GameObject levelDisplay;
  private GameObject startMenu;
  private GameObject startMenuText;
  private GameObject modeText;
  private bool gameIsRunning;
  private bool gameEnded;
  public float timeRemaining;
  public int score;
  public int level;
  public bool ascended;
  public bool descended;
  public bool fastmode;

  // Start is called before the first frame update
  void Start()
  {
    // Moved stuff to Awake()
    Debug.Log("Start in GameManagerScript");
    Debug.Log("Game running = " + gameIsRunning.ToString());
    Debug.Log("Game ended = " + gameEnded.ToString());
    Debug.Log("Time remaining = " + timeRemaining.ToString());

  }

  void Awake()
  {
    Debug.Log("AWOKE!");
    Debug.Log("Game running = " + gameIsRunning.ToString());

    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);

    startMenu = GameObject.Find("StartMenu");
    hudCanvas = GameObject.Find("HUDCanvas");
    player = GameObject.Find("Player");
    timerDisplay = GameObject.Find("TMP Timer");
    scoreDisplay = GameObject.Find("TMP Score");
    levelDisplay = GameObject.Find("TMP Level");
    startMenuText = GameObject.Find("StartMenuText");
    modeText = GameObject.Find("ModeText");

    DontDestroyOnLoad(startMenu);
    DontDestroyOnLoad(hudCanvas);
    DontDestroyOnLoad(player);

    gameIsRunning = false;
    gameEnded = false;
    ascended = false;
    descended = false;
    fastmode = false;
    startMenu.GetComponent<CanvasGroup>().alpha = 1;
    hudCanvas.GetComponent<CanvasGroup>().alpha = 0;
  }

  // Update is called once per frame
  void Update()
  {

    // Level transition
    if (ascended || descended)
    {
      int levelNow = SceneManager.GetActiveScene().buildIndex;
      if (level == levelNow)
      {
        Scene scene = SceneManager.GetActiveScene();
        GameObject[] rootObjs = scene.GetRootGameObjects();
        foreach(GameObject rootObj in rootObjs)
        {
          if (ascended && rootObj.name == "GoDown")
          {
            Vector3 stairPos = rootObj.transform.localPosition;
            Vector3 enterPos = new Vector3(stairPos.x - 0.2F, stairPos.y, stairPos.z);
            player.transform.localPosition = enterPos;
            player.GetComponent<PlayerScript>().FaceRight();
            break;
          }
          if (descended && rootObj.name == "GoUp")
          {
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

    // Player input
    if (Input.GetKeyDown(KeyCode.Space) || 
        Input.GetKeyDown(KeyCode.Return)) {
      if(gameEnded) {
        startMenuText.GetComponent<MenuScript>().InitGame();
        gameEnded = false;
      }
      else if(!gameIsRunning)
      {
        this.StartGame();
      }
    }
    if (Input.GetKeyDown(KeyCode.F) && !gameIsRunning) {
      fastmode = !fastmode;
      modeText.GetComponent<ModeScript>().PromptFastmode(fastmode);
    }

    // Timer update
    if (gameIsRunning && timeRemaining > 0)
    {
      timeRemaining -= (Time.deltaTime * (fastmode ? 2.0F : 1.0F));
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
    }

  }

  public void AddBonusTime(float timeToAdd) 
  {
    timeRemaining += timeToAdd;
  }

  public void addScore(int scoreToAdd) {
    score += scoreToAdd;
  }

  public void EndGame()
  {
    if(gameIsRunning)
    {
        gameIsRunning = false;
        player.GetComponent<PlayerScript>().EndGame();
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
    }
  }

  public void WinGame()
  {
    if(gameIsRunning)
    {
        gameIsRunning = false;
        gameEnded = true;
        player.GetComponent<PlayerScript>().EndGame();
        startMenuText.GetComponent<MenuScript>().WinGame();
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
    }
  }

  public void LoseGame()
  {
    if(gameIsRunning)
    {
        gameIsRunning = false;
        gameEnded = true;
        player.GetComponent<PlayerScript>().EndGame();
        startMenuText.GetComponent<MenuScript>().LoseGame();
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
    }
  }

  public void StartGame()
  {
    if(!gameIsRunning)
    {
      SceneManager.LoadScene(1);
      gameIsRunning = true;
      timeRemaining = 30;
      score = 0;
      level = 1;
      player.transform.localPosition = new Vector3(2.5F, 1.0F, 0.0F);
      player.GetComponent<PlayerScript>().SetSpeed(fastmode ? 2.0F : 1.0F);
      player.GetComponent<PlayerScript>().StartGame();
      startMenu.GetComponent<CanvasGroup>().alpha = 0;
      hudCanvas.GetComponent<CanvasGroup>().alpha = 1;
    }
  }

  public void LoadLowerLevel()
  {
    level = SceneManager.GetActiveScene().buildIndex + 1;
    descended = true;
    SceneManager.LoadScene(level);
  }

  public void LoadUpperLevel()
  {
    level = SceneManager.GetActiveScene().buildIndex - 1;
    ascended = true;
    SceneManager.LoadScene(level);
  }
}
