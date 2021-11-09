using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent();
public class HealthCounter : MonoBehaviour, IManager
{
    public event GameEvent LifeIsOver = delegate { };
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private SphereManager _sphereManager;

    private int _currentHealth;
    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }

        private set
        {
            if (value <= 0)
            {
                _currentHealth = 0;
                LifeIsOver();
            }
            else
                _currentHealth = value;

            OnHealthUpdated(_currentHealth);
        }
    }

    public event PointsEvent OnHealthUpdated = delegate { };

    private void SphereOutOfBoundHolder(SphereData sphereData)
    {
        CurrentHealth-= sphereData.Damage;
    }
    private void Start()
    {
        _sphereManager.OnSphereOutOfBound += SphereOutOfBoundHolder;
        GameCycleManager.AddManager(this);
    }

    public void ResetManager()
    {
        CurrentHealth = _maxHealth;
    }
}
