using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public float speed;

    public GameObject splashPrefab;

    void FixedUpdate()
    {
        transform.position += (Player.P1.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }

    public void die()
    {
        GameObject clone = Instantiate(splashPrefab, transform.position, Quaternion.Euler(0, 180, Random.Range(0, 360))) as GameObject;
        Destroy(clone.gameObject, 10);
        Destroy(gameObject, 0.5f);
    }
}
