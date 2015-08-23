using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(coll.gameObject);
    }
}
