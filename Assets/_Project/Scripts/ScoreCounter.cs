using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    public int Score => (int)Mathf.Round(_score);
    [SerializeField] private Text _view;
    [Inject] private Player _player;
    [Inject] private PanelWorker _panelWorker;
    [Inject] private DataWorker _dataWorker;
    private bool _isRun;
    private float _score;

    public void Run()
    {
        _isRun = true;
    }

    private void Stop()
    {
        _isRun = false;
        if (Score > _dataWorker.BestScore)
        {
            _dataWorker.UpdateBestScore(Score);
        }
    }

    private void Update()
    {
        if (_isRun)
        {
            _score += Time.deltaTime;
            _view.text = _score.ToString("F0");
        }
    }

    private void OnEnable()
    {
        _player.Die += Stop;
        _panelWorker.GameStart += Run;
    }

    private void OnDisable()
    {
        _player.Die -= Stop;
        _panelWorker.GameStart -= Run;
    }
}
