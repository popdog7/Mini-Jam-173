using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameInput game_input;
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform gun_end_point;
    private Camera cam;

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
        RotateGun();
    }

    private void RotateGun()
    {
        transform.eulerAngles = new Vector3 (0, 0, getRotationAngle());
        Debug.DrawLine(transform.position, getMousePosition(), Color.green, Time.deltaTime);
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
