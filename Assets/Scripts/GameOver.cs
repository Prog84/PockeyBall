using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private void OnEnable()
    {
        _ball.GameOver += OnGameOver;
    }
    private void OnDisable()
    {
        _ball.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Debug.Log("Уровень пройден!!!");
    }
}
