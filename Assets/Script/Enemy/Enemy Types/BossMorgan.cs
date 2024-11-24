using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMorgan : Enemy
{
    [SerializeField] private MorganShooting morganShotting;
    [SerializeField] private MorganTrainAttack morganTrainAttack;

    public void Shotting(){
        morganShotting.SpawnBulletsCone(this.transform, this.player.transform);
    }

    public void TrainAttack(){
        morganTrainAttack.TrainAttack(this.transform, this.player.transform);
    }

    public void EarthquakeAttack(){
        this.RB.MovePosition(this.player.transform.localPosition);
    }
}
