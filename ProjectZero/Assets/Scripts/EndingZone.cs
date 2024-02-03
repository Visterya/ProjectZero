using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(other.gameObject.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = Vector3.zero;
            }
            GameManager.instance.GameWin();
        }
    }
}
