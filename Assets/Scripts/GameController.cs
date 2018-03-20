using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController singleton;

    public bool GamePaused;

    public bool GameOver;

    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float bottomBorder;

    public int PauseTime = 3;

    public GameObject PlayerPrefab;

    Vector3 SpawnPosition;

    public GameObject PauseTimerLabel;

    public Text ScoreTxt;

    public Text LifeTxt;


    public GameObject EndPanel;

    private int Score;


    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
             
            
            PauseTime = 3;
            GameOver = false;
            leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
            topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
            bottomBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;

            SpawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.04f));

            Respawn();
        }

    }

    private void Respawn()
    {
        Score = 0;

        Instantiate(PlayerPrefab, SpawnPosition, Quaternion.identity);
        StartCoroutine(Pause(PauseTime));   
    }

    public void ReAppear(Transform _transform)
    {
        _transform.position = SpawnPosition;
        StartCoroutine(Pause(PauseTime));
    }


    private IEnumerator Pause(int _time)
    {
        GamePaused = true;
        PauseTimerLabel.SetActive(true);
        yield return new WaitForSecondsRealtime(_time);
        GamePaused = false;
        PauseTimerLabel.SetActive(false);
    }

    public void SetLife(int life)
    {
        LifeTxt.text = "Life:" + life;
    }

    public void AddScore(int score)
    {
        Score += score;
        ScoreTxt.text = "Score:" + Score;
    }


}


