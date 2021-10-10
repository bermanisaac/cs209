using System;

public class Point {
    private int XCoor, YCoor, ZCoor;

    public Point() {
        XCoor = YCoor = ZCoor = 0;
    }

    public Point(int x, int y, int z) {
        XCoor = x;
        YCoor = y;
        ZCoor = z;
    }

    public void SetLocation(int x, int y, int z) {
        XCoor = x;
        YCoor = y;
        ZCoor = z;
    }

    public void SetX(int x) {
        XCoor = x;
    }

    public void SetY(int y) {
        YCoor = y;
    }

    public void SetZ(int z) {
        ZCoor = z;
    }

    public int GetX() {
        return XCoor;
    }

    public int GetY() {
        return YCoor;
    }

    public int GetZ() {
        return ZCoor;
    }

    // Calculate distance between this Point and input argument p
    // Error conditions: None
    public float CalculateDistance(Point p) {
        int xDist = XCoor - p.XCoor;
        xDist *= xDist;
        int yDist = YCoor - p.YCoor;
        yDist *= yDist;
        int zDist = ZCoor - p.ZCoor;
        zDist *= zDist;
        return (float) Math.Sqrt(xDist + yDist + zDist);
    }

    // Define what it means for two Points to be equal. Look at the Sprite Equals for the pattern of how to code it. Two points are equal if all three member variables are equal.
    // Error conditions: return false if anything other than equal. No error message.
    public override bool Equals(Object obj) {
        if ((obj == null) ||
            ! this.GetType().Equals(obj.GetType())) {
            return false;
        }

        return CalculateDistance((Point) obj) == 0;
    }

    // Again, use the Sprite code as a guide. Perform an xor of the three variables. Error conditions: none
    public override int GetHashCode() {
        return (XCoor << 16) ^ (YCoor << 8) ^ ZCoor;
    }

    //Turn a Point into string!
    public override string ToString() {
        return ("(" + XCoor + ", " + YCoor + ", " + ZCoor + ")");
    }
}