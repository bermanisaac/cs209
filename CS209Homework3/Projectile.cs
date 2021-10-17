using System;

// I am declaring a struct because this is really
// holding some temporary data and doesn't need to be fancy
public class Projectile {
    public int healthChange;
    public int shieldChange;
    public int eitherChange;
    public uint maxHealth;
    public uint maxShield;
    public uint speed;
    public uint maxDistance;
    public Point location;
    public Point velocity;

    public Projectile(int hc, int sc, int ec,
              uint mh, uint ms, uint s, uint md,
        Point loc, Point vel)
    {
        healthChange = hc;
        shieldChange = sc;
        eitherChange = ec;
        maxHealth = mh;
        maxShield = ms;
        speed = s;
        maxDistance = md;
        location = loc;
        velocity = vel;
    }
}

