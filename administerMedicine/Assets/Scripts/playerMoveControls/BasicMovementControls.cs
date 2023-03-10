using UnityEngine;

public class BasicMovementControls : MonoBehaviour
{
    // NO RIGID BODY, THIS IS A PLAYER UNAFFECTED BY PHYSICS AND CAN FLY - testing purposes
    public Transform player;
    public float moveSpeed = 25f;
    public float verticalSpeed = 10f;
    public float turnSpeed = 150f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move player object using wasd controls
        if (Input.GetKey("w")) {
            player.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s")) {
            player.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d")) {
            player.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a")) {
            player.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
        // lets the player move up and down in the world
        if (Input.GetKey("x")) {
            player.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }
        if (Input.GetKey("c")) {
            player.Translate(-Vector3.up * verticalSpeed * Time.deltaTime);
        }
    }
}
