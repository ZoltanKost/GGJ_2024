using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InventoryHandler inventoryHandler;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private Transform collect_PopUp;
    [SerializeField] private TMP_Text collect_PopUpLabel;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementForce;
    [SerializeField] KeyCode pickUp;
    [SerializeField] KeyCode inventoryOpen;
    [SerializeField] float radius;
    [SerializeField] DialogBox dialogBox;

    public InventoryHandler InventoryHandler => inventoryHandler;

    readonly HashSet<object> _inputBlockingObjects = new HashSet<object>();
    readonly List<AInteractable> _interactablesInRange = new List<AInteractable>();

    private void Update()
    {
        collect_PopUp.gameObject.SetActive(false);
        if (_inputBlockingObjects.Count == 0)
        {
            if (Input.GetKeyDown(inventoryOpen))
            {
                if (!InventoryUI.activeSelf)
                {
                    InventoryUI.SetActive(true);
                }
                else
                {
                    InventoryUI.SetActive(false);
                }
            }

            if(_interactablesInRange.Count>0)
            {
                var pos = transform.position;
                var closestInteractable = _interactablesInRange[0];
                var closestInteractableDist = (_interactablesInRange[0].transform.position - pos).sqrMagnitude;

                for(var i=0; i< _interactablesInRange.Count; i++)
                {
                    var dist = (_interactablesInRange[i].transform.position - pos).sqrMagnitude;
                    if(dist< closestInteractableDist)
                    {
                        closestInteractableDist = dist;
                        closestInteractable = _interactablesInRange[i];
                    }
                }

                collect_PopUpLabel.text = closestInteractable.UILabel;
                collect_PopUp.gameObject.SetActive(true);
                if (Input.GetKeyDown(pickUp))
                {
                    closestInteractable.Interact(this);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (_inputBlockingObjects.Count == 0)
        {
            var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rb.AddForce(input * movementForce);
        }
    }

    public void BlockInput(object key)
    {
        if(!_inputBlockingObjects.Add(key))
        {
            throw new System.Exception("Can't add key " + key.ToString());
        }
    }

    public void UnblockInput(object key)
    {
        if (!_inputBlockingObjects.Remove(key))
        {
            throw new System.Exception("Can't remove key " + key.ToString());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var interactable = collision.GetComponentInParent<AInteractable>();
        Debug.Log("ENTER"+ interactable);

        if (interactable)
        {
            _interactablesInRange.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable = collision.GetComponentInParent<AInteractable>(true);
        Debug.Log("Exit" + interactable);
        if (interactable)
        {
            _interactablesInRange.Remove(interactable);
        }
    }
}
