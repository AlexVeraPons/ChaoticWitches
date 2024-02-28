using System.Collections.Generic;

public class Team
{
    private TeamIdentity _teamIdentity;
    private Inventory _inventory;

    public Team(TeamIdentity teamIdentity, Item[] items)
    {
        _teamIdentity = teamIdentity;
        _inventory = new Inventory(items);
    }
}

