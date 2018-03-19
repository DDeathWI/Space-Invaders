using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController singleton;

    public float leftBorder;
    public float rightBorder;


    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        }
    }

}
