using DG.Tweening;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int health;
    
    protected virtual Sequence GenerateAnimation()
    {
        var sequence = DOTween.Sequence();

        return sequence;
    }
}
