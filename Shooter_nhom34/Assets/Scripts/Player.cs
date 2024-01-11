using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public float _speed = 10f;
    private Vector3 moveInput;
    public Animator animator;

    //health
    [SerializeField] int maxHealth;
    int currentHealth;

    public HealthBar healthBar;

    public UnityEvent OnDeath;

    public GameMenu gameMenu;



    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }
    //

    private void Start()
    {


        animator = GetComponent<Animator>();
        // health
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);


    }

    // cap nhat mau Player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameMenu.gameOver();
            OnDeath.Invoke();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    //

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
