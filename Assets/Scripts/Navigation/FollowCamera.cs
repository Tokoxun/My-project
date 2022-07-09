using System.Collections;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Distance between player and camerea in horizontal direction
    public float xOffset = 0f;
    // Distance between player and camerea in vertical direction
    public float yOffset = 0f;
    // Reference to the player's transform.
    public Transform player;

    void Awake()
    {
        // check the player reference.
        player = GameObject.Find("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player object not found");
        }
    }

  void LateUpdate()
  {
      this.transform.position = new Vector3(player.transform.position.x + xOffset,
      this.transform.position.y + yOffset, -10);
  }
}
