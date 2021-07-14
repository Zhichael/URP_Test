using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ListOfMaterials : MonoBehaviour
{
    [SerializeField]
    private Object[] materials;

    [SerializeField]
    private Material mat;

    [SerializeField]
    private TMP_Dropdown materialsDropdown;

    [SerializeField]
    private Toggle changeMaterial;

    [SerializeField]
    private Controls controls;
    [SerializeField]
    private CapsuleCollider capsuleCollider;

    private int materialsCount = 0;
    private int dropdownValue = 0;

    private List<string> materialNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Grabs a list of materials inside of the resources folder.
        materials = Resources.LoadAll("Materials", typeof(Material));

        StartCoroutine(PopulateDropdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (materialsDropdown.gameObject.activeInHierarchy)
        {
            dropdownValue = materialsDropdown.value;
            if (materials[dropdownValue] != null && materialsDropdown.options[dropdownValue].text == materials[dropdownValue].name)
            {
                mat = materials[dropdownValue] as Material;
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Input.touchCount == 1)
                    {
                        if (touch.phase == TouchPhase.Began)
                        {
                            if (Physics.Raycast(ray, out hit, 100.0f))
                            {
                                if (hit.collider.tag != "Rotate")
                                {
                                    var mesh = hit.collider.GetComponent<MeshRenderer>();
                                    if (mesh)
                                    {
                                        for (int i = 0; i < materialsCount; i++)
                                        {
                                            if (materials[dropdownValue] != null && materialsDropdown.options[dropdownValue].text == materials[dropdownValue].name)
                                            {
                                                for (int j = 0; j < mesh.materials.Length; j++)
                                                {
                                                    Debug.Log("Meshes hit: " + mesh.materials[j]);
                                                    //mesh.material = mat;
                                                    Material[] newMat = mesh.materials;
                                                    newMat[j] = mat;
                                                    mesh.materials = newMat;
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void ChangeTheMaterial(bool on)
    {
        on = changeMaterial.isOn;

        if(on)
        {
            materialsDropdown.gameObject.SetActive(true);
            capsuleCollider.enabled = false;
            controls.enabled = false;
        }
        else
        {
            materialsDropdown.gameObject.SetActive(false);
            capsuleCollider.enabled = true;
            controls.enabled = true;
        }
    }

    IEnumerator PopulateDropdown()
    {
        yield return null;

        materialsCount = materials.Length;
        for (int i = 0; i < materialsCount; i++)
        {
            materialNames.Add(materials[i].name);
        }
        materialsDropdown.ClearOptions();
        materialsDropdown.AddOptions(materialNames);

        materialsDropdown.gameObject.SetActive(false);

    }
}
