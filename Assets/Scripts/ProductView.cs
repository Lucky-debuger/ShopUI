using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

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
    }

    private void BuyProduct()
    {
        OnBuyClick?.Invoke(_productModel);
    }
}
