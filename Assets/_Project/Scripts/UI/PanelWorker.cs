using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class PanelWorker : MonoBehaviour
{
    public event UnityAction GameStart;
    [SerializeField] private Button _start;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [Inject] private Player _player;
    [Inject] private DataWorker _dataWorker;
    [Inject] private ScoreCounter _scoreCounter;

    public void StartGame()
    {
        _menuPanel.SetActive(false);
        GameStart?.Invoke();
    }

    private void GameOver()
    {
        _gameOverPanel.gameObject.SetActive(true);
        _gameOverPanel.UpdateScores(_dataWorker.BestScore, _scoreCounter.Score);
    }

    private void Start()
    {
        _start.onClick.AddListener(StartGame);
    }

    private void OnEnable()
    {
        _player.Die += GameOver;
    }

    private void OnDisable()
    {
        _player.Die -= GameOver;
    }
}