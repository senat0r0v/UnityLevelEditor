using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditor : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject placerPrefab;
    [SerializeField] private TextAsset csvFile;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Edit Level Success
            EditLevel(csvFile);
            Debug.Log("Level Succesfully Generated!");
        }
        catch
        {
            // Failed to edit level
            Debug.Log("You need to place csv file into the LevelEditorManager part of the script.");
        }
    }

    // Function that edits level based on csv values
    private void EditLevel(TextAsset csvFile)
    {
        string[] csvRows = csvFile.text.Split('\n');

        for (int i = 0; i < csvRows.Length; i++)
        {
            // If everything is valid it will add the placer prefab in that position on the 0 y axis
            string[] csvColumns = csvRows[i].Split(',');
            if (csvColumns.Length > 1 && IsValid(csvColumns[0]) && IsValid(csvColumns[1]))
            {
                float posX = float.Parse(csvColumns[0]);
                float posZ = float.Parse(csvColumns[1]);
                Vector3 position = new Vector3(posX, 0, posZ);
                Instantiate(placerPrefab, position, Quaternion.identity);
            }
        }

    }

    // Function that checks if the value is valid that it is a floating point value or integer
    private bool IsValid(string v)
    {
        try
        {
            float value = float.Parse(v);
            return true;
        }
        catch
        {
            Debug.Log("Column failed to parse: " + v);
            return false;
        }
    }
}
