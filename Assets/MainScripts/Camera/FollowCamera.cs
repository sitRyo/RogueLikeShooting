using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Transform player;

    private void LateUpdate() {
        float cx = player.transform.position.x;
        float cz = player.transform.position.z;
        transform.position = new Vector3(cx, transform.position.y, cz);
    }
}
