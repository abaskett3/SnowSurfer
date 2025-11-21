using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] ParticleSystem powerupParticles;

    private InputAction moveAction;
    private Rigidbody2D rigidbody2D;
    private SurfaceEffector2D surfaceEffector2D;
    private bool canControlPlayer;
    private float previousRotation;
    private float totalRotation;
    private uint flipCount;
    private ScoreManager scoreManager;
    private uint powerupCount;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoreManager = FindFirstObjectByType<ScoreManager>();
        canControlPlayer = true;
        powerupCount = 0;
        powerupParticles.Stop();
    }

    void Update()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        if (canControlPlayer)
        {
            RotatePlayer(moveVector);
            BoostPlayer(moveVector);
            CalculateFlips();
        }

    }

    private void RotatePlayer(Vector2 moveVector)
    {
        if (moveVector.x < 0)
        {
            rigidbody2D.AddTorque(torqueAmount);
        }
        if (moveVector.x > 0)
        {
            rigidbody2D.AddTorque(-torqueAmount);
        }
    }

    private void BoostPlayer(Vector2 moveVector)
    {
        surfaceEffector2D.speed = moveVector.y > 0 ? boostSpeed : baseSpeed;
    }

    public void DisableControls()
    {
        canControlPlayer = false;
    }

    private void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        float deltaAngle = Mathf.DeltaAngle(previousRotation, currentRotation);
        totalRotation += deltaAngle;

        //Debug.Log(totalRotation);

        if (totalRotation > 340 || totalRotation < -340)
        {
            flipCount++;
            totalRotation = 0;
            scoreManager.AddScore(1);
        }

        previousRotation = currentRotation;


    }

    public void ActivePowerup(PowerupSO powerup)
    {
        if (powerup.GetPowerupType() == "Speed")
        {
            baseSpeed += powerup.GetValueChange();
            boostSpeed += powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "Torque")
        {
            torqueAmount += powerup.GetValueChange();
        }
        Debug.Log("Incrementing powerup count");
        powerupCount++;
        Debug.Log("Powerup count: " + powerupCount);
        powerupParticles.Play();
    }

    public void DeactivatePowerup(PowerupSO powerup)
    {
        if (powerup.GetPowerupType() == "Speed")
        {
            baseSpeed -= powerup.GetValueChange();
            boostSpeed -= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "Torque")
        {
            torqueAmount -= powerup.GetValueChange();
        }

        Debug.Log("Decrementing powerup count");
        --powerupCount;
        Debug.Log("Powerup count: " + powerupCount);
        CheckAndResetPowerupParticles();
    }

    private void CheckAndResetPowerupParticles()
    {
        Debug.Log("Checking powerup count to possibly stop particles.");
        if (powerupCount == 0)
        {
            Debug.Log(string.Format("Powerup count is {0}. Stopping particles", powerupCount));
            powerupParticles.Stop();
        }
    }
}
