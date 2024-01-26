using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swing : MonoBehaviour
{
    Vector3 throwVector;

    [Header("Components")]
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        CalculateThrowVector();
        Path.StartVisualizingPath(this.gameObject);
    }


    private void OnMouseDrag()
    {
        CalculateThrowVector();
        Path.VisualizePath(this.gameObject, throwVector);
    }

    private void CalculateThrowVector()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        Vector2 distance = mousePos - this.transform.position;

        throwVector = -distance.normalized * 500;
    }

    private void OnMouseUp()
    {
        Path.StopVisualizingPath(this.gameObject);
        Throw();
    }

    private void Throw()
    {
        _rb.AddForce(throwVector);
    }

}
