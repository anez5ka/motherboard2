using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private float currentPositionX;
    private Vector3 velocity = Vector3.zero;
    private PlayerMovement move;

    void Awake()
    {
        move = player.GetComponent<PlayerMovement>();
    }
    void Update()
    {

        if (System.Math.Abs(player.transform.position.x - transform.position.x) > 8)
        {
            // Debug.Log(player.transform.position.x + "  ;  " + transform.position.x + "  ;  " + ((System.Math.Round((player.transform.position.x / 16)))));
            currentPositionX = System.Convert.ToSingle(System.Math.Round((player.transform.position.x / 16)) * 16f);
        }

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, transform.position.y, transform.position.z),
            ref velocity, speed*Time.deltaTime);
    }
}
