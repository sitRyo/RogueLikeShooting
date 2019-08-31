using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour {
    [SerializeField] private Transform m_Player;

    private void LateUpdate() {
        Vector3 direction = (m_Player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
