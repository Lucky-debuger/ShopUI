using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class ShopWindowView : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private TMP_Text textBalance;
    [SerializeField] private ProductView productViewPrefab;
    [SerializeField] private Transform productsParent;

    public ProductView ProductViewPrefab => productViewPrefab;
    public Transform ProductsParent => productsParent;

    public event Action OnCloseClick;

    private void Awake()
    {
        buttonClose.onClick.AddListener(OnButtonCloseClick);
    }

    public void SetBalance(float balance)
    {
        textBalance.text = balance.ToString();
        PlayJumpBalanceAnimation();
    }

    private void OnButtonCloseClick()
    {
        PlayOnCloseButtonClick();
        OnCloseClick?.Invoke();
    }

    private void PlayJumpBalanceAnimation()
    {
        textBalance.transform.DOKill();
        textBalance.transform.localScale = Vector3.one;

        textBalance.transform.DOScale(1.15f, 0.15f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                textBalance.transform.DOScale(1f, 0.15f)
                    .SetEase(Ease.InQuad);
            });
    }

    private void PlayOnCloseButtonClick()
    {
        buttonClose.transform.DOKill();
        buttonClose.transform.localScale = Vector3.one;

        buttonClose.transform.DOScale(1.15f, 0.15f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                buttonClose.transform.DOScale(1f, 0.15f)
                    .SetEase(Ease.InQuad);
            });
    }
}
