using UnityEngine;

public class BasicSlime : Enemy
{
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
    
   
}
