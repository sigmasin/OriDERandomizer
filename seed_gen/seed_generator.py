import re
import random
import math
import xml.etree.ElementTree as XML

class Area:

    def __init__(self, name):
        self.name = name
        self.connections = []
        self.locations = []        
        
    def add_connection(self, connection):
        self.connections.append(connection)
        
    def get_connections(self):
        return self.connections
        
    def remove_connection(self, connection):
        self.connections.remove(connection)
        
    def add_location(self, location):
        self.locations.append(location)
        
    def get_locations(self):
        return self.locations
        
    def clear_locations(self):
        self.locations = []
        
    def remove_location(self, location):
        self.locations.remove(location)

class Connection:

    def __init__(self, home, target):
        self.home = home
        self.target = target
        self.keys = 0
        self.requirements = []
        
    def add_requirements(self, req):
        self.requirements.append(req)
        match = re.match(".*KS.*KS.*KS.*KS.*",str(req))
        if match:
            self.keys = 4
            return
        match = re.match(".*KS.*KS.*",str(req))
        if match:
            self.keys = 2
            return       
        
    def get_requirements(self):
        return self.requirements
        
    def cost(self):
        minReqScore = 7777
        minReq = []
        for req in self.requirements:
            score = 0
            energy = 0
            health = 0
            for abil in req:
                if abil == "EC":
                    energy += 1
                    if inventory["EC"] < energy:
                        score += costs[abil.strip()]
                elif abil == "HC":
                    health += 1
                    if inventory["HC"] < health:
                        score += costs[abil.strip()]
                else:
                    score += costs[abil.strip()]
            if score < minReqScore:
                minReqScore = score
                minReq = req
        return (minReqScore, minReq)

class Location:

    factor = 4.0

    def __init__(self, x, y, area, orig):
        self.x = int(math.floor((x)/self.factor) * self.factor)
        self.y = int(math.floor((y)/self.factor) * self.factor)
        self.orig = orig
        self.area = area
        
    def get_key(self):
        return self.x*10000 + self.y
        
def open_free_connections():
    
    found = False
    keystoneCount = 0
    for area in areasReached.keys():
        for connection in areas[area].get_connections():
            if connection.cost()[0] <= 0:
                if connection.keys > 0:
                    if area not in doorQueue.keys():
                        doorQueue[area] = connection
                        keystoneCount += connection.keys
                else:
                    areasReached[connection.target] = True
                    connectionQueue.append((area,connection))
                    found = True
    return (found, keystoneCount)
    
def get_all_accessible_locations():

    locations = []
    for area in areasReached.keys():
        locations.extend(areas[area].get_locations())
        areas[area].clear_locations()
    if reservedLocations:
        locations.append(reservedLocations.pop(0))
        locations.append(reservedLocations.pop(0))
    if itemCount > 2 and len(locations) >= 2:
        reservedLocations.append(locations.pop(random.randrange(len(locations))))
        reservedLocations.append(locations.pop(random.randrange(len(locations))))
    return locations
    
def prepare_path(free_space):
    
    abilities_to_open = {}
    totalCost = 0.0
    #find the sets of abilities we need to get somewhere
    for area in areasReached.keys():
        for connection in areas[area].get_connections():
            if connection.target in areasReached:
                continue
            for req_set in connection.get_requirements():
                requirements = []
                cost = 0
                energy = 0
                health = 0
                for req in req_set:
                    if costs[req] > 0:
                        if req == "EC":
                            energy += 1
                            if energy > inventory["EC"]:
                                requirements.append(req);
                                cost += costs[req];
                        elif req == "HC":
                            health += 1
                            if health > inventory["HC"]:
                                requirements.append(req);
                                cost += costs[req];
                        else:
                            requirements.append(req);
                            cost += costs[req];
                #cost *= len(requirements) #decrease the rate of multi-ability paths
                if len(requirements) <= free_space:
                    for req in requirements:
                        if req not in abilities_to_open:
                            abilities_to_open[req] = (cost, requirements)
                        elif abilities_to_open[req][0] > cost:
                            abilities_to_open[req] = (cost, requirements)
    #pick a random path weighted by cost
    for path in abilities_to_open:
        totalCost += 1.0/abilities_to_open[path][0]
    position = 0
    target = random.random() * totalCost
    for path in abilities_to_open:
        position += 1.0/abilities_to_open[path][0]
        if target <= position:
            for req in abilities_to_open[path][1]:
                if itemPool[req] > 0:
                    assignQueue.append(req)
            return abilities_to_open[path][1]
        

        
def assign_random():
    value = random.random()
    position = 0.0
    for key in itemPool.keys():
        position += itemPool[key]/itemCount
        if value <= position:
            return assign(key)

def assign(item):
    itemPool[item] -= 1
    if item == "EC" or item == "KS" or item == "HC":
        if costs[item] > 0:
            costs[item] -= 1
    elif item in costs.keys():
        costs[item] = 0
    inventory[item] += 1
    return item

for seed in range(0,1000):
    seed

    random.seed(seed)

    areas = {}
    areasReached = {"sunkenGladesRunaway": True}
    connectionQueue = []
    assignQueue = []
    
    modes = ["normal", "speed", "lure", "dboost"]
    
    skillsOutput = {
    "WallJump": "SK3",
    "ChargeFlame": "SK2",
    "Dash": "SK50",
    "Stomp": "SK4",
    "DoubleJump": "SK5",
    "Glide": "SK14",
    "Bash": "SK0",
    "Climb": "SK12",
    "Grenade": "SK51",
    "ChargeJump": "SK8"
    }

    eventsOutput = {
    "GinsoKey": "EV0",
    "Water": "EV1",
    "ForlornKey": "EV2",
    "Wind": "EV3",
    "HoruKey": "EV4",
    "Warmth": "EV5"
    }

    itemCount = 208.0
    keystoneCount = 0

    itemPool = {
    "EX15":6,
    "EX100":53,
    "EX200":29,
    "KS":36,
    "MS":9,
    "AC":33,
    "EC":14,
    "HC":12,
    "WallJump":1,
    "ChargeFlame":1,
    "Dash":1,
    "Stomp":1,
    "DoubleJump":1,
    "Glide":1,
    "Bash":1,
    "Climb":1,
    "Grenade":1,
    "ChargeJump":1,
    "GinsoKey":1,
    "ForlornKey":1,
    "HoruKey":1,
    "Water":1,
    "Wind":1,
    "Warmth":1
    }

    costs = {
    "Free":0,
    "KS":2,
    "EC":6,
    "HC":12,
    "WallJump":8,
    "ChargeFlame":22,
    "DoubleJump":16,
    "Bash":20,
    "Stomp":25,
    "Glide":18,    
    "Climb":22,
    "ChargeJump":50,
    "Dash":12,
    "Grenade":14,
    "GinsoKey":9,
    "ForlornKey":9,
    "HoruKey":9,
    "Water":99,
    "Wind":99
    }

    inventory = {
    "EX15":0,
    "EX100":0,
    "EX200":0,
    "KS":0,
    "MS":0,
    "AC":0,
    "EC":1,
    "HC":3,
    "WallJump":0,
    "ChargeFlame":0,
    "Dash":0,
    "Stomp":0,
    "DoubleJump":0,
    "Glide":0,
    "Bash":0,
    "Climb":0,
    "Grenade":0,
    "ChargeJump":0,
    "GinsoKey":0,
    "ForlornKey":0,
    "HoruKey":0,
    "Water":0,
    "Wind":0,
    "Warmth":0
    }

    tree = XML.parse("areas.xml")
    root = tree.getroot()
    
    for child in root:
        area = Area(child.attrib["name"])

        for location in child.find("Locations"):
            area.add_location(Location(int(location.find("X").text), int(location.find("Y").text), area.name, location.find("Item").text))
        for conn in child.find("Connections"):
            connection = Connection(conn.find("Home").attrib["name"], conn.find("Target").attrib["name"])
            for req in conn.find("Requirements"):
                if req.attrib["mode"] in modes:
                    connection.add_requirements(req.text.split('+'))
            if connection.get_requirements():
                area.add_connection(connection)
        areas[area.name] = area
        
    output = open("seeds/normal/randomizer_normal" + str(seed) + ".dat", 'w')
    
    spoiler = open("spoilers/normal/spoiler_normal" + str(seed) + ".txt", 'w')
    
    output.write("-240256|EC|1\n") #first energy cell
    output.write("-1720104|EX|100\n") #glitchy 100 orb at spirit tree
    #misty keystones
    output.write("-10759972|KS|1\n")
    output.write("-10480008|KS|1\n")
    output.write("-9120036|KS|1\n")
    output.write("-7680148|KS|1\n")
    

    locationsToAssign = []
    connectionQueue = []
    reservedLocations = []

    while itemCount > 0:
        
        assignQueue = []
        doorQueue = {}
        spoilerPath = ""

        #open all paths that we can already access
        opening = True
        while opening:
            (opening, keys) = open_free_connections()
            keystoneCount += keys
            for connection in connectionQueue:
                areas[connection[0]].remove_connection(connection[1])
            connectionQueue = []
            
        locationsToAssign = get_all_accessible_locations()

        #if there aren't any doors to open, it's time to get a new skill
        #consider -- work on stronger anti-key-lock logic so that we don't
        #have to give keys out right away (this opens up the potential of
        #using keys in the wrong place, will need to be careful)
        if not doorQueue:
            spoilerPath = prepare_path(len(locationsToAssign))
            if not assignQueue:
                locationsToAssign.append(reservedLocations.pop(0))
                locationsToAssign.append(reservedLocations.pop(0))
                spoilerPath = prepare_path(len(locationsToAssign))
        #pick what we're going to put in our accessible space
        itemsToAssign = []
        for i in range(0,len(locationsToAssign)):
            if assignQueue:
                itemsToAssign.append(assign(assignQueue.pop(0)))            
            elif inventory["KS"] < keystoneCount:
                itemsToAssign.append(assign("KS"))            
            else:
                itemsToAssign.append(assign_random())
            itemCount -=1

        #open all reachable doors (for the next iteration)
        for area in doorQueue.keys():
            areasReached[doorQueue[area].target] = True
            areas[area].remove_connection(doorQueue[area])
        
        #shuffle the items around and put them somewhere
        random.shuffle(itemsToAssign)
        for i in range(0,len(locationsToAssign)):
            output.write(str(locationsToAssign[i].get_key()) + "|")
            if itemsToAssign[i] in skillsOutput:
                output.write(str(skillsOutput[itemsToAssign[i]][:2]) + "|" + skillsOutput[itemsToAssign[i]][2:] + "\n")
            elif itemsToAssign[i] in eventsOutput:
                output.write(str(eventsOutput[itemsToAssign[i]][:2]) + "|" + eventsOutput[itemsToAssign[i]][2:] + "\n")
            elif itemsToAssign[i][2:]:
                output.write(itemsToAssign[i][:2] + "|" + itemsToAssign[i][2:] +"\n")
            else:
                output.write(itemsToAssign[i][:2] + "|1\n")
            if itemsToAssign[i] in costs.keys():
                spoiler.write(itemsToAssign[i] + " from " + locationsToAssign[i].area + " " + locationsToAssign[i].orig + " (" + str(locationsToAssign[i].x) + ", " + str(locationsToAssign[i].y) + ")\n")
        
        if spoilerPath:
            spoiler.write("Forced pickups: " + str(spoilerPath) + "\n")
        locationsToAssign = []
    
    spoiler.close()
    output.close()
        
        
    
    

 