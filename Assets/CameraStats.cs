using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStats
{
    [SerializeField]
    private Camera Camera;
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
        this.Camera = Camera.main;
        _camPosition = Camera.transform.position;
        CamHeght = Camera.orthographicSize;
        CamWidth = CamHeght * Camera.aspect;
        MaxX = _camPosition.x + CamWidth;
        MinX = _camPosition.x - CamWidth;
        MaxY = _camPosition.y + CamHeght;
        MinY = _camPosition.y - CamHeght;
        CamHeght *= 2;
        CamWidth *= 2;
    }
    public static Vector3 GetRandomPosOnCamBorder()
    {
        Vector3 position = new Vector3();
        if (Random.Range(0f, 1f) > 0.5f) 
        {
            position.x = Random.Range(0f, 1f) > 0.5f ? GetInstance().MaxX - GetInstance().Border : GetInstance().MinX + GetInstance().Border;
            position.y = Random.Range(GetInstance().MinY + GetInstance().Border, GetInstance().MaxY - GetInstance().Border);
        }
        else
        {
            position.y = Random.Range(0f, 1f) > 0.5f ? GetInstance().MaxY - GetInstance().Border : GetInstance().MinY + GetInstance().Border;
            position.x = Random.Range(GetInstance().MinX + GetInstance().Border, GetInstance().MaxX - GetInstance().Border);
        }
        return position;
    }
    public static CameraStats GetInstance()
    {
        if (_instance == null)
            _instance = new CameraStats();
        return _instance;
    }
}
