using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TheLine.UI;

namespace TheLine
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] Text view;


        [Inject] TheLine.Player.Player player;
        [Inject] PanelWorker panelWorker;
        [Inject] DataWorker dataWorker;


        bool isRun;
        float score;

        public int Score => (int)Mathf.Round(score);


        void Update()
        {
            if (isRun)
            {
                score += Time.deltaTime;
                view.text = score.ToString("F0");
            }
        }

        void OnEnable()
        {
            player.OnDied += PlayerOnDiedStop;
            panelWorker.OnGameStarted += PanelWorkerOnGameStarted;
        }

        void OnDisable()
        {
            player.OnDied -= PlayerOnDiedStop;
            panelWorker.OnGameStarted -= PanelWorkerOnGameStarted;
        }


        public void PanelWorkerOnGameStarted()
        {
            isRun = true;
        }


        void PlayerOnDiedStop()
        {
            isRun = false;
            if (Score > dataWorker.BestScore)
            {
                dataWorker.UpdateBestScore(Score);
            }
        }
    }
}
