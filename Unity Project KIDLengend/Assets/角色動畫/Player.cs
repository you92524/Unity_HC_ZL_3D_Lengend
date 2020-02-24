using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rig;
    public float speed=25f;


    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        print("按");
    }
    private void FixedUpdate()
    {
        Move();
      

    }
    private void Move()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 pos = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rig.AddForce(pos * speed);
    }
   
}
