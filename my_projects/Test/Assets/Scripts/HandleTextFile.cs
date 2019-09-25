using UnityEngine;
using UnityEditor;
using System.IO;

public class HandleTextFile : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Tools/Write file")]
    // [MenuItem("AssetDatabase/ImportExample")]
#endif
    static void WriteString()
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();

        //Re-import the file to update the reference in the editor
#if UNITY_EDITOR
        AssetDatabase.ImportAsset(path); 
#endif        
        TextAsset asset = Resources.Load("test") as TextAsset;

        //Print the text from the file
        Debug.Log(asset.text);
    }

#if UNITY_EDITOR
    [MenuItem("Tools/Read file")]
#endif
    static void ReadString()
    {
        string path = "Assets/Resources/test.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    void Start()
    {
        WriteString();
        ReadString();
        Debug.Log("Current time " + System.DateTime.Now);
    }
}
