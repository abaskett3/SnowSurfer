using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] PowerupSO powerup;
    private PlayerController player;
    private int playerLayerIndex;
    private SpriteRenderer spriteRenderer;
    private float timeLeft;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
        playerLayerIndex = LayerMask.NameToLayer("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        timeLeft = powerup.GetTime();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayerIndex && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
            player.ActivePowerup(powerup);
        }
    }

    void FixedUpdate()
    {
        CountDownTimer();
    }

    private void CountDownTimer()
    {
        if (spriteRenderer.enabled == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;

                if (timeLeft <= 0)
                {
                    player.DeactivatePowerup(powerup);
                }
            }
        }
    }
}
