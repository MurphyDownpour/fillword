using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private float _raycastDistance = 5f;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Vector3 p1 = Vector3.zero;
        // Vector3 p2 = Vector3.zero;
        // var d1 = Vector3.Distance(p1, p2);
        // var d2 = (p2 - p1).magnitude;
        // var d3 = (p2 - p1).sqrMagnitude;
        // var targetDistance = 5f;
        // var sqrTargetDistance = targetDistance * targetDistance;
        // if (d2 >= targetDistance)
        // {
        //     
        // }
        //
        // if (d3 >= sqrTargetDistance)
        // {
        //     
        // }
        // var layerDefault = LayerMask.NameToLayer("Default");
        // var layerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        // var r = Physics.Raycast(new Ray(Vector3.zero, Vector3.back), _raycastDistance, 1 << layerDefault | 1 << layerIgnoreRaycast);
        // 0 1 0 1 0 1 0 0


        StringBuilder strBuilder = new StringBuilder();
        var strList = new List<string>()
        {
            "Ä",
            "B",
            "C"
        };

        var resultLine = "";
        foreach (var str in strList)
        {
            //resultLine += str;
            strBuilder.Append(str);
        }

        resultLine = strBuilder.ToString();
        Debug.Log(resultLine);
    }

    private void Start()
    {
        _startButton.onClick.AddListener(() => StartCoroutine(nameof(OnStartGame)));
    }

    private IEnumerator OnStartGame()
    {
        var loading = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

        if (!loading.isDone)
        {
            yield return null;
        }
    }
}