using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float Time;
    public bool BulletOfPlayer;
    private Collider col;

    void Start()
    {
        col = GetComponent<Collider>();
        Destroy(this.gameObject, Time);
    }
    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && !goodSizeBullet)
                collision.GetComponent<Player>().TakeDamage(5);
            Destroy(gameObject);
            if (collision.CompareTag("Enemy") && goodSizeBullet)
                collision.GetComponent<EnemyAI>().TakeHit(1);
            Destroy(gameObject);
        }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*var enemy = collision.collider.GetComponent<EnemyAI>();
        if (enemy)
            enemy.TakeHit(1);

        Destroy(gameObject);*/
        if (collision.gameObject.CompareTag("Player") && !BulletOfPlayer)
        {
            collision.collider.GetComponent<Player>().TakeDamage(5);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && BulletOfPlayer)
        {
            collision.collider.GetComponent<EnemyAI>().TakeHit(1);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && !BulletOfPlayer)
        {
            col.enabled = false;
        }
    }

}
