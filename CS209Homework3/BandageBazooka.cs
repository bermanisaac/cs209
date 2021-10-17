using System;

public class BandageBazooka : Item
{

    public BandageBazooka(Sprite h) : base("BandageBazooka",h)
    { // no additional work in constructor
    }

    public override Projectile Use()
    {
        // apply shield pot to the holder
        uint shield = holder.GetShield();
        if (shield < 100)
        {
            holder.SetShield(shield + 100);
        }
        else if (shield < 100)
        {
            holder.SetShield(100);
        }

        // TODO: decrement the quantity of small shield pots
        // in the holder's inventory

        // small shield pots don't fire projectiles
        return null;
    }

}