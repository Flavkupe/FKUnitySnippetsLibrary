### Weighted List
This is a simple data structure which creates a very basic probability distribution given multiple objects with different weights. In other words, you can use this to randomly pick items such that some items are picked more commonly than others.

For example, if you have 3 items with these weights:
1. Gold: Weight of 1.
2. Silver: Weight of 5.
3. Copper: Weight of 20.

This means that you have a 20/26 chance of randomly picking Copper, a 5/26 chance of randomly picking Silver, and a 1/26 chance of randomly picking Gold.

This is helpful to use, for example, when generating random loot items where items have different rarities.

The Demo uses `GameObjects` to represent the items and their weights; this works well for Demo purposes but I recommend setting up `ScriptableObjects` for this purpose instead, as weighted items are better represented in such a form. Alternatively, weighted items can be pretty much anything as long as they define a `Weight`.
