using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Con : MonoBehaviour
{
    public Attack_Con attack_check;
    public Player_health death_check;
    Rigidbody rb;
    Animator anim;
    [SerializeField] float Speed;
    bool touchStart;
    Vector3 pointA;
    Vector3 pointB;

    Vector3 Offset;
    Vector3 direction;

    public GameObject moveCon;
    public Control_Ui con;
    

    public Control_Ui con_check;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
        pointB = moveCon.transform.position;
        pointA = con.clickPosition;
        if (attack_check == null)
        {
            if (death_check.death_state == false)
            {
                if (con_check.conIsTouch == true)
                {
                    Offset = pointA - pointB;
                    direction = Vector3.ClampMagnitude(Offset, 1.0f);
                    playerMove(direction);
                    playerLook(direction);
                }
                else
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                    anim.SetBool("Walk", false);
                }
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                con_check.conIsTouch = false;
                if(SceneManager.GetActiveScene().name == "Stag03(Puffer)")
                {
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
        }
        else
        {
            if (death_check.death_state == false)
            {
                if (attack_check.attackIsTrue == false)
                {
                    if (con_check.conIsTouch == true)
                    {
                        Offset = pointA - pointB;
                        direction = Vector3.ClampMagnitude(Offset, 1.0f);
                        playerMove(direction);
                        playerLook(direction);
                    }
                    else
                    {
                        rb.velocity = new Vector3(0, rb.velocity.y, 0);
                        anim.SetBool("Walk", false);
                    }
                }
                else if(attack_check.attackIsTrue == true)
                {
                    rb.velocity = new Vector3(0, rb.velocity.y, 0);
                }
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                con_check.conIsTouch = false;
            }
       
        }
    }

    void playerMove(Vector3 moveDir)
    {
        rb.velocity = new Vector3(moveDir.x * Speed, rb.velocity.y, moveDir.y * Speed);
        anim.SetBool("Walk", true);
    }

    void playerLook(Vector3 LookDir)
    {
        Vector3 lookAt = new Vector3(LookDir.x, 0, LookDir.y);
        rb.rotation = Quaternion.LookRotation(lookAt);
    }
}
