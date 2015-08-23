using UnityEngine;
using System.Collections;

public class IWeapon : MonoBehaviour {
    void playFX() {
        GetComponent<AudioSource>().Play();
    }
}
