using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TheLine.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] string bestScorePrefix;
        [SerializeField] Text bestScore;
        [SerializeField] string scorePrefix;
        [SerializeField] Text score;
        [SerializeField] Button menu;


        void Awake()
        {
            menu.onClick.AddListener(RestartLevel);
        }


        public void UpdateScores(int bestScore, int score)
        {
            this.bestScore.text = bestScorePrefix + bestScore.ToString();
            this.score.text = scorePrefix + score.ToString();
        }

        public void RestartLevel()
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index);
        }
    }
}
