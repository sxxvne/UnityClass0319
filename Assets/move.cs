using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;

public class move : MonoBehaviour
{
    private int speed = 5;
    public int jumpPower = 50;
    public int jumpCnt = 0;

    private Vector3 movement;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        movement.Normalize();

        rigid.velocity= movement * speed;  
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < 1)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            jumpCnt++;

        }
        Physics.gravity=new Vector3(0, -50f, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCnt = 0;
        }
    }
} 