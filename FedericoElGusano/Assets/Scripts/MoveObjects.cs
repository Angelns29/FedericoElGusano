using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveObjects : MonoBehaviour
{
    [SerializeField] private float _velocity;
    // Update is called once per frame
    void Update()
    {
        float xPosition = transform.position.x;
        transform.position = new Vector3(xPosition - _velocity * ParallaxManager.instance.GetSpeed() * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
