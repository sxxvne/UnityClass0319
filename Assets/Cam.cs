using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject player;
    private Camera cam;
    private float mouseSpeed = 2000f; //���콺�ǰ���
    private float xrot;
    private float yrot;

    private void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY  = Input.GetAxis("Mouse Y") * (mouseSpeed * Time.deltaTime);
        xrot -= mouseY;
        yrot += mouseX;

        xrot = Mathf.Clamp(xrot, -70f, 70f);
        cam.transform.rotation = Quaternion.Euler(xrot, yrot, 0);
        player.transform.rotation =  Quaternion.Euler(0, yrot, 0);

    }
}