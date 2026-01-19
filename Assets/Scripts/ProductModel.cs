using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ProductModel", menuName = "Scriptable Objects/ProductModel")]
public class ProductModel : ScriptableObject
{
    [SerializeField] private string productName;
    [SerializeField] private float productPrice; // [ ] Почему не видно в инспекторе?
    [SerializeField] private Sprite productSprite; // [ ] Sprite это не Unity.UI?

    public string ProductName => productName;
    public float ProductPrice => productPrice; // [ ] Стоит ли испльзовать decemal в играх?
    public Sprite Sprite => productSprite;
}
