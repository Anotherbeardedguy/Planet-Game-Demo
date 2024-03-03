using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject pendingObject;

    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if(pendingObject != null)
        {
            pendingObject.transform.position = pos;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceObject();
            }
        }
    }
    private void FixedUpdate()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            // get the position of the hit on a sphere
            pos = hit.point + hit.normal * 0.5f;

            // rotate the object to the normal of the surface
            pendingObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(objects[0], pos, Quaternion.identity);
            }
        }


    }
    public void PlaceObject()
    {
        pendingObject = null;
    }
    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, transform.rotation);

    }
}
