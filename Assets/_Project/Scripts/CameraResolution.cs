using UnityEngine;

namespace TheLine
{
    public class CameraResolution : MonoBehaviour
    {
        float defaultWidth;
        Camera camera;


        void Start()
        {
            camera = Camera.main;
            float ortSize = 2.5f * Screen.height / Screen.width;
            camera.orthographicSize = ortSize;

        }
    }
}
