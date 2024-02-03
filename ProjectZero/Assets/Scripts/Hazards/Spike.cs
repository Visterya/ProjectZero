using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = Vector3.zero;
            }
            GameManager.instance.GameLose();
        }
    }
}
