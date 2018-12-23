from collections import OrderedDict

_glades = [
	("Unusually Sharp Spike", "Twice as deadly as the other spikes."),
	("Discarded Leaf", "Seems to have three puncture holes in it."),
	("Hardy Tuber", "Seems to thrive in the moisture of the Glades."),
	("Withered Fruit", "Gazing at it evokes memories of happier times."),
	("Fil's Bracelet", "A simple band made of tightly-woven plant fibers."),
	("Redcap Mushroom", "Eating these is said to help you grow taller."),
]

_grove = [
	("Unhatched Spider Egg", "Hopefully it stays unhatched."),
	("Fallen Branch", "A small, faintly glowing branch of the Spirit Tree."),
	("Reem's Lucky Coin", "Said to help you escape the notice of predators."),
	("Seed Stash", "An innocent squirrel was saving these. What kind of devil are you?"),
]

_grotto = [
	("Slick Stone", "So smooth and slippery, you can barely hang on to it."),
	("Grotto Relic 2", "Description of the relic."),
	("Grotto Relic 3", "Description of the relic."),
	("Grotto Relic 4", "Description of the relic."),
]

_blackroot = [
	("Sol's Defused Grenade", "Safe enough to use as a ball! ...right?"),
	("Torn Friendship Bracelet", "A bond that was made would soon be dissolved."),
	("Ike's Boots of Fleetness", "He moved swifter than the wind."),
	("Naru's Chisel", "A skilled artisan could sculpt great works with this tool."),
	("Glowing Mushroom", "Doubles as a light source and a tasty snack."),
]

_swamp = [
	("Polluted Water Canteen", "Who would want to drink this?"),
	("Gold-eyed Frog", "Insects stand no chance against its deft tongue."),
	("Rhino Fossil", "The hard armor plating of a much smaller ancestor creature."),
	("Ilo's Training Weights", "Solid rock, nearly too heavy to carry."),
]

_ginso = [
	("Ginso Relic 1", "Description of the relic."),
	("Ginso Relic 2", "Description of the relic."),
	("Ginso Relic 3", "Description of the relic."),
	("Ginso Relic 4", "Description of the relic."),
]

_valley = [
	("Treasure Map", "A map depicting a treasure found after a long swim."),
	("White Raven Feather", "A bit too small to be used as a parachute."),
	("", "Description of the relic."),
	("Valley Relic 4", "Description of the relic."),
]

_misty = [
	("Atsu's Candle", "Does little good in these heavy mists."),
	("Map of Misty Woods", "A crudely-drawn jumble of crooked lines."),
	("Misty Relic 3", "Description of the relic."),
	("Misty Relic 4", "Description of the relic."),
]

_forlorn = [
	("Furtive Fritter", "A favorite snack of the Gumon."),
	("Mathematical Reference", "Only used by the most cerebral forest denizens."),
	("Forlorn Relic 3", "Description of the relic."),
	("Forlorn Relic 4", "Description of the relic."),
]

_sorrow = [
	("Drained Light Vessel", "The light of the Spirit Tree once filled this orb."),
	("Sorrow Relic 2", "Description of the relic."),
	("Sorrow Relic 3", "Description of the relic."),
	("Sorrow Relic 4", "Description of the relic."),
]

_horu = [
	("Obsidian Fragment", "Chipped off of an ancient lava flow."),
	("Ancient Sketch", "A drawing of what appears to be the Water Vein."),
	("\"The Fish Stratagem\"", "A record of many tasty recipes involving fish."),
	("Horu Relic 4", "Description of the relic."),
]

relics = OrderedDict([
	("Glades", _glades),
	("Grove", _grove),
	("Grotto", _grotto),
	("Blackroot", _blackroot),
	("Swamp", _swamp),
	("Ginso", _ginso),
	("Valley", _valley),
	("Misty", _misty),
	("Forlorn", _forlorn),
	("Sorrow", _sorrow),
	("Horu", _horu)
])