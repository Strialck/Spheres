using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private string _mouseAxisName;


    private void FixedUpdate()
    {
        if(GameCycleManager.CurrentGameState== GameState.Play)
        {
            if (Input.GetAxis(_mouseAxisName) > 0)
            {
                Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
                    hit.transform.GetComponent<Sphere>().Click();
            }
        }
    }
}
