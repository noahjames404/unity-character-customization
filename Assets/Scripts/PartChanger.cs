using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PartChanger : MonoBehaviour
{
    public PartsList part;
    public PartsFixer playerPart;
    [SerializeField] TextMeshProUGUI PartName;
    [SerializeField] TextMeshProUGUI PartIndex;
    [SerializeField] TextMeshProUGUI MaterialIndex;
    [SerializeField] Button PartPrevButton;
    [SerializeField] Button PartNextButton;
    [SerializeField] Button MaterialPrevButton;
    [SerializeField] Button MaterialNextButton;

    private void Start()
    {
        string name = part.name;
        name = name.Substring(0, name.Length - 4);
        gameObject.name = string.Format("PartChanger ({0})", name);
        PartName.text = name;
        updateIndex();

        PartNextButton.onClick.AddListener(delegate { NextPart(); });
        PartPrevButton.onClick.AddListener(delegate { PrevPart(); });
        MaterialNextButton.onClick.AddListener(delegate { NextMaterial(); });
        MaterialPrevButton.onClick.AddListener(delegate { PrevMaterial(); });
    }
    private void NextPart()
    {
        part.NextPart();
        playerPart.UpdatePart();
        updateIndex();
    }
    private void PrevPart()
    {
        part.PreviousPart();
        playerPart.UpdatePart();
        updateIndex();
    }
    private void NextMaterial()
    {
        part.NextMaterial();
        playerPart.UpdatePart();
        updateIndex();
    }
    private void PrevMaterial()
    {
        part.PreviousMaterial();
        playerPart.UpdatePart();
        updateIndex();
    }

    public void RandomPart()
    {
        part.GetRandomPart();
        playerPart.UpdatePart();
        updateIndex();
    }
    private void updateIndex()
    {
        if (part.getPartListSize() > 0)
        {
            PartIndex.text = (part.getCurrentPartIndex() + 1) + "/" + part.getPartListSize();
            MaterialIndex.text = (part.getCurrentMaterialIndex() + 1) + "/" + part.getMaterialListSize();
        }
        else
        {
            PartIndex.text = "NA";
            MaterialIndex.text = "NA";
        }
    }
}
