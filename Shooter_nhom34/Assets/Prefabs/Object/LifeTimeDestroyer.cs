using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float Time;

    void Start()
    {
        Destroy(this.gameObject, Time);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyAI>();
        if (enemy)
            enemy.TakeHit(1);

        Destroy(gameObject);
    }

    // Update is called once per frame
}
