using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControls : MonoBehaviour
{
    public GameObject mesh;
    public float rotationSpeed = 2.0f;

    private bool isRotating = false;

    private Vector3 mouseReference;
    private Vector3 mouseOffset;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                isRotating = true;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                //Check to see if the second finger hit the gameobject. If it did, rotate the gameobject on the Y axis.
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    //Adding a check if the player hits the rotate cylinder and 
                    if (hit.transform.CompareTag("Rotate") && !hit.transform.CompareTag("Player"))
                    {
                        if (isRotating)
                        {
                            mouseOffset = Input.mousePosition - mouseReference;

                            rotation.y = -(mouseOffset.x + mouseOffset.y) * rotationSpeed;

                            mesh.transform.Rotate(rotation);
                            this.transform.Rotate(rotation);

                            mouseReference = Input.mousePosition;
                        }
                    }
                }
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                isRotating = false;
            }
        }
    }
}
