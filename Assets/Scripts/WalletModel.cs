using UnityEngine;

public class WalletModel
{
    private float _balance;
    public float Balance => _balance;

    // public void Initialize() // [ ] Так вообще можно делать у ScriptableObject? 
    // {
    //     _balance = float.TryParse(balance, out float result) ? result : 0m; // [ ] Стоит ли так делать, как я сделал?
    // }

    public WalletModel(float startBalance)
    {
        _balance = startBalance;
    }

    public bool TrySpend(float price)
    {
        if (price > _balance) return false;

        _balance -= price;
        return true;
    }

    // [ ] Еще предлагает сделать bool TrySpend(int amount) зачем?
}
