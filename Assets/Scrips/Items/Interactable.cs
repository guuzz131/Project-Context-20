using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;


    public Transform player;
    public GameObject gameManager;

    public bool hasInteracted = false;
    public bool pickupInput;
    bool objectsSet = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!objectsSet)
        {
            gameManager = GameObject.Find("GameManager");
            player = gameManager.GetComponent<GameManager>().thisPlayer.transform;
            objectsSet = true;
        }
        pickupInput = Input.GetKeyDown(KeyCode.E);
        if (pickupInput && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Object.Destroy(gameObject);
                hasInteracted = true;
            }
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    
}
