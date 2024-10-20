using System.Collections;
using UnityEngine;

public class GameButton : MonoBehaviour
{
    [SerializeField]
    private GameObject floor;
    private Animator anim;
    [SerializeField] private AudioClip hitEffect;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        floor.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Box"))
        {
            anim.SetTrigger("Hit");
            SoundManager.instance.PlaySound(hitEffect);
            floor.SetActive(true);
        }
        else
        {
            anim.SetTrigger("Normal");
            floor.SetActive(false);
        }
    }

}
