using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    float timeToWait;

    public GameObject EnemyBullet;
    void Start()
    {
        // set random time to wait
        timeToWait = UnityEngine.Random.Range(3.5f, 5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // if time to wait is over shoot, reset time to wait
        if (timeToWait <= 0) {
            Shoot();
            timeToWait = 5.0f;
        } else {
            timeToWait -= Time.deltaTime;
        }
    }

    public void Shoot() {
        GameObject bullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity) as GameObject;
        // set velocity towards paddle
        bullet.GetComponent<Rigidbody2D>().velocity = (GameObject.Find("Paddle").transform.position - transform.position).normalized * 5.0f;
        // rotate bullet to face paddle
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward, GameObject.Find("Paddle").transform.position - transform.position);
    }
}
