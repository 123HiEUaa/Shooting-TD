using UnityEngine;

public class EnergySlime : Enemy
{
    [SerializeField] private GameObject energyObject;

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

    protected override void Die ()
    {
        if (energyObject != null)
        {
            GameObject energy = Instantiate(energyObject, transform.position, Quaternion.identity);
            Destroy(energy, 5f);
        }
        base.Die();
    }
}
