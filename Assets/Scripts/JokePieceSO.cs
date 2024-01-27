using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "JokePieceSO/NewJoke")]
public class JokePieceSO : ScriptableObject{
    public Sprite sprite;
    public bool isFirst;
    public int JOKE_ID;
    public Dictionary<JokePieceSO, int> jokePiece_Points;
    [SerializeField] private List<JokePieceSO> compatible;
    [SerializeField] private List<int> points;
    void Awake(){
        for(int i = 0; i < compatible.Count; i++){
            jokePiece_Points.Add(compatible[i],points[i]);
        }
    }
}