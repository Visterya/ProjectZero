using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
            {
                collision.transform.DOScale(Vector3.zero, 1);
                Destroy(rb.gameObject);
            }
            GameManager.instance.GameLose();
        }
    }
}
