using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject EndMenu;
    public PlayerControls Player;
    public TMPro.TextMeshProUGUI ScoreText;
    public float ScrollSpead = 1.5f;
    int score = 0;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerControls>();
    }

    public void IncreaseScore() 
    {
        if (Player.isDead)
        {
            return;
        }
        score += 1;
        ScoreText.text = "Score: " + score.ToString();
    }

    #region Buttons
    public void PlayAgain() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit() 
    {
        Application.Quit();
    }
    #endregion

}
