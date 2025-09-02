using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public PointingSystemScript pointingSystemScript;
    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;

    public void Awake()
    {
        int currentPoints = int.Parse(pointingSystemScript.pointText.text);
        finalScoreText.text = currentPoints.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentPoints > highScore)
        {
            highScoreText.text = currentPoints.ToString();
            PlayerPrefs.SetInt("HighScore", currentPoints);
            PlayerPrefs.Save();
        }
        else
        {
            highScoreText.text = highScore.ToString();
        }
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
