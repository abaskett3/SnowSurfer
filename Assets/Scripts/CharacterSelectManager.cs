using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{

    [SerializeField] GameObject ScoreCanvas;
    [SerializeField] GameObject DinoSprite;
    [SerializeField] GameObject FrogSprite;
    void Start()
    {
        //Pause that ish while the homies select their characters
        Time.timeScale = 0;
        ScoreCanvas.SetActive(false);
        gameObject.SetActive(true);
    }

    void BeginGame()
    {
        //Unpause the game when character selection is done
        Time.timeScale = 1;
        ScoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        DinoSprite.SetActive(true);
        //FrogSprite.SetActive(false);
        BeginGame();
    }

    public void ChooseFrog()
    {
        FrogSprite.SetActive(true);
        //DinoSprite.SetActive(false);
        BeginGame();
    }

}
