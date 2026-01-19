using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ProductView : MonoBehaviour
{
    // [ ] Могу ли дать этому блоку название что-то типо сслыки на компоненты?

    [SerializeField] private Image productIcon;
    [SerializeField] private TMP_Text productName;
    [SerializeField] private TMP_Text productPrice;
    [SerializeField] private Button buyButton;

    private ShopController _shopController;
    private ProductModel _productModel; // [ ] Стоит ли тут хранить?

    private void Awake()
    {
        buyButton.onClick.AddListener(BuyProduct);
    }

    public void Construct(ShopController shopController, ProductModel productModel, Sprite icon, string title, string price) // [ ] price string или int?
    {
        _shopController = shopController;
        _productModel = productModel;

        productIcon.sprite = icon; // [ ] Чем image отличается от spite? Как понять, что использовать?
        productName.text = title;
        productPrice.text = price;
    }

    private void BuyProduct()
    {
        _shopController.BuyProduct(_productModel);
    }
}
