using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController singleton;
    
    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float bottomBorder;

    public float spawnEnemyStartPosition;

    public bool GamePaused;

    public int PauseTime = 3;

    public GameObject PlayerPrefab;

    Vector3 SpawnPosition;

    public GameObject PauseTimerLabel;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;

            leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
            topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
            bottomBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;

            SpawnPosition = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.04f));

            Respawn();
        }
    }

    public void Respawn()
    {
        Instantiate(PlayerPrefab, SpawnPosition, Quaternion.identity);
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


}

/*
public class GameEvents
{
    public delegate void GameOperation();

    public enum Actions { Pause, InGame };

    //Event gameEvent;

    public Dictionary<Actions, GameOperation> dictionary;

    public GameEvents(){
        dictionary = new Dictionary<Actions, GameOperation>();
    }

    public void AddEvent(Actions action, GameOperation operation)
    {
        dictionary.Add(action, operation);
    }

    public void EventHappens(Actions action)
    {
        if (dictionary[action] != null)
        {
            dictionary[action]();
        }
    }
}
*/
