using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    private bool goingUp = true;

    void Update()
    {
        if (transform.position.y >= 22f) {
            goingUp = false;
        } else if (transform.position.y <= 1f) {
            goingUp = true;
        }

        if (goingUp) {
            transform.position += new Vector3(0f, moveSpeed, 0f);
        } else {
            transform.position -= new Vector3(0f, moveSpeed, 0f);
        }
    }
}