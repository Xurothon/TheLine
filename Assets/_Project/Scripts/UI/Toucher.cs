using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TheLine.UI
{
    public class Toucher : MonoBehaviour, IDragHandler, IPointerDownHandler
    {
        [SerializeField] Vector2 borderX;


        [Inject] TheLine.Player.Player player;


        Camera main;
        Vector2 touch;


        public void OnDrag(PointerEventData eventData)
        {
            touch = main.ScreenToViewportPoint(Input.mousePosition);
            player.Move(new Vector2(Mathf.Lerp(borderX.x, borderX.y, touch.x), 0));
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            touch = main.ScreenToViewportPoint(Input.mousePosition);
            player.SetStartPosition(new Vector2(Mathf.Lerp(borderX.x, borderX.y, touch.x), 0));
        }


        void Awake()
        {
            main = Camera.main;
        }
    }
}