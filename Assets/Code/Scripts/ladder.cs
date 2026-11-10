using UnityEngine;

public class ladder : MonoBehaviour
{

    public float climbspeed = 5f;
    public LayerMask ladderLayer;
    public float laddercheckraduis = 0.5f;
    private float veritcalInput;
    private bool isClimbling;

    private void readInput()
    {
        veritcalInput = 0f;

        if (Input.GetKey(KeyCode.W)) veritcalInput = 1f;

        if (Input.GetKey(KeyCode.S)) veritcalInput = -1f;

    }

    private bool isOnLadder() 
    { 
    return Physics2D.OverlapCircle(transform.position, laddercheckraduis, ladderLayer);
   
    }

    private void HaddleLadder()
    {

        bool onLadder = isOnLadder();

        if (onLadder && veritcalInput != 0f) isClimbling = true;
        if (!onLadder) return;

        if (isClimbling)
        {

        }



    }






}
