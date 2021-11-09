using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Menu,
    Play,
    Paused
}

public delegate void GameStateChanged(GameState gameState);
public class GameCycleManager : MonoBehaviour
{
    [SerializeField]
    private Menu _menu;
    [SerializeField]
    private HealthCounter _healthCounter;
    public static GameState CurrentGameState { get; private set; }
    public static List<IManager> Managers { get; private set; } = new List<IManager>();
    public static void AddManager(IManager manager)
    {
        Managers.Add(manager);
    }
    public static void RemoveManager(IManager manager)
    {
        Managers.Remove(manager);
    }
    //рестарт и старт из за простоты логики аналогичны, но в менеджере игрового цикла их сливать в один метод как то неправильно и логика чуть-чуть разнится
    //    в интерфейсе IManager,так как код дублировался и логика опять же одинакова старт и рестарт стал рестартом)


    private void ContinueGame()
    {
        CurrentGameState = GameState.Play;
        _menu.HideMenu();
        Time.timeScale = 1;
    }
    private void StartNewGame()
    {
        CurrentGameState = GameState.Play;
        _menu.HideMenu();
        Time.timeScale = 1;
        foreach (var manager in Managers)
        {
            manager.ResetManager();
        }
    }
    private void PauseGame()
    {
        CurrentGameState = GameState.Paused;
        _menu.ShowMenu();
        Time.timeScale = 0;
    }
    public void GameLoose()
    {
        CurrentGameState = GameState.Menu;
        _menu.ShowMenu(); 
        Time.timeScale = 0;

    }

    private void Start()
    {
        _menu.NewGameClick += StartNewGame;
        _menu.PauseGameClick += PauseGame;
        _menu.ContinueGameClick += ContinueGame;
        _healthCounter.LifeIsOver += GameLoose;
    }
}
