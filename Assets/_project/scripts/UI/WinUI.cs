using UnityEngine;
using DG.Tweening;


public class WinUI : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, 0.2f).SetDelay(1f);
    }
    public void Hide()
    {
        _canvasGroup.DOFade(0, 0.2f).OnComplete(() => gameObject.SetActive(false));
    }
}
