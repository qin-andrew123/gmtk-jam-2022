using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameObject Manager;
    public static bool gameIsPaused;
    public delegate void Health(int amount);
    public static event Health UpdateHealth;

    public static event Action<GameState> OnGameStateChanged;
    public GameState gameState;

    public void UpdateGameState(GameState newState)
    {
        gameState = newState;
        switch (newState)
        {
            case GameState.mainMenu:
                HandleMainMenu();
                break;
            case GameState.levelOne:
                HandleLevelOne();
                break;
            case GameState.victory:
                HandleVictory();
                break;
            case GameState.death:
                HandleDeath();
                break;
            case GameState.pause:
                HandlePause();
                break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        OnGameStateChanged?.Invoke(newState);
    }

    

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void Start()
    {
        UpdateGameState(GameState.mainMenu);
    }

    // Start is called before the first frame update
    void Awake() {
        print("GameManager Awake");
        Manager = GameObject.Find("GameManager");
        if (Instance != null && Instance != this) {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Manager);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Map1");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }


    private void HandleMainMenu()
    {

    }

    private void HandlePause()
    {
        throw new NotImplementedException();
    }

    private void HandleDeath()
    {
        throw new NotImplementedException();
    }

    private void HandleVictory()
    {
        throw new NotImplementedException();
    }

    private void HandleLevelOne()
    {
        
    }
    private void HandleNextLevel()
    {

    }
}

public enum GameState
{
    mainMenu,
    levelOne,
    nextLevel,
    victory,
    death,
    pause,
}