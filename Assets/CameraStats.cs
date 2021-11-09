using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStats
{
    [SerializeField]
    private Camera _camera;
    public float CamWidth { get; private set; }
    public float CamHeght { get; private set; }
    public float MaxX { get; private set; }
    public float MinX { get; private set; }
    public float MaxY { get; private set; }
    public float MinY { get; private set; }
    public float Border { get; private set; }

   

    private static CameraStats _instance;
    private Vector3 _camPosition;

    private CameraStats()
    {
        Border = 0.1f;
        this._camera = Camera.main;
        _camPosition = _camera.transform.position;
        CamHeght = _camera.orthographicSize;
        CamWidth = CamHeght * _camera.aspect;
        MaxX = _camPosition.x + CamWidth;
        MinX = _camPosition.x - CamWidth;
        MaxY = _camPosition.y + CamHeght;
        MinY = _camPosition.y - CamHeght;
        CamHeght *= 2;
        CamWidth *= 2;
    }
   
    public static CameraStats GetInstance()
    {
        if (_instance == null)
            _instance = new CameraStats();
        return _instance;
    }
}
