using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Swing : MonoBehaviour
{
    Vector3 throwVector;
    private bool isFlyMode = false;
    private bool isThrowing = false;

    [Header("Components")]
    private Rigidbody2D _rb;
    private Animator _anim;
    private LineRenderer _lr;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _anim = this.GetComponent<Animator>();
        _lr = this.GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        transform.DOScale(Vector3.zero, 1).From();
    }

    private void Update()
    {
        ChangeSprite();
    }
    private void OnMouseDown()
    {
        if (GameManager.instance.ThrowLimit <= 0)
        {
            return;
        }
        CalculateThrowVector();
        SetArrow();
        isFlyMode = false;
    }


    private void OnMouseDrag()
    {
        if (GameManager.instance.ThrowLimit <= 0) 
        {
            return;
        }
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
        _lr.SetPosition(0, new Vector3(0, 0, 10));
        _lr.SetPosition(1, new Vector3(0, 4, 10));
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

        _anim.SetBool("isFlying", isFlyMode);
        
    }

    void ResetThrowFlag()
    {
        isThrowing = false;
    }

    private IEnumerator GameLoseSequence()
    {
        yield return new WaitForSeconds(2);
        _rb.velocity = Vector2.zero;
        GameManager.instance.GameLose();
    }


}
