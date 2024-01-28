using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InventoryHandler inventoryHandler;
    [SerializeField] private Transform collect_PopUp;
    [SerializeField] private TMP_Text collect_PopUpLabel;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float movementForce;
    [SerializeField] string pickUpButton;
    [SerializeField] KeyCode inventoryOpen;
    [SerializeField] DialogBox dialogBox;
    [SerializeField] private string WalkAnimation;
    private Animator animator;
    private AudioSource audioSource;
    private bool looksLeft = true;

    float _speedBonus;
    void Awake(){
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    internal void AddSpeedBonus(float speedBonusAmount)
    {
        _speedBonus += speedBonusAmount;
    }

    [SerializeField] float throwPower;

    public InventoryHandler InventoryHandler => inventoryHandler;
    public float ThrowPower => throwPower;

    readonly HashSet<object> _inputBlockingObjects = new HashSet<object>();
    readonly List<AInteractable> _interactablesInRange = new List<AInteractable>();

    private void Update()
    {
        collect_PopUp.gameObject.SetActive(false);
        if (_inputBlockingObjects.Count == 0)
        {
            if (Input.GetKeyDown(inventoryOpen))
            {
                inventoryHandler.ToggleInventory();
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
                if (Input.GetButtonDown(pickUpButton))
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
            bool moving = input.normalized.magnitude > 0;
            animator.SetBool(WalkAnimation, moving);
            rb.AddForce(input * (movementForce+ _speedBonus));
            if(!moving) {
                if(audioSource.isPlaying) audioSource.Stop();
                return;
            }
            if(!audioSource.isPlaying) audioSource.Play();
            bool goesLeft = input.x < 0;
            if(goesLeft) LookLeft();
            else LookRight();
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

        if (interactable)
        {
            _interactablesInRange.Add(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var interactable = collision.GetComponentInParent<AInteractable>(true);
        if (interactable)
        {
            _interactablesInRange.Remove(interactable);
        }
    }
    void LookLeft(){
        Vector3 targetLook = transform.localScale;
        targetLook.x = Mathf.Abs(targetLook.x); 
        animator.transform.localScale = targetLook;
    }
    void LookRight(){
        Vector3 targetLook = transform.localScale;
        targetLook.x = -Mathf.Abs(targetLook.x); 
        animator.transform.localScale = targetLook;
    }
}
