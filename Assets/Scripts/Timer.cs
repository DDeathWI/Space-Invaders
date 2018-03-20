using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    float startTime;

    Text showTimeText;

    private void Awake()
    {
       showTimeText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        startTime = Time.realtimeSinceStartup;
        showTimeText.text = GameController.singleton.PauseTime.ToString();
    }

    private void Update()
    {
        int timePassed = (int)(Time.realtimeSinceStartup - startTime);
        showTimeText.text = (GameController.singleton.PauseTime - timePassed).ToString();
    }

}
