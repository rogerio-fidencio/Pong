using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Paddles")]
    public Transform playerOnePaddle;
    public Transform playerTwoPaddle;

    [Header("Ball")]
    public BallController ballController;

    [Header("Score")]
    public int playerOneScore = 0;
    public int playerTwoScore = 0;
    public TextMeshProUGUI textPointsPlayerOne;
    public TextMeshProUGUI textPointsPlayerTwo;
    public int winPoints;

    [Header("End Game")]
    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;


    void Start()
    {
        ResetGame();
    }
    public void ResetGame()
    {
        playerOnePaddle.position = new Vector3(-7f, 0f, 0f);
        playerTwoPaddle.position = new Vector3(7f, 0f, 0f);
        ballController.ResetBall();

        playerOneScore = 0;
        playerTwoScore = 0;
        textPointsPlayerOne.text = playerOneScore.ToString();
        textPointsPlayerTwo.text = playerTwoScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayerOne()
    {
        playerOneScore++;
        textPointsPlayerOne.text = playerOneScore.ToString();
        CheckWin();
    }
    public void ScorePlayerTwo()
    {
        playerTwoScore++;
        textPointsPlayerTwo.text = playerTwoScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (playerTwoScore >= winPoints || playerOneScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerOneScore > playerTwoScore);
        textEndGame.text = "Vitória " + winner;
        SaveController.Instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
