using UnityEngine;
using Zenject;

public class TimeScale : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float _slowTime;
    [Inject] private Player _player;
    [Inject] private PanelWorker _panelWorker;
    private float _maxTimeSpeed = 1;
    private float _startFixedDeltaTime;

    public void Up()
    {
        Time.timeScale = _maxTimeSpeed;
        Time.fixedDeltaTime = _startFixedDeltaTime;
    }

    public void Down()
    {
        Time.timeScale = _slowTime;
        Time.fixedDeltaTime = Time.fixedDeltaTime * _slowTime;
    }

    private void Awake()
    {
        _startFixedDeltaTime = Time.fixedDeltaTime;
        Down();
    }

    private void OnEnable()
    {
        _player.Die += Down;
        _panelWorker.GameStart += Up;
    }

    private void OnDisable()
    {
        _player.Die -= Down;
        _panelWorker.GameStart -= Up;
    }

    private void OnDestroy()
    {
        Up();
    }
}
