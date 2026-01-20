public class WalletModel
{
    private float _balance;
    public float Balance => _balance;

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
}