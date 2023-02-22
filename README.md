Lautaro Ferreira Unity test.


For this game I used the new ´Player Input´ system of Unity, to a better control of the player. And designers can set the ´Movement speed´ and ´Interacting Range´ from inspector. 

You can move with WASD and the arrows, talk with NPC´s with ´Space bar´ and open the Inventory with ´I´ key. 

In the canvas you can see the Inventory and the Shop screen. But it is setted by code, so it can be scaled for multiplayers and create new shops easily. And in each NPC shop you can drag the item´s prefab through the inspector. 

You must be inside the interacting range to talk with the NPC. When you get inside the area and press the space bar, inventory and shop screen open automatically and close when you leave it. 

Now you can buy and sell items that will be seen in your inventory, and you can equip/unequip them. 

You can only sell the items that you don´t have equipped, and there are in your inventory, thinking on decreasing the chance of selling usefull items by mistake. 

I created the map with Tile Palette, this is useful to create more levels/scenes faster. 

Some other design patterns could be implemented with more available time, such us object pull and factory for items creation and storing, or MVC for multiplayers scalability. 
