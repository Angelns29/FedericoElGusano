using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;

    private Transform cameraTransform;
    private Vector3 CameraPosition;
    private float spriteWidth, startPosition;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        CameraPosition = cameraTransform.position;
        spriteWidth=GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }
    void FixedUpdate()
    {
        float deltaX = (cameraTransform.position.x - CameraPosition.x) * parallaxMultiplier;
        float moveAmount=cameraTransform.position.x * (1-parallaxMultiplier);
        transform.Translate(new Vector3(deltaX, 0, 0));
        CameraPosition=cameraTransform.position;

        if (moveAmount > startPosition+spriteWidth) 
        { 
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;
        }
        else if (moveAmount < startPosition-spriteWidth) 
        { 
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;

        }
    }
}
