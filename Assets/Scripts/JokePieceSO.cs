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
    private Dictionary<JokePieceSO, AudioClip>  _jokePiece_Audio;

    [SerializeField] private List<ComboData> data;
    public int GetScore(JokePieceSO so){
        if(_jokePiece_Points == null){
            Generate();
        }
        return _jokePiece_Points[so];
    }
    public AudioClip GetAudio(JokePieceSO so){
        if(_jokePiece_Points == null){
            Generate();
        }
        return _jokePiece_Audio[so];
    }
    public Dictionary<JokePieceSO, int> Generate(){
        _jokePiece_Points = new();
        _jokePiece_Audio = new();
        for(int i = 0; i < data.Count; i++){
            _jokePiece_Points.Add(data[i].compatiblePiece,data[i].score);
            _jokePiece_Audio.Add(data[i].compatiblePiece,data[i].clip);
        }
        return _jokePiece_Points;
    }
}