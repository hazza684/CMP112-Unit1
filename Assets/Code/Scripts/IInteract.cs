using UnityEngine;
using UnityEngine.InputSystem;


public interface IInteractable
{
    public void Intertact();

    void Interact();

    void OnTouchingPlayer();

    void OnNotTouchingplayer();

}
public class Interact : MonoBehaviour
{
    private IInteractable currentInteractable;

    private void Update()
    {
        if (Keyboard.current.eKey.IsActuated() && currentInteractable != null)
        { 
        currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null)
        {

            currentInteractable = interactable;
            currentInteractable.OnTouchingPlayer();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable.OnNotTouchingplayer();
            currentInteractable = null;

        }
    }
}