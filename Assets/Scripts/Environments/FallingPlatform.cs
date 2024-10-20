using UnityEngine;
using System.Collections;
public class FallingPlatform : MonoBehaviour
{
    private float fallDelay = 0.25f;
    private float destroyDelay = 1f;
    private Animator anim;
    [SerializeField] private AudioClip collapsEffect;

    [SerializeField] private Rigidbody2D _rb;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(collapsEffect);
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        _rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
