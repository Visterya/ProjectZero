using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            var speedMultiplier = 2;

            rb.velocity *= speedMultiplier;
        }
    }
}
