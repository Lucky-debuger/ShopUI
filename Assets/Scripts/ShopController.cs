using System;
using UnityEngine;
public class ShopController
{
    private readonly WalletModel _walletModel; // [ ] Зачем readonly?
    private readonly ProductsListModel _productsListModel;
    private readonly ShopWindowView _shopWindowView;

    public ShopController(WalletModel walletModel, ProductsListModel productsListModel, ShopWindowView shopWindowView)
    {
        _walletModel = walletModel;
        _productsListModel = productsListModel;
        _shopWindowView = shopWindowView;

        // Initialize(); // [ ] Тут или лучше в CompositionRoot? Да
    }

    public void Initialize()
    {
        _shopWindowView.SetBalance(_walletModel.Balance);

        foreach (ProductModel product in _productsListModel.ProductsList)
        {
            ProductView productModelInstance = GameObject.Instantiate(_shopWindowView.ProductViewPrefab, _shopWindowView.ProductsParent);
            productModelInstance.Render(product);
            productModelInstance.OnBuyClick += HandleByClick;
        }
    }

    private void HandleByClick(ProductModel productModel)
    {
        if (_walletModel.TrySpend(productModel.ProductPrice))
        {
            _shopWindowView.SetBalance(_walletModel.Balance);
        }
    }

    public void CloseWindow()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}