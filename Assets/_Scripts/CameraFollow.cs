using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float followSpeed;
    void Update() {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}