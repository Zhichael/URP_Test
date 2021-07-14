using UnityEngine;
using UnityEngine.UI;

public class CheckMeshCollider : MonoBehaviour
{
    [SerializeField]
    private CapsuleCollider capsuleCollider;
    [SerializeField]
    private MeshCollider meshCollider;
    [SerializeField]
    private Toggle changeMaterial;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = this.gameObject.GetComponent<CapsuleCollider>();
    }

    public void CheckMesh(bool on)
    {
        on = changeMaterial.isOn;
        meshCollider = this.gameObject.GetComponentInChildren<MeshCollider>();
        if (on)
        {
            if(capsuleCollider.enabled == false)
            {
                meshCollider.enabled = true;
            }
        }
        else
        {
            if(capsuleCollider.enabled == true)
            {
                meshCollider.enabled = false;
            }
        }
    }
}
