using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SkinButton[] skinButton;
    [SerializeField] private Button purchaseButton;
    public static Action<int> onSelectSkin;

    [Header("Skins")]
    [SerializeField] private Sprite[] skins;
    // Start is called before the first frame update
    [Header("Price")]
     private int skinprice;
    [SerializeField] private Text priceText;

    private void Awake() {
        priceText.text = skinprice.ToString();
        skinprice = PlayerPrefs.GetInt("Price",5);
        UnlockSkins(0);
        
    }
    IEnumerator Start()
    {
        configerButtton();
        UpdatePurchaseButton();
        yield return null;

        skinslected(GetLastSelectedSkin());
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.D))
        //     UnlockSkins(UnityEngine.Random.Range(0,skinButton.Length));
        if(Input.GetKeyDown("s"))
            PlayerPrefs.DeleteAll();
        priceText.text = skinprice.ToString();
    }
    private void configerButtton()
    {
        for (int i = 0; i < skinButton.Length; i++)
        {
            bool unlock = PlayerPrefs.GetInt("skinButton" +i) == 1 ;            
            skinButton[i].configer(skins[i],unlock);
            int skinAmount = i;
            skinButton[i].getbutton().onClick.AddListener(() => skinslected(skinAmount));
            
        }

    }
    private void UnlockSkins(int index)
    {
        PlayerPrefs.SetInt("skinButton" + index,1);
        skinButton[index].unlock();
    }
    private void UnlockSkins(SkinButton skinButtonIndex)
    {
        int skinIndex = skinButtonIndex.transform.GetSiblingIndex();
        UnlockSkins(skinIndex);
    }
    private void skinslected(int skinamount)
    {
        // Debug.Log("skin Button"+ skinamount);
        for (int i = 0; i < skinButton.Length; i++)
        {
            if(skinamount == i)
                skinButton[i].selector();
            else
                skinButton[i].Unselector();
        }
        onSelectSkin?.Invoke(skinamount);
        setSelectedskin(skinamount);
    }
    public void purchaseSkinsButton()
    {
        List<SkinButton> skinButtonlist = new List<SkinButton>();
        for (int i = 0; i < skinButton.Length; i++)
        {
            if(!skinButton[i].IsUnlock())
                skinButtonlist.Add(skinButton[i]);
        }
        if(skinButtonlist.Count <= 0)
            return;
        if(DataManager.instance.getconi() < skinprice){
            UpdatePurchaseButton();
            return;
        }
        
        SkinButton RandomeSkinbutton = skinButtonlist
                                        [UnityEngine.Random.Range(0,skinButtonlist.Count)];
        UnlockSkins(RandomeSkinbutton);
        skinslected(RandomeSkinbutton.transform.GetSiblingIndex());
        DataManager.instance.removeCoins(skinprice);
        UpdatePurchaseButton();
        // skinprice *=2;
        Invoke("updateprice",.1f);
    }
    public void UpdatePurchaseButton()
    {
        if(DataManager.instance.getconi() < skinprice)
            purchaseButton.interactable = false;
        else 
            purchaseButton.interactable = true;
        
    }
    private void updateprice()
    {
        skinprice *=2;
        PlayerPrefs.SetInt("Price",skinprice);
    }
    private int GetLastSelectedSkin()
    {
        return PlayerPrefs.GetInt("lastselectedSkin",0);
    }
    private void setSelectedskin(int index)
    {
        PlayerPrefs.SetInt("lastselectedSkin",index);
    }
}
