using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;
using System.Collections;
using DG.Tweening;


public class ProductView : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image productIcon;
    [SerializeField] private TMP_Text productName;
    [SerializeField] private TMP_Text productPrice;
    [SerializeField] private Button buyButton;

    private ProductModel _productModel;

    public event Action<ProductModel> OnBuyClick;

    private void Awake()
    {
        buyButton.onClick.AddListener(BuyProduct);
    }

    public void Render(ProductModel productModel)
    {
        _productModel = productModel;

        productIcon.sprite = productModel.Sprite;
        productName.text = productModel.ProductName;
        productPrice.text = productModel.ProductPrice.ToString();

        PlayPopAnimation();
    }

    private void BuyProduct()
    {
        PlayBuyButtonClickAnimation();
        UIAudioManager.Instance.PlayBuy();
        OnBuyClick?.Invoke(_productModel);
    }

    private void PlayPopAnimation()
    {
        transform.localScale = Vector3.one * 0.5f;

        transform.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
    }

    private void PlayBuyButtonClickAnimation()
    {
        buyButton.transform.DOKill();
        buyButton.transform.DOScale(0.9f, 0.07f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                buyButton.transform.DOScale(1f, 0.07f)
                   .SetEase(Ease.InQuad);
            });
    }
}
