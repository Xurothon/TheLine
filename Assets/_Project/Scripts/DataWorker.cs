using UnityEngine;

public class DataWorker : MonoBehaviour
{
    public int BestScore { get; private set; }

    public void UpdateBestScore(int value)
    {
        BestScore = value;
    }

    private void ReadAllPlayerPrefs()
    {
        BestScore = GetValue(PlayerPrefsKeys.BEST_SCORE);
    }

    private void SaveValue(PlayerPrefsKeys playerPrefsKey, int value)
    {
        PlayerPrefs.SetInt(playerPrefsKey.ToString(), value);
    }

    private int GetValue(PlayerPrefsKeys playerPrefsKey)
    {
        if (PlayerPrefs.HasKey(playerPrefsKey.ToString()))
        {
            return PlayerPrefs.GetInt(playerPrefsKey.ToString());
        }
        return 0;
    }

    private void Awake()
    {
        ReadAllPlayerPrefs();
    }

    private void OnDisable()
    {
        SaveValue(PlayerPrefsKeys.BEST_SCORE, BestScore);
    }
}
