using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private Vector2 boundingBoxSize = new Vector2 (5f, 3f);
    private GameObject refToPlayer;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Get mouse position
        Vector2 mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Get player position
        Vector2 playerPosition = refToPlayer.transform.position;
        //Mouse position relative to playerPosition
        Vector2 target = mousePos - playerPosition;

        // Clamp mouse position within the bounding box
        float clampedX = Mathf.Clamp(target.x, playerPosition.x - boundingBoxSize.x / 2f, playerPosition.x + boundingBoxSize.x / 2f);
        float clampedY = Mathf.Clamp(target.y, playerPosition.y - boundingBoxSize.y / 2f, playerPosition.y + boundingBoxSize.y / 2f);
        // Fix z coordiante to nearClipPlane
        float clampedZ = Camera.main.nearClipPlane;

        // Set the object's position to the clamped mouse position
        transform.position = new Vector3(clampedX, clampedY, clampedZ);
    }

    //Draw the Bounding Box for the mouse follower (Debugging)
    private void OnDrawGizmosSelected()
    {
        Vector3 playerPosition = refToPlayer.transform.position;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(playerPosition, new Vector3(boundingBoxSize.x, boundingBoxSize.y, 0.1f));
    }
}
