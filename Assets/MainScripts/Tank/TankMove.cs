using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private Vector3 velocity;
    
    
    private void Update() {
        //float localAngleY = transform.localEulerAngles.y;

        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) 
            velocity.z += 1;
        if (Input.GetKey(KeyCode.S)) 
            velocity.z -= 1;
        if (Input.GetKey(KeyCode.D)) 
            velocity.x += 1;
        if (Input.GetKey(KeyCode.A)) 
            velocity.x -= 1;
        
        Vector3 normV = velocity.normalized;

        float forwardY = Mathf.Atan2(transform.forward.x, transform.forward.z);
        float angleY = Mathf.Atan2(normV.x, normV.z);

        velocity = velocity.normalized * moveSpeed * Time.deltaTime;
        transform.position += velocity;

        float rot = angleY - forwardY;
    
        // Debug.Log(Mathf.Atan2(transform.forward.x, transform.forward.z));
        // Debug.Log(Mathf.Atan2(normV.x, normV.z));
        // Debug.Log(normV);
    }
}
