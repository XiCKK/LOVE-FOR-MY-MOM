using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;

public class RatEnemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Rigidbody2D _rb;
    [SerializeField] private float moveSpeed = 4f;

    [SerializeField] private float agroRange;

    private Animator anim;

    [SerializeField] private AudioClip RatEffect;
    private bool walkCheck;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        walkCheck = true;
    }


    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

        if (transform.position.x != 0)
        {
            if (walkCheck == false)
            {
                walkCheck = true;
            }
        }
        else
        {
            walkCheck = false;
        }
    }

    private void ChasePlayer()
    {
        SoundManager.instance.PlaySound2(RatEffect);
        anim.SetBool("RatWalk", true);
        if (transform.position.x < player.position.x)
        {
            _rb.velocity = new Vector2(moveSpeed, _rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            _rb.velocity = new Vector2(-moveSpeed, _rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

    }
    private void StopChasingPlayer()
    {
        SoundManager.instance.StopSound(RatEffect);
        _rb.velocity = new Vector2(0, 0);
        anim.SetBool("RatWalk", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PosionWater")
        {
            StartCoroutine(RatDie());
        }

        if (collision.tag == "Player")
        {
            anim.SetTrigger("Attack");
        }
    }
    IEnumerator RatDie()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}