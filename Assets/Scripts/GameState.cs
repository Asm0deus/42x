using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private int _scoreCurrent = 0;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        Debug.Log("Старт игры!");
    }

    public void GameOver(int panelNum)
    {
        if (panelNum == 0)
        {
            _winPanel.SetActive(true);
            Debug.Log("Победа!");
        }
        else
        {
            _gameOverPanel.SetActive(true);
            Debug.Log("Проиграл!");
        }

        StartCoroutine(TimeToRestart());
    }

    private IEnumerator TimeToRestart()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);

    }

    public void UpdateScore(int score)
    {
        _scoreCurrent += score;
        _scoreText.text = "You Score: " + _scoreCurrent.ToString();
    }
}
