using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {

    class Shell {
        public GameObject shell;
        public float elapsed;
        public bool isLive;
        private float deadline;

        public Shell (GameObject sh) {
            shell = sh;
            elapsed = 0.0f;
            deadline = 2.0f;
            isLive = true;
        }

        public bool check() {
            if (elapsed > deadline) {
                isLive = false;
                return true;
            } else {
                return false;
            }
        }
    }

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 0.2f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private GameObject m_Shell;
    [SerializeField] private float ShellSpeed = 15.0f;

    private Vector3 m_ShellPosition;
    private List<Shell> Shells = new List<Shell>();

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
            transform.rotation = Quaternion.Slerp(
                        transform.rotation,
                        Quaternion.LookRotation(velocity), 
                        rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            m_ShellPosition = transform.position + transform.forward * 5.0f;
            GameObject m_InstantiateShell = Instantiate(m_Shell, m_ShellPosition, transform.rotation);
            Shell sh = new Shell(m_InstantiateShell);
            Shells.Add(sh);
        }

        foreach (var sh in Shells) {
            if (ShellUpdate(sh)) {
                Destroy(sh.shell);
            }
        }

        Shells.RemoveAll(sh => !sh.isLive);
    }

    private bool ShellUpdate(Shell shell) {
        shell.elapsed += Time.deltaTime;
        shell.shell.gameObject.transform.position
            += shell.shell.gameObject.transform.forward * Time.deltaTime * ShellSpeed;
        return shell.check();
    }
}
