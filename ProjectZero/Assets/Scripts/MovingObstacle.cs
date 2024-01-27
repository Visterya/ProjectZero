using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Transform[] destinationPoints;
    private bool _switch = false;
    private void Start()
    {
        foreach (var point in destinationPoints)
        {
            point.SetParent(null);
        }
    }
    private void Update()
    {
        MoveObject();
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(destinationPoints[0].position, destinationPoints[1].position);
        
    }
    private void MoveObject()
    {
        if (_switch == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationPoints[0].position, .009f);
        }
        else if(_switch == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, destinationPoints[1].position, .009f);
        }
        if(transform.position == destinationPoints[0].position)
        {
            _switch = true;
        }
        else if(transform.position == destinationPoints[1].position)
        {
            _switch = false;
        }
        


    }

}
