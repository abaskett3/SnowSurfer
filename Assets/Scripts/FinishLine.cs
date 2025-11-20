using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private int sceneIndex = 0;
    [SerializeField] float ReloadSceneDelay = 1f;

    [SerializeField] ParticleSystem FinishLineParticles;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        if (collision.gameObject.layer == layerIndex)
        {
            FinishLineParticles.Play();
            Invoke("ReloadScene", ReloadSceneDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

