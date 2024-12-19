using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameInput game_input;
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform gun_end_point;
    private Camera cam;

    private bool is_flipped = false;

    private void Start()
    {
        cam = Camera.main;
        game_input.on_shoot_action += GameInputOnShootAction;
    }

    private void GameInputOnShootAction(object sender, System.EventArgs e)
    {
        Transform bullet_transform = Instantiate(bullet, gun_end_point.position, Quaternion.identity);

        Vector3 shoot_direction = (getMousePosition() - gun_end_point.position).normalized;
        float angle = getRotationAngle();

        bullet_transform.GetComponent<BulletScript>().Setup(shoot_direction, angle);
    }

    private void Update()
    {
        SetGunRotation();
    }

    private void SetGunRotation()
    {
        float angle = getRotationAngle();
        FlipGun();

        if (is_flipped)
        {
            transform.rotation = Quaternion.Euler(-180f, 0f, -angle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        Debug.DrawLine(transform.position, getMousePosition(), Color.green, Time.deltaTime);
    }

    private void FlipGun()
    {
        float angle = getRotationAngle();
        if (!is_flipped && (angle > 90f || angle < -90f))
        {
            is_flipped = true;
        }
        else if (is_flipped && (angle < 90f && angle > -90f))
        {
            is_flipped = false;
        }       
    }

    private float getRotationAngle()
    {
        Vector3 shoot_direction = (getMousePosition() - transform.position).normalized;
        float angle = Mathf.Atan2(shoot_direction.y, shoot_direction.x) * Mathf.Rad2Deg;

        return angle;
    }
    

    private Vector3 getMousePosition()
    {
        return (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
