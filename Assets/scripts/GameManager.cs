using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject obstacleSpawner;

    // Start is called before the first frame update
    void Start() {
        Vector3 center = new Vector3(0, 0, 0);
        Instantiate(player, center, Quaternion.identity);

        Instantiate(obstacleSpawner, Vector3.up * 10, Quaternion.identity);
        Instantiate(obstacleSpawner, Vector3.left * 5, Quaternion.identity);
        Instantiate(obstacleSpawner, Vector3.right * 5, Quaternion.identity);
    }

    // Update is called once per frame
    void Update() {
    }
}
