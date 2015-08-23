using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public float speed;

    void FixedUpdate()
    {
        transform.position += (Player.P1.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }
}
