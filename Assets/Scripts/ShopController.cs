using System.Collections.Generic;
using UnityEngine;

public class ShopController
{
    private readonly WalletModel _walletModel;
    private readonly ProductsListModel _productsListModel;
    private readonly ShopWindowView _shopWindowView;
    private readonly List<ProductView> _productViews = new List<ProductView>();

    public ShopController(WalletModel walletModel, ProductsListModel productsListModel, ShopWindowView shopWindowView)
    {
        _walletModel = walletModel;
        _productsListModel = productsListModel;
        _shopWindowView = shopWindowView;
    }

    public void Initialize()
    {
        _shopWindowView.SetBalance(_walletModel.Balance);
        _shopWindowView.OnCloseClick += CloseWindow;

        RenderProducts();
    }

    private void RenderProducts()
    {
        foreach (ProductModel product in _productsListModel.ProductsList)
        {
            ProductView productModelInstance = GameObject.Instantiate(_shopWindowView.ProductViewPrefab, _shopWindowView.ProductsParent);
            productModelInstance.Render(product);
            productModelInstance.OnBuyClick += HandleBuyClick;
            _productViews.Add(productModelInstance);
        }
    }

    private void HandleBuyClick(ProductModel productModel)
    {
        if (_walletModel.TrySpend(productModel.ProductPrice))
        {
            _shopWindowView.SetBalance(_walletModel.Balance);
        }
    }

    private void ClearProducts()
    {
        foreach (ProductView product in _productViews)
        {
            product.OnBuyClick -= HandleBuyClick;
            GameObject.Destroy(product.gameObject);
        }
        _productViews.Clear();
    }

    public void CloseWindow()
    {
        ClearProducts();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}