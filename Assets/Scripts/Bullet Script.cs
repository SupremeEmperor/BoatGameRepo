using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed = 200;
    [SerializeField] float bulletLife = 5;
    [SerializeField] int damage = 5;
    float lifeStartTime = 0;

    private void Start()
    {
        lifeStartTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed * Time.deltaTime;
        if(Time.time - lifeStartTime > bulletLife)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
