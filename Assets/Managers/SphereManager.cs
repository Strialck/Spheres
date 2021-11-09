using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SphereManager : MonoBehaviour, IManager
{
    public List<Transform> ActiveSphereTransforms { get; private set; } = new List<Transform>();
    public event SphereEvent OnSphereOutOfBound = delegate {};
    public event SphereEvent OnSphereDestroyByPlayer = delegate { };

    private void Start()
    {
        GameCycleManager.AddManager(this);
    }
    public void DeleteAllSpheres()
    {
        foreach (var sphere in ActiveSphereTransforms)
        {
            Object.Destroy(sphere.gameObject);
        }
        ActiveSphereTransforms.Clear();
    }
    public void OnSphereClickHandler (SphereData sphereData)
    {
        ActiveSphereTransforms.Remove(sphereData.SphereTransform);
        Object.Destroy(sphereData.SphereTransform.gameObject);
        OnSphereDestroyByPlayer(sphereData);
    }     
    public void OnSphereOutOfBoundsHandler (SphereData sphereData)
    {
        ActiveSphereTransforms.Remove(sphereData.SphereTransform);
        Object.Destroy(sphereData.SphereTransform.gameObject);
        OnSphereOutOfBound(sphereData);
    }

    public void ResetManager()
    {
        DeleteAllSpheres();
    }
}
