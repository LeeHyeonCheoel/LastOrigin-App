using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class State
{
    public float hp;            // 체력        : 기본+ , 링크%
    public float atk;           // 공격력      : 기본+ , 링크% , 버프%
    public float cri;           // 치명타      : 기본+ , 링크+ , 버프+
    public float armor;         // 방어력      : 기본+ , 링크% , 버프%
    public float hitrate;       // 적중률      : 기본+ , 링크+ , 버프+
    public float speed;         // 행동력      : 기본+ , 링크+ , 버프+ or %
    public float avoid;         // 회피율      : 기본+ , 링크+ , 버프+
    public float experience;    // 경험치      : 기본x , 링크+ , 버프+
    public float skillDamage;   // 스킬 데미지 : 기본x , 링크+ , 버프+
    public float penetrate;     // 방어 관통   : 기본x , 링크x , 버프+
}
