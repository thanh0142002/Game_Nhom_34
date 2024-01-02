using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun1 : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire = 0.2f;
    public float bulletForce;
    private float timeBtwFire;


    public float _speed = 10f;
    private Vector3 moveInput;
    public Animator animator;

    void Update()
    {
        // Xử lý di chuyển
        if (Input.GetKey(KeyCode.A))
        {
            moveInput.x = -_speed;
            transform.localScale = new Vector3(-0.5f, 0.5f, 0);

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

        RotateGun();
        timeBtwFire -= Time.deltaTime;

        if(Input.GetMouseButton(0) && timeBtwFire <0)
        {
            FireBullet();
        }

       
    }
    
   void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(6, -6, 0);
        else
            transform.localScale = new Vector3(6, 6, 0);

    }

    void FireBullet()
    {
        timeBtwFire = TimeBtwFire;
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
