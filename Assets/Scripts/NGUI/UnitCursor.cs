using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCursor : MonoBehaviour
{
    static UnitCursor m_instance = null;
    
    public static UnitCursor instance
    {
        get
        {
            return m_instance;
        }
    }

    public Camera uiCamera;
    public UISprite uiUnitIcon;
    new Transform transform;

    UnitData m_PickupUnit = null;
   

    public void Awake()
    {
        m_instance = this;
    }
    public void OnDestroy()
    {
        m_instance = null;
    }

    public void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        // 커서 위치따라서 이동
        Vector3 position = Vector3.zero;

#if UNITY_ANDROID || UNITY_IOS
        if(Input.touchCount > 0)
        {
            position = Input.GetTouch(0).position;
        }
        else
        {
            position = Vector3.zero;
        }
#else
        position = Input.mousePosition;
#endif

        if (uiCamera != null)
        {
            position.x = Mathf.Clamp01(position.x / Screen.width);
            position.y = Mathf.Clamp01(position.y / Screen.height);

            transform.position = uiCamera.ViewportToWorldPoint(position);

            // For pixel - peerfect results
            if (uiCamera.orthographic)
            {
                Vector3 lp = transform.localPosition;
                lp.x = Mathf.Round(lp.x);
                lp.y = Mathf.Round(lp.y);

                transform.localPosition = lp;
            }
        }
        else
        {
            // Simple calculation that assumes that the camera is of fixed size
            position.x -= Screen.width * 0.5f;
            position.y -= Screen.height * 0.5F;
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);
            transform.localPosition = position;
        }

    }

    public UnitData UpdateUnit(UnitData _unit)
    {
       
        if (m_PickupUnit != null)
        {
            if(_unit != null)
            {
                UnitData tempUnit = m_PickupUnit;
                m_PickupUnit = _unit;
                _unit = tempUnit;
                CursorUpdate();
                ArrangementManager.instance.ExplanceUpdate(_unit);
                return _unit;
            }
            else
            {
                _unit = m_PickupUnit;
                m_PickupUnit = null;
                ArrangementManager.instance.ExplanceUpdate(_unit);
                CursorUpdate();
                return _unit;
            }
        }
        else
        {
            m_PickupUnit = _unit;
            ArrangementManager.instance.ExplanceUpdate(_unit);
            CursorUpdate();
            return null;
        }
    }

    void CursorUpdate()
    {
        if(m_PickupUnit != null)
        {
            uiUnitIcon.spriteName = m_PickupUnit.id;
            uiUnitIcon.gameObject.SetActive(true);
        }
        else
        {
            uiUnitIcon.gameObject.SetActive(false);
            uiUnitIcon.spriteName = null;
        }
    }

}
