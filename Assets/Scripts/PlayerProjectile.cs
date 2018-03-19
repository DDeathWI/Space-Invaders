using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    [SerializeField]
    private float speed = 1;
    
    // Update is called once per frame
    void LateUpdate () {
        transform.Translate(new Vector2(0, speed));
    }

}

