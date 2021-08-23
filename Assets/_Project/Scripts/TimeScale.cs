using UnityEngine;
using Zenject;
using TheLine.UI;

namespace TheLine
{
    public class TimeScale : MonoBehaviour
    {
        [SerializeField] [Range(0, 1)] float slowTime;


        [Inject] TheLine.Player.Player player;
        [Inject] PanelWorker panelWorker;


        float _maxTimeSpeed = 1;
        float _startFixedDeltaTime;


        void Awake()
        {
            _startFixedDeltaTime = Time.fixedDeltaTime;
            Down();
        }

        void OnEnable()
        {
            player.OnDied += Down;
            panelWorker.OnGameStarted += Up;
        }

        void OnDisable()
        {
            player.OnDied -= Down;
            panelWorker.OnGameStarted -= Up;
        }

        void OnDestroy()
        {
            Up();
        }


        public void Up()
        {
            Time.timeScale = _maxTimeSpeed;
            Time.fixedDeltaTime = _startFixedDeltaTime;
        }

        public void Down()
        {
            Time.timeScale = slowTime;
            Time.fixedDeltaTime = Time.fixedDeltaTime * slowTime;
        }
    }
}