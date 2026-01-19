using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ProductModel", menuName = "Scriptable Objects/ProductModel")]
public class ProductModel : ScriptableObject
{
    [SerializeField] private string productName;
    [SerializeField] private float productPrice; // [ ] Почему не видно в инспекторе?
    [SerializeField] private Sprite productSprite; // [ ] Sprite это не Unity.UI?

    public string ProductName => productName;
    public decimal ProductPrice => Convert.ToDecimal(productPrice); // [ ] Стоит ли так делать?
    public Sprite Sprite => productSprite;
}
