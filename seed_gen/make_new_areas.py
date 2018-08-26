import lxml.etree as XML

meta = []

with open("areas.ori", 'r') as f:
	meta = f.readlines()

new_areas = XML.Element("Areas")

area_name = None
area = None
conn = None
has_reqs = False
all_req = None

loc_homes = {}
homes = {}

def OpenConnection(target):
	global area, area_name, conn
	conn = XML.SubElement(area, "Connection")
	XML.SubElement(conn, "Home", name=area_name)
	XML.SubElement(conn, "Target", name=target)
	conn = XML.SubElement(conn, "Requirements")

def AddRequirement(tokens):
	global conn, has_reqs, all_req
	path_type = tokens[0]

	if path_type == "all":
		all_req = tokens[1:]
		return

	req_node = XML.SubElement(conn, "Requirement", mode=path_type)
	has_reqs = True
	reqs = tokens[1:]
	if all_req:
		reqs = all_req + reqs

	req_text = ""

	for thing in reqs:
		if req_text:
			req_text += '+'

		if '=' in thing:
			pickup, count = thing.split('=')
			count = int(count)
			for i in range(count):
				if i > 0:
					req_text += '+'
				if pickup == 'Health':
					pickup = 'HC'
				elif pickup == 'Energy':
					pickup = 'EC'
				elif pickup == 'Mapstone':
					pickup = 'MS'
				elif pickup == 'Keystone':
					pickup = 'KS'
				req_text += pickup
			continue

		req_text += thing

	req_node.text = req_text

def CloseConnection():
	global conn, has_reqs, all_req

	if conn is None:
		return

	if not has_reqs:
		req_node = XML.SubElement(conn, "Requirement", mode="normal")
		req_node.text = "Free"

	conn = None
	has_reqs = False
	all_req = None

# collect home names for validation purposes later
for line in meta:
	tokens = line.split()

	if len(tokens) == 0:
		continue
	if tokens[0][:2] == '--':
		continue

	if tokens[0] == "home:":
		homes[tokens[1]] = True

# now actually parse the file
for line in meta:
	tokens = line.split()

	if len(tokens) == 0:
		continue
	if tokens[0][:2] == '--':
		continue

	if tokens[0] == "pickup:":
		assert not area
		assert not conn

		loc_name = tokens[1]
		loc_x = tokens[2]
		loc_y = tokens[3]
		loc_item = tokens[4]
		loc_diff = tokens[5]
		loc_zone = tokens[6]

		new_area = XML.SubElement(new_areas, "Area", name=loc_name)
		new_locs = XML.SubElement(new_area, "Locations")
		new_loc = XML.SubElement(new_locs, "Location")

		XML.SubElement(new_loc, "X").text = loc_x
		XML.SubElement(new_loc, "Y").text = loc_y
		XML.SubElement(new_loc, "Item").text = loc_item
		XML.SubElement(new_loc, "Difficulty").text = loc_diff
		XML.SubElement(new_loc, "Zone").text = loc_zone

		loc_homes[loc_name] = "NOT LINKED"
	elif tokens[0] == "home:":
		assert len(tokens) == 2
		area_name = tokens[1]

		area_el = XML.SubElement(new_areas, "Area", name=area_name)
		area = XML.SubElement(area_el, "Connections")
		conn = None
	elif tokens[0] == "loc:":
		assert area_name
		assert area is not None
		loc = tokens[1]

		assert loc_homes[loc] == "NOT LINKED", loc
		loc_homes[loc] = area_name

		CloseConnection()
		OpenConnection(loc)
	elif tokens[0] == "conn:":
		assert area_name
		assert area is not None
		target = tokens[1]

		assert target in homes, target
		assert target not in loc_homes, target

		CloseConnection()
		OpenConnection(target)
	else:
		assert area_name
		assert area is not None
		assert conn is not None
		AddRequirement(tokens)

for loc, area in loc_homes.items():
	assert area != "NOT LINKED", loc

new_tree = XML.ElementTree(new_areas)
new_tree.write("areas_new.xml", pretty_print=True)