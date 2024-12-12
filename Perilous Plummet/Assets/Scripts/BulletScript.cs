using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public void Setup(Vector3 shoot_direction, float angle)
    {
        Rigidbody2D rigid_body = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0, 0, angle);
        float move_speed = 10f;
        rigid_body.AddForce(shoot_direction * move_speed, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseHealth target_health = collision.GetComponent<BaseHealth>();

        if (target_health != null)
        {
            target_health.ChangeHealth(-1);
        }

        Destroy(gameObject);
    }
}
