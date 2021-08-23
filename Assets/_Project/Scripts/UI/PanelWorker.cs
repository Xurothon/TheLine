using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace TheLine.UI
{
    public class PanelWorker : MonoBehaviour
    {
        public event UnityAction OnGameStarted;


        [SerializeField] Button start;
        [SerializeField] GameObject menuPanel;
        [SerializeField] GameOverPanel gameOverPanel;


        [Inject] TheLine.Player.Player player;
        [Inject] DataWorker dataWorker;
        [Inject] ScoreCounter scoreCounter;


        void Start()
        {
            start.onClick.AddListener(StartGame);
        }

        void OnEnable()
        {
            player.OnDied += PlayerOnDied;
        }

        void OnDisable()
        {
            player.OnDied -= PlayerOnDied;
        }


        public void StartGame()
        {
            menuPanel.SetActive(false);
            OnGameStarted?.Invoke();
        }


        void PlayerOnDied()
        {
            gameOverPanel.gameObject.SetActive(true);
            gameOverPanel.UpdateScores(dataWorker.BestScore, scoreCounter.Score);
        }
    }
}