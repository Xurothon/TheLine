using UnityEngine;
using UnityEngine.UI;

namespace TheLine.UI
{
    [RequireComponent(typeof(Text))]
    public class SkillTimeView : MonoBehaviour
    {
        Text timeView;
        float time;
        bool isRun;


        void Update()
        {
            if (isRun)
            {
                time -= Time.deltaTime;
                timeView.text = time.ToString("F1");
                if (time < 0)
                {
                    isRun = false;
                    gameObject.SetActive(false);
                }
            }
        }

        void Awake()
        {
            timeView = GetComponent<Text>();
        }


        public void Run(float time)
        {
            gameObject.SetActive(true);
            isRun = true;
            this.time = time;
        }
    }
}
