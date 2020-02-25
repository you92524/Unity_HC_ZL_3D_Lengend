using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rig;
    private Animator ani;
    private float timer; 
    

    public float speed=25f;
    public float cd = 0.9f;


    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        print("按");
    }
    private void FixedUpdate()
    {
        Move();
        Attack();

    }
    private void Move()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 pos = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rig.AddForce(pos * speed);
        ani.SetBool("移動開關", moveVertical != 0 || moveHorizontal != 0);
    }

    private void Dead()
    {
        ani.SetBool("死亡開關", true);                   
        enabled = false;                                
       
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer > cd)            // 如果 計時器 < 冷卻時間
        {
            
            ani.SetTrigger("攻擊觸發");
            print("攻擊");
            timer = 0;
        }
        else 
        {
           
            timer += Time.deltaTime;
        }
        
    }
    
}
