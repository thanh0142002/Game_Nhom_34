using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public bool goodSizeBullet;
    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.GetComponent<Player>().TakeDamage(50);

            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            col.enabled = false;
        }
    }
}
