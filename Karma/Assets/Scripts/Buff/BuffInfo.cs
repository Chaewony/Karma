using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //추가

[System.Serializable]
[CreateAssetMenu (menuName = "Buff", fileName = "Buff/BuffInfo")] //menuName에 들어간 이름으로 에셋 생성할 수 있음

public class BuffInfo : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private string buffName;
    [SerializeField] 
    private float fullHp;
    [SerializeField]
    private float dashCoolBuff;
    [SerializeField]
    private float fireBallCoolBuff;
    [SerializeField]
    private float rhythmCoolBuff;
    [SerializeField]
    private string buffContext;

    public Sprite mySprite { get => sprite; }
    public string myBuffName { get => buffName; }
    public float myHpBuff { get => fullHp; }
    public float myDashCoolBuff { get => dashCoolBuff; }
    public float myFireBallCoolBuff { get => fireBallCoolBuff; }
    public float myRhythmCoolBuff { get => rhythmCoolBuff; }
    public string myBuffContext { get => buffContext; }
}

public enum buffSlot
{
    BuffSlot1,
    BuffSlot2,
    BuffSlot3
}
