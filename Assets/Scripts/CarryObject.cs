using UnityEngine;
using System.Collections;

public class CarryObject : MonoBehaviour
{
    public float interactDistance;
    private float carryDistance = 150f;
    public LayerMask interactLayer;

    private Transform carryObject;
    private bool haveObject;

    void Update()
    {
        //Raycast variables.
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        //Raycasting mechanics.
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            //If we press LMB, it will update the carryObject and its gravity.
            if (Input.GetKeyDown("space"))
            {
                carryObject = hit.transform;
                carryObject.GetComponent<Rigidbody>().useGravity = false;
                haveObject = true;
            }
        }

        //If we release LMB and we have an object in hand, it will reset the carryObject.
        if (Input.GetKeyUp("space"))
        {
            if (haveObject)
            {
                haveObject = false;
                carryObject.GetComponent<Rigidbody>().useGravity = true;
                carryObject = null;
            }
        }

        //If we have an object in hand, we update its position and smooth it out with basic interpolation.
        if (haveObject)
        {
            carryObject.position = Vector3.Lerp(carryObject.position, Camera.main.transform.position + Camera.main.transform.forward * carryDistance, Time.deltaTime * 8);
            carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}