using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PosionWater : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PosionWater" || collision.tag == "PlatformClose") //if hit platformclose in PlatformClose
        {
            SoundManager.instance.PlaySound(dieEffect);
            StartCoroutine(Reload());
        }
    }
    [SerializeField] private AudioClip dieEffect;
    private IEnumerator Reload()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
 