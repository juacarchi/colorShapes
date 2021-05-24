using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int recollectedFormas;
    float fallSpeed;
    float basketSpeed;
    int level; //level = 0 ==> Basico, level = 1 ==> Intermedio, level = 2 ==> Dificil; 
    public static GameManager instance;
    Forma actualForma;
    int numberToSucces;
    bool completed;
    bool levelComplete;
    float timerVictory = 2;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(recollectedFormas == numberToSucces && numberToSucces != 0 && !completed && levelComplete == false)
        {
            completed = true;
            fallSpeed = 0;
            basketSpeed = 0;
            
        }
        if (completed)
        {
            timerVictory -= Time.deltaTime;
            if (timerVictory <= 0)
            {
                UIManager.instance.Victory();
                SoundNumberManager.instance.PlaySFX(SoundNumberManager.instance.victorySound);
                timerVictory = 2f;
                completed = false;
            }
        }
    }
    public void SetCompleted(bool completed)
    {
        this.completed = completed;
    }
    public void SetForma(Forma forma)
    {
        actualForma = forma;
    }
    public Forma GetActualForma()
    {
        return actualForma;
    }
    public int GetRecollectedFormas()
    {
        return this.recollectedFormas;
    }
    public void SetRecollectedFormas(int recollectedFormas)
    {
        this.recollectedFormas = recollectedFormas;
    }
    public void SumaRecollectedFormas()
    {
        this.recollectedFormas ++;
        SoundNumberManager.instance.PlaySFX(SoundNumberManager.instance.soundsNumbers[recollectedFormas-1]);
    }
    public float GetFallSpeed()
    {
        return this.fallSpeed;
    }
    public void SetFallSpeed(float fallSpeed)
    {
        this.fallSpeed = fallSpeed;
    }
    public float GetBasketSpeed()
    {
        return this.basketSpeed;
    }
    public void SetBasketSpeed(float basketSpeed)
    {
        this.basketSpeed = basketSpeed;
    }
    public void SetLevel(int level)
    {
        this.level = level;
    }
    public int GetLevel()
    {
        return level;
    }
    public bool GetLevelComplete()
    {
        return levelComplete;
    }
    public void SetLevelComplete(bool levelComplete)
    {
        this.levelComplete = levelComplete;
    }
    public void SetNumberToSucces(int numberToSucces)
    {
        this.numberToSucces = numberToSucces;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        UIManager.instance.OpenPause();
        //ABRIR PANEL UI
    }
    public void Resume()
    {
        Time.timeScale = 1;
        UIManager.instance.ClosePause();
        //CERRAR PANEL UI
    }
    
      
   
}
