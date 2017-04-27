using UnityEngine;
using System.Collections;

public class SoulMonster : MonoBehaviour {

    private Transform player;
    private PlayerATKAndDamage playerAtkAndDamage;
    private CharacterController cc;
    private Animator animator;

    public float attackDistance = 3;//这个是攻击距离，也是寻路的目标距离
    public float speed = 2;
    public float attackTime = 3;
    private float attackTimer = 0;
    void Start() {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        playerAtkAndDamage = player.GetComponent<PlayerATKAndDamage>();
        cc = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
        attackTimer = attackTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerAtkAndDamage.hp <= 0) {
            animator.SetBool("Walk", false);
            return;
        }
        Vector3 targetPos = player.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
        float distance = Vector3.Distance(targetPos, transform.position);
        if (distance <= attackDistance) {//在攻击距离之内
            attackTimer += Time.deltaTime;
            if (attackTimer > attackTime) {//达到计时的攻击时间
                animator.SetTrigger("Attack");
                attackTimer = 0;
            } else {
                animator.SetBool("Walk", false);
            }
        } else {//进行跟踪 跑向目标
            attackTimer = attackTime;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("MonRun")) {
                cc.SimpleMove(transform.forward * speed);
            }
            animator.SetBool("Walk", true);
        }
	}
}

