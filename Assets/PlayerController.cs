using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 OriginalPos = new Vector3(3, 1, 3);
    public Rigidbody Player;
    public MeshFilter PlayerMesh;
    private MeshFilter NewMesh;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shapeshifting!!");
            PlayerMesh.mesh = NewMesh.mesh;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Object"))
        {
            Debug.Log("New mesh registered..");
            NewMesh = (MeshFilter) other.gameObject.GetComponent("MeshFilter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sky"))
        {
            Debug.Log("Reached sky boundary, resetting coordinates.");
            Player.transform.position = OriginalPos;
        }
    }
}