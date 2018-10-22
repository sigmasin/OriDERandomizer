from collections import OrderedDict

_glades = [
	("Unusually Sharp Spike", "Twice as deadly as the other spikes."),
	("Discarded Leaf", "Seems to have three puncture holes in it."),
	("Glades Relic 3", "Description of the relic."),
	("Glades Relic 4", "Description of the relic."),
]

_grove = [
	("Unhatched Spider Egg", "Hopefully it stays unhatched."),
	("Grove Relic 2", "Description of the relic."),
	("Grove Relic 3", "Description of the relic."),
	("Grove Relic 4", "Description of the relic."),
]

_grotto = [
	("Grotto Relic 1", "Description of the relic."),
	("Grotto Relic 2", "Description of the relic."),
	("Grotto Relic 3", "Description of the relic."),
	("Grotto Relic 4", "Description of the relic."),
]

_blackroot = [
	("Sol's Defused Grenade", "Safe enough to use as a ball! ...right?"),
	("Torn Friendship Bracelet", "A bond that was made would soon be dissolved."),
	("Eki's Boots of Fleetness", "He moved swifter than the wind."),
	("Blackroot Relic 4", "Description of the relic."),
]

_swamp = [
	("Polluted Water Canteen", "Who would want to drink this?"),
	("Swamp Relic 2", "Description of the relic."),
	("Swamp Relic 3", "Description of the relic."),
	("Swamp Relic 4", "Description of the relic."),
]

_ginso = [
	("Ginso Relic 1", "Description of the relic."),
	("Ginso Relic 2", "Description of the relic."),
	("Ginso Relic 3", "Description of the relic."),
	("Ginso Relic 4", "Description of the relic."),
]

_valley = [
	("Treasure Map", "A map depicting a treasure found after a long swim."),
	("Valley Relic 2", "Description of the relic."),
	("Valley Relic 3", "Description of the relic."),
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