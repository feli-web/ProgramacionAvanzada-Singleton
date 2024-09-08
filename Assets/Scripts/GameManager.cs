using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin = 10;
    private int currentScore = 0;
    public TextMeshProUGUI scoreText;

    void Update()
    {
   
        if (Input.GetKeyDown(KeyCode.P) && currentScore < scoreToWin)
        {
            currentScore++;
            scoreText.text = currentScore.ToString("D2");
        }
        if (currentScore >= scoreToWin)
        {
            LevelComplete();
        }
    }

    private void LevelComplete()
    {
        SoundManager.Instance.PlaySound("explosion"); 
        scoreText.text = "Level Complete!!";
        Invoke("Restart", 0.5f);
    }
    private void Restart()
    {
        SoundManager.Instance.StopSound();
        scoreText.text = currentScore.ToString("D2");
        currentScore = 0;
    }
}
