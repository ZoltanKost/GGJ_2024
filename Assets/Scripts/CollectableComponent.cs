using UnityEngine;

public class Collectable : MonoBehaviour{
    [SerializeField] private JokePieceSO JokePieceSO;
    public JokePieceSO GetSO(){
        return JokePieceSO;
    }
}