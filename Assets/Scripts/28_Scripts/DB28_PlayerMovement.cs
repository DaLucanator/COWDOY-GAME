using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB28_PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
    }
}
