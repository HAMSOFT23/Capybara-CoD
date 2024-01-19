using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FacePlayer : MonoBehaviour
{
    public Transform playerTransform; // Assign the player's transform here
    public Vector3 faceDirection = Vector3.forward; // Adjust this if the "face" side isn't along the object's local Z-axis

    void Update()
    {
        if (playerTransform != null)
        {
            // Get the direction from this object to the player's position
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            // Use Quaternion.LookRotation to find the rotation to face the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

            // Calculate the rotation to align the "face" side of the object with the direction to the player
            Quaternion faceRotation = Quaternion.FromToRotation(faceDirection, targetRotation * Vector3.forward) * transform.rotation;

            // Apply the calculated rotation to the object
            transform.rotation = faceRotation;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the faceDirection in the Unity Editor
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, faceDirection * 2f); // Change the length of the gizmo ray if needed
    }
}

