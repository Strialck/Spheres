using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PointsEvent(int newPointsCount);
public class ScoreCounter : MonoBehaviour, IManager
{
    public event PointsEvent UpdateBestScore = delegate { };
    public event PointsEvent UpdateScore = delegate { };

    [SerializeField]
    private SphereManager _sphereManager;

    private int _bestScore;
    public int BestScore
    {
        get
        {
            return _bestScore;
        }

        private set
        {
            _bestScore = value;
            UpdateBestScore(value);
        }
    }

    private int _currentScore;
    public int CurrentScore
    {
        get
        {
            return _currentScore;
        }

        private set
        {
            _currentScore = value;
            if (value > BestScore)
                BestScore = value;
                
            UpdateScore(value);
        }
    }

    private void Start()
    {
        _sphereManager.OnSphereDestroyByPlayer += OnSphereClick;
        GameCycleManager.AddManager(this);
    }
    public void OnSphereClick(SphereData sphereData)
    {
        CurrentScore += sphereData.Points;
    }
    void IManager.ResetManager()
    {
        CurrentScore = 0;
    }
}
