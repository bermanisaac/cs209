ITEM_LIST = SmallShieldPot.cs LargeShieldPot.cs MedKit.cs Bandage.cs BandageBazooka.cs AssaultRifle.cs

TestSprite.exe: Sprite.cs TestSprite.cs Point.cs
	mcs TestSprite.cs Sprite.cs Point.cs Item.cs Projectile.cs $(ITEM_LIST)

TestPoint.exe: Point.cs TestPoint.cs
	mcs TestPoint.cs Point.cs

clean:
	rm *.exe
