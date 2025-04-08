using UnityEngine;

public class KaBoomEnemy : Enemy
{
    [SerializeField] private GameObject boomPrefabs;
    private void CreateBoom()
    {
        if (boomPrefabs != null)
        {
            Instantiate(boomPrefabs, transform.position, Quaternion.identity);
        }
    }
    protected override void Die()
    {
        CreateBoom();
        base.Die();
    }
    private void OnTriggerEnter2D(Collider2D boom)
    {
        if (boom.CompareTag("Player"))
        {
            CreateBoom();
        }
    }
}
