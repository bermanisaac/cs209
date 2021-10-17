using System;

public class Bandage : Item
{

    public Bandage(Sprite h) : base("Bandage",h)
    { // no additional work in constructor
    }

    public override Projectile Use()
    {
        holder.DecrementItem(this);
        // apply shield pot to the holder
        if(holder.GetHealth() < 75) {
            holder.SetHealth(Math.Min(75, 15 + holder.GetHealth()));
        }

        // TODO: decrement the quantity of small shield pots
        // in the holder's inventory

        // small shield pots don't fire projectiles
        return null;
    }

}