using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Swing : MonoBehaviour
{
    Vector3 throwVector;
    private bool isFlyMode = false;
    private bool isThrowing = false;

    [Header("Components")]
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private LineRenderer _lr;
    [SerializeField] private Sprite idle, fly;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _lr = this.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        ChangeSprite();
    }
    private void OnMouseDown()
    {
        CalculateThrowVector();
        SetArrow();
        isFlyMode = false;
    }


    private void OnMouseDrag()
    {
        CalculateThrowVector();
        SetArrow();
    }

    private void CalculateThrowVector()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        Vector2 distance = mousePos - this.transform.position;

        Vector3 lookDir = mousePos - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -270;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        throwVector = -distance.normalized * 500;
    }
    private void SetArrow()
    {

        _lr.positionCount = 2;
        _lr.SetPosition(0, Vector3.zero);
        _lr.SetPosition(1, Vector3.up * 4);
        _lr.enabled = true;


    }
    private void OnMouseUp()
    {
        if(GameManager.instance.ThrowLimit > 0 && !isThrowing)
        {
            RemoveArrow();
            Throw();
            isFlyMode = true;

            if(GameManager.instance.ThrowLimit == 0)
            {
                isThrowing = true;
                StartCoroutine(GameLoseSequence());
            }
        }

    }

    private void RemoveArrow()
    {
        _lr.enabled = false;
    }

    private void Throw()
    {
        _rb.AddForce(throwVector);
        GameManager.instance.ThrowLimit--;
        Invoke("ResetThrowFlag", 3.5f);
    }


    private void ChangeSprite()
    {
        if(isFlyMode == true)
        {
            _spriteRenderer.sprite = fly;
        }
        else
        {
            _spriteRenderer.sprite = idle;
        }
    }

    void ResetThrowFlag()
    {
        isThrowing = false;
    }

    private IEnumerator GameLoseSequence()
    {
        yield return new WaitForSeconds(2);
        GameManager.instance.GameLose();
    }


}
