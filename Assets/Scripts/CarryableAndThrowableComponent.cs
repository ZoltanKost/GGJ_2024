using UnityEngine;

public class CarryableAndThrowableComponent : AInteractable
{
    [SerializeField] Collider2D[] colliders;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float throwOffsetDistance;

    PlayerController _carryingController;
    Vector2 _prevPosition;
    Vector2 _direction;

    public override string UILabel => _carryingController? "Thrown" : "Carry";

    private void Update()
    {
        if (!_carryingController) return;

        var pos = (Vector2)transform.position;

        if(pos != _prevPosition)
        {
            _direction = pos - _prevPosition;
            _prevPosition = pos;
        }

        transform.position = _carryingController.transform.position;
    }

    public override void Interact(PlayerController interactor)
    {
        //pickup
        if(_carryingController != interactor)
        {
            _carryingController = interactor;
            foreach(var c in colliders)
            {
                c.enabled = false;
            }
            rb.isKinematic = true;
            _prevPosition = transform.position;
            transform.position = _carryingController.transform.position;
        }
        else //throw
        {
            var dir = _direction.normalized;
            transform.position = (Vector2)_carryingController.transform.position + dir * throwOffsetDistance;
            foreach (var c in colliders)
            {
                c.enabled = true;
            }
            rb.isKinematic = false;
            rb.AddForce(dir * interactor.ThrowPower, ForceMode2D.Impulse);
            _carryingController = null;
        }
    }
}
