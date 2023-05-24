using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
    
{
    //Rigidbody obj;
    //Quaternion rotation;
    //[SerializeField] float speedRotation;
    //Vector3 rotateVector = new Vector3();
    //// Start is called before the first frame update
    //void Start()
    //{
    //    obj = this.gameObject.GetComponent<Rigidbody>();

    //}

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    ChangeVector();
    //    RotateObject();

    //}
    //void ChangeVector()
    //{
    //    rotateVector.x = speedRotation;
    //}
    //void RotateObject()
    //{
    //    obj.AddTorque(rotateVector, ForceMode.VelocityChange);
    //    //rotation.x = rotation.x + speedRotation * Time.deltaTime;
    //    //transform.localRotation = rotation;

    public Vector3 RotationSpeed;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotationSpeed * Time.deltaTime);
    }

}
