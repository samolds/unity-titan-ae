using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float slingMax = 5;
    public float slingStrength = 1;
    public float deathMagnitude = 1;
    public GameObject bullet;
    public int shootDelay = 1;
    public float bulletSpeed = 1;
    private int shooties = 0;

    // Start is called before the first frame update
    void Start() {
        //gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    // Update is called once per frame
    private void FixedUpdate() {
        shooties = (shooties + 1) % shootDelay;
        if (!Input.GetMouseButton(0)) {
            return;
        }

        if (shooties == 0) {
            shootOffset(0.05f, 0.1f);
            shootOffset(-0.05f, 0.1f);
        }

        Vector2 touchPosOnScreen = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newVelocity = new Vector2(
             touchPosOnScreen.x - player.transform.position.x,
             touchPosOnScreen.y - player.transform.position.y
        );

        player.AddForce(
            Vector2.ClampMagnitude(newVelocity * slingStrength, slingMax)
        );
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Obstacle") {
            print(other.relativeVelocity.magnitude);
            if (other.relativeVelocity.magnitude > deathMagnitude) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void shootOffset(float x, float y) {
        Vector2 pos = new Vector2(
            player.transform.position.x + x,
            player.transform.position.y + y
        );
        GameObject o = Instantiate(bullet, pos, Quaternion.identity);
        Rigidbody2D rb = o.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bulletSpeed);
    }
}
