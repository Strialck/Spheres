using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public delegate void MenuEvent();
public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _continueGameButton;
    [SerializeField]
    private GameObject _pauseGameButton;
    [SerializeField]
    private GameObject _menuParent; 

    public event MenuEvent NewGameClick = delegate{};
    public event MenuEvent ContinueGameClick = delegate{};
    public event MenuEvent PauseGameClick = delegate{};

    public void ShowMenu()
    {
        switch (GameCycleManager.CurrentGameState)
        {
            case GameState.Menu:
                {
                    _continueGameButton.SetActive(false);
                    _pauseGameButton.SetActive(false);
                    break;
                }
            case GameState.Paused:
                {
                    _continueGameButton.SetActive(true);
                    _pauseGameButton.SetActive(false);
                    break;
                }
            default:
                break;
        }
        _menuParent.SetActive(true);
        
    }
    public void HideMenu()
    {
        _menuParent.SetActive(false);
    }
    public void NewGame()
    {
        _pauseGameButton.SetActive(true);
        NewGameClick();
    }
    public void ContinueGame()
    {
        _pauseGameButton.SetActive(true);
        ContinueGameClick();
    }
    public void PauseGame()
    {
        _pauseGameButton.SetActive(false);
        PauseGameClick();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
