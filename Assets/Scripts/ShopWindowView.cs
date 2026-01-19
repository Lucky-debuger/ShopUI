using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindowView : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private TMP_Text textBalance;
    [SerializeField] private ProductView productViewPrefab;
    [SerializeField] private Transform productsParent;

    [SerializeField] private ProductsListModel productsList; // [ ] Стоит ли сюда это запихивать?

    private ShopController _shopController;

    private void Awake()
    {
        buttonClose.onClick.AddListener(CloseWindow); // [ ] Стоит ли так писать?
    }

    // private void OnEnable() // [ ] Почему не всегда успевает срабатывать?
    // {
    //     _shopController.OnBuyProduct += UpdateBalance;
    // }

    private void OnDisable()
    {
        _shopController.OnBuyProduct -= UpdateBalance;
    }

    public void Initialize(ShopController shopController)
    {
        _shopController = shopController;
        Construct(productsList);
        _shopController.OnBuyProduct += UpdateBalance;
    }

    private void Construct(ProductsListModel productsList) // [ ] Может она вообще не нужна?
    {
        RenderProducts(productsList);

        textBalance.text = _shopController.GetBalance().ToString();
    }

    private void UpdateBalance(float balance)
    {
        textBalance.text = balance.ToString();
    }

    private void RenderProducts(ProductsListModel productsList)
    {
        foreach (ProductModel product in productsList.ProductsList)
        {
            ProductView productViewInstance = Instantiate(productViewPrefab, productsParent);

            productViewInstance.Construct(_shopController, product, product.Sprite, product.ProductName, product.ProductPrice.ToString());
        }
    }

    private void CloseWindow()
    {
        _shopController.CloseWindow();
    }
}
