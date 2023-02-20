using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputActions : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float interactingRange;

    InputAction moveAction;
    Vector2 direction;
    List<IInteractable> interactingObjects = new();
    Inventory inventory;

    void Awake()
    {
        moveAction = GetComponent<PlayerInput>().actions["Move"];
        inventory = FindObjectOfType<Inventory>(true);
    }

    private void Update()
    {
        CheckCancelInteractions();
    }

    void FixedUpdate()
    {
        MovementUpdate();
    }

    void MovementUpdate()
    {
        direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * movementSpeed * Time.deltaTime;
    }

    public void TriggerInventory(InputAction.CallbackContext context)
    {
        inventory.OpenInventory();
    }

    public void TriggerInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, interactingRange);
            if (colliders.Any())
            {
                var interactables = colliders.SelectMany(go => go.GetComponents<IInteractable>()).Where(c => c != null).ToList();
                if (interactables.Any())
                {
                    foreach (var interactable in interactables)
                    {
                        interactable.OnBeginInteraction();
                        if (!interactingObjects.Contains(interactable))
                            interactingObjects.Add(interactable);
                    }
                }
            }
        }
    }

    void CheckCancelInteractions()
    {
        List<IInteractable> interactablesToCancel = new();
        foreach (var interaction in interactingObjects)
        {
            var dist = Vector2.Distance(interaction.GetGameObject().transform.position, transform.position);
            if(dist > interactingRange)
            {
                interaction.OnEndInteraction();
                interactablesToCancel.Add(interaction);
            }
        }

        foreach (var interaction in interactablesToCancel)
            interactingObjects.Remove(interaction);
    }
}
