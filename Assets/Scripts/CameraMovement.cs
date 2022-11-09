using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 0.04f;
    public float yMin = 5f;
    public float yMax = 20f;
    private bool goingUp = true;

    void Update()
    {
        if (transform.position.y >= yMax) {
            goingUp = false;
        } else if (transform.position.y <= yMin) {
            goingUp = true;
        }

        if (goingUp) {
            transform.position += new Vector3(0f, moveSpeed, 0f);
            transform.Rotate(0.1f, 0f, 0f);
        } else {
            transform.position -= new Vector3(0f, moveSpeed, 0f);
            transform.Rotate(-0.1f, 0f, 0f);

        }
    }
}