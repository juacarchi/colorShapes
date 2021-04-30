using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forma : MonoBehaviour
{
    
    public string tagCorrecto;
    public GameObject correctGO;
    public List<GameObject> otherGO;
    public Sprite spriteForma;
    public AudioClip audioForma;
    
    public Forma( string tagCorrecto, GameObject correctGO, List<GameObject> otherGO, Sprite spriteForma)
    {
        
        this.tagCorrecto = tagCorrecto;
        this.correctGO = correctGO;
        this.otherGO = otherGO;
        this.spriteForma = spriteForma;
        
    }
   
    public string GetTagCorrecto()
    {
        return this.tagCorrecto;
    }
    public GameObject GetCorrectGO()
    {
        return this.correctGO;
    }
    public List<GameObject> GetOtherGO()
    {
        return this.otherGO;
    }
    public Sprite GetSpriteForma()
    {
        return this.spriteForma;
    }
    public AudioClip GetAudioForma()
    {
        return this.audioForma;
    }
    
}
