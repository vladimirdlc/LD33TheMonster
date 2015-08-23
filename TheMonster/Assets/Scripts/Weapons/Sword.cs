using UnityEngine;
using System.Collections;

public class Sword : IWeapon {
    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.gameObject.GetComponent<EnemyScript>().die();
    }
}
