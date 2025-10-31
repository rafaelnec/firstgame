using System.Collections.Generic;
using UnityEngine;

public class StaticSceneController : MonoBehaviour
{
    public float scrollSpeed = 1f;


    private Camera mainCamera;


    void Start()
    {
        mainCamera = Camera.main;       
    }

    void Update()
    {
        // Move background left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Convert the sprite's position to viewport coordinates
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);
    }

}
