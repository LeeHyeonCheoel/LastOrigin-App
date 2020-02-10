using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    UISprite uiIcon;

    [HideInInspector]
    public bool isArrangment = false;
   // [HideInInspector]
    public UnitData m_Unit;


    void OnEnable()
    {
        if(uiIcon == null)
        {
            uiIcon = transform.GetChild(0).GetComponent<UISprite>();
        }
        ImageUpdate();
    }

    void OnClick()
    {
        if(UICamera.currentKey == KeyCode.Mouse0 /* left */)
        {
            m_Unit = UnitCursor.instance.UpdateUnit(m_Unit);
        }
        else if (UICamera.currentKey == KeyCode.Mouse1 /* right */)
        {
            if (isArrangment == true)
            {
                // 유닛 정보 변경 메뉴 출력
            }
            else
            {
                // 유닛 셋팅 메뉴 출력
            }
        }

        ImageUpdate();
        
    }

    void ImageUpdate()
    {
        if(m_Unit != null)
        {
            uiIcon.spriteName = m_Unit.id;
            uiIcon.gameObject.SetActive(true);
        }
        else
        {
            uiIcon.gameObject.SetActive(false);
            uiIcon.spriteName = null;
        }
    }
}
