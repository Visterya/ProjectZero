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
    private LineRenderer _line;

    private void Awake()
    {
        _line = this.GetComponent<LineRenderer>();
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
    private void SetArrow()
    {
        _line.positionCount = 2;
        _line.SetPosition(0, Vector3.zero);
        _line.SetPosition(1, throwVector.normalized * 2);
        _line.enabled = true;
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

    private void RemoveArrow()
    {
        _line.enabled = false;
    }
}
