using UnityEngine;

public struct TeamIdentity
{
    public string teamName;
    public Sprite teamImage;

    public TeamIdentity(string teamName, Sprite teamImage)
    {
        this.teamName = teamName;
        this.teamImage = teamImage;
    }
}

