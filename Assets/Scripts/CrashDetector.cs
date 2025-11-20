using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    private int sceneIndex = 0;
    [SerializeField] float reloadSceneDelay = 1f;
    [SerializeField] ParticleSystem CrashParticles;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            CrashParticles.Play();
            Invoke("ReloadScene", reloadSceneDelay);
        }


    }
    void ReloadScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}