using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : MonoBehaviour, IManager
{
    [SerializeField]
    private SphereGenerator _sphereGenerator;
    [SerializeField]
    private float _deltaSpawnTime;

    private CameraStats _cameraStats;

    
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Vector3 position = new Vector3(Random.Range(_cameraStats.MinX, _cameraStats.MaxX), _cameraStats.MaxY);
            _sphereGenerator.GenerateSphere(position);
            
            yield return new WaitForSeconds(_deltaSpawnTime);
        }
    }

    public void StartWorking()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void Start()
    {
        _cameraStats = CameraStats.GetInstance();
        GameCycleManager.AddManager(this);
    }

    public void ResetManager()
    {
        StopAllCoroutines();
        StartWorking();
    }
}
