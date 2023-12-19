using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed = 10f;
    private Vector3 moveInput;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Xử lý di chuyển
        if (Input.GetKey(KeyCode.A))
        {
            moveInput.x = -_speed;
            transform.localScale = new Vector3(-0.5f ,0.5f , 0);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput.x = _speed;
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
        else
        {
            moveInput.x = 0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveInput.y = _speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveInput.y = -_speed;
        }
        else
        {
            moveInput.y = 0f;
        }

        // Cập nhật vị trí
        transform.position += moveInput * Time.deltaTime;
        animator.SetFloat("speed", moveInput.sqrMagnitude);
    }
}
