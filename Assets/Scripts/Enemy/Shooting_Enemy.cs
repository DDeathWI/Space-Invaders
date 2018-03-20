using System.Collections;
using UnityEngine;

public class Shooting_Enemy : Normal_Enemy {

    [SerializeField]
    private float ShootingTime;

    [SerializeField]
    protected GameObject Enemy_Projectile;

    [SerializeField]
    protected Transform Projectile_Start_Position;

    protected override void Awake()
    {
        base.Awake();

        StartCoroutine(ShootingManager(ShootingTime));
    }

    protected IEnumerator ShootingManager(float _timeShot)
    {
        while (true)
        {
            if (!GameController.singleton.GamePaused)
            {
                Shooting();
                yield return new WaitForSecondsRealtime(_timeShot);
            }
            else {
                yield return null;
            }

        }
    }

    protected void Shooting()
    {
        Instantiate(Enemy_Projectile, Projectile_Start_Position.position, Quaternion.identity);
    }
}
