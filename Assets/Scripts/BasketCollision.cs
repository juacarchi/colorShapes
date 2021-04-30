using UnityEngine;

public class BasketCollision : MonoBehaviour
{
    public SpriteRenderer basketFront;
    public SpriteRenderer basketBack;
    public Color colorStart;
    public Color colorEnd;
    bool fail;
    float timerFail;
    public float timeFail;
    string tagCorrect;
    GameObject failObject;
    Animator animBasket;
    int collisions;
    private void Start()
    {
        timerFail = timeFail;
        animBasket = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        tagCorrect = CollisionManager.instance.GetTagCorrect();
        Debug.Log("Ha detectado colision");
        if (other.CompareTag(tagCorrect))
        {
            collisions++;
            Debug.Log("ACIERTO");
            GameManager.instance.SumaRecollectedFormas();
            FXManager.instance.InstantitateFX(0, other.transform);
            SoundManager.instance.PlaySFX(SoundManager.instance.correctSound);
            //FALTAN SONIDOS
            //SoundNumberManager.instance.PlaySFX(SoundNumberManager.instance.soundsNumbers[collisions]);
            other.transform.SetParent(this.transform);
            other.transform.position = this.transform.position;
            int level = GameManager.instance.GetLevel();
            if (level == 0)
            {
                Destroy(other.gameObject, 0.25f);
            }
            else if (level == 1)
            {
                Destroy(other.gameObject, 0.15f);
            }
            else if(level == 2)
            {
                Destroy(other.gameObject, 0.05f);
            }
        }
        else
        {
            SoundManager.instance.PlaySFX(SoundManager.instance.failSound);
            other.transform.SetParent(this.transform);
            other.transform.position = this.transform.position;
            int level = GameManager.instance.GetLevel();
            if (level == 0)
            {
                Destroy(other.gameObject, 0.25f);
            }
            else if (level == 1)
            {
                Destroy(other.gameObject, 0.15f);
            }
            else if (level == 2)
            {
                Destroy(other.gameObject, 0.05f);
            }
            animBasket.SetTrigger("Fail");
        }
    }

    

}
