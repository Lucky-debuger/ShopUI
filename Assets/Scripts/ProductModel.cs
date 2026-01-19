using UnityEngine;

[CreateAssetMenu(fileName = "ProductModel", menuName = "Scriptable Objects/ProductModel")]
public class ProductModel : ScriptableObject
{
    [SerializeField] private string productName;
    [SerializeField] private float productPrice;
    [SerializeField] private Sprite productSprite; // [ ] Sprite это не Unity.UI?

    public string ProductName => productName;
    public float ProductPrice => productPrice;
    public Sprite Sprite => productSprite;
}
