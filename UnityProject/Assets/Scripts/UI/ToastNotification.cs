using UnityEngine;
using TMPro;
using DG.Tweening;

public class ToastNotification : MonoBehaviour
{
    public static ToastNotification Instance;

    public TMP_Text toastText;
    public float showTime = 0.8f;
    public RectTransform rect;

    void Awake()
    {
        Instance = this;
        rect.localScale = Vector3.zero;
    }

    public void Show(string message)
    {
        toastText.text = message;

        rect.DOKill();
        rect.localScale = Vector3.zero;

        Sequence seq = DOTween.Sequence();

        seq.Append(rect.DOScale(new Vector3(4, 4, 4), 0.35f).SetEase(Ease.OutBack));
        seq.AppendInterval(showTime);
        seq.Append(rect.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InBack));
    }
}