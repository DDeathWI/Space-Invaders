using UnityEngine;
using UnityEngine.UI;

// Need more work for Use 

public class UserView : MonoBehaviour {

    [SerializeField]
    private GameObject GamePauseTextHolder;

    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private Text LifeText;

    [SerializeField]
    private GameObject GameOverHolder;

    [SerializeField]
    private GameObject FloatingFadingScoreTextHolder;

    public delegate void GameState();

    public event GameState OnGamePause
    {
        add
        {
            OnGamePause += value;
        }
        remove
        {
            OnGamePause -= value;
            GamePauseTextHolder.SetActive(true);
        }
    }

    public event GameState OnGameOver;

    public delegate void ChangeDynamicValues(int value);

    public event ChangeDynamicValues OnChangeScore;

    public event ChangeDynamicValues OnChangeLife;

    public event ChangeDynamicValues OnEnemyDestroy; 


}
