using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangementManager : MonoBehaviour
{
    private static ArrangementManager m_Instance = null;
    public static ArrangementManager instance
    {
        get
        {
            return m_Instance;
        }
    }

    // Set UI 관련
    public GameObject uiMenuRoot;
    public List<GameObject> uiMenuList;

    // Unit UI 관련
    [Space(15)]
    [Header("<< 유닛 정보 출력관련 UI >>")]
    [Space(15)]
    public UILabel uiHP;
    public UILabel uiATK;
    public UILabel uiCri;
    public UILabel uiArmor;
    public UILabel uiHitrate;
    public UILabel uiSpeed;
    public UILabel uiAvoid;
    public UILabel uiName;
    public UILabel uiGroup;


    public UnitData m_LastChoisedUnit;
    
    float screenWidth, screenHeight;
    private void OnEnable()
    {
        if(m_Instance == null)
        {
            m_Instance = this;
        }

        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    private void OnDestroy()
    {
        m_Instance = null;
    }

    public void ExplanceUpdate(UnitData _lastUnit)
    {
        m_LastChoisedUnit = _lastUnit;

        if(m_LastChoisedUnit == null)
        {
            UnitUISetActive(false);
        }
        else
        {
            uiHP.text = m_LastChoisedUnit.state.hp.ToString();
            uiATK.text = m_LastChoisedUnit.state.atk.ToString();
            uiCri.text = m_LastChoisedUnit.state.cri.ToString() + "%";
            uiArmor.text = m_LastChoisedUnit.state.armor.ToString();
            uiHitrate.text = m_LastChoisedUnit.state.hitrate.ToString() + "%";
            uiSpeed.text = m_LastChoisedUnit.state.speed.ToString();
            uiAvoid.text = m_LastChoisedUnit.state.avoid.ToString() + "%";
            uiName.text = m_LastChoisedUnit.name;
            uiGroup.text = m_LastChoisedUnit.group + " 소속";

            UnitUISetActive(true);
        }
    }

    void UnitUISetActive(bool _bool)
    {
        uiHP.gameObject.SetActive(_bool);
        uiATK.gameObject.SetActive(_bool);
        uiCri.gameObject.SetActive(_bool);
        uiArmor.gameObject.SetActive(_bool);
        uiHitrate.gameObject.SetActive(_bool);
        uiSpeed.gameObject.SetActive(_bool);
        uiAvoid.gameObject.SetActive(_bool);
        uiName.gameObject.SetActive(_bool);
        uiGroup.gameObject.SetActive(_bool);
    }


}
