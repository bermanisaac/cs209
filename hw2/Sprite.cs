using System;
using System.Collections.Generic

public class Sprite {
    private Point Location;
    private uint Horiz;
    private uint Vert;
    private uint Health;
    private uint Shield;

    private Dictionary<String, int> Inventory;

    /* Default constructor
     * set all values to 0
     */
     public Sprite()
     {
        Location = new Point();
        Horiz = 0;
        Vert = 0;
        Health = 0;
        Shield = 0;
    }

    /* SetState
     * receives inputs for all instance variables.
     * sets all of the instance variables to inputs
     */
    public void SetState(int x, int y, int z,
        uint horiz, uint vert, uint h, uint s)
    {
        Location = new Point(x, y, z);
        Horiz = horiz;
        Vert = vert;
        Health = h;
        Shield = s;
    }

    /* Equals
     * Compares an input object to the current object
     * If the input object is non-null, a Sprite, and all
     * fields match, return true, otherwise return false
     */
    public override bool Equals(Object obj)
    {
        //Check for null and compare run-time types.
        if ((obj == null) ||
            ! this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            Sprite s = (Sprite) obj;
            return ((Location.Equals(s.Location)) &&
                (Horiz == s.Horiz) &&
                (Vert == s.Vert) &&
                (Health == s.Health) &&
                (Shield == s.Shield));
        }
    }

    /* GetHashCode
     * This produces a non-unique but at least somewhat unique
     * number based on a sprite's state.
     */
    public override int GetHashCode()
    {
        return (int)(Location.GetHashCode() ^ (Vert << 9) ^
            (Health << 18) ^ (Shield << 25));
    }

    /* ToString
     * Creates a string that can be used to print out the
     * Sprite's state in human-readable form
     */
    public override String ToString()
    {
        return String.Format(
            "Sprite: loc({0},{1},{2}),rot({3},{4}),hs({5},{6})",
            Location.GetX(), Location.GetY(), Location.GetZ(), Horiz, Vert, Health, Shield);
    }

    /* HorizontalRotate
     * rotates along the horizontal axis.
     * inputs:
     *   int degrees - amount to rotate
     * outputs:
     *   modifies instance variable Horiz
     */
    public void HorizontalRotate(int degrees)
    {
        while(degrees <= 0) degrees += 360;
        Horiz += (uint) degrees;
        Horiz %= 360;
    }

    /* VerticalRotate
     * rotates along the vertical axis.
     * inputs:
     *   int degrees - amount to rotate
     * outputs:
     *   modifies instance variable Vert
     */
    public void VerticalRotate(int degrees)
    {
        while(degrees <= 0) degrees += 360;
        Vert += (uint) degrees;
        Vert %= 360;
    }



    /* Move
      * Changes the location to move Sprite in direction it is pointing
     * along the horizontal axis.
     * inputs:
     *   int steps
     * outputs:
     *   modifies instance variables XCoor, YCoor as appropriate
     */
    public void Move(int steps)
    {
        double angle = Math.PI * Horiz / 180.0;
        double xDist = Math.Cos(angle) * steps;
        Location.SetX(Location.GetX() + (int) xDist);

        double yDist = Math.Sin(angle) * steps;
        Location.SetY(Location.GetY() + (int) yDist);
    }

    /* DrinkSmallShieldPot
     * Increases Shield by 25, up to a max of 50
     * outputs:
     *  Modifies instance variable Shield
     *  returns 1 if made modification, 0 if not
      */
    public uint DrinkSmallShieldPot()
    {
        if(Shield >= 50) return 0;
        Shield = Math.Min(50, 25 + Shield);
        return 1;
    }

    /* DrinkLargeShieldPot
     * Increases Shield by 50, up to a max of 100
     * outputs:
     *  Modifies instance variable Shield
     *  returns 1 if made modification, 0 if not
      */
    public uint DrinkLargeShieldPot()
    {
        if(Shield == 100) return 0;
        Shield = Math.Min(100, 50 + Shield);
        return 1;
    }

    /* ApplyBandage
     * Increases Health by 15, up to a max of 75
     * outputs:
     *  Modifies instance variable Health
     *  returns 1 if made modification, 0 if not
      */
    public uint ApplyBandage()
    {
        if(Health >= 75) return 0;
        Health = Math.Min(75, 15 + Health);
        return 1;
    }

    /* UseMedKit
     * Sets Health to 100
     * outputs:
     *  Modifies instance variable Health
     *  returns 1 if made modification, 0 if not
      */
    public uint UseMedKit()
    {
        if(Health == 100) return 0;
        Health = 100;
        return 1;
    }

    /* WeaponsDamage
     * Decrements Shield by damage, down to a min of 0
     * If still damage left, decrements Health by leftover damage,
     * down to a min of 0
     * outputs:
     *  Modifies instance variables Shield, Health
     *  returns 1 if resulting Health > 0, 0 if not
      */
    public uint WeaponDamage(uint damage)
    {
        if(Shield >= 0) {
            uint runover = damage - Shield;
            Shield -= Math.Min(damage, Shield);

            if(runover > 0) {
                Health -= Math.Min(runover, Health);
            }
        } else {
            Health -= Math.Min(damage, Health);
        }
        if(Health > 0) return 1;
        return 0;
    }

    /*
       DO NOT IMPLEMENT THIS FUNCTION
     FallDamage
      Decrements Health by damage, down to a min of 0
      outputs:
       Modifies instance variable Health
       returns 1 if resulting Health > 0, 0 if not

    public uint FallDamage(uint damage)
    {
        Console.WriteLine("Not Yet Implemented");
        return 0;
    }
    */

    /* Revive
     * This is also applied only to a Sprite that is dead.
     * If the Sprite is dead, restores it to 30 health, 0 shield.
     * Return 1 if the person had been dead (and is now revived),
     * 0 if it was called on an ineligible Sprite (and did nothing).
     */
    public uint Revive()
    {
        if(Health != 0) return 0;

        Health = 30;
        Shield = 0;
        return 1;
    }

    /* Reboot
     * This is also applied only to a Sprite that is dead.
     * If the Sprite is dead, restores it to 100 health, 0 shield.
     * Return 1 if the person had been dead (and is now rebooted),
     * 0 if it was called on an ineligible Sprite (and did nothing).
     */
    public uint Reboot()
    {
        if(Health != 0) return 0;

        Health = 100;
        Shield = 0;
        return 1;
    }


}
