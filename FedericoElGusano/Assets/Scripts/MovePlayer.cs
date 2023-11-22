using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position += new Vector3(speed*Input.GetAxis("Horizontal"), 0, 0);
    }
}
