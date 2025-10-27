using UnityEngine;

public class MirrorLogic : MonoBehaviour {

    public Transform player;
    public Transform mirror;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Position of the player relative to the mirror
        Vector3 localPlayer = mirror.InverseTransformPoint(player.position);
        // Inverts position of player (bc it's a mirror)
        transform.position = mirror.TransformPoint(new Vector3(localPlayer.x, localPlayer.y,  -localPlayer.z));

        Vector3 lookAtMirror = mirror.TransformPoint(new Vector3(-localPlayer.x, localPlayer.y, localPlayer.z));
        transform.LookAt(lookAtMirror);
    }
}
