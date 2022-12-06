using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PartsList")]
public class PartsList : ScriptableObject
{
    [SerializeField] int selectedPart;
    [SerializeField] PartsData[] parts;

    public PartsData GetCurrentPart() {
        if (parts.Length > 0) {
            return parts[selectedPart];
        }

        return null;
    }

    public int getCurrentMaterialIndex()
    {
        return parts[selectedPart].selectedMaterial;
    }
    public int getMaterialListSize()
    {
        return parts[selectedPart].partMaterial.Length;
    }

    public int getCurrentPartIndex()
    {
        return selectedPart;
    }
    public int getPartListSize()
    {
        return parts.Length;
    }

    public void NextMaterial()
    {
        if (parts[selectedPart].partMaterial.Length > 0)
        {
            parts[selectedPart].selectedMaterial++;
            if (parts[selectedPart].selectedMaterial >= parts[selectedPart].partMaterial.Length)
            {
                parts[selectedPart].selectedMaterial = 0;
            }
        }

    }
    public void PreviousMaterial()
    {
        if (parts[selectedPart].partMaterial.Length > 0)
        {
            parts[selectedPart].selectedMaterial--;
            if (parts[selectedPart].selectedMaterial < 0)
            {
                parts[selectedPart].selectedMaterial = parts[selectedPart].partMaterial.Length - 1;
            }
        }

    }

    public void NextPart()
    {
        if (parts.Length > 0)
        {
            selectedPart++;
            if (selectedPart >= parts.Length )
            {
                selectedPart = 0;
            }

        }

    }
    public void PreviousPart()
    {
        if (parts.Length > 0)
        {
            selectedPart--;
            if (selectedPart < 0)
            {
                selectedPart = parts.Length-1;
            }

        }

    }
    public PartsData GetRandomPart()
    {
        if (parts.Length > 0)
        {
            int result = Random.Range(0, parts.Length );
            selectedPart = result;
            parts[selectedPart].selectedMaterial = Random.Range(0, parts[selectedPart].partMaterial.Length); ;
            return parts[selectedPart];
        }

        return null;
    }
}
