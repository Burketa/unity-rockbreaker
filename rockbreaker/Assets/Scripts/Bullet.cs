using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject target;
    private float speed = 1.0f;
    private int dmg = 1;
    private Rigidbody2D _rgdbd;

    private Vector3 targetPosition;

    private void Awake()
    {
        dmg = PlayerStats.dmg;
        speed = PlayerStats.bulletSpeed;

        _rgdbd = GetComponent<Rigidbody2D>();

        GameObject.Destroy(gameObject, 2.0f);

    }

    void Update()
    {
        dmg = PlayerStats.dmg;

        if (target != null)
        {
            targetPosition = target.transform.position;

            Vector2 dir = (targetPosition - transform.position).normalized;
            _rgdbd.velocity = dir * speed;
            if (transform.position == target.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if (col.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
            col.GetComponent<Enemy>().TakeDamage(dmg);
        }
    }
}
