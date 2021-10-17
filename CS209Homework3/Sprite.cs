using System;
using System.Collections.Generic;

public class Sprite {
    private Point Location;
    private uint Horiz;
    private uint Vert;
    private uint Health;
    private uint Shield;

    private Dictionary<Item, int> Inventory;
    private Item[] Slots;

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
        Inventory = new Dictionary<Item, int>();
        Slots = new Item[6];

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

        Sprite s = (Sprite) obj;

        Console.WriteLine(this);
        this.PrintInventory();

        Console.WriteLine(s);
        s.PrintInventory();
        //Check arrays
        for(int i = 0 ; i < 6; i++) {
            if(Slots[i] == null) {
                if(s.Slots[i] == null) continue;
                else return false;
            }
            if(!Slots[i].Equals(s.Slots[i])) {
                return false;
            }
        }
        foreach(KeyValuePair<Item, int> value in Inventory) {
            if(!s.Inventory.ContainsKey(value.Key) || s.Inventory[value.Key] != value.Value) {
                return false;
            }
        }
        return ((Location.Equals(s.Location)) &&
            (Horiz == s.Horiz) &&
            (Vert == s.Vert) &&
            (Health == s.Health) &&
            (Shield == s.Shield));
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

    public uint GetShield() {
        return Shield;
    }

    public void SetShield(uint s) {
        Shield = s;
    }

    public uint GetHealth() {
        return Health;
    }

    public void SetHealth(uint h) {
        Health = h;
    }

    /* AddIten
     * adds an item to the inventory
     */
    public void AddItem(string item) {
        Item dummy = new Item(item, null);
        if(Inventory.ContainsKey(dummy)) {
            Inventory[dummy]++;
        } else {
            switch(item) {
                case "SmallShieldPot":
                    dummy = new SmallShieldPot(this);
                    break;
                case "LargeShieldPot":
                    dummy = new LargeShieldPot(this);
                    break;
                case "MedKit":
                    dummy = new MedKit(this);
                    break;
                case "Bandage":
                    dummy = new Bandage(this);
                    break;
                case "BandageBazooka":
                    dummy = new BandageBazooka(this);
                    break;
                case "AssaultRifle":
                    dummy = new AssaultRifle(this);
                    break;
            }
            Inventory.Add(dummy, 1);
        }
    }

    /* HasItem
     * Class-specific wrapper around the ContainsKey method
     */
     public bool HasItem(string item) {
         Item dummy = new Item(item, null);
         return Inventory.ContainsKey(dummy) && Inventory[dummy] > 0;
     }

     /* PutItemInQuickSlot
      * adds the item into the provided quickslot, removing any previous item
      * from that quickslot. Will perform a swap if provided item is in another
      * slot. Does not remove items from inventory
      */
     public void PutItemInQuickSlot(string item, uint slot) {
         if(slot >= 6) return;

         Item dummy = new Item(item, null);

         int index = Array.IndexOf(Slots, dummy);
         if(index != -1) {
             Slots[index] = Slots[slot];
         }
         Slots[slot] = dummy;
     }

     /* GetItemInQuickSlot
      * returns the name of the item in the specified quickslot. Returns null if
      * there is no item present.
      */
     public string GetItemInQuickSlot(uint slot) {
         if(slot >= 6 || Slots[slot] == null) {
             return null;
         }
         return Slots[slot].GetName();
     }

     /* PrintInventory
      * to little surprise, prints the inventory
      */
     public void PrintInventory() {
         int i = 0;
         foreach(KeyValuePair<Item, int> item in Inventory) {
             Console.WriteLine(i++ +": ("+item.Key.GetName()+", "+item.Value+")");

         }
     }

     /* PrintQuickSlots
      * to little surprise, prints the inventory
      */
     public void PrintQuickSlots() {
         for(int i = 0; i < 6; i++) {
             if(Slots[i] == null) {
                 Console.WriteLine(i + ": empty");
                 continue;
             }
             Console.WriteLine(i +": ("+Slots[i]+", "+Inventory[Slots[i]]+")");

         }
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
        if(Shield >= 100) return 0;
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
            int runover = (int) damage - (int) Shield;
            Shield -= Math.Min(damage, Shield);

            if(runover > 0) {
                Health -= (uint) Math.Min(runover, Health);
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

    public bool DecrementItem(Item item) {
        if(!Inventory.ContainsKey(item)) return false;

        if(Inventory[item] <= 0) {
            Inventory.Remove(item);
            return false;
        } else if(Inventory[item] == 1) {
            Inventory.Remove(item);
            return true;
        } else {
            Inventory[item]--;
            return true;
        }
    }

    public Projectile UseQuickSlotItem(uint slot) {
        if(Slots[slot] == null) return null;

        return Slots[slot].Use();
    }


}
