using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private float detectionRange = 20f;
    public float attackRange = 2f;     
    public int damage = 10;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player"); // 플레이어 찾기

        if (playerObject != null)
        {
            player = playerObject.transform;

        }
    }

    private void Update()
    {
        if (agent != null) return;
        float distancePlayer =
            Vector3.Distance(player.position, transform.position);
        if (distancePlayer < detectionRange)
        {
            agent.SetDestination(player.transform.position);
        }



        if (distancePlayer <= attackRange)
        {
           Hp playerHp = player.GetComponent<Hp>();
           if (playerHp != null) 
           { playerHp.Damage(damage);
           }
        }
    }
}
   


