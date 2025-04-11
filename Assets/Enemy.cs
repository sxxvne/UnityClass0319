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
    private float lastAttackTime = 0f;
    public float distancePlayer;
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
        if (agent == null) return;
        distancePlayer =
            Vector3.Distance(player.position, transform.position);
        if (distancePlayer < detectionRange)
        {
            agent.SetDestination(player.transform.position);
        }
        if (distancePlayer <= attackRange && Time.time - lastAttackTime > 1f)
        {
            lastAttackTime = Time.time;
          
            player.GetComponent<Hp>().Damage(damage);
        }
       



        
    }
}



