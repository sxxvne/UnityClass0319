using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAt : MonoBehaviour
{
    public int damage = 5;
    private float attackRange = 10f;
    public LayerMask enemyLayer;
    private Ray ray;
    RaycastHit hit;

    private float lastAttack = 0;
    private float attackCoolTime = 1f;
   

  
    private void Attack()
    {
        if (Time.time - lastAttack >= attackCoolTime)
        {
            if (Physics.Raycast(ray, attackRange, enemyLayer))
            {
                Hp enemyHp = hit.collider.GetComponent<Hp>();
                Debug.Log("Attack SphereEnemy");
                enemyHp.Damage(damage);
            }
            lastAttack = Time.time;

        }
    }
    private void Update()
    {
        if (Physics.Raycast(ray, out hit, attackRange, enemyLayer))
        {
            if (hit.collider.gameObject.CompareTag("SphereEnemy"))
            {
                Attack();
            }
        }
    }
}
