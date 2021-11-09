using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField]
    private Material sampleMaterial;
    [SerializeField]
    private GameObject sampleSphere;




    [SerializeField]
    private SphereManager _sphereManager;


    //скорее всего это надо вынести в отдельный класс)

    [SerializeField]
    private float _minSpeed;
    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private int _minPoints;
    [SerializeField]
    private int _maxPoints;
    
    [SerializeField]
    private int _minDamage;
    [SerializeField]
    private int _maxDamage;








    private void Start()
    {
        _sphereManager = GetComponent<SphereManager>();

    }
    public void GenerateSphere(Vector3 position)
    {
        float _currentSpeed = Random.Range(_minSpeed, _maxSpeed);
        var sphere = Instantiate(sampleSphere, position, Quaternion.Euler(-90,0,0)).GetComponent<Sphere>();

        sphere.InitSphere(GetMaterialWithRandomColor(), Random.Range(_minPoints, _maxPoints),_currentSpeed,
            CameraStats.GetInstance().CamHeght, Random.Range(_minDamage, _maxDamage));

        _sphereManager.ActiveSphereTransforms.Add(sphere.transform);
        sphere.OnSphereClick += _sphereManager.OnSphereClickHandler;
        sphere.OnSphereOutOfBounds += _sphereManager.OnSphereOutOfBoundsHandler;
    }



    private Material GetMaterialWithRandomColor()
    {
        var mat = new Material(sampleMaterial);
        mat.color = Random.ColorHSV();
        return mat;
    }
   
}
