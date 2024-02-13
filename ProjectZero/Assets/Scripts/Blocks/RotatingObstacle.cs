using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField, Range(-45, 45)] private float rotateSpeed;
    void Start()
    {
        InvokeRepeating("RotateObstacle", 0.1f, 1f);
    }

    private void RotateObstacle()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed));
    }
}
