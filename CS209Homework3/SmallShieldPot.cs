using System;

public class SmallShieldPot : Item
{

    public SmallShieldPot(Sprite h) : base("SmallShieldPot",h)
    { // no additional work in constructor
    }

    public override Projectile Use()
    {
        holder.DecrementItem(this);
        // apply shield pot to the holder
        uint shield = holder.GetShield();
        if (shield < 25)
        {
            holder.SetShield(shield + 25);
        }
        else if (shield < 50)
        {
            holder.SetShield(50);
        }

        // TODO: decrement the quantity of small shield pots
        // in the holder's inventory

        // small shield pots don't fire projectiles
        return null;
    }

}

