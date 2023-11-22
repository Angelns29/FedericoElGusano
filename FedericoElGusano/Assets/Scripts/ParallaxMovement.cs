using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMovement : MonoBehaviour
{
    [SerializeField] private float _paralaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //// Update is called once per frame
    void Update()
    {
       
        float xPosition = transform.position.x;
        if (xPosition> ParallaxManager.instance.GetParalaxPivot().position.x*2)
        {
            transform.position=new Vector3 (xPosition - _paralaxSpeed * ParallaxManager.instance.GetSpeed()*Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + (20.91f*2), transform.position.y, transform.position.z);
        }
    }
}
