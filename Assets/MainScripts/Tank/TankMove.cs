using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 0.2f;
    [SerializeField] private Vector3 velocity;
    
    
    private void Update() {
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

        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        if (velocity.magnitude > 0) {
            transform.position += velocity;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(velocity), rotationSpeed);
        }


    }
}
