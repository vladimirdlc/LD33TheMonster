using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    public float speed;
    public float damageAmount;
    public int score = 10;
    public int healthBonus = 1;

    public GameObject splashPrefab;

    void FixedUpdate()
    {
        transform.position += (Player.P1.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }

    public void die()
    {
        ScoreHandler.Instance.addScore(score);
        speed = 0;
        GetComponent<Collider2D>().enabled = false;
        GameObject clone = Instantiate(splashPrefab, transform.position, Quaternion.Euler(0, 180, Random.Range(0, 360))) as GameObject;
        GetComponent<AudioSource>().Play();
        Healthbar.Instance.heal(healthBonus);
        Destroy(clone.gameObject, 10);
        Destroy(gameObject, 0.5f);
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Healthbar.Instance.damage(damageAmount);
        }
    }

}
