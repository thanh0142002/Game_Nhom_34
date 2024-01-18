using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
using static Cinemachine.DocumentationSortingAttribute;

public class EnemyAI : MonoBehaviour
{
    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;
    private Transform player; // Tham chiếu đến nhân vật của người chơi
    private SpriteRenderer spriteRenderer; // Tham chiếu đến SpriteRenderer của AI


    public Seeker seeker;
    public bool updateContinuesPath;

    //shoot
    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;

    //Health
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public EnemyHeal HealthBar;
    public Animator animator;

    bool reachDestination = false;
    Path path;
    Coroutine moveCoroutine;
    public levelUp levelup;

    public GameObject Boss;
    public GameMenu gameMenu;
    public AudioClip createPrefabAudio;
    private void Start()
    {
        player = FindObjectOfType<Player>().transform; // Lấy tham chiếu đến nhân vật của người chơi
        spriteRenderer = GetComponent<SpriteRenderer>(); // Lấy tham chiếu đến SpriteRenderer của AI

        Hitpoints = MaxHitpoints;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);

        InvokeRepeating("CalculatePath", 0f, 0.5f);
        reachDestination = true;
        levelup = FindObjectOfType<levelUp>();



    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.x < 0) // Nếu nhân vật của người chơi đang ở bên trái AI
        {
            // Đảo ngược hình ảnh của AI
            spriteRenderer.flipX = true;
        }
        else if (direction.x > 0) // Nếu nhân vật của người chơi đang ở bên phải AI
        {
            // Khôi phục hình ảnh ban đầu của AI
            spriteRenderer.flipX = false;
        }

        fireCooldown -= Time.deltaTime;
        if (fireCooldown < 0) {

            fireCooldown = timeBtwFire;
            //shoot
            EnemyFireBullet();
        }
    }

    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    void CalculatePath()
    {

        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathComplete);

    }

    //tìm player 
    void OnPathComplete(Path p)
    {
        if (p.error) return;
             path = p;
        MovetoTarget();
    }
    void MovetoTarget()
    {
        if (moveCoroutine != null) { StopCoroutine(moveCoroutine); }
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }
    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count) {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
                currentWP++;

            yield return null;
        }

        reachDestination = true;
    }
    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        if (roaming == true)
            return (Vector2)playerPos + (Random.Range(10f, 50f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
        else
            return playerPos;
    }

    //AI cập nhật máu khi bị gây dame
    public void TakeHit(float damege)
    {
        Hitpoints -= damege;
        HealthBar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0 && !Boss)
        {
            levelup.levelup();
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(createPrefabAudio, transform.position);
        }
        if (Hitpoints <= 0 && Boss) 
        {
            Destroy(gameObject);
            gameMenu.gameWin();
            AudioSource.PlayClipAtPoint(createPrefabAudio, transform.position);
            Time.timeScale = 0f;
        }
    }
}
