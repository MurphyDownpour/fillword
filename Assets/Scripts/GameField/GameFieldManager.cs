using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class GameFieldManager : MonoBehaviour
{
    [SerializeField] private WordsDatabase _db;
    [SerializeField] private GameFieldCell _cell;
    [SerializeField] private Transform _root;
    
    private GameFieldCell[,] _cells;

    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _xOffset;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _spawnDelay;

    private GameFieldCell _selectedCell;
    // private WordsModel _wordsModel;

    private void Awake()
    {
        // var words = new List<string> { "kill", "milk", "sausage", "grounded", "down", "strike", "hill", "satisfaction" };
        // _wordsModel = new WordsModel(words);
        StartCoroutine(GenerateMatrix());
    }

    private IEnumerator GenerateMatrix()
    {
    
        /*
         public class Bot : IComparable<Bot>
{
    public float Health;
    
    public int CompareTo(Bot other)
    {
        if (Health == other.Health) 
            return 0;
        if (Health > other.Health) 
            return 1;
        else 
            return -1;
    }
}

public class BotSorter : IComparer<Bot>
{
    public int Compare(Bot x, Bot y)
    {
        if (x.Health == y.Health) 
            return 0;
        if (x.Health > y.Health) 
            return 1;
        else 
            return -1;
    }
}

             //List
        var comparer = new BotSorter();
        var lst = new List<Bot>();
        lst.Sort(comparer);
        
        
        List<string> str = new List<string>(new string[] { "1", "2" });
        str.Add("Test");
        str.Remove("Test");
        str.RemoveAt(0);
        if (str.Contains("T"))
        {
            str.AddRange(new string[] { "1", "2"});
        }
        str.Clear();
        str.Sort(); //разобрать сортировки!! (IComparable, IComparer) (IDisposable, IClonable e.t.c)
        
        
 //Array
        int[] arr;
        arr = new int[2]; //v1
        arr = new [] { 1, 2, 3}; //v2
        

        //List
        List<string> str = new List<string>(new string[] { "1", "2" });
        str.Add("Test");
        str.Remove("Test");
        str.RemoveAt(0);
        if (str.Contains("T"))
        {
            str.AddRange(new string[] { "1", "2"});
        }
        str.Clear();
        str.Sort(); //разобрать сортировки!! (IComparable, IComparer) (IDisposable, IClonable e.t.c)
      

        //Dictionary
        Dictionary<string, int> human = new Dictionary<string, int>();
        human.Clear();
        if (!human.ContainsKey("Sam"))
        {
            human.Add("Sam", 32);
        }
        
        if (human.TryGetValue("Tom", out var result))
        {
            Debug.Log($"Tom: {result}");
        }
        else
        {
            human["Tom"] = 12;
        }

        //HashSet
        HashSet<int> set = new HashSet<int>();
        set.Add(2);
        set.Clear();
        set.Remove(2);
        if (set.Add(2))
        {
            Debug.Log("2 added");
        }
        else
        {
            Debug.Log("2 already exists");
        }

        //Stack
        Stack<int> stack = new Stack<int>(new[] { 1, 2, 3, 4 });
        stack.Push(11);
        var res2 = stack.Pop();
        var read2 = stack.Peek();
        
        //Queue
        Queue<int> q = new Queue<int>(new[] { 10, 11, 12 });
        q.Enqueue(11);
        var res = q.Dequeue();
        var read = q.Peek();
         
         */

       

        //var words = _wordsModel.Words; //todo: make Queue
        var stage = _db.GetStageData(0);

        if (stage == null)
            yield break;

        var words = new Queue<WordData>(stage.WordDatas);
        WordData currentWordData = null;
        
        Queue<char> currentWord = new Queue<char>();
        _cells = new GameFieldCell[_width, _height];
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (currentWord.Count == 0)
                {
                    if (words.Count > 0)
                        currentWordData = words.Dequeue();
                    else
                        currentWordData = null;
                    
                    if(currentWordData != null)
                        currentWord = currentWordData.GetAsCharQueue();
                }

                var letter = currentWord.Count > 0 && currentWordData != null ? currentWord.Dequeue() : '-';
                var newCell = Instantiate(_cell, _root);
                newCell.SetUp(x, y, letter);
                newCell.OnPressed += OnCellPressed;
                _cells[x, y] = newCell;
                newCell.transform.localPosition = new Vector3(_xOffset * x, _yOffset * y, 0);

                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }

    private void OnCellPressed(int x, int y)
    {
        var cell = _cells[x, y];
        
        if (_selectedCell != null)
            _selectedCell.Deselect();

        _selectedCell = cell;
        cell.Select();
    }
    
    /**
     * Доработать конфиги.
     * Добавить конфиги в зенджект.
     * Продумать и попробовать усложнить алгоритм генерации матрицы на основе слов
     ** Мульти-выделение нескольких ячеек
     */
}
