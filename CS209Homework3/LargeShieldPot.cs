using System;

public class LargeShieldPot : Item
{

    public LargeShieldPot(Sprite h) : base("LargeShieldPot",h)
    { // no additional work in constructor
    }

    public override Projectile Use()
    {
        holder.DecrementItem(this);
        // apply shield pot to the holder
        uint shield = holder.GetShield();
        if (shield < 50)
        {
            holder.SetShield(shield + 50);
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

