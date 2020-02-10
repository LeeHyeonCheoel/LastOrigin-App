using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eBioKinds
{
    Salute,         // 경장
    Activation,     // 기동
    Heavy           // 중장
}
public enum eBioType
{
    Supporter,      // 지원기
    Saver,          // 보호기
    Attacker,       // 공격기
}
public enum eBioRank
{
    SS,
    S,
    A,
    B
}

[CreateAssetMenu(menuName ="Bioroid Data")]
public class UnitData : ScriptableObject
{
    [Tooltip("Atlas 내부 Sprite의 이름으로도 사용됩니다. XXX 3자리를 입력해주세요.")]
    public string id;
    public new string name;
    public string group;

    public eBioType bioType;
    public eBioKinds bioKind;
    public eBioRank bioRank;
    
    public Consumed consumed;
    public State state;

    public bool fullRink;
    public State rinkBonus;

    public bool IsBioroid;
   

    private void OnValidate()
    {
        consumed = ConsumedTable.SearchTable(bioType, bioRank, bioKind, fullRink);
    }
}
