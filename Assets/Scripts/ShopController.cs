using System;
using UnityEngine;
public class ShopController
{
    private WalletModel _walletModel;

    public event Action<float> OnBuyProduct;

    public ShopController(WalletModel walletModel)
    {
        _walletModel = walletModel;
    }

    public void BuyProduct(ProductModel productModel)
    {
        _walletModel.TryBuy(productModel.ProductPrice);
        OnBuyProduct?.Invoke(_walletModel.Balance);
    }

    public float GetBalance()
    {
        return _walletModel.Balance;
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