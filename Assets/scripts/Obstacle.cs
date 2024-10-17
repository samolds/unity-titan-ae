using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Obstacle : MonoBehaviour
{
    private Vector3 spawnPosition;
    public float deathDistance = 10f;

    // Start is called before the first frame update
    void Start() {
        spawnPosition = transform.position;
        //gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update() {
        // TODO(sam): re-enable this if spawned objects are directed towards center
        //if (transform.position.x == 0 && transform.position.y == 0) {
        //    Destroy(gameObject);
        //}
        if (Vector3.Distance(transform.position, spawnPosition) > deathDistance) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        transform.Rotate(0, 0, 1f, Space.Self);
    }
}
