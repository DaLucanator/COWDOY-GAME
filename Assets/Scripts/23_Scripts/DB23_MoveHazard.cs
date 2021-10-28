using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB23_MoveHazard : MonoBehaviour
{
    [SerializeField]
    Transform[] Positions;

    public float HazardSpeed;
    Transform NextPos;
    int NextPosIndex;
    
    void Start()
    {
        NextPos = Positions[0];
    }

    void Update()
    {
        MoveGameObject();
    }

    void MoveGameObject()
    {
        if (transform.position == NextPos.position)
        {
            NextPosIndex++;
            if (NextPosIndex >= Positions.Length)
            {
                NextPosIndex = 0;
            }
            NextPos = Positions[NextPosIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos.position, HazardSpeed * Time.deltaTime);
        }
    }
}
