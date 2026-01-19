using UnityEngine;

public class WalletModel
{
    private decimal _balance;
    public decimal Balance => _balance;

    // public void Initialize() // [ ] Так вообще можно делать у ScriptableObject? 
    // {
    //     _balance = decimal.TryParse(balance, out decimal result) ? result : 0m; // [ ] Стоит ли так делать, как я сделал?
    // }

    public WalletModel(decimal startBalance)
    {
        _balance = startBalance;
    }

    public bool TrySpend(decimal price)
    {
        if (price > _balance) return false;

        _balance -= price;
        return true;
    }

    // [ ] Еще предлагает сделать bool TrySpend(int amount) зачем?
}
