using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] public Transform target;
    public Vector3 targetOffSet = new Vector3(0,15,-10);
    [SerializeField] private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();

        // Camera Lock On

    }

        void MoveCamera() {
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffSet, movementSpeed * Time.deltaTime);
        }

}
