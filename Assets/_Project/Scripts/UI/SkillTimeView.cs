using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SkillTimeView : MonoBehaviour
{
    private Text _timeView;
    private float _time;
    private bool _isRun;

    public void Run(float time)
    {
        gameObject.SetActive(true);
        _isRun = true;
        _time = time;
    }

    private void Update()
    {
        if (_isRun)
        {
            _time -= Time.deltaTime;
            _timeView.text = _time.ToString("F1");
            if (_time < 0)
            {
                _isRun = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void Awake()
    {
        _timeView = GetComponent<Text>();
    }
}
