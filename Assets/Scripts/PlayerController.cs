﻿using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movement_speed = 0.1f;

    [SerializeField]
    private GameObject projectile_prefab;

    [SerializeField]
    private Transform projectile_start_position;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	private void Update () {
        Move();

        Shooting();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, GameController.singleton.leftBorder, GameController.singleton.rightBorder), transform.position.y);

    }

    /// <summary>
    /// Player Move
    /// </summary>
    private void Move() {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(movement_speed, 0));
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-movement_speed, 0));
        }
    }


    /// <summary>
    /// Player Shooting
    /// </summary>
    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(projectile_prefab, projectile_start_position, false);

            Destroy(projectile, 3); 
        }
    }
}
