using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListOfPrefabs : MonoBehaviour
{

    [SerializeField]
    private Object[] prefabs;

    [SerializeField]
    private GameObject currentGameObject;

    [SerializeField]
    private GameObject prefabHolder;

    [SerializeField]
    private TMP_Dropdown prefabsDropdown;

    private Controls controls;
    private int dropdownCount = 0;
    private int prefabsCount = 0;
    private int dropdownValue = 0;
    private int previousDropdownValue = 0;

    private List<string> prefabNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        //Grabs the controls script.
        controls = prefabHolder.GetComponent<Controls>();

        //Grabs a list of prefabs inside of the resources folder.
        prefabs = Resources.LoadAll("Prefabs", typeof(GameObject));

        //Grabs the first one in the list instantiates it
        currentGameObject = Instantiate(prefabs[0], prefabHolder.transform.position, Quaternion.identity) as GameObject;

        //Sets the first object as the child of the prefabHolder gameObject.
        currentGameObject.transform.parent = prefabHolder.transform;

        StartCoroutine(PopulateDropdown());
    }

    // Update is called once per frame
    void Update()
    {
        dropdownValue = prefabsDropdown.value;
        if (previousDropdownValue != dropdownValue)
        {
            //Debug.Log("Choosing new prefab to instantiate!");
            ChoosePrefabToInstatiate();
            previousDropdownValue = dropdownValue;
        }
    }

    private void ChoosePrefabToInstatiate()
    {
        //dropdownValue = prefabsDropdown.value;

        for(int i = 0; i < prefabsCount; i++)
        {
            if (prefabs[dropdownValue] != null && prefabsDropdown.options[dropdownValue].text == prefabs[dropdownValue].name)
            {
                //Destroy the current gameobject in the scene.
                Destroy(currentGameObject);

                //Resets only the scale. If you want to rest it all at once, change int to 3.
                controls.ResetGameObject(2);

                //Instantiates the selected prefab based on the dropdown value from the dropdown list.
                currentGameObject = Instantiate(prefabs[dropdownValue], prefabHolder.transform.position, Quaternion.identity) as GameObject;

                currentGameObject.transform.parent = prefabHolder.transform;
            }
        }
    }

    //This function was only used for testing purposes with a forced unity button.
    public void CheckForPrefab()
    {
        if(prefabHolder.transform.childCount > 0)
        {
            //Destroy the current gameobject in the scene.
            Destroy(currentGameObject);

            //Resets only the scale. If you want to rest it all at once, change int to 3.
            controls.ResetGameObject(2);

            //Instantiates the selected prefab.
            currentGameObject = Instantiate(prefabs[1], prefabHolder.transform.position, Quaternion.identity) as GameObject;

            currentGameObject.transform.parent = prefabHolder.transform;
        }
    }

    IEnumerator PopulateDropdown()
    {
        yield return null;

        prefabsCount = prefabs.Length;
        for(int i = 0; i < prefabsCount; i++)
        {
            prefabNames.Add(prefabs[i].name);
        }
        prefabsDropdown.ClearOptions();
        prefabsDropdown.AddOptions(prefabNames);

        dropdownCount = prefabsDropdown.options.Count;

        //prefabsDropdown.value = dropdownCount - 1;
        ChoosePrefabToInstatiate();

    }
}
