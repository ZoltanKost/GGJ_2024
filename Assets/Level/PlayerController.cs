using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InventoryHandler inventoryHandler;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private Transform collect_PopUp;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementForce;
    [SerializeField] KeyCode pickUp;
    [SerializeField] KeyCode inventoryOpen;
    [SerializeField] float radius;
    [SerializeField] DialogBox dialogBox;

    readonly HashSet<object> _inputBlockingObjects = new HashSet<object>();

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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Collectable component))
                {
                    collect_PopUp.gameObject.SetActive(true);
                    if (Input.GetKeyDown(pickUp))
                    {
                        inventoryHandler.AddToInventory(component.GetSO());
                        dialogBox.ShowDialog("You acuired half a joke!");
                        component.gameObject.SetActive(false);
                    }
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
}
