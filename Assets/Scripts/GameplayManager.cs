using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public Text numberText;
    public SpriteRenderer posSpriteForma;
    Forma newForma;
    string correctTag;
    public List<GameObject> formasList;
    List<GameObject> incorrectForm;

    public float minRandom0, maxRandom0;
    public float minRandom1, maxRandom1;
    public float minRandom2, maxRandom2;
    public float timeSecure;

    AudioClip soundForma;
    GameObject correctForm;

    int numberToSucces;
    int n_forma;
    float incorrectTimer;
    float correctTimer;
    float securityTimer;
    int level;
    private void Awake()
    {
        GameManager.instance.SetCompleted(false);
        level = GameManager.instance.GetLevel();
        GameManager.instance.SetBasketSpeed(6);
        if (level == 0)
        {
            GameManager.instance.SetFallSpeed(2);
        }
        else if (level == 1)
        {
            GameManager.instance.SetFallSpeed(4);
        }
        else if (level == 2)
        {
            GameManager.instance.SetFallSpeed(6);
        }

        RandomForma();
        
        correctTimer = 5;
        incorrectTimer = 3;
        securityTimer = 15;
    }
    public void RandomForma()
    {
        if(level == 0)
        {
            numberToSucces = Random.Range(1, 3);
        }
        else if(level == 1)
        {
            numberToSucces = Random.Range(3, 7);
        }
        else if(level == 2)
        {
            numberToSucces = Random.Range(4, 9);
        }
        GameManager.instance.SetNumberToSucces(numberToSucces);
        numberText.text = numberToSucces.ToString();
        n_forma = Random.Range(0, formasList.Count);
        newForma = formasList[n_forma].GetComponent<Forma>();
        Sprite spriteForma = newForma.GetSpriteForma();
        posSpriteForma.sprite = spriteForma;
        correctTag = newForma.GetTagCorrecto();
        CollisionManager.instance.SetTagCorrect(correctTag);
        soundForma = newForma.GetAudioForma();
        //SoundManager.instance.PlaySFX(soundForma);
        correctForm = newForma.GetCorrectGO();
        incorrectForm = newForma.GetOtherGO();
    }
    
    public void Update()
    {
        //HACER OTRO TIMER PARA ASEGURARNOS QUE SIEMPRE ACABAN INSTANCIANDOSE EL ELEMENTO BUENO
        securityTimer -= Time.deltaTime;
        if (securityTimer <= 0)
        {
            Instantiate(correctForm, new Vector2(Random.Range(BasketMovement.instance.minXValue, BasketMovement.instance.maxXValue), 7.0f), Quaternion.identity);
            ResetTimers();
            securityTimer = timeSecure;
        }
        correctTimer -= Time.deltaTime;
        if (correctTimer <= 0)
        {
            Instantiate(correctForm, new Vector2(Random.Range(BasketMovement.instance.minXValue, BasketMovement.instance.maxXValue), 7.0f), Quaternion.identity);
            ResetTimers();
        }
        incorrectTimer -= Time.deltaTime;
        if (incorrectTimer <= 0)
        {
            Instantiate(incorrectForm[Random.Range(0, incorrectForm.Count)], new Vector2(Random.Range(BasketMovement.instance.minXValue, BasketMovement.instance.maxXValue), 7.0f), Quaternion.identity);
            ResetTimers();
        }
    }
    public void ResetTimers()
    {
        if (level == 0)
        {
            correctTimer = Random.Range(minRandom0, maxRandom0);
            incorrectTimer = Random.Range(minRandom0 - 1, maxRandom0 - 1);
            securityTimer += 1;
        }
        else if (level == 1)
        {
            correctTimer = Random.Range(minRandom1, maxRandom1);
            incorrectTimer = Random.Range(minRandom1 - 1, maxRandom1 - 1);
            securityTimer += 1;
        }
        else if (level == 2)
        {
            correctTimer = Random.Range(minRandom2, maxRandom2);
            incorrectTimer = Random.Range(minRandom2, maxRandom2 - 1);
            securityTimer += 1;
        }

        if (correctTimer == incorrectTimer)
        {
            correctTimer = Random.Range(minRandom2, maxRandom2);
            incorrectTimer = Random.Range(minRandom2, maxRandom2 - 1);
            
        }
    }
    public void MuteMusic()
    {
        MusicManager.instance.MuteMusic();
    }
    public void PlayButton()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.buttonSound);
    }
    public void ResetGame()
    {
        GameManager.instance.Resume();
        GameManager.instance.SetRecollectedFormas(0);
        ManagerScene.instance.SetNumberSceneToChange(1);
        TransitionManager.instance.AnimateTransition();
    }
    public void ReturnMenu()
    {
        GameManager.instance.Resume();
        GameManager.instance.SetRecollectedFormas(0);
        ManagerScene.instance.SetNumberSceneToChange(0);
        TransitionManager.instance.AnimateTransition();
    }
}
