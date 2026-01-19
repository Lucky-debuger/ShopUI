using UnityEngine;

public class ShopCompositRoot : MonoBehaviour
{
    // [SerializeField] private ShopController shopController; // [ ] Почему его не видно в инспекторе?
    [SerializeField] private ShopWindowView shopWindowView;
    [SerializeField] private WalletModel walletModel;

    private ShopController _shopController;

    private void Awake()
    {
        _shopController = new ShopController(walletModel); // [ ] Я могу создать его только черзе new?

        shopWindowView.Initialize(_shopController);
    }
}
