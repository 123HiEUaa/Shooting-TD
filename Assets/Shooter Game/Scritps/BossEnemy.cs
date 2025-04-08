using UnityEngine;

public class BossEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float speedDanThuong = 40f;
    [SerializeField] private float speedDanVongTron = 30f;
    [SerializeField] private float skillCoolDown = 2f;
    private float nextSKillTime = 0f;
    [SerializeField] private GameObject awardPrefabs;

    protected override void Update()
    {
        base.Update();
        if (Time.time >= nextSKillTime)
        {
            UseSKill();
        }
    }

    protected override void Die()
    {
        Instantiate(awardPrefabs, transform.position,Quaternion.identity);
        base.Die(); 
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(stayDamage);
            }
        }
    }

    private void BanDanThuong()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.transform.position - firePoint.position;
            directionToPlayer.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(directionToPlayer * speedDanThuong);
        }
    }

    private void BanDanVongTron()
    {
        const int bulletCount = 30;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position,Quaternion.identity);
            EnemyBullet enemyBullet = bullet.AddComponent<EnemyBullet>();
            enemyBullet.SetMovementDirection(bulletDirection * speedDanVongTron);
        }
    }


    private void DichChuyen()
    {
        if (player != null)
        {
            transform.position = player.transform.position;
        }
    }
    private void RandomSkill()
    {
        int randomSkill = Random.Range(0, 3);
        switch(randomSkill) 
        {
            case 0:
                BanDanThuong();
                break;
            case 1:
                BanDanVongTron();
                break;
            case 2:
                DichChuyen();
                break;
        }
    }
    private void UseSKill()
    {
        nextSKillTime = Time.time + skillCoolDown;
        RandomSkill();
    }
}
