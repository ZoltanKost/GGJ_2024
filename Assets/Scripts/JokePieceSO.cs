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
    [SerializeField] AudioClip audio;
    [SerializeField] private List<ComboData> data;

    private Dictionary<JokePieceSO, ComboData>  _jokePiece_data;
    public int GetScore(JokePieceSO so){
        if(_jokePiece_data == null){
            Generate();
        }
        return _jokePiece_data[so].score;
    }
    public AudioClip GetAudio(JokePieceSO so){
        if(_jokePiece_data == null){
            Generate();
        }
        return _jokePiece_data[so].clip;
    }
    public Dictionary<JokePieceSO, ComboData> Generate(){
        _jokePiece_data = new();
        for(int i = 0; i < data.Count; i++){
            _jokePiece_data.Add(data[i].compatiblePiece,data[i]);
        }
        return _jokePiece_data;
    }
}