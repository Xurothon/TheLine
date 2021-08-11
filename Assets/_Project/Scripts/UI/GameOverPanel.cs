using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private string _bestScorePrefix;
    [SerializeField] private Text _bestScore;
    [SerializeField] private string _scorePrefix;
    [SerializeField] private Text _score;
    [SerializeField] private Button _menu;

    public void UpdateScores(int bestScore, int score)
    {
        _bestScore.text = _bestScorePrefix + bestScore.ToString();
        _score.text = _scorePrefix + score.ToString();
    }

    public void RestartLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    private void Awake()
    {
        _menu.onClick.AddListener(RestartLevel);
    }

}
