using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void SphereEvent(SphereData shereData);

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Sphere : MonoBehaviour
{
    private Renderer _renderer;
    private SphereData _sphereData;
    private Vector3 _deltaSpeed;
    private Rigidbody _rigidbody;


    public event SphereEvent OnSphereClick = delegate {};
    public event SphereEvent OnSphereOutOfBounds = delegate { };

    /*
    IEnumerator LifeCorutine(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        _sphereData.SphereTransform = transform;
        OnSphereOutOfBounds(_sphereData);
    }*/

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();


    }
    public void InitSphere(Material material, int points, float speed, float pathLenght, int damage, float acceleration = 3)
    {
        _renderer.material = material;
        
        _sphereData = new SphereData();
        _sphereData.Material = material;
        _sphereData.Points = points;
        _sphereData.Damage = damage;
        _rigidbody.velocity = Vector3.down * speed;
        /*
        double b = 2 * speed;
        double c = -2 * (pathLenght +  _sphereRadius);
        double discriminant = Math.Pow(b,2) - 4 * acceleration * c;
        float lifetime = (float)( (-b + Math.Sqrt(discriminant)) / (2 * acceleration));*/


        _deltaSpeed = new Vector3(0, -acceleration  * Time.fixedDeltaTime);


    }

    public void Click()
    {
        _sphereData.SphereTransform = transform;
        OnSphereClick(_sphereData);
    }
    /*
    private void OnMouseDown()
    {
        _sphereData.SphereTransform = transform;
        OnSphereClick(_sphereData);
    }*/
    private void FixedUpdate()
    {
        _rigidbody.velocity += _deltaSpeed;
        if(transform.position.y < SphereData.DownBound)
        {
            _sphereData.SphereTransform = transform;
            OnSphereOutOfBounds(_sphereData);
        }
           

    }




}
