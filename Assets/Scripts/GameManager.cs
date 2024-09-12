using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    public Text scoreText;
    //public GameObject playButton;
    //public GameObject gameOver;
    
    //public void Play()
    //{
    //    score = 0;
    //    scoreText.text = score.ToString();

    //    //playButton.SetActive(false);
    //    //gameOver.SetActive(false);
    //}

    public void GameOver()
    {
        //gameOver.SetActive(true);
        //playButton.SetActive(true);
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
