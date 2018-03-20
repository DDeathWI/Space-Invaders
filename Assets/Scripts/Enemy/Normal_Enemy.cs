using UnityEngine;

public class Normal_Enemy : Enemy {

    [SerializeField]
    protected float DownSpeed;

    protected virtual void Start()
    {
        EnemyController.moveObserver.AddEvent(EnemyMoveObserver.Destionation.Right, ChangeDestination);


    }

    protected virtual void LateUpdate()
    {
        //
        if (transform.position.x + Collider2D.size.x / 2 >= GameController.singleton.rightBorder - 0.2f)
        {
            //false

            EnemyController.moveObserver.EventHappens(EnemyMoveObserver.Destionation.Right, false, DownSpeed);
            EnemyController.moveObserver.AddEvent(EnemyMoveObserver.Destionation.Left, ChangeDestination);
        }
        else if (transform.position.x - Collider2D.size.x / 2 <= GameController.singleton.leftBorder + 0.2f)
        {
            //true
            EnemyController.moveObserver.EventHappens(EnemyMoveObserver.Destionation.Left, true, DownSpeed);
            EnemyController.moveObserver.AddEvent(EnemyMoveObserver.Destionation.Right, ChangeDestination);
        }
    }

    protected void ChangeDestination(bool value, float _downSpeed)
    {
        EnemyController.HitScreenEdge(value, _downSpeed);
    }

}
