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

    private void Update()
    {
        collect_PopUp.gameObject.SetActive(false);
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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,radius);
        foreach(Collider2D collider in colliders)
        {
            if(collider.TryGetComponent(out Collectable component))
            {
                collect_PopUp.gameObject.SetActive(true);
                if(Input.GetKeyDown(pickUp)){
                    inventoryHandler.AddToInventory(component.GetSO());
                    component.gameObject.SetActive(false);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(input * movementForce);
    }
}
