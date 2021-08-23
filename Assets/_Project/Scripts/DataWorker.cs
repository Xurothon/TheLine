using UnityEngine;
using TheLine.Enum;

namespace TheLine
{
    public class DataWorker : MonoBehaviour
    {
        public int BestScore { get; private set; }


        void Awake()
        {
            ReadAllPlayerPrefs();
        }

        void OnDisable()
        {
            SaveValue(PlayerPrefsKeys.BEST_SCORE, BestScore);
        }


        public void UpdateBestScore(int value)
        {
            BestScore = value;
        }


        void ReadAllPlayerPrefs()
        {
            BestScore = GetValue(PlayerPrefsKeys.BEST_SCORE);
        }

        void SaveValue(PlayerPrefsKeys playerPrefsKey, int value)
        {
            PlayerPrefs.SetInt(playerPrefsKey.ToString(), value);
        }

        int GetValue(PlayerPrefsKeys playerPrefsKey)
        {
            if (PlayerPrefs.HasKey(playerPrefsKey.ToString()))
            {
                return PlayerPrefs.GetInt(playerPrefsKey.ToString());
            }
            return 0;
        }
    }
}
