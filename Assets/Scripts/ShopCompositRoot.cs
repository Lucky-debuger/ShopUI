using UnityEngine;

public class ShopCompositRoot : MonoBehaviour
{
    // [SerializeField] private ShopController shopController; // [ ] Почему его не видно в инспекторе?
    [SerializeField] private ShopWindowView shopWindowView;
    [SerializeField] private ProductsListModel productsListModel;

    private ShopController _shopController;
    private WalletModel _walletModel;
    private decimal _startBalance = 10000; // [ ] Можно ли как-то вывести в инспекторе?

    private void Awake()
    {
        _walletModel = new WalletModel(_startBalance);
        _shopController = new ShopController(_walletModel, productsListModel, shopWindowView); // [ ] Я могу создать его только черзе new?
        _shopController.Initialize();
        // shopWindowView.Initialize(_shopController);
    }
}
