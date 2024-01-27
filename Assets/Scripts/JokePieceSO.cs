using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(menuName = "JokePieceSO/NewJoke")]
public class JokePieceSO : ScriptableObject{
    [Serializable]
    public class ComboData{
        public JokePieceSO compatiblePiece;
        public  int score;
        public  AudioClip clip; 
    }
    public String text;
    private Dictionary<JokePieceSO, int>  _jokePiece_Points;
    [SerializeField] private List<ComboData> data;
    // [SerializeField] private List<int> points;
    public int GetScore(JokePieceSO so){
        if(_jokePiece_Points == null){
            Generate();
        }
        return _jokePiece_Points[so];
    }   
    public Dictionary<JokePieceSO, int> Generate(){
        _jokePiece_Points = new();
        for(int i = 0; i < data.Count; i++){
            _jokePiece_Points.Add(data[i].compatiblePiece,data[i].score);
        }
        return _jokePiece_Points;
    }
}