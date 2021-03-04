using TMPro;
using UnityEngine;

public class WalletPresenter : MonoBehaviour
{
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private TMP_Text _scoreCoin;

    private void OnEnable()
    {
        _playerWallet.CoinTaken += OnScoreCoinTaken;
    }

    private void OnDisable()
    {
        _playerWallet.CoinTaken -= OnScoreCoinTaken;
    }

    private void OnScoreCoinTaken(int score)
    {
        _scoreCoin.text = score.ToString();
    }
}
