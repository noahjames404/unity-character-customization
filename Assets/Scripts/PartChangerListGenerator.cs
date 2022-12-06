using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartChangerListGenerator : MonoBehaviour
{
    [SerializeField] CharacterBody body;
    [SerializeField] PartChanger partChangerTemplate;
    [SerializeField] List<PartChanger> partChangers;
    // Start is called before the first frame update
    void Start()
    {
        partChangers = new List<PartChanger>();
        AddPartChanger(body.Armor);
        AddPartChanger(body.Body);
        AddPartChanger(body.Boot);
        AddPartChanger(body.Eyes);
        AddPartChanger(body.Gloves);
        AddPartChanger(body.Hair);
        AddPartChanger(body.Top);
        AddPartChanger(body.Bottom);
        AddPartChanger(body.Accessory);
        Destroy(partChangerTemplate.gameObject);
    }

    private void AddPartChanger(PartsList parts) {
        PartChanger newPart = Instantiate(partChangerTemplate, transform);
        newPart.part = parts;
        partChangers.Add(newPart);
    }

    public void RandomizeCharacter()
    {
        foreach (PartChanger part in partChangers) {
            part.RandomPart();
        }
    }



}
