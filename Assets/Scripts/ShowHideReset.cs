using UnityEngine;
using UnityEngine.EventSystems;

public class ShowHideReset : MonoBehaviour, IDeselectHandler
{
    [SerializeField]
    private GameObject resetHolder;
    private bool isShowing = true;

    public void OnDeselect(BaseEventData eventData)
    {
        isShowing = true;
        resetHolder.SetActive(false);
    }

    public void ShowHide()
    {
        if(isShowing)
        {
            resetHolder.SetActive(true);
            isShowing = false;
        }
        else
        {
            resetHolder.SetActive(false);
            isShowing = true;
        }
    }
}
