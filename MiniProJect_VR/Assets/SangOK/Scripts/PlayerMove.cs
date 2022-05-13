using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform player;
    CharacterController cc;
    public float speed = 5;
    float rx;
    float ry;
    public float rotSpeed = 10.0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        player = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
    }

    public float jumpPower = 7f;
    public float gravity = -15f;
    float yVelocity;
    // 다중 점프를 뛰고싶다.
    int jumpCount;
    public int maxJumpCount = 1;

    void Update()
    {
        if (cc.isGrounded)
        {
            jumpCount = 0;
        }
        else
        {
            yVelocity += gravity * Time.deltaTime;
        }

        if (jumpCount < maxJumpCount && Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
            jumpCount++;
        }



        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float mx = Input.GetAxisRaw("Mouse X");
        float my = Input.GetAxisRaw("Mouse Y");

        rx += my * Time.deltaTime * rotSpeed;
        ry += mx * Time.deltaTime * rotSpeed;

        rx = Mathf.Clamp(rx, -70f, 70f);

        player.eulerAngles = new Vector3(-rx, ry, 0);

        Vector3 dir = new Vector3(h, 0, v);


        dir = player.TransformDirection(dir);
        dir.y = 0;
        dir.Normalize();
        Vector3 velocity = dir * speed;
        velocity.y = yVelocity;

        cc.Move(velocity * Time.deltaTime);
    }
}

