using UnityEngine;

[System.Serializable]
public class Card
{
    public string name;
    
    [HideInInspector]
    public enum CardState
    {
        NotGuessed,
        Right,
        Wrong
    }

    [HideInInspector]
    public CardState state = CardState.NotGuessed;

    public Card(string name)
    {
        this.name = name;
        state = CardState.NotGuessed;
    }
}