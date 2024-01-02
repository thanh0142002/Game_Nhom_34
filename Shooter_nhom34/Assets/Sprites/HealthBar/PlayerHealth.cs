using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
/*    [SerializeField] int maxHealth;
    int currentHealth;

    public HealthBar healthBar;

    public UnityEvent OnDeath;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    public void Start()
    {
        currentHealth = maxHealth;

        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateBar(currentHealth, maxHealth);
        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            OnDeath.Invoke();  
        }
    }

    public void Death() 
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }*/


}
