using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB13_TargetKill : MonoBehaviour
{
    void Update()
    {
        //Checking when the Mouse is clicked//
        if (Input.GetMouseButtonDown(0))
        {
            //Raycasts to where the mouse position is. Declares a Raycast hit//
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            //If the Raycast hits an object that isn't null, and has the "CanKill" tag, destroy it//
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null && hit.transform.gameObject.tag == "CanKill")
            {
                Debug.Log("Click");
                Destroy(hit.transform.gameObject);
            }
        }
    }
}