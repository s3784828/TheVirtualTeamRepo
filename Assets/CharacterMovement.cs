using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //public Vector3 dir;
    public float speed;
    public float jumpForce;
    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void MoveCharacter(Vector2 dir)
    {
        Vector3 actualDir = new Vector3(dir.x, rigidBody.velocity.y, dir.y);
        FacePosition(dir);

        //transform.Translate(actualDir * speed * Time.deltaTime, Space.World);
        rigidBody.velocity = actualDir * speed * Time.fixedDeltaTime;
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
        rigidBody.AddForce(new Vector3(rigidBody.velocity.x, jumpForce, rigidBody.velocity.z) * Time.fixedDeltaTime, ForceMode.Impulse);
    }
}
