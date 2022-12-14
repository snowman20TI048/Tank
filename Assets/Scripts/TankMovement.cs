using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        TankMove();
        TankTurn();
    }

    // 前進・後退のメソッド
    void TankMove()
    {
        movementInputValue = Input.GetAxis("Vertical");//縦
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // 旋回のメソッド
    void TankTurn()
    {
        turnInputValue = Input.GetAxis("Horizontal");//横
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);  //回転軸を決定  .EulerをつけないとVector3型からQuaternion型に変換してくれない！ 回転するにはQuaternion型が必須！
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
