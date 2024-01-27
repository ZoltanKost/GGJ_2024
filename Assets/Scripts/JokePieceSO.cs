using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "JokePieceSO/NewJoke")]
public class JokePieceSO : ScriptableObject{
    public String text;
    public Dictionary<JokePieceSO, int> jokePiece_Points;
    [SerializeField] private List<JokePieceSO> compatible;
    [SerializeField] private List<int> points;
    void Awake(){
        jokePiece_Points = new Dictionary<JokePieceSO, int>();
        for(int i = 0; i < compatible.Count; i++){
            jokePiece_Points.Add(compatible[i],points[i]);
        }
    }
}