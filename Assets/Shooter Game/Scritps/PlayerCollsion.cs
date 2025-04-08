using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField]private AudioManager audioManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            PlayerMove player = GetComponent<PlayerMove>();
            player.TakeDamage(10f);
        }
        else if (collision.CompareTag("cup"))
        {
            gameManager.WinGame();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Energy"))
        {
            gameManager.AddEnergy();
            Destroy(collision.gameObject);
            audioManager.PlayEnergySound();
        }
    }
    
}
