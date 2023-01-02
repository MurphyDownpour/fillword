using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordsDatabase", menuName = "Configs/WordsDatabase")]
public class WordsDatabase : ScriptableObject
{
    [SerializeField] private List<StageData> _stageDatas = new List<StageData>();

    public StageData GetStageData(int id)
    {
        foreach (var stageData in _stageDatas)
        {
            if (stageData.StageId == id)
                return stageData;
        }

        return null;
    }
}

[System.Serializable]
public class StageData
{
    public int StageId;
    public List<WordData> WordDatas = new List<WordData>();
}

[System.Serializable]
public class WordData
{
    public string RawWord;
    [SerializeField] private CharCase CharCase;

    public Queue<char> GetAsCharQueue()
    {
        var tempWord = RawWord;
        switch (CharCase)
        {
            case CharCase.Default:
                break;
            case CharCase.Lower:
                tempWord = RawWord.ToLower();
                break;
            case CharCase.Upper:
                tempWord = RawWord.ToUpper();
                break;
        }

        var asArray = tempWord.ToCharArray();
        var q = new Queue<char>(asArray);
        return q;
    }
}

public enum CharCase
{
    Default,
    Upper,
    Lower,
}