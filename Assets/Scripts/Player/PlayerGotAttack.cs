using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerGotAttack : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            StartCoroutine(GotAttack());
        }
    }

    IEnumerator GotAttack()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
