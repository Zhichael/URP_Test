using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour
{
    public GameObject mesh;
    public float rotationSpeed = 1.0f;

    public float xMin = -1.0f;
    public float xMax = 1.0f;
    public float yMin = 0.5f;
    public float yMax = 3.0f;
    public float zMin = -1.0f;

    public float scaleMin = 0.2f;
    public float scaleMax = 2.0f;

    //keep the original values for position, rotation and scale on start.
    private Vector3 startPos;
    private Quaternion startRot;
    private Vector3 startScale;

    private float startFingerDistance;
    private Vector3 startingScale;

    // Start is called before the first frame update
    void Start()
    {
        mesh = this.gameObject;

        //if the gameobject is null, find the gameobject with the player tag.
        if (!mesh)
        {
            mesh = GameObject.FindGameObjectWithTag("Player");
        }

        //save the start values.
        startPos = mesh.transform.position;
        startRot = mesh.transform.rotation;
        startScale = mesh.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Debug the movement inside of unity.
            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
            //mesh.transform.position = mousePos;
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.touchCount == 1)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    if(EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        return;
                    }
                    //Shoot a raycast out from your mouses position and see if you hit the specific tag. If you do, move the gameobject within the set constrants.
                    if (Physics.Raycast(ray, out hit, 100.0f))
                    {
                        if (hit.transform.CompareTag("Player"))
                        {
                            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z - transform.position.z)));
                            mesh.transform.position = mousePos;
                        }
                    }

                    float xPos = Mathf.Clamp(transform.position.x, xMin, xMax);
                    float yPos = Mathf.Clamp(transform.position.y, yMin, yMax);
                    mesh.transform.position = new Vector3(xPos, yPos, 0.0f);
                }
            }
            if(Input.touchCount == 2)
            {
                Touch touchOne = Input.GetTouch(1);
                if(touch.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
                {
                    startFingerDistance = Vector2.Distance(touch.position, touchOne.position);
                    startingScale = mesh.transform.localScale;
                }
                else if (touch.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
                {
                    var currentFingerDistance = Vector2.Distance(touch.position, touchOne.position);
                    var scaleFactor = currentFingerDistance / startFingerDistance;
                    //Debug.Log("ScaleFactor is: " + scaleFactor);

                    mesh.transform.localScale = startingScale * scaleFactor;

                    //Apply a clamp range to the scale of the object. Default is 0.2 to 2.0.
                    float xScaleSize = Mathf.Clamp(mesh.transform.localScale.x, scaleMin, scaleMax);
                    float yScaleSize = Mathf.Clamp(mesh.transform.localScale.y, scaleMin, scaleMax);
                    float zScaleSize = Mathf.Clamp(mesh.transform.localScale.z, scaleMin, scaleMax);
                    mesh.transform.localScale = new Vector3(xScaleSize, yScaleSize, zScaleSize);
                }
            }
        }
    }

    public void ResetGameObject(int reset)
    {
        switch(reset)
        {
            case 0:
                mesh.transform.position = startPos;
                break;
            case 1:
                mesh.transform.localRotation = startRot;
                break;
            case 2:
                mesh.transform.localScale = startScale;
                break;
            case 3:
                mesh.transform.position = startPos;
                mesh.transform.localRotation = startRot;
                mesh.transform.localScale = startScale;
                break;
        }
    }
}
