using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Vector3 spawnPosition;
    public float deathDistance = 10f;

    // Start is called before the first frame update
    void Start() {
        spawnPosition = transform.position;
        //gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    // Update is called once per frame
    void Update() {
        if (Vector3.Distance(transform.position, spawnPosition) > deathDistance) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}