using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer rbSprite;
    private Animator anim;
    [SerializeField] private float maxHp = 100f;
    private float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rbSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        currentHP = maxHp;
        UpdateHpBar();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.PauseMenu();
        }
    }
    private void MovePlayer()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = playerInput.normalized * moveSpeed;

        if (playerInput.x < 0)
        {
            rbSprite.flipX = true;
        }
        else if (playerInput.x > 0 )
        {
            rbSprite.flipX = false;
        }

        if (playerInput != Vector2.zero)
        {
            anim.SetBool("IsRunning", true);
        }
        else 
        {
            anim.SetBool("IsRunning", false);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        UpdateHpBar();
        if (currentHP <=0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameManager.GameOverMenu();
    }
    private void UpdateHpBar()
    {
        if (hpBar != null) 
        {
            hpBar.fillAmount = currentHP / maxHp;
        }
    }
    
}
