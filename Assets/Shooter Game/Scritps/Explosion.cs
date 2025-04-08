using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMove player = collision.GetComponent<PlayerMove>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.CompareTag("Player"))
        {
            player.TakeDamage(damage);
        }
        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }

    }

    public void DestroyBoom()
    {
        Destroy(gameObject);
    }
}
