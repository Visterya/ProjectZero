using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerZone : MonoBehaviour
{
    public Ease ease;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.DOMoveY(10, 2f).SetEase(ease);
        }
    }


}
