using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class UISelectedMovement : MonoBehaviour /*IPointerEnterHandler, ISelectHandler,IDeselectHandler,IPointerExitHandler*/ {

    
    Vector3 myOriginalPosition;
    Vector3 OriginPosUp;
    Vector3 OriginPosDown;
    bool animate = false;
    bool animateDown = false;
    bool animateUp = false;
    [SerializeField]
    EventSystem myUiEventSystem;
    private void Start()
    {
        myOriginalPosition = GetComponent<RectTransform>().rect.position;
        OriginPosDown = myOriginalPosition;
        OriginPosUp = myOriginalPosition;
        OriginPosDown.y = myOriginalPosition.y - 5f;
        OriginPosUp.y = myOriginalPosition.y = 5f;
    }
    //public void OnDeselect(BaseEventData eventData)
    //{
    //    animate = false;
    //    animateDown = false;
    //    animateUp = false;
    //}

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    animate = true;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    animate = false;
    //    animateDown = false;
    //    animateUp = false;
    //}

    //public void OnSelect(BaseEventData eventData)
    //{
    //    animate = true;
    //}

    private void Update()
    {

        if (myUiEventSystem.currentSelectedGameObject.name == transform.name)
        {
            animate = true;
            animateUp = true;
        }
        else
            animate = false;

        Debug.Log(myUiEventSystem.currentSelectedGameObject.ToString());

        if(animate)
        {
            Debug.Log("I'm selected");
            if (animateDown)
            {
                if ((transform.position - OriginPosDown).magnitude < 5f)
                {
                    animateUp = true;
                    animateDown = false;
                }
                else
                {
                    transform.Translate(OriginPosDown);
                }
            }
            if (animateUp)
            {
                if ((transform.position - OriginPosUp).magnitude < 5f)
                {
                    animateUp = false;
                    animateDown = true;
                }
                else
                {
                    transform.Translate(OriginPosUp);
                }
            }
        }
        else
        {
            transform.position = myOriginalPosition;
        }
    }

}
