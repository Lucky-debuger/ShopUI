using UnityEngine;

[CreateAssetMenu(fileName = "WalletModel", menuName = "Scriptable Objects/WalletModel")]
public class WalletModel : ScriptableObject
{
    [SerializeField] private float balance; // [ ] Почему значение менятеся каждый раз при покупке?

    public float Balance => balance;

    public void TryBuy(float price) // [ ] buy должна быть тут или в controller?
    {
        if (balance < price) return;

        balance -= price;
    }

    // [ ] Еще предлагает сделать bool TrySpend(int amount) зачем?
}
