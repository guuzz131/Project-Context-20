using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public Transform pickupAura;
    public LayerMask playerLayer;

    private bool pickup;
    private bool playersNear;

    private void Update()
    {
        PickupCheck();
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pickupAura.position, radius);
    }

    void PickupCheck()
    {
        pickup = Input.GetKeyDown(KeyCode.E);
        if (pickup)
        {
            playersNear = Physics.CheckSphere(pickupAura.position, radius, playerLayer);
            if (playersNear)
            {
                Interaction();
            }
        }
    }

    public virtual void Interaction()
    {

    }
}
