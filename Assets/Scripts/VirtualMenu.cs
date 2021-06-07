using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VirtualMenu : MonoBehaviour
{
    public GameObject definedButton;
    public UnityEvent Onclick = new UnityEvent();
    void Start()
    {
        definedButton = this.gameObject;
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        if (Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                SceneManager.LoadScene(2);

            }

        }
    }
}
