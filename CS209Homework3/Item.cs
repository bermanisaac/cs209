
using System;

public class Item
{
    private string name;
    protected Sprite holder;

    public Item(string n, Sprite h)
    {
        name = n;
        holder = h;
    }

    public virtual Projectile Use()
    {
        return null;
    }

	public override bool Equals(Object o) {
		if(o == null) return false;
		Item i = null;
		try {
			i = (Item) o;
		} catch (Exception e) {
			return false;
		}
		return name.Equals(i.name);
	}

	public string GetName() {
		return name;
	}
}

