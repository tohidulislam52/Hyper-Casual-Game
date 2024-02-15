using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour
{
    [SerializeField] private Button thisButton;
    [SerializeField] private Image skinImage;
    [SerializeField] private GameObject LockImage;
    [SerializeField] private GameObject Selector;
    private bool unlocked =true;
    // Start is called before the first frame update
   
    public void configer(Sprite skinSprite,bool unlocked)
    {
        skinImage.sprite = skinSprite;
        this.unlocked = unlocked;
        if(unlocked)
            unlock();
        else
            Lock();

    }
    public void unlock()
    {
        thisButton.interactable = true;
        skinImage.gameObject.SetActive(true);
        LockImage.SetActive(false);
        unlocked = true;
    }
    public void Lock()
    {
        thisButton.interactable = false;
        skinImage.gameObject.SetActive(false);
        LockImage.SetActive(true);
    }
    public void selector()
    {
        Selector.SetActive(true);
    }
    public void Unselector()
    {
        Selector.SetActive(false);
    }
    public bool IsUnlock()
    {
        return unlocked;
    }
    public Button getbutton()
    {
        return thisButton;
    }


}
