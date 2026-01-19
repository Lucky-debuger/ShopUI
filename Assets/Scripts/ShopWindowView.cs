using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopWindowView : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private TMP_Text textBalance;
    [SerializeField] private ProductView productViewPrefab; // [ ] Имеет ли смысл тут теперь его оставлять?
    [SerializeField] private Transform productsParent; // [ ] Имеет ли смысл тут теперь его оставлять?

    public ProductView ProductViewPrefab => productViewPrefab;
    public Transform ProductsParent => productsParent;

    public event Action OnCloseClick;

    private void Awake()
    {
        buttonClose.onClick.AddListener(OnButtonCloseClick); // [ ] Стоит ли так писать?
    }

    // private void OnEnable() // [ ] Почему не всегда успевает срабатывать?
    // {
    //     _shopController.OnBuyProduct += UpdateBalance;
    // }

    // private void OnDisable()
    // {
    //     _shopController.OnBuyProduct -= SetBalance;
    // }

    // public void Initialize(ShopController shopController)
    // {
    //     _shopController = shopController;
    //     Construct(productsList);
    //     _shopController.OnBuyProduct += SetBalance;
    // }

    // private void Construct(ProductsListModel productsList) // [ ] Может она вообще не нужна?
    // {
    //     RenderProducts(productsList);

    //     textBalance.text = _shopController.GetBalance().ToString();
    // }

    public void SetBalance(float balance)
    {
        textBalance.text = balance.ToString();
    }

    // private void RenderProducts(ProductsListModel productsList)
    // {
    //     foreach (ProductModel product in productsList.ProductsList)
    //     {
    //         ProductView productViewInstance = Instantiate(productViewPrefab, productsParent);

    //         productViewInstance.Render(_shopController, product);
    //     }
    // }

    // private void CloseWindow()
    // {
    //     _shopController.CloseWindow();
    // }

    private void OnButtonCloseClick() // [ ] Стоит ли оставить так имя? И вообще стоит ли так издавать сигнал?   
    {
        OnCloseClick?.Invoke();
    }
}
