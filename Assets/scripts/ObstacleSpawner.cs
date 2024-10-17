using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate;
    private float timer;
    public float randomRadius;
    public float forceFactor;

    // Start is called before the first frame update
    void Start() {
        spawn();
    }

    // Update is called once per frame
    void Update() {
        if (timer < spawnRate) {
            timer = timer + Time.deltaTime;
        } else {
            spawn();
            timer = 0;
        }
    }

    void spawn() {
        float x = Random.Range(-randomRadius, randomRadius);
        float y = Random.Range(-randomRadius, randomRadius);
        Vector2 force = new Vector2(0, 0);
        if (transform.position.x == 0) {
            y = transform.position.y;
            force = Vector2.down * forceFactor;
        } else if (transform.position.y == 0) {
            x = transform.position.x;
            if (x < 0) {
                force = Vector2.right * forceFactor;
            } else {
                force = Vector2.left * forceFactor;
            }
        }

        // TODO(sam): direct spawned objects towards center?
        GameObject o = Instantiate(obstacle, new Vector3(x, y, 0), transform.rotation);
        Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }
}