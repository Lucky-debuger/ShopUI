using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class ProductView : MonoBehaviour
{
    // [ ] Могу ли дать этому блоку название что-то типо сслыки на компоненты?

    [SerializeField] private Image productIcon;
    [SerializeField] private TMP_Text productName;
    [SerializeField] private TMP_Text productPrice;
    [SerializeField] private Button buyButton;

    // private ShopController _shopController; // [ ] Почему view не должен знать о controller?
    private ProductModel _productModel; // [ ] Стоит ли тут хранить?

    public event Action<ProductModel> OnBuyClick;

    private void Awake()
    {
        buyButton.onClick.AddListener(BuyProduct);
    }

    public void Render(ProductModel productModel) // [ ] price string или int?
    {
        _productModel = productModel;

        productIcon.sprite = productModel.Sprite; // [ ] Чем image отличается от spite? Как понять, что использовать?
        productName.text = productModel.ProductName;
        productPrice.text = productModel.ProductPrice.ToString();
    }

    private void BuyProduct()
    {
        // _shopController.BuyProduct(_productModel); // [ ] Почему нельзя вызывать напрямую?
        OnBuyClick?.Invoke(_productModel);
    }
}
