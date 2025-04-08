using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 18f;
    [SerializeField] private float timeDestroy = 0.5f;
    [SerializeField] private float damage = 20f;
    [SerializeField] GameObject bloodPrefabs;
    
    void Start()
    {
        Destroy(gameObject , timeDestroy);
    }

    
    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.CompareTag("Enemy"))
        {
            Enemy enemy = bullet.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                GameObject blood = Instantiate(bloodPrefabs, transform.position, Quaternion.identity);
                Destroy(blood, 1f);
            }
            Destroy(gameObject );
        }
    }
}
