// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// public class BackgroundFollow : MonoBehaviour
// {
//     public Transform cameraTransform;
//     public float parallaxEffectMultiplier = 0.5f;
//     private Vector3 lastCameraPosition;

//     private void Start()
//     {
//         lastCameraPosition = cameraTransform.position;
//     }

//     private void Update()
//     {
//         Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
//         transform.position += deltaMovement * parallaxEffectMultiplier;
//         lastCameraPosition = cameraTransform.position;
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxEffectMultiplier = 1.0f;  // Adjust this to control the effect along the x-axis
    private Vector3 lastCameraPosition;
    private float fixedYPosition;  // This will keep the y position fixed

    private void Start()
    {
        lastCameraPosition = cameraTransform.position;
        fixedYPosition = transform.position.y;  // Initialize with the starting y position of the background
    }

    private void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        // Apply the parallax effect only to the x component and keep y fixed
        transform.position = new Vector3(transform.position.x + deltaMovement.x * parallaxEffectMultiplier, fixedYPosition, transform.position.z);
        lastCameraPosition = cameraTransform.position;
    }
}
