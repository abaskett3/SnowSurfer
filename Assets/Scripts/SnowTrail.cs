using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrailParticles;
    private int floorLayer;

    void Start()
    {
        floorLayer = LayerMask.NameToLayer("Floor");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == floorLayer)
        {
            snowTrailParticles.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == floorLayer)
        {
            snowTrailParticles.Stop();
        }
    }
}
