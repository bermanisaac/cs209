using System;

public class MedKit : Item
{

    public MedKit(Sprite h) : base("MedKit",h)
    { // no additional work in constructor
    }

    public override Projectile Use()
    {
        holder.DecrementItem(this);
        uint h = holder.GetHealth();

        if(h < 100) {
            holder.SetHealth(100);
        }

        // TODO: decrement the quantity of small shield pots
        // in the holder's inventory

        // small shield pots don't fire projectiles
        return null;
    }

}