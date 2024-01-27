using UnityEngine;

public class CalculatorHandler : MonoBehaviour
{
    
    [SerializeField] private DropScript footer1;
    [SerializeField] private DropScript footer2;
    JokePieceSO joke1;
    JokePieceSO joke2;
    public void Calculate(){
        joke1 = footer1.GetJokeSO();
        joke2 = footer2.GetJokeSO();
        // int num = joke1.jokePiece_Points[joke2];
        // num += joke2.jokePiece_Points[joke1];
         Debug.Log("You gain " + joke1.ToString() + " and " + joke2.ToString());
    }
}
