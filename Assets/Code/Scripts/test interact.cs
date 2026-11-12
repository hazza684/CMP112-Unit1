
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour, IInteractable
{

    private SpriteRenderer sr;
    private Color orginalcolor;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        orginalcolor = sr.color;

    }

    public void Interact()
    {
        ClimbLadder();
    }
    public void Intertact()
    {

    }

    public void OnNotTouchingplayer()
    {
        sr.color = orginalcolor;
    }

    public void OnTouchingPlayer()
    {
        sr.color = Color.red;
    }

    void ClimbLadder() 
    {
    
    
    }

   
}
