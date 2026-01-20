using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopWindowView : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private TMP_Text textBalance;
    [SerializeField] private ProductView productViewPrefab;
    [SerializeField] private Transform productsParent;

    public ProductView ProductViewPrefab => productViewPrefab;
    public Transform ProductsParent => productsParent;

    public event Action OnCloseClick;

    private void Awake()
    {
        buttonClose.onClick.AddListener(OnButtonCloseClick);
    }

    public void SetBalance(float balance)
    {
        textBalance.text = balance.ToString();
    }

    private void OnButtonCloseClick()
    {
        OnCloseClick?.Invoke();
    }
}
