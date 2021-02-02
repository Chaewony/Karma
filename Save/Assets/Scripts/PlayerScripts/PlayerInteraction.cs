using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector3 dirVec;
    private RaycastHit2D rayHit;
    private GameObject scanObject;
    public GameManager manager;
    public GameObject buffUI;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //방향
        if (spriteRenderer.flipX == false)
            dirVec = Vector2.right;
        else if (spriteRenderer.flipX == true)
            dirVec = Vector2.left;

        //레이캐스팅
        Debug.DrawRay(rb.position, dirVec * 0.7f, new Color(0, 1, 0));
        rayHit = Physics2D.Raycast(rb.position, dirVec, 0.7f, LayerMask.GetMask("NPC"));
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
        {
            scanObject = null;
            manager.isAction = false;
            buffUI.SetActive(false); //NPC와 멀어지면 버프 선택창이 저절로 꺼진다
        }
    }

    public void Talk()
    {
        if (scanObject != null) //스캔된 오브젝트가 있으면
        {
            manager.isAction = true;
            manager.Action(scanObject);
        }

        if(rayHit.collider == null)
        {
            manager.isAction = false;
        }
    }
}
