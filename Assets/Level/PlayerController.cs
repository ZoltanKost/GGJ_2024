using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementForce;
    [SerializeField] GameObject Inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!Inventory.activeSelf)
            {
                Inventory.SetActive(true);
            }
            else
            {
                Inventory.SetActive(false);
            }
        }
    }
    private void FixedUpdate()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.AddForce(input * movementForce);
    }
}
