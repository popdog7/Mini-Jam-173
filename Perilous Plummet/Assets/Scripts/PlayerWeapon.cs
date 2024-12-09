using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameInput game_input;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        game_input.on_shoot_action += GameInputOnJumpAction; ;
    }

    private void GameInputOnJumpAction(object sender, System.EventArgs e)
    {
        Debug.Log("shot");
    }

    private void Update()
    {
        RotateGun();
    }

    private void RotateGun()
    {
        Vector3 mouse_position = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        float angle_radians = Mathf.Atan2(mouse_position.y - transform.position.y, mouse_position.x - transform.position.x);
        float angle_degreee = (180 / Mathf.PI) * angle_radians;

        angle_degreee += FlipGun();

        transform.rotation = Quaternion.Euler(0f, 0f, angle_degreee);
        Debug.DrawLine(transform.position, mouse_position, Color.green, Time.deltaTime);
    }

    private float FlipGun()
    {
        if( game_input.GetHorizontalMovement() < 0)
        {
            return 180;
        }

        return 0;
    }
}
