using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coins;

    public event UnityAction<int> CoinTaken;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            IncreaseCoin();
            Destroy(coin.gameObject);
        }
    }

    private void IncreaseCoin()
    {
        _coins++;
        CoinTaken?.Invoke(_coins);
    }
}
