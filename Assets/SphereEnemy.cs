using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SphereEnemy : MonoBehaviour
{
    public Transform player;
    private float detectionRange = 20f;

   

    private void Start()
    {
      
    }

    private void Update()
    {
        float distancePlayer =
            Vector3.Distance(player.position, transform.position);
        if (distancePlayer < detectionRange)
        {
           
        }


    }


}
