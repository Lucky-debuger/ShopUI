using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductsListModel", menuName = "Scriptable Objects/ProductsListModel")]
public class ProductsListModel : ScriptableObject
{
    [SerializeField] private List<ProductModel> productsList;

    public List<ProductModel> ProductsList => productsList; // [ ] Стоит ли так делать?
}
