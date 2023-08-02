using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerActivation : MonoBehaviour
{
    Animator animator;
    public float distance = 5f;
    public Vector3 boxSize = new Vector3(1f, 1f, 1f);
    public LayerMask layerMask;
    [SerializeField]
    bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttack && !animator.GetBool("isAttack"))
        {
            StartCoroutine(Attack());
        }
    }
    private IEnumerator Attack()
    {
        animator.SetBool("isAttack", true);
        isAttack = true;
        float attackTiming = (animator.GetCurrentAnimatorStateInfo(0).length) * 0.3f;
        yield return new WaitForSeconds(attackTiming);
        // 현재 오브젝트의 위치와 방향을 기준으로 박스 캐스트를 수행
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;

        RaycastHit[] hits = Physics.BoxCastAll(origin, boxSize * 0.5f, direction, transform.rotation, distance, layerMask);
        foreach (RaycastHit hit in hits)
        {
            Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
            if (enemy != null) 
            {
                enemy.DamageCulculate(1);
            }
        }
        isAttack = false;
        animator.SetBool("isAttack", false);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + transform.forward * distance * 0.5f, boxSize);
    }

}
