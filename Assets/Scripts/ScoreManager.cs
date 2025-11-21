using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    private uint score;

    void Start()
    {
        score = 0;
        scoreText.text = "Flips: 0";
    }

    public void AddScore(uint score)
    {
        this.score += score;
        scoreText.text = string.Format("Flips: {0}", this.score.ToString("G"));
    }
}
