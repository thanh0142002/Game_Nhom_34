using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float Time;
    public bool BulletOfPlayer;
    private CircleCollider2D col;

    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        Destroy(this.gameObject, Time);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !BulletOfPlayer)
        {
            collision.GetComponent<Player>().TakeDamage(10);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy") && BulletOfPlayer)
        {
            collision.GetComponent<EnemyAI>().TakeHit(1);
            Destroy(gameObject);
        }
    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && BulletOfPlayer)
        {
            collision.collider.GetComponent<EnemyAI>().TakeHit(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player") && !BulletOfPlayer)
        {
            collision.collider.GetComponent<Player>().TakeDamage(20);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && !BulletOfPlayer)
        {
            col.isTrigger = true;
            col.isTrigger = false;
        }
    }*/

}
