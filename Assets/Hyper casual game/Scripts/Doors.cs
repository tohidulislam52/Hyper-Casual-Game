using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum BonusType{PointPlas,PointMinas,PointMultipication,PointDivition}
public class Doors : MonoBehaviour
{
   
    [Header("Element")]
    [SerializeField] SpriteRenderer LeftDoorSprite;
    [SerializeField] SpriteRenderer RightDoorSprite;
    [SerializeField] TextMeshPro leftDoorText;
    [SerializeField] TextMeshPro RighyDoorText;
    [SerializeField] Collider Doorcollider;
    
    [Header("Sattings")]
    [SerializeField] BonusType RightDoorBonusType;
    [SerializeField] int RightDoorBonudNumber;
    [SerializeField] BonusType LeftDoorBonusType;
    [SerializeField] int LeftDoorBonusNumber;
    [SerializeField] Color PointPlasColor;
    [SerializeField] Color PointMinasColor;
    void Start()
    {
        configureBonus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void configureBonus()
    {
        switch (RightDoorBonusType)
        {
            case BonusType.PointPlas:
                RightDoorSprite.color = PointPlasColor;
                RighyDoorText.text = "+" + RightDoorBonudNumber;
                break;
            case BonusType.PointMinas:
                RightDoorSprite.color = PointMinasColor;
                RighyDoorText.text= "-" +RightDoorBonudNumber;
                break;
            case BonusType.PointMultipication:
                RightDoorSprite.color = PointPlasColor;
                RighyDoorText.text = "x"+ RightDoorBonudNumber;
                break;
            case BonusType.PointDivition:
                RightDoorSprite.color = PointMinasColor;
                RighyDoorText.text = "/"+ RightDoorBonudNumber;
                break;
        }

        switch (LeftDoorBonusType)
        {
            case BonusType.PointPlas:
                LeftDoorSprite.color = PointPlasColor;
                leftDoorText.text = "+"+ LeftDoorBonusNumber;
                break;
            case BonusType.PointMinas:
                LeftDoorSprite.color= PointMinasColor;
                leftDoorText.text= "-"+ LeftDoorBonusNumber;
                break;
            case BonusType.PointMultipication:
                LeftDoorSprite.color = PointPlasColor;
                leftDoorText.text = "x"+ LeftDoorBonusNumber;
                break;
            case BonusType.PointDivition:
                LeftDoorSprite.color = PointMinasColor;
                leftDoorText.text = "/"+ LeftDoorBonusNumber;
                break;
        }
    }

    public int GetbonusNumber(float Xposition)
    {
        if(Xposition>0)
        {
            return RightDoorBonudNumber;
        }
        else
        {
            return LeftDoorBonusNumber;
        }
    }

    public BonusType GetBonusType(float Xposition)
    {
        if(Xposition>0)
        {
            return RightDoorBonusType;
        }
        else
        {
            return LeftDoorBonusType;
        }
    }
 public void disabal()
 {
    Doorcollider.enabled=false;
 }

}
