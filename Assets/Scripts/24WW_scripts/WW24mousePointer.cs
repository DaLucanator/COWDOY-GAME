using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WW24mousePointer : MonoBehaviour
{
    public Transform temporary;
    public Vector3 mousePos;
    public Vector3 tempMousePos;
    public LayerMask hitLayers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
        {
            //this.transform.position = hit.point;
            this.transform.position = new Vector3(hit.point.x, hit.point.y, -1f);
        }
    }
}
