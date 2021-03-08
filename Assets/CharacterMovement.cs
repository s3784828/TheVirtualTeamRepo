using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 movement;
    public float speed;
    public float jumpForce;
    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = movement * Time.fixedDeltaTime;
    }

    //public void MoveCharacter(Vector2 dir)
    //{
    //    Vector3 actualDir = new Vector3(dir.x * speed, rigidBody.velocity.y, dir.y * speed);
    //    FacePosition(dir);
    //    rigidBody.velocity = actualDir * Time.deltaTime;
    //}

    public void SetMovement(Vector2 dir)
    {
        movement = new Vector3(dir.x * speed, rigidBody.velocity.y, dir.y * speed);
        
        if (dir.x != 0 && dir.y != 0)
            FacePosition(dir);
    }

    public void FacePosition(Vector2 toFace)
    {
        Vector3 newPos = new Vector3(toFace.x, transform.position.y, toFace.y);
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 facePos = currentPos + newPos;
        facePos.y = transform.position.y;
        transform.LookAt(facePos);
    }

    //Jump is called by action controller script
    public void Jump()
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, 0f, rigidBody.velocity.z);
        rigidBody.velocity += Vector3.up * jumpForce;
    }

    
    
}
