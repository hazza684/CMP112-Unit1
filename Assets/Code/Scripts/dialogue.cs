using UnityEngine;

public class dialogue : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            // if the player touches a NPC
            
            if (other.gameObject.CompareTag("thomatoes thomas"))
            {
                
            }
           
        }
    }
}
