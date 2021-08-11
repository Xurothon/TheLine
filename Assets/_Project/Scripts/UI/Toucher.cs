using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Toucher : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Vector2 _borderX;
    [Inject] private Player _player;
    private Camera _main;
    private Vector2 _touch;

    public void OnDrag(PointerEventData eventData)
    {
        _touch = _main.ScreenToViewportPoint(Input.mousePosition);
        _player.Move(new Vector2(Mathf.Lerp(_borderX.x, _borderX.y, _touch.x), 0));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _touch = _main.ScreenToViewportPoint(Input.mousePosition);
        _player.SetStartPosition(new Vector2(Mathf.Lerp(_borderX.x, _borderX.y, _touch.x), 0));
    }

    private void Awake()
    {
        _main = Camera.main;
    }
}