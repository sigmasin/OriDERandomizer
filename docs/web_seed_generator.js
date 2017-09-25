/* start module: web_seed_generator */
$pyjs.loaded_modules['web_seed_generator'] = function (__mod_name__) {
	if($pyjs.loaded_modules['web_seed_generator'].__was_initialized__) return $pyjs.loaded_modules['web_seed_generator'];
	var $m = $pyjs.loaded_modules["web_seed_generator"];
	$m.__repr__ = function() { return "<module: web_seed_generator>"; };
	$m.__was_initialized__ = true;
	if ((__mod_name__ === null) || (typeof __mod_name__ == 'undefined')) __mod_name__ = 'web_seed_generator';
	$m.__name__ = __mod_name__;


	$m['re'] = $p['___import___']('re', null);
	$m['math'] = $p['___import___']('math', null);
	$m['time'] = $p['___import___']('time', null);
	$m['Random'] = (function(){
		var $cls_definition = new Object();
		var $method;
		$cls_definition.__module__ = 'web_seed_generator';
		$method = $pyjs__bind_method2('seed', function(seed) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				seed = arguments[1];
			}
			var $mul4,$iter1_nextval,$iter1_type,i,$iter1_iter,$add2,$iter1_array,$add1,$sub3,$sub2,$sub1,$sub4,$mul3,$mul2,$mul1,$iter1_idx;
			self.index = 624;
			self.mt = (typeof ($mul1=$p['list']([0]))==typeof ($mul2=624) && typeof $mul1=='number'?
				$mul1*$mul2:
				$p['op_mul']($mul1,$mul2));
			$p['getattr'](self, 'mt').__setitem__(0, (typeof seed_hash == "undefined"?$m.seed_hash:seed_hash)(seed));
			$iter1_iter = $p['range'](1, 624);
			$iter1_nextval=$p['__iter_prepare']($iter1_iter,false);
			while (typeof($p['__wrapped_next']($iter1_nextval).$nextval) != 'undefined') {
				i = $iter1_nextval.$nextval;
				$p['getattr'](self, 'mt').__setitem__(i, $p['float_int']((4294967295)&($p['__op_add']($add1=(typeof ($mul3=1812433253)==typeof ($mul4=($p['getattr'](self, 'mt').__getitem__($p['__op_sub']($sub1=i,$sub2=1)))^(($p['getattr'](self, 'mt').__getitem__($p['__op_sub']($sub3=i,$sub4=1)))>>(30))) && typeof $mul3=='number'?
					$mul3*$mul4:
					$p['op_mul']($mul3,$mul4)),$add2=i))));
			}
			return null;
		}
	, 1, [null,null,['self'],['seed']]);
		$cls_definition['seed'] = $method;
		$method = $pyjs__bind_method2('generate_sequence', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}
			var $iter2_nextval,$iter2_type,$mod3,$iter2_iter,$mod4,i,$add5,$mod5,$add3,$iter2_idx,$mod6,$mod1,$add7,$add4,$mod2,y,$add6,$add8,$iter2_array;
			$iter2_iter = $p['range'](624);
			$iter2_nextval=$p['__iter_prepare']($iter2_iter,false);
			while (typeof($p['__wrapped_next']($iter2_nextval).$nextval) != 'undefined') {
				i = $iter2_nextval.$nextval;
				y = $p['float_int']((4294967295)&($p['__op_add']($add5=($p['getattr'](self, 'mt').__getitem__(i))&(2147483648),$add6=($p['getattr'](self, 'mt').__getitem__((typeof ($mod1=$p['__op_add']($add3=i,$add4=1))==typeof ($mod2=624) && typeof $mod1=='number'?
					(($mod1=$mod1%$mod2)<0&&$mod2>0?$mod1+$mod2:$mod1):
					$p['op_mod']($mod1,$mod2))))&(2147483647))));
				$p['getattr'](self, 'mt').__setitem__(i, ($p['getattr'](self, 'mt').__getitem__((typeof ($mod3=$p['__op_add']($add7=i,$add8=397))==typeof ($mod4=624) && typeof $mod3=='number'?
					(($mod3=$mod3%$mod4)<0&&$mod4>0?$mod3+$mod4:$mod3):
					$p['op_mod']($mod3,$mod4))))^((y)>>(1)));
				if ($p['bool'](!$p['op_eq']((typeof ($mod5=y)==typeof ($mod6=2) && typeof $mod5=='number'?
					(($mod5=$mod5%$mod6)<0&&$mod6>0?$mod5+$mod6:$mod5):
					$p['op_mod']($mod5,$mod6)), 0))) {
					$p['getattr'](self, 'mt').__setitem__(i, ($p['getattr'](self, 'mt').__getitem__(i))^(2567483615));
				}
			}
			self.index = 0;
			return null;
		}
	, 1, [null,null,['self']]);
		$cls_definition['generate_sequence'] = $method;
		$method = $pyjs__bind_method2('random', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}
			var $div1,$div2,$add10,y,$add9;
			if ($p['bool'](((($p['cmp']($p['getattr'](self, 'index'), 624))|1) == 1))) {
				self['generate_sequence']();
			}
			y = $p['getattr'](self, 'mt').__getitem__($p['getattr'](self, 'index'));
			y = (y)^((y)>>(11));
			y = (y)^(((y)<<(7))&(2636928640));
			y = (y)^(((y)<<(15))&(4022730752));
			y = (y)^((y)>>(18));
			self.index = $p['__op_add']($add9=$p['getattr'](self, 'index'),$add10=1);
			return (typeof ($div1=$p['float_int']((2147483647)&(y)))==typeof ($div2=$p['float'](2147483648)) && typeof $div1=='number' && $div2 !== 0?
				$div1/$div2:
				$p['op_div']($div1,$div2));
		}
	, 1, [null,null,['self']]);
		$cls_definition['random'] = $method;
		$method = $pyjs__bind_method2('randrange', function(length) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				length = arguments[1];
			}
			var $mul6,$mul5;
			return $p['float_int']((typeof ($mul5=self['random']())==typeof ($mul6=length) && typeof $mul5=='number'?
				$mul5*$mul6:
				$p['op_mul']($mul5,$mul6)));
		}
	, 1, [null,null,['self'],['length']]);
		$cls_definition['randrange'] = $method;
		$method = $pyjs__bind_method2('randint', function(low, high) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				low = arguments[1];
				high = arguments[2];
			}
			var $add14,$add13,$add11,$add12,$mul8,$mul7,$sub6,$sub5;
			return $p['float_int']($p['__op_add']($add13=low,$add14=(typeof ($mul7=self['random']())==typeof ($mul8=$p['__op_add']($add11=$p['__op_sub']($sub5=high,$sub6=low),$add12=1)) && typeof $mul7=='number'?
				$mul7*$mul8:
				$p['op_mul']($mul7,$mul8))));
		}
	, 1, [null,null,['self'],['low'],['high']]);
		$cls_definition['randint'] = $method;
		$method = $pyjs__bind_method2('uniform', function(low, high) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				low = arguments[1];
				high = arguments[2];
			}
			var $mul10,$add15,$add16,$sub8,$mul9,$sub7;
			return $p['__op_add']($add15=(typeof ($mul9=self['random']())==typeof ($mul10=$p['__op_sub']($sub7=high,$sub8=low)) && typeof $mul9=='number'?
				$mul9*$mul10:
				$p['op_mul']($mul9,$mul10)),$add16=low);
		}
	, 1, [null,null,['self'],['low'],['high']]);
		$cls_definition['uniform'] = $method;
		$method = $pyjs__bind_method2('shuffle', function(items) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				items = arguments[1];
			}
			var $iter3_idx,i,$iter3_array,original,$iter3_iter,$iter3_type,$iter3_nextval;
			original = $p['list'](items);
			$iter3_iter = $p['range']($p['len'](items));
			$iter3_nextval=$p['__iter_prepare']($iter3_iter,false);
			while (typeof($p['__wrapped_next']($iter3_nextval).$nextval) != 'undefined') {
				i = $iter3_nextval.$nextval;
				items.__setitem__(i, original['pop'](self['randrange']($p['len'](original))));
			}
			return null;
		}
	, 1, [null,null,['self'],['items']]);
		$cls_definition['shuffle'] = $method;
		var $bases = new Array(pyjslib.object);
		var $data = $p['dict']();
		for (var $item in $cls_definition) { $data.__setitem__($item, $cls_definition[$item]); }
		return $p['_create_class']('Random', $p['tuple']($bases), $data);
	})();
	$m['Area'] = (function(){
		var $cls_definition = new Object();
		var $method;
		$cls_definition.__module__ = 'web_seed_generator';
		$method = $pyjs__bind_method2('__init__', function(name) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				name = arguments[1];
			}

			self.$$name = name;
			self.connections = $p['list']([]);
			self.locations = $p['list']([]);
			self.difficulty = 1;
			return null;
		}
	, 1, [null,null,['self'],['name']]);
		$cls_definition['__init__'] = $method;
		$method = $pyjs__bind_method2('add_connection', function(connection) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				connection = arguments[1];
			}

			self['connections']['append'](connection);
			return null;
		}
	, 1, [null,null,['self'],['connection']]);
		$cls_definition['add_connection'] = $method;
		$method = $pyjs__bind_method2('get_connections', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}

			return $p['getattr'](self, 'connections');
		}
	, 1, [null,null,['self']]);
		$cls_definition['get_connections'] = $method;
		$method = $pyjs__bind_method2('remove_connection', function(connection) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				connection = arguments[1];
			}

			self['connections']['remove'](connection);
			return null;
		}
	, 1, [null,null,['self'],['connection']]);
		$cls_definition['remove_connection'] = $method;
		$method = $pyjs__bind_method2('add_location', function(location) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				location = arguments[1];
			}

			self['locations']['append'](location);
			return null;
		}
	, 1, [null,null,['self'],['location']]);
		$cls_definition['add_location'] = $method;
		$method = $pyjs__bind_method2('get_locations', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}

			return $p['getattr'](self, 'locations');
		}
	, 1, [null,null,['self']]);
		$cls_definition['get_locations'] = $method;
		$method = $pyjs__bind_method2('clear_locations', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}

			self.locations = $p['list']([]);
			return null;
		}
	, 1, [null,null,['self']]);
		$cls_definition['clear_locations'] = $method;
		$method = $pyjs__bind_method2('remove_location', function(location) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				location = arguments[1];
			}

			self['locations']['remove'](location);
			return null;
		}
	, 1, [null,null,['self'],['location']]);
		$cls_definition['remove_location'] = $method;
		var $bases = new Array(pyjslib.object);
		var $data = $p['dict']();
		for (var $item in $cls_definition) { $data.__setitem__($item, $cls_definition[$item]); }
		return $p['_create_class']('Area', $p['tuple']($bases), $data);
	})();
	$m['Connection'] = (function(){
		var $cls_definition = new Object();
		var $method;
		$cls_definition.__module__ = 'web_seed_generator';
		$method = $pyjs__bind_method2('__init__', function(home, target) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				home = arguments[1];
				target = arguments[2];
			}

			self.home = home;
			self.target = target;
			self.keys = 0;
			self.mapstone = false;
			self.requirements = $p['list']([]);
			self.difficulties = $p['list']([]);
			return null;
		}
	, 1, [null,null,['self'],['home'],['target']]);
		$cls_definition['__init__'] = $method;
		$method = $pyjs__bind_method2('add_requirements', function(req, difficulty) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				req = arguments[1];
				difficulty = arguments[2];
			}
			var match;
			if ($p['bool']((typeof shards == "undefined"?$m.shards:shards))) {
				match = $m['re']['match']('.*GinsoKey.*', $p['str'](req));
				if ($p['bool'](match)) {
					req['remove']('GinsoKey');
					req['append']('WaterVeinShard');
					req['append']('WaterVeinShard');
					req['append']('WaterVeinShard');
					req['append']('WaterVeinShard');
					req['append']('WaterVeinShard');
				}
				match = $m['re']['match']('.*ForlornKey.*', $p['str'](req));
				if ($p['bool'](match)) {
					req['remove']('ForlornKey');
					req['append']('GumonSealShard');
					req['append']('GumonSealShard');
					req['append']('GumonSealShard');
					req['append']('GumonSealShard');
					req['append']('GumonSealShard');
				}
				match = $m['re']['match']('.*HoruKey.*', $p['str'](req));
				if ($p['bool'](match)) {
					req['remove']('HoruKey');
					req['append']('SunstoneShard');
					req['append']('SunstoneShard');
					req['append']('SunstoneShard');
					req['append']('SunstoneShard');
					req['append']('SunstoneShard');
				}
			}
			self['requirements']['append'](req);
			self['difficulties']['append'](difficulty);
			match = $m['re']['match']('.*KS.*KS.*KS.*KS.*', $p['str'](req));
			if ($p['bool'](match)) {
				self.keys = 4;
				return null;
			}
			match = $m['re']['match']('.*KS.*KS.*', $p['str'](req));
			if ($p['bool'](match)) {
				self.keys = 2;
				return null;
			}
			match = $m['re']['match']('.*MS.*', $p['str'](req));
			if ($p['bool'](match)) {
				self.mapstone = true;
				return null;
			}
			return null;
		}
	, 1, [null,null,['self'],['req'],['difficulty']]);
		$cls_definition['add_requirements'] = $method;
		$method = $pyjs__bind_method2('get_requirements', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}

			return $p['getattr'](self, 'requirements');
		}
	, 1, [null,null,['self']]);
		$cls_definition['get_requirements'] = $method;
		$method = $pyjs__bind_method2('cost', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}
			var $iter5_nextval,minReqScore,$iter4_type,$iter5_idx,energy,$iter5_iter,abil,$iter5_type,$iter4_iter,minDiff,$add23,$add21,$add20,$add22,$add25,$add24,$add26,score,health,$iter5_array,$add17,$add18,$add19,i,$iter4_nextval,$iter4_idx,$iter4_array,minReq;
			minReqScore = 7777;
			minDiff = 7777;
			minReq = $p['list']([]);
			$iter4_iter = $p['range'](0, $p['len']($p['getattr'](self, 'requirements')));
			$iter4_nextval=$p['__iter_prepare']($iter4_iter,false);
			while (typeof($p['__wrapped_next']($iter4_nextval).$nextval) != 'undefined') {
				i = $iter4_nextval.$nextval;
				score = 0;
				energy = 0;
				health = 0;
				$iter5_iter = $p['getattr'](self, 'requirements').__getitem__(i);
				$iter5_nextval=$p['__iter_prepare']($iter5_iter,false);
				while (typeof($p['__wrapped_next']($iter5_nextval).$nextval) != 'undefined') {
					abil = $iter5_nextval.$nextval;
					if ($p['bool']($p['op_eq'](abil, 'EC'))) {
						energy = $p['__op_add']($add17=energy,$add18=1);
						if ($p['bool'](($p['cmp']((typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('EC'), energy) == -1))) {
							score = $p['__op_add']($add19=score,$add20=(typeof costs == "undefined"?$m.costs:costs).__getitem__(abil['strip']()));
						}
					}
					else if ($p['bool']($p['op_eq'](abil, 'HC'))) {
						health = $p['__op_add']($add21=health,$add22=1);
						if ($p['bool'](($p['cmp']((typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('HC'), health) == -1))) {
							score = $p['__op_add']($add23=score,$add24=(typeof costs == "undefined"?$m.costs:costs).__getitem__(abil['strip']()));
						}
					}
					else {
						score = $p['__op_add']($add25=score,$add26=(typeof costs == "undefined"?$m.costs:costs).__getitem__(abil['strip']()));
					}
				}
				if ($p['bool'](($p['cmp'](score, minReqScore) == -1))) {
					minReqScore = score;
					minReq = $p['getattr'](self, 'requirements').__getitem__(i);
					minDiff = $p['getattr'](self, 'difficulties').__getitem__(i);
				}
			}
			return $p['tuple']([minReqScore, minReq, minDiff]);
		}
	, 1, [null,null,['self']]);
		$cls_definition['cost'] = $method;
		var $bases = new Array(pyjslib.object);
		var $data = $p['dict']();
		for (var $item in $cls_definition) { $data.__setitem__($item, $cls_definition[$item]); }
		return $p['_create_class']('Connection', $p['tuple']($bases), $data);
	})();
	$m['Location'] = (function(){
		var $cls_definition = new Object();
		var $method;
		$cls_definition.__module__ = 'web_seed_generator';
		$cls_definition['factor'] = 4.0;
		$method = $pyjs__bind_method2('__init__', function(x, y, area, orig, difficulty, zone) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				x = arguments[1];
				y = arguments[2];
				area = arguments[3];
				orig = arguments[4];
				difficulty = arguments[5];
				zone = arguments[6];
			}
			var $mul12,$mul13,$mul11,$mul14,$div3,$div5,$div6,$div4;
			self.x = $p['float_int']((typeof ($mul11=$m['math']['floor']((typeof ($div3=x)==typeof ($div4=$p['getattr'](self, 'factor')) && typeof $div3=='number' && $div4 !== 0?
				$div3/$div4:
				$p['op_div']($div3,$div4))))==typeof ($mul12=$p['getattr'](self, 'factor')) && typeof $mul11=='number'?
				$mul11*$mul12:
				$p['op_mul']($mul11,$mul12)));
			self.y = $p['float_int']((typeof ($mul13=$m['math']['floor']((typeof ($div5=y)==typeof ($div6=$p['getattr'](self, 'factor')) && typeof $div5=='number' && $div6 !== 0?
				$div5/$div6:
				$p['op_div']($div5,$div6))))==typeof ($mul14=$p['getattr'](self, 'factor')) && typeof $mul13=='number'?
				$mul13*$mul14:
				$p['op_mul']($mul13,$mul14)));
			self.orig = orig;
			self.area = area;
			self.difficulty = difficulty;
			self.zone = zone;
			return null;
		}
	, 1, [null,null,['self'],['x'],['y'],['area'],['orig'],['difficulty'],['zone']]);
		$cls_definition['__init__'] = $method;
		$method = $pyjs__bind_method2('get_key', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}
			var $mul16,$mul15,$add27,$add28;
			return $p['__op_add']($add27=(typeof ($mul15=$p['getattr'](self, 'x'))==typeof ($mul16=10000) && typeof $mul15=='number'?
				$mul15*$mul16:
				$p['op_mul']($mul15,$mul16)),$add28=$p['getattr'](self, 'y'));
		}
	, 1, [null,null,['self']]);
		$cls_definition['get_key'] = $method;
		$method = $pyjs__bind_method2('to_string', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}
			var $add29,$add38,$add39,$add32,$add33,$add31,$add36,$add37,$add34,$add35,$add41,$add42,$add40,$add30;
			return $p['__op_add']($add41=$p['__op_add']($add39=$p['__op_add']($add37=$p['__op_add']($add35=$p['__op_add']($add33=$p['__op_add']($add31=$p['__op_add']($add29=$p['getattr'](self, 'area'),$add30=' '),$add32=$p['getattr'](self, 'orig')),$add34=' ('),$add36=$p['str']($p['getattr'](self, 'x'))),$add38=' '),$add40=$p['str']($p['getattr'](self, 'y'))),$add42=')');
		}
	, 1, [null,null,['self']]);
		$cls_definition['to_string'] = $method;
		var $bases = new Array(pyjslib.object);
		var $data = $p['dict']();
		for (var $item in $cls_definition) { $data.__setitem__($item, $cls_definition[$item]); }
		return $p['_create_class']('Location', $p['tuple']($bases), $data);
	})();
	$m['open_free_connections'] = function() {
		var $iter6_type,$iter8_iter,cost,$or1,$iter6_iter,$iter6_nextval,$add48,area,$add47,$add46,$add45,$add44,$add43,visitMap,mapstoneCount,keystoneCount,$iter7_type,map,$iter8_idx,$iter6_idx,$or2,$iter7_iter,$iter8_type,$iter6_array,$iter8_nextval,$iter7_idx,$mul17,$iter7_nextval,$iter7_array,$iter8_array,$mul18,connection,found;
		found = false;
		keystoneCount = 0;
		mapstoneCount = 0;
		$iter6_iter = $m.areaList;
		$iter6_nextval=$p['__iter_prepare']($iter6_iter,false);
		while (typeof($p['__wrapped_next']($iter6_nextval).$nextval) != 'undefined') {
			area = $iter6_nextval.$nextval;
			if ($p['bool']($m.areasReached['keys']().__contains__(area))) {
				$iter7_iter = (typeof areas == "undefined"?$m.areas:areas).__getitem__(area)['get_connections']();
				$iter7_nextval=$p['__iter_prepare']($iter7_iter,false);
				while (typeof($p['__wrapped_next']($iter7_nextval).$nextval) != 'undefined') {
					connection = $iter7_nextval.$nextval;
					cost = connection['cost']();
					if ($p['bool'](($p['cmp'](cost.__getitem__(0), 0) < 1))) {
						(typeof areas == "undefined"?$m.areas:areas).__getitem__($p['getattr'](connection, 'target')).difficulty = cost.__getitem__(2);
						if ($p['bool'](($p['cmp']($p['getattr'](connection, 'keys'), 0) == 1))) {
							if ($p['bool'](!$m.doorQueue['keys']().__contains__(area))) {
								(typeof doorQueue == "undefined"?$m.doorQueue:doorQueue).__setitem__(area, connection);
								keystoneCount = $p['__op_add']($add43=keystoneCount,$add44=$p['getattr'](connection, 'keys'));
							}
						}
						else if ($p['bool']($p['getattr'](connection, 'mapstone'))) {
							if ($p['bool'](!(typeof areasReached == "undefined"?$m.areasReached:areasReached).__contains__($p['getattr'](connection, 'target')))) {
								visitMap = true;
								$iter8_iter = $m.mapQueue['keys']();
								$iter8_nextval=$p['__iter_prepare']($iter8_iter,false);
								while (typeof($p['__wrapped_next']($iter8_nextval).$nextval) != 'undefined') {
									map = $iter8_nextval.$nextval;
									if ($p['bool'](($p['bool']($or1=$p['op_eq'](map, area))?$or1:$p['op_eq']($p['getattr']((typeof mapQueue == "undefined"?$m.mapQueue:mapQueue).__getitem__(map), 'target'), $p['getattr'](connection, 'target'))))) {
										visitMap = false;
									}
								}
								if ($p['bool'](visitMap)) {
									(typeof mapQueue == "undefined"?$m.mapQueue:mapQueue).__setitem__(area, connection);
									mapstoneCount = $p['__op_add']($add45=mapstoneCount,$add46=1);
								}
							}
						}
						else {
							if ($p['bool'](!(typeof areasReached == "undefined"?$m.areasReached:areasReached).__contains__($p['getattr'](connection, 'target')))) {
								$m.currentAreas['append']($p['getattr'](connection, 'target'));
								$m['seedDifficulty'] = $p['__op_add']($add47=$m['seedDifficulty'],$add48=(typeof ($mul17=cost.__getitem__(2))==typeof ($mul18=cost.__getitem__(2)) && typeof $mul17=='number'?
									$mul17*$mul18:
									$p['op_mul']($mul17,$mul18)));
							}
							(typeof areasReached == "undefined"?$m.areasReached:areasReached).__setitem__($p['getattr'](connection, 'target'), true);
							$m.connectionQueue['append']($p['tuple']([area, connection]));
							found = true;
						}
					}
				}
			}
		}
		return $p['tuple']([found, keystoneCount, mapstoneCount]);
	};
	$m['open_free_connections'].__name__ = 'open_free_connections';

	$m['open_free_connections'].__bind_type__ = 0;
	$m['open_free_connections'].__args__ = [null,null];
	$m['get_all_accessible_locations'] = function() {
		var $iter10_nextval,locations,currentLocations,$iter10_iter,loc,$add49,$iter9_iter,$iter10_idx,$iter9_nextval,$iter9_idx,location,$and1,$iter11_idx,$iter9_type,$iter11_type,$iter11_iter,$and2,$iter11_array,$iter11_nextval,$add50,area,$iter10_array,$iter10_type,$iter9_array;
		locations = $p['list']([]);
		$iter9_iter = $m.areaList;
		$iter9_nextval=$p['__iter_prepare']($iter9_iter,false);
		while (typeof($p['__wrapped_next']($iter9_nextval).$nextval) != 'undefined') {
			area = $iter9_nextval.$nextval;
			if ($p['bool']($m.areasReached['keys']().__contains__(area))) {
				currentLocations = (typeof areas == "undefined"?$m.areas:areas).__getitem__(area)['get_locations']();
				$iter10_iter = currentLocations;
				$iter10_nextval=$p['__iter_prepare']($iter10_iter,false);
				while (typeof($p['__wrapped_next']($iter10_nextval).$nextval) != 'undefined') {
					location = $iter10_nextval.$nextval;
					location.difficulty = $p['__op_add']($add49=$p['getattr'](location, 'difficulty'),$add50=$p['getattr']((typeof areas == "undefined"?$m.areas:areas).__getitem__(area), 'difficulty'));
				}
				if ($p['bool']((typeof limitkeys == "undefined"?$m.limitkeys:limitkeys))) {
					loc = '';
					$iter11_iter = currentLocations;
					$iter11_nextval=$p['__iter_prepare']($iter11_iter,false);
					while (typeof($p['__wrapped_next']($iter11_nextval).$nextval) != 'undefined') {
						location = $iter11_nextval.$nextval;
						if ($p['bool']($m.keySpots['keys']().__contains__($p['getattr'](location, 'orig')))) {
							loc = location;
							break;
						}
					}
					if ($p['bool'](loc)) {
						(typeof force_assign == "undefined"?$m.force_assign:force_assign)((typeof keySpots == "undefined"?$m.keySpots:keySpots).__getitem__($p['getattr'](loc, 'orig')), loc);
						currentLocations['remove'](loc);
					}
				}
				locations['extend'](currentLocations);
				(typeof areas == "undefined"?$m.areas:areas).__getitem__(area)['clear_locations']();
			}
		}
		if ($p['bool']((typeof reservedLocations == "undefined"?$m.reservedLocations:reservedLocations))) {
			locations['append']($m.reservedLocations['pop'](0));
			locations['append']($m.reservedLocations['pop'](0));
		}
		if ($p['bool'](($p['bool']($and1=($p['cmp']((typeof itemCount == "undefined"?$m.itemCount:itemCount), 2) == 1))?((($p['cmp']($p['len'](locations), 2))|1) == 1):$and1))) {
			$m.reservedLocations['append'](locations['pop']($m.random['randrange']($p['len'](locations))));
			$m.reservedLocations['append'](locations['pop']($m.random['randrange']($p['len'](locations))));
		}
		return locations;
	};
	$m['get_all_accessible_locations'].__name__ = 'get_all_accessible_locations';

	$m['get_all_accessible_locations'].__bind_type__ = 0;
	$m['get_all_accessible_locations'].__args__ = [null,null];
	$m['prepare_path'] = function(free_space) {
		var $iter17_type,$add70,$iter13_array,$mul20,$iter17_nextval,$iter14_array,$add65,$and3,$iter12_array,$and5,$iter13_nextval,$add76,$add74,$add75,$add72,$add73,$iter18_array,$add71,$iter15_idx,energy,$iter16_idx,cost,abilities_to_open,req_set,totalCost,$add64,$add67,$add66,$add61,$iter15_iter,$add63,$add62,req,$add69,$add68,$iter19_nextval,health,$iter16_nextval,$iter14_type,$iter19_array,sunstoneShard,path,$add51,$add52,$add53,$add54,$add55,$add56,$iter13_iter,$add58,$add59,$mul19,connection,$iter19_type,$iter12_idx,$iter12_nextval,$iter13_idx,area,$div10,$iter19_iter,$iter13_type,$iter18_type,$iter19_idx,$iter14_idx,$iter14_nextval,target,$add57,$iter12_iter,$iter15_type,$iter17_idx,waterVeinShard,$iter16_iter,$iter17_iter,requirements,$iter16_type,$iter18_idx,$iter18_nextval,$or5,$or4,$iter18_iter,$or3,$and4,$iter15_array,gumonSealShard,$iter17_array,$div8,$div9,$iter14_iter,$div7,$add60,$iter16_array,$iter12_type,$iter15_nextval,position;
		abilities_to_open = $p['dict']([]);
		totalCost = 0.0;
		$iter12_iter = $m.areaList;
		$iter12_nextval=$p['__iter_prepare']($iter12_iter,false);
		while (typeof($p['__wrapped_next']($iter12_nextval).$nextval) != 'undefined') {
			area = $iter12_nextval.$nextval;
			if ($p['bool']($m.areasReached['keys']().__contains__(area))) {
				$iter13_iter = (typeof areas == "undefined"?$m.areas:areas).__getitem__(area)['get_connections']();
				$iter13_nextval=$p['__iter_prepare']($iter13_iter,false);
				while (typeof($p['__wrapped_next']($iter13_nextval).$nextval) != 'undefined') {
					connection = $iter13_nextval.$nextval;
					if ($p['bool']((typeof areasReached == "undefined"?$m.areasReached:areasReached).__contains__($p['getattr'](connection, 'target')))) {
						continue;
					}
					if ($p['bool'](($p['bool']($and3=(typeof limitkeys == "undefined"?$m.limitkeys:limitkeys))?($p['bool']($and4=connection['get_requirements']())?($p['bool']($or3=connection['get_requirements']().__getitem__(0).__contains__('GinsoKey'))?$or3:($p['bool']($or4=connection['get_requirements']().__getitem__(0).__contains__('ForlornKey'))?$or4:connection['get_requirements']().__getitem__(0).__contains__('HoruKey'))):$and4):$and3))) {
						continue;
					}
					$iter14_iter = connection['get_requirements']();
					$iter14_nextval=$p['__iter_prepare']($iter14_iter,false);
					while (typeof($p['__wrapped_next']($iter14_nextval).$nextval) != 'undefined') {
						req_set = $iter14_nextval.$nextval;
						requirements = $p['list']([]);
						cost = 0;
						energy = 0;
						health = 0;
						waterVeinShard = 0;
						gumonSealShard = 0;
						sunstoneShard = 0;
						$iter15_iter = req_set;
						$iter15_nextval=$p['__iter_prepare']($iter15_iter,false);
						while (typeof($p['__wrapped_next']($iter15_nextval).$nextval) != 'undefined') {
							req = $iter15_nextval.$nextval;
							if ($p['bool'](($p['cmp']((typeof costs == "undefined"?$m.costs:costs).__getitem__(req), 0) == 1))) {
								if ($p['bool']($p['op_eq'](req, 'EC'))) {
									energy = $p['__op_add']($add51=energy,$add52=1);
									if ($p['bool'](($p['cmp'](energy, (typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('EC')) == 1))) {
										requirements['append'](req);
										cost = $p['__op_add']($add53=cost,$add54=(typeof costs == "undefined"?$m.costs:costs).__getitem__(req));
									}
								}
								else if ($p['bool']($p['op_eq'](req, 'HC'))) {
									health = $p['__op_add']($add55=health,$add56=1);
									if ($p['bool'](($p['cmp'](health, (typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('HC')) == 1))) {
										requirements['append'](req);
										cost = $p['__op_add']($add57=cost,$add58=(typeof costs == "undefined"?$m.costs:costs).__getitem__(req));
									}
								}
								else if ($p['bool']($p['op_eq'](req, 'WaterVeinShard'))) {
									waterVeinShard = $p['__op_add']($add59=waterVeinShard,$add60=1);
									if ($p['bool'](($p['cmp'](waterVeinShard, (typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('WaterVeinShard')) == 1))) {
										requirements['append'](req);
										cost = $p['__op_add']($add61=cost,$add62=(typeof costs == "undefined"?$m.costs:costs).__getitem__(req));
									}
								}
								else if ($p['bool']($p['op_eq'](req, 'GumonSealShard'))) {
									gumonSealShard = $p['__op_add']($add63=gumonSealShard,$add64=1);
									if ($p['bool'](($p['cmp'](gumonSealShard, (typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('GumonSealShard')) == 1))) {
										requirements['append'](req);
										cost = $p['__op_add']($add65=cost,$add66=(typeof costs == "undefined"?$m.costs:costs).__getitem__(req));
									}
								}
								else if ($p['bool']($p['op_eq'](req, 'SunstoneShard'))) {
									sunstoneShard = $p['__op_add']($add67=sunstoneShard,$add68=1);
									if ($p['bool'](($p['cmp'](sunstoneShard, (typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('SunstoneShard')) == 1))) {
										requirements['append'](req);
										cost = $p['__op_add']($add69=cost,$add70=(typeof costs == "undefined"?$m.costs:costs).__getitem__(req));
									}
								}
								else {
									requirements['append'](req);
									cost = $p['__op_add']($add71=cost,$add72=(typeof costs == "undefined"?$m.costs:costs).__getitem__(req));
								}
							}
						}
						if ($p['bool'](($p['cmp']($p['len'](requirements), free_space) < 1))) {
							$iter16_iter = requirements;
							$iter16_nextval=$p['__iter_prepare']($iter16_iter,false);
							while (typeof($p['__wrapped_next']($iter16_nextval).$nextval) != 'undefined') {
								req = $iter16_nextval.$nextval;
								if ($p['bool'](!abilities_to_open.__contains__(req))) {
									abilities_to_open.__setitem__(req, $p['tuple']([cost, requirements]));
								}
								else if ($p['bool'](($p['cmp'](abilities_to_open.__getitem__(req).__getitem__(0), cost) == 1))) {
									abilities_to_open.__setitem__(req, $p['tuple']([cost, requirements]));
								}
							}
						}
					}
				}
			}
		}
		$iter17_iter = abilities_to_open;
		$iter17_nextval=$p['__iter_prepare']($iter17_iter,false);
		while (typeof($p['__wrapped_next']($iter17_nextval).$nextval) != 'undefined') {
			path = $iter17_nextval.$nextval;
			totalCost = $p['__op_add']($add73=totalCost,$add74=(typeof ($div7=1.0)==typeof ($div8=abilities_to_open.__getitem__(path).__getitem__(0)) && typeof $div7=='number' && $div8 !== 0?
				$div7/$div8:
				$p['op_div']($div7,$div8)));
		}
		position = 0;
		target = (typeof ($mul19=$m.random['random']())==typeof ($mul20=totalCost) && typeof $mul19=='number'?
			$mul19*$mul20:
			$p['op_mul']($mul19,$mul20));
		$iter18_iter = $m.itemList;
		$iter18_nextval=$p['__iter_prepare']($iter18_iter,false);
		while (typeof($p['__wrapped_next']($iter18_nextval).$nextval) != 'undefined') {
			path = $iter18_nextval.$nextval;
			if ($p['bool'](abilities_to_open['keys']().__contains__(path))) {
				position = $p['__op_add']($add75=position,$add76=(typeof ($div9=1.0)==typeof ($div10=abilities_to_open.__getitem__(path).__getitem__(0)) && typeof $div9=='number' && $div10 !== 0?
					$div9/$div10:
					$p['op_div']($div9,$div10)));
				if ($p['bool'](($p['cmp'](target, position) < 1))) {
					$iter19_iter = abilities_to_open.__getitem__(path).__getitem__(1);
					$iter19_nextval=$p['__iter_prepare']($iter19_iter,false);
					while (typeof($p['__wrapped_next']($iter19_nextval).$nextval) != 'undefined') {
						req = $iter19_nextval.$nextval;
						if ($p['bool'](($p['cmp']((typeof itemPool == "undefined"?$m.itemPool:itemPool).__getitem__(req), 0) == 1))) {
							$m.assignQueue['append'](req);
						}
					}
					return abilities_to_open.__getitem__(path).__getitem__(1);
				}
			}
		}
		return null;
	};
	$m['prepare_path'].__name__ = 'prepare_path';

	$m['prepare_path'].__bind_type__ = 0;
	$m['prepare_path'].__args__ = [null,null,['free_space']];
	$m['assign_random'] = function(recurseCount) {
		if (typeof recurseCount == 'undefined') recurseCount=arguments.callee.__args__[2][1];
		var $and8,$iter20_iter,$iter20_nextval,$iter20_type,$add77,$add80,$and6,$div11,value,$and7,$iter20_idx,$div12,key,position,$add79,$add78,$iter20_array;
		value = $m.random['random']();
		position = 0.0;
		$iter20_iter = $m.itemList;
		$iter20_nextval=$p['__iter_prepare']($iter20_iter,false);
		while (typeof($p['__wrapped_next']($iter20_nextval).$nextval) != 'undefined') {
			key = $iter20_nextval.$nextval;
			position = $p['__op_add']($add77=position,$add78=(typeof ($div11=(typeof itemPool == "undefined"?$m.itemPool:itemPool).__getitem__(key))==typeof ($div12=(typeof itemCount == "undefined"?$m.itemCount:itemCount)) && typeof $div11=='number' && $div12 !== 0?
				$div11/$div12:
				$p['op_div']($div11,$div12)));
			if ($p['bool'](($p['cmp'](value, position) < 1))) {
				if ($p['bool'](($p['bool']($and6=(typeof starved == "undefined"?$m.starved:starved))?($p['bool']($and7=(typeof skillsOutput == "undefined"?$m.skillsOutput:skillsOutput).__contains__(key))?($p['cmp'](recurseCount, 3) == -1):$and7):$and6))) {
					return $pyjs_kwargs_call(null, $m['assign_random'], null, null, [{recurseCount:$p['__op_add']($add79=recurseCount,$add80=1)}]);
				}
				return (typeof assign == "undefined"?$m.assign:assign)(key);
			}
		}
		return null;
	};
	$m['assign_random'].__name__ = 'assign_random';

	$m['assign_random'].__bind_type__ = 0;
	$m['assign_random'].__args__ = [null,null,['recurseCount', 0]];
	$m['assign'] = function(item) {
		var $or7,$or6,$sub13,$sub12,$sub11,$sub10,$or9,$or8,$sub14,$sub9,$or11,$or10,$add82,$add81;
		(typeof itemPool == "undefined"?$m.itemPool:itemPool).__setitem__(item, $p['max']($p['__op_sub']($sub9=(typeof itemPool == "undefined"?$m.itemPool:itemPool).__getitem__(item),$sub10=1), 0));
		if ($p['bool'](($p['bool']($or6=$p['op_eq'](item, 'EC'))?$or6:($p['bool']($or7=$p['op_eq'](item, 'KS'))?$or7:$p['op_eq'](item, 'HC'))))) {
			if ($p['bool'](($p['cmp']((typeof costs == "undefined"?$m.costs:costs).__getitem__(item), 0) == 1))) {
				(typeof costs == "undefined"?$m.costs:costs).__setitem__(item, $p['__op_sub']($sub11=(typeof costs == "undefined"?$m.costs:costs).__getitem__(item),$sub12=1));
			}
		}
		else if ($p['bool'](($p['bool']($or9=$p['op_eq'](item, 'WaterVeinShard'))?$or9:($p['bool']($or10=$p['op_eq'](item, 'GumonSealShard'))?$or10:$p['op_eq'](item, 'SunstoneShard'))))) {
			if ($p['bool'](($p['cmp']((typeof costs == "undefined"?$m.costs:costs).__getitem__(item), 0) == 1))) {
				(typeof costs == "undefined"?$m.costs:costs).__setitem__(item, $p['__op_sub']($sub13=(typeof costs == "undefined"?$m.costs:costs).__getitem__(item),$sub14=1));
			}
		}
		else if ($p['bool']($m.costs['keys']().__contains__(item))) {
			(typeof costs == "undefined"?$m.costs:costs).__setitem__(item, 0);
		}
		(typeof inventory == "undefined"?$m.inventory:inventory).__setitem__(item, $p['__op_add']($add81=(typeof inventory == "undefined"?$m.inventory:inventory).__getitem__(item),$add82=1));
		return item;
	};
	$m['assign'].__name__ = 'assign';

	$m['assign'].__bind_type__ = 0;
	$m['assign'].__args__ = [null,null,['item']];
	$m['force_assign'] = function(item, location) {

		$m['assign'](item);
		(typeof assign_to_location == "undefined"?$m.assign_to_location:assign_to_location)(item, location);
		return null;
	};
	$m['force_assign'].__name__ = 'force_assign';

	$m['force_assign'].__bind_type__ = 0;
	$m['force_assign'].__args__ = [null,null,['item'],['location']];
	$m['assign_to_location'] = function(item, location) {
		var $add134,$add127,$add89,$add88,$add129,$add131,$add116,$and9,$add83,$add117,$add114,$add115,$add87,$add86,$add85,$add84,$add133,$sub16,$add108,$sub18,$add121,$add128,$add105,$add123,$add113,$add104,$add100,$add118,$add132,$add119,$add124,$add136,$add94,$add120,$sub17,$add95,$add137,$add110,$mul22,$mul21,$add101,$add103,$add102,$add98,$add99,$add107,$add106,assignment,$add96,$add97,$add90,$add91,$add92,$add93,$and10,$add111,$add138,$add126,$add140,$add130,$add135,value,$sub15,$add109,$add122,$add125,$add139,$add112;
		assignment = '';
		if ($p['bool'](($p['bool']($and9=!$p['bool']((typeof nonProgressiveMapstones == "undefined"?$m.nonProgressiveMapstones:nonProgressiveMapstones)))?$p['op_eq']($p['getattr'](location, 'orig'), 'MapStone'):$and9))) {
			$m['mapstonesAssigned'] = $p['__op_add']($add83=$m['mapstonesAssigned'],$add84=1);
			assignment = $p['__op_add']($add89=assignment,$add90=$p['__op_add']($add87=$p['str']($p['__op_add']($add85=20,$add86=(typeof ($mul21=$m['mapstonesAssigned'])==typeof ($mul22=4) && typeof $mul21=='number'?
				$mul21*$mul22:
				$p['op_mul']($mul21,$mul22)))),$add88='|'));
			if ($p['bool']($m.costs['keys']().__contains__(item))) {
				if ($p['bool'](!$m['spoilerGroup'].__contains__(item))) {
					$m['spoilerGroup'].__setitem__(item, $p['list']([]));
				}
				$m['spoilerGroup'].__getitem__(item)['append']($p['__op_add']($add95=$p['__op_add']($add93=$p['__op_add']($add91=item,$add92=' from MapStone '),$add94=$p['str']($m['mapstonesAssigned'])),$add96='\r\n'));
			}
		}
		else {
			assignment = $p['__op_add']($add99=assignment,$add100=$p['__op_add']($add97=$p['str'](location['get_key']()),$add98='|'));
			if ($p['bool']($m.costs['keys']().__contains__(item))) {
				if ($p['bool'](!$m['spoilerGroup'].__contains__(item))) {
					$m['spoilerGroup'].__setitem__(item, $p['list']([]));
				}
				$m['spoilerGroup'].__getitem__(item)['append']($p['__op_add']($add105=$p['__op_add']($add103=$p['__op_add']($add101=item,$add102=' from '),$add104=location['to_string']()),$add106='\r\n'));
			}
		}
		if ($p['bool']((typeof skillsOutput == "undefined"?$m.skillsOutput:skillsOutput).__contains__(item))) {
			assignment = $p['__op_add']($add111=assignment,$add112=$p['__op_add']($add109=$p['__op_add']($add107=$p['str']($p['__getslice']((typeof skillsOutput == "undefined"?$m.skillsOutput:skillsOutput).__getitem__(item), 0, 2)),$add108='|'),$add110=$p['__getslice']((typeof skillsOutput == "undefined"?$m.skillsOutput:skillsOutput).__getitem__(item), 2, null)));
		}
		else if ($p['bool']((typeof eventsOutput == "undefined"?$m.eventsOutput:eventsOutput).__contains__(item))) {
			assignment = $p['__op_add']($add117=assignment,$add118=$p['__op_add']($add115=$p['__op_add']($add113=$p['str']($p['__getslice']((typeof eventsOutput == "undefined"?$m.eventsOutput:eventsOutput).__getitem__(item), 0, 2)),$add114='|'),$add116=$p['__getslice']((typeof eventsOutput == "undefined"?$m.eventsOutput:eventsOutput).__getitem__(item), 2, null)));
		}
		else if ($p['bool']($p['op_eq'](item, 'EX*'))) {
			value = (typeof get_random_exp_value == "undefined"?$m.get_random_exp_value:get_random_exp_value)($m['expRemaining'], $m['expSlots']);
			$m['expRemaining'] = $p['__op_sub']($sub15=$m['expRemaining'],$sub16=value);
			$m['expSlots'] = $p['__op_sub']($sub17=$m['expSlots'],$sub18=1);
			assignment = $p['__op_add']($add121=assignment,$add122=$p['__op_add']($add119='EX|',$add120=$p['str'](value)));
		}
		else if ($p['bool']($p['__getslice'](item, 2, null))) {
			assignment = $p['__op_add']($add127=assignment,$add128=$p['__op_add']($add125=$p['__op_add']($add123=$p['__getslice'](item, 0, 2),$add124='|'),$add126=$p['__getslice'](item, 2, null)));
		}
		else {
			assignment = $p['__op_add']($add131=assignment,$add132=$p['__op_add']($add129=$p['__getslice'](item, 0, 2),$add130='|1'));
		}
		assignment = $p['__op_add']($add137=assignment,$add138=$p['__op_add']($add135=$p['__op_add']($add133='|',$add134=$p['getattr'](location, 'zone')),$add136='\r\n'));
		if ($p['bool']((typeof eventsOutput == "undefined"?$m.eventsOutput:eventsOutput).__contains__(item))) {
			$m['eventList']['append'](assignment);
		}
		else {
			$m['outputStr'] = $p['__op_add']($add139=$m['outputStr'],$add140=assignment);
		}
		return null;
	};
	$m['assign_to_location'].__name__ = 'assign_to_location';

	$m['assign_to_location'].__bind_type__ = 0;
	$m['assign_to_location'].__args__ = [null,null,['item'],['location']];
	$m['get_random_exp_value'] = function(expRemaining, expSlots) {
		var $mul25,$mul28,min,$div15,$div16,$add144,$div13,$div14,$add141,$add143,$add142,$mul26,$mul27,$mul24,$mul23;
		min = $m.random['randint'](2, 9);
		if ($p['bool'](($p['cmp'](expSlots, 1) < 1))) {
			return $p['max'](expRemaining, min);
		}
		return $p['float_int']($p['max']((typeof ($div15=(typeof ($mul25=(typeof ($mul23=expRemaining)==typeof ($mul24=$p['__op_add']($add141=(typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('EX*'),$add142=(typeof ($div13=expSlots)==typeof ($div14=4) && typeof $div13=='number' && $div14 !== 0?
			$div13/$div14:
			$p['op_div']($div13,$div14)))) && typeof $mul23=='number'?
			$mul23*$mul24:
			$p['op_mul']($mul23,$mul24)))==typeof ($mul26=$m.random['uniform'](0.0, 2.0)) && typeof $mul25=='number'?
			$mul25*$mul26:
			$p['op_mul']($mul25,$mul26)))==typeof ($div16=(typeof ($mul27=expSlots)==typeof ($mul28=$p['__op_add']($add143=expSlots,$add144=(typeof inventory == "undefined"?$m.inventory:inventory).__getitem__('EX*'))) && typeof $mul27=='number'?
			$mul27*$mul28:
			$p['op_mul']($mul27,$mul28))) && typeof $div15=='number' && $div16 !== 0?
			$div15/$div16:
			$p['op_div']($div15,$div16)), min));
	};
	$m['get_random_exp_value'].__name__ = 'get_random_exp_value';

	$m['get_random_exp_value'].__bind_type__ = 0;
	$m['get_random_exp_value'].__args__ = [null,null,['expRemaining'],['expSlots']];
	$m['preferred_difficulty_assign'] = function(item, locationsToAssign) {
		var $sub22,$sub23,$sub20,$sub21,$sub26,$iter22_array,$sub24,$sub25,$sub19,$iter22_type,total,loc,$div18,$div17,$add145,$add147,$add146,$mul29,$add149,$add148,$iter22_iter,$iter21_idx,$iter21_nextval,$iter22_nextval,$iter21_iter,$mul34,$div19,$div20,i,$iter22_idx,value,$iter21_type,$add150,$add151,$add152,$iter21_array,$mul35,position,$mul36,$mul31,$mul30,$mul33,$mul32;
		total = 0.0;
		$iter21_iter = locationsToAssign;
		$iter21_nextval=$p['__iter_prepare']($iter21_iter,false);
		while (typeof($p['__wrapped_next']($iter21_nextval).$nextval) != 'undefined') {
			loc = $iter21_nextval.$nextval;
			if ($p['bool']($p['op_eq']((typeof pathDifficulty == "undefined"?$m.pathDifficulty:pathDifficulty), 'easy'))) {
				total = $p['__op_add']($add145=total,$add146=(typeof ($mul29=$p['__op_sub']($sub19=15,$sub20=$p['getattr'](loc, 'difficulty')))==typeof ($mul30=$p['__op_sub']($sub21=15,$sub22=$p['getattr'](loc, 'difficulty'))) && typeof $mul29=='number'?
					$mul29*$mul30:
					$p['op_mul']($mul29,$mul30)));
			}
			else {
				total = $p['__op_add']($add147=total,$add148=(typeof ($mul31=$p['getattr'](loc, 'difficulty'))==typeof ($mul32=$p['getattr'](loc, 'difficulty')) && typeof $mul31=='number'?
					$mul31*$mul32:
					$p['op_mul']($mul31,$mul32)));
			}
		}
		value = $m.random['random']();
		position = 0.0;
		$iter22_iter = $p['range'](0, $p['len'](locationsToAssign));
		$iter22_nextval=$p['__iter_prepare']($iter22_iter,false);
		while (typeof($p['__wrapped_next']($iter22_nextval).$nextval) != 'undefined') {
			i = $iter22_nextval.$nextval;
			if ($p['bool']($p['op_eq']((typeof pathDifficulty == "undefined"?$m.pathDifficulty:pathDifficulty), 'easy'))) {
				position = $p['__op_add']($add149=position,$add150=(typeof ($div17=(typeof ($mul33=$p['__op_sub']($sub23=15,$sub24=$p['getattr'](locationsToAssign.__getitem__(i), 'difficulty')))==typeof ($mul34=$p['__op_sub']($sub25=15,$sub26=$p['getattr'](locationsToAssign.__getitem__(i), 'difficulty'))) && typeof $mul33=='number'?
					$mul33*$mul34:
					$p['op_mul']($mul33,$mul34)))==typeof ($div18=total) && typeof $div17=='number' && $div18 !== 0?
					$div17/$div18:
					$p['op_div']($div17,$div18)));
			}
			else {
				position = $p['__op_add']($add151=position,$add152=(typeof ($div19=(typeof ($mul35=$p['getattr'](locationsToAssign.__getitem__(i), 'difficulty'))==typeof ($mul36=$p['getattr'](locationsToAssign.__getitem__(i), 'difficulty')) && typeof $mul35=='number'?
					$mul35*$mul36:
					$p['op_mul']($mul35,$mul36)))==typeof ($div20=total) && typeof $div19=='number' && $div20 !== 0?
					$div19/$div20:
					$p['op_div']($div19,$div20)));
			}
			if ($p['bool'](($p['cmp'](value, position) < 1))) {
				$m['assign_to_location'](item, locationsToAssign.__getitem__(i));
				break;
			}
		}
		locationsToAssign.__delitem__(i);
		return null;
	};
	$m['preferred_difficulty_assign'].__name__ = 'preferred_difficulty_assign';

	$m['preferred_difficulty_assign'].__bind_type__ = 0;
	$m['preferred_difficulty_assign'].__args__ = [null,null,['item'],['locationsToAssign']];
	$m['selectText'] = function(selectFrom, selectTo, line) {
		var $add160,$add153,$add156,$add157,$add154,$add155,$add159,$add158;
		return $m['re']['match']($p['__op_add']($add159=$p['__op_add']($add157=$p['__op_add']($add155=$p['__op_add']($add153='.*',$add154=selectFrom),$add156='(.*)'),$add158=selectTo),$add160='.*'), line)['group'](1);
	};
	$m['selectText'].__name__ = 'selectText';

	$m['selectText'].__bind_type__ = 0;
	$m['selectText'].__args__ = [null,null,['selectFrom'],['selectTo'],['line']];
	$m['placeItems'] = function(seed, expPool, hardMode, includePlants, shardsMode, limitkeysMode, cluesMode, noTeleporters, modes, flags, starvedMode, preferPathDifficulty, setNonProgressiveMapstones) {
		var $sub27,$iter33_nextval,$iter40_array,$sub28,$sub29,satisfied,$iter26_idx,$iter32_iter,seedDifficultyMap,$iter37_nextval,skill,$add285,$add258,$add269,$iter34_iter,$iter33_type,$iter30_nextval,$iter26_type,$iter27_idx,$add282,$iter31_idx,$iter29_array,$add189,$add188,currentConnection,mapstoneCount,keystoneCount,location,$add235,$add234,$add181,$add180,$add183,$add185,ginso,match,$add186,$sub31,$sub30,$sub33,$add168,$sub35,$sub34,$sub37,$add163,$add162,$add161,$add167,$add166,$add165,$add164,$iter35_idx,$iter33_array,instance,$add262,$iter28_iter,$add196,$add197,$add194,$add195,$add192,$add193,$add190,$add191,$iter34_idx,$iter27_type,$iter28_nextval,$iter28_array,$add198,$add199,$add220,item,$add222,$add223,$add224,mode,$add226,$add227,$add228,$add229,$mul37,$iter37_iter,$add178,$add179,$sub32,$iter35_type,$add286,$add287,$add284,$iter25_nextval,$add170,$add171,$add172,$add173,$add174,$add175,$add176,$add177,$mul41,horu,$iter26_array,$and20,event,$iter31_array,$iter39_type,$add221,$iter36_nextval,keys,$iter24_array,$add219,$add218,$add215,$add214,$add217,$add216,$add211,$add210,$add213,$add212,$add225,$iter30_type,$add279,opening,$iter35_nextval,$add276,$add275,$add274,$add273,$add272,$add271,$add270,difficulty,$iter29_nextval,$iter30_idx,key,$iter24_iter,$iter38_array,$iter33_idx,$iter39_idx,$iter38_type,$iter34_type,$iter23_nextval,$iter26_iter,$iter24_idx,$iter30_iter,$add233,$iter37_idx,$iter37_type,$iter29_type,connection,$add209,$add278,$add202,$add203,$add200,$add201,$add206,spoilerStr,$add204,$add205,$iter39_nextval,spoilerPath,$iter32_idx,$iter40_iter,$add268,$iter37_array,$iter33_iter,$add264,$add265,$add266,$add267,$iter31_nextval,$iter23_type,$add263,$add244,$add281,$iter36_iter,$iter36_type,$iter40_type,$iter40_nextval,loc,$iter28_type,locationsToAssign,area,$add231,$iter40_idx,$add230,$mul39,$iter32_array,mapstones,$iter27_iter,$add288,$add236,$add259,$add237,$add260,$iter32_nextval,$iter36_idx,$add251,$add250,$add253,$add252,$add255,$add254,$add257,$add256,$iter23_array,$add239,plants,$add182,$add240,$iter29_iter,$add184,$iter34_array,$add187,$or13,$or12,$iter30_array,$iter29_idx,$add283,groupDepth,$add232,$iter38_iter,$iter25_array,$add280,$add241,$iter26_nextval,$iter28_idx,$add169,$iter38_idx,$add238,$iter23_idx,$iter25_iter,$sub40,$iter39_iter,itemsToAssign,difficultyMap,$add247,$iter23_iter,$iter31_type,$sub36,$mul40,$add208,$mul42,$iter24_type,$iter32_type,$sub39,$add245,$sub38,$add242,$iter36_array,$iter24_nextval,$iter25_idx,$iter27_nextval,$iter38_nextval,$mul38,$add277,$iter39_array,$and12,$and13,$and11,$and16,$and17,$and14,$and15,$add261,$iter35_array,$and18,$and19,$iter25_type,$iter34_nextval,$iter35_iter,i,lines,limitKeysPool,$add207,$add246,$iter27_array,$add243,forlorn,$add249,$add248,$iter31_iter;
		$m['shards'] = shardsMode;
		$m['limitkeys'] = limitkeysMode;
		$m['starved'] = starvedMode;
		$m['pathDifficulty'] = preferPathDifficulty;
		$m['nonProgressiveMapstones'] = setNonProgressiveMapstones;
		$m['skillsOutput'] = $p['dict']([['WallJump', 'SK3'], ['ChargeFlame', 'SK2'], ['Dash', 'SK50'], ['Stomp', 'SK4'], ['DoubleJump', 'SK5'], ['Glide', 'SK14'], ['Bash', 'SK0'], ['Climb', 'SK12'], ['Grenade', 'SK51'], ['ChargeJump', 'SK8']]);
		$m['eventsOutput'] = $p['dict']([['GinsoKey', 'EV0'], ['Water', 'EV1'], ['ForlornKey', 'EV2'], ['Wind', 'EV3'], ['HoruKey', 'EV4'], ['Warmth', 'EV5'], ['WaterVeinShard', 'RB17'], ['GumonSealShard', 'RB19'], ['SunstoneShard', 'RB21']]);
		seedDifficultyMap = $p['dict']([['Dash', 2], ['Bash', 2], ['Glide', 3], ['DoubleJump', 2], ['ChargeJump', 1]]);
		$m['seedDifficulty'] = 0;
		limitKeysPool = $p['list'](['SKWallJump', 'SKChargeFlame', 'SKDash', 'SKStomp', 'SKDoubleJump', 'SKGlide', 'SKClimb', 'SKGrenade', 'SKChargeJump', 'EVGinsoKey', 'EVForlornKey', 'EVHoruKey', 'SKBash', 'EVWater', 'EVWind']);
		difficultyMap = $p['dict']([['normal', 1], ['speed', 2], ['lure', 2], ['dboost', 2], ['dboost-light', 1], ['dboost-hard', 3], ['cdash', 2], ['cdash-farming', 2], ['dbash', 3], ['extended', 3], ['extended-damage', 3], ['lure-hard', 4], ['extreme', 4], ['glitched', 5], ['timed-level', 5]]);
		$m['outputStr'] = '';
		$m['eventList'] = $p['list']([]);
		spoilerStr = '';
		groupDepth = 0;
		$m['costs'] = $p['dict']([['Free', 0], ['MS', 0], ['KS', 2], ['EC', 6], ['HC', 12], ['WallJump', 13], ['ChargeFlame', 13], ['DoubleJump', 13], ['Bash', 30], ['Stomp', 28], ['Glide', 17], ['Climb', 40], ['ChargeJump', 52], ['Dash', 13], ['Grenade', 18], ['GinsoKey', 12], ['ForlornKey', 12], ['HoruKey', 12], ['Water', 80], ['Wind', 80], ['WaterVeinShard', 5], ['GumonSealShard', 5], ['SunstoneShard', 5], ['TPForlorn', 180], ['TPGrotto', 60], ['TPSorrow', 90], ['TPGrove', 60], ['TPSwamp', 60], ['TPValley', 90]]);
		$m['areas'] = $p['dict']([]);
		$m['areasReached'] = $p['dict']([['SunkenGladesRunaway', true]]);
		$m['currentAreas'] = $p['list'](['SunkenGladesRunaway']);
		$m['areaList'] = $p['list']([]);
		$m['connectionQueue'] = $p['list']([]);
		$m['assignQueue'] = $p['list']([]);
		$m['itemCount'] = 244.0;
		$m['expRemaining'] = expPool;
		keystoneCount = 0;
		mapstoneCount = 0;
		if ($p['bool'](!$p['bool'](hardMode))) {
			$m['itemPool'] = $p['dict']([['EX1', 1], ['EX*', 93], ['KS', 40], ['MS', 9], ['AC', 33], ['EC', 14], ['HC', 12], ['WallJump', 1], ['ChargeFlame', 1], ['Dash', 1], ['Stomp', 1], ['DoubleJump', 1], ['Glide', 1], ['Bash', 1], ['Climb', 1], ['Grenade', 1], ['ChargeJump', 1], ['GinsoKey', 1], ['ForlornKey', 1], ['HoruKey', 1], ['Water', 1], ['Wind', 1], ['Warmth', 1], ['RB0', 3], ['RB1', 3], ['RB6', 3], ['RB8', 1], ['RB9', 1], ['RB10', 1], ['RB11', 1], ['RB12', 1], ['RB13', 3], ['RB15', 3], ['WaterVeinShard', 0], ['GumonSealShard', 0], ['SunstoneShard', 0], ['TPForlorn', 1], ['TPGrotto', 1], ['TPSorrow', 1], ['TPGrove', 1], ['TPSwamp', 1], ['TPValley', 1]]);
		}
		else {
			$m['itemPool'] = $p['dict']([['EX1', 1], ['EX*', 169], ['KS', 40], ['MS', 9], ['AC', 0], ['EC', 3], ['HC', 0], ['WallJump', 1], ['ChargeFlame', 1], ['Dash', 1], ['Stomp', 1], ['DoubleJump', 1], ['Glide', 1], ['Bash', 1], ['Climb', 1], ['Grenade', 1], ['ChargeJump', 1], ['GinsoKey', 1], ['ForlornKey', 1], ['HoruKey', 1], ['Water', 1], ['Wind', 1], ['Warmth', 1], ['WaterVeinShard', 0], ['GumonSealShard', 0], ['SunstoneShard', 0], ['TPForlorn', 1], ['TPGrotto', 1], ['TPSorrow', 1], ['TPGrove', 1], ['TPSwamp', 1], ['TPValley', 1]]);
		}
		plants = $p['list']([]);
		if ($p['bool'](!$p['bool'](includePlants))) {
			$m['itemCount'] = $p['__op_sub']($sub27=$m['itemCount'],$sub28=24);
			$m['itemPool'].__setitem__('EX*', $p['__op_sub']($sub29=$m['itemPool'].__getitem__('EX*'),$sub30=24));
		}
		if ($p['bool']($m['shards'])) {
			$m['itemPool'].__setitem__('WaterVeinShard', 5);
			$m['itemPool'].__setitem__('GumonSealShard', 5);
			$m['itemPool'].__setitem__('SunstoneShard', 5);
			$m['itemPool'].__setitem__('GinsoKey', 0);
			$m['itemPool'].__setitem__('ForlornKey', 0);
			$m['itemPool'].__setitem__('HoruKey', 0);
			$m['itemPool'].__setitem__('EX*', $p['__op_sub']($sub31=$m['itemPool'].__getitem__('EX*'),$sub32=12));
		}
		if ($p['bool']($m['limitkeys'])) {
			satisfied = false;
			while ($p['bool'](!$p['bool'](satisfied))) {
				ginso = $m.random['randint'](0, 12);
				if ($p['bool']($p['op_eq'](ginso, 12))) {
					ginso = 14;
				}
				forlorn = $m.random['randint'](0, 13);
				horu = $m.random['randint'](0, 14);
				if ($p['bool'](($p['bool']($and11=!$p['op_eq'](ginso, forlorn))?($p['bool']($and12=!$p['op_eq'](ginso, horu))?($p['bool']($and13=!$p['op_eq'](forlorn, horu))?($p['cmp']($p['__op_add']($add161=ginso,$add162=forlorn), 26) == -1):$and13):$and12):$and11))) {
					satisfied = true;
				}
			}
			$m['keySpots'] = $p['dict']([[limitKeysPool.__getitem__(ginso), 'GinsoKey'], [limitKeysPool.__getitem__(forlorn), 'ForlornKey'], [limitKeysPool.__getitem__(horu), 'HoruKey']]);
			$m['itemPool'].__setitem__('GinsoKey', 0);
			$m['itemPool'].__setitem__('ForlornKey', 0);
			$m['itemPool'].__setitem__('HoruKey', 0);
			$m['itemCount'] = $p['__op_sub']($sub33=$m['itemCount'],$sub34=3);
		}
		if ($p['bool'](noTeleporters)) {
			$m['itemPool'].__setitem__('TPForlorn', 0);
			$m['itemPool'].__setitem__('TPGrotto', 0);
			$m['itemPool'].__setitem__('TPSorrow', 0);
			$m['itemPool'].__setitem__('TPGrove', 0);
			$m['itemPool'].__setitem__('TPSwamp', 0);
			$m['itemPool'].__setitem__('TPValley', 0);
			$m['itemPool'].__setitem__('EX*', $p['__op_add']($add163=$m['itemPool'].__getitem__('EX*'),$add164=6));
		}
		$m['inventory'] = $p['dict']([['EX1', 0], ['EX*', 0], ['KS', 0], ['MS', 0], ['AC', 0], ['EC', 1], ['HC', 3], ['WallJump', 0], ['ChargeFlame', 0], ['Dash', 0], ['Stomp', 0], ['DoubleJump', 0], ['Glide', 0], ['Bash', 0], ['Climb', 0], ['Grenade', 0], ['ChargeJump', 0], ['GinsoKey', 0], ['ForlornKey', 0], ['HoruKey', 0], ['Water', 0], ['Wind', 0], ['Warmth', 0], ['RB0', 0], ['RB1', 0], ['RB6', 0], ['RB8', 0], ['RB9', 0], ['RB10', 0], ['RB11', 0], ['RB12', 0], ['RB13', 0], ['RB15', 0], ['WaterVeinShard', 0], ['GumonSealShard', 0], ['SunstoneShard', 0], ['TPForlorn', 1], ['TPGrotto', 1], ['TPSorrow', 1], ['TPGrove', 1], ['TPSwamp', 1], ['TPValley', 1]]);
		lines = '<?xml version="1.0"?>\n<Areas>\n  <Area name="SunkenGladesRunaway">\n    <Locations>\n      <Location>\n        <X>92</X>\n        <Y>-227</Y>\n        <Item>EX15</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-154</X>\n        <Y>-271</Y>\n        <Item>EX15</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>83</X>\n        <Y>-222</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-11</X>\n        <Y>-206</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="SunkenGladesNadePool"/>\n        <Requirements>\n          <Requirement mode="normal">Water+Grenade</Requirement>\n          <Requirement mode="dboost">Grenade+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost">Grenade+HC+HC+HC+HC+HC+Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="SunkenGladesNadeTree"/>\n        <Requirements>\n          <Requirement mode="speed">Grenade+WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Grenade+ChargeJump</Requirement>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="SunkenGladesMainPool"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost">Bash</Requirement>\n          <Requirement mode="dboost">Stomp</Requirement>\n          <Requirement mode="dboost">HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="SunkenGladesMainPoolDeep"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost">HC+HC+HC+HC+HC+HC+HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="WallJump"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="DashArea"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">Climb</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="FronkeyWalkRoof"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="lure">Bash</Requirement>\n          <Requirement mode="normal">Glide+Wind</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="Forlorn"/>\n        <Requirements>\n          <Requirement mode="dboost-light">TPForlorn+DoubleJump+ChargeJump</Requirement>\n          <Requirement mode="dboost-light">TPForlorn+DoubleJump+Bash</Requirement>\n          <Requirement mode="dboost-light">TPForlorn+Glide+ChargeJump</Requirement>\n          <Requirement mode="dboost-light">TPForlorn+Glide+Bash</Requirement>\n          <Requirement mode="dboost-light">TPForlorn+Grenade+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="MoonGrotto"/>\n        <Requirements>\n          <Requirement mode="normal">TPGrotto+ChargeJump</Requirement>\n          <Requirement mode="normal">TPGrotto+WallJump</Requirement>\n          <Requirement mode="normal">TPGrotto+Climb</Requirement>\n          <Requirement mode="normal">TPGrotto+Grenade+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="GumoHideoutMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">TPGrotto+MS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="HollowGrove"/>\n        <Requirements>\n          <Requirement mode="normal">TPSwamp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="SpiritTreeRefined"/>\n        <Requirements>\n          <Requirement mode="normal">TPGrove</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="ValleyRight"/>\n        <Requirements>\n          <Requirement mode="normal">TPValley+Bash+WallJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SunkenGladesRunaway"/>\n        <Target name="Sunstone"/>\n        <Requirements>\n          <Requirement mode="normal">TPSorrow+Glide+Climb+ChargeJump</Requirement>\n          <Requirement mode="extended-damage">TPSorrow+Glide+Stomp+ChargeJump+Dash+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dbash">TPSorrow+Glide+Stomp+Bash</Requirement>\n          <Requirement mode="dbash">TPSorrow+Glide+ChargeJump+Bash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="SunkenGladesNadePool">\n    <Locations>\n      <Location>\n        <X>59</X>\n        <Y>-280</Y>\n        <Item>EX200</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SunkenGladesNadeTree">\n    <Locations>\n      <Location>\n        <X>82</X>\n        <Y>-196</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SunkenGladesMainPool">\n    <Locations>\n      <Location>\n        <X>5</X>\n        <Y>-241</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SunkenGladesMainPoolDeep">\n    <Locations>\n      <Location>\n        <X>-40</X>\n        <Y>-239</Y>\n        <Item>EC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="FronkeyWalkRoof">\n    <Locations>\n      <Location>\n        <X>257</X>\n        <Y>-199</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="WallJump">\n    <Locations>\n      <Location>\n        <X>-80</X>\n        <Y>-189</Y>\n        <Item>HC</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-59</X>\n        <Y>-244</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-316</X>\n        <Y>-308</Y>\n        <Item>SKWallJump</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-283</X>\n        <Y>-236</Y>\n        <Item>EX15</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="DeathGauntlet"/>\n        <Requirements>\n          <Requirement mode="dboost-light">EC+EC+EC+EC+WallJump</Requirement>\n          <Requirement mode="dboost-light">EC+EC+EC+EC+Climb</Requirement>\n          <Requirement mode="dboost-light">EC+EC+EC+EC+ChargeJump+Bash</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+Grenade+Bash</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+Climb+DoubleJump+Glide</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+WallJump+DoubleJump+Glide</Requirement>\n          <Requirement mode="timed-level">EC+EC+WallJump</Requirement>\n          <Requirement mode="timed-level">EC+EC+Climb</Requirement>\n          <Requirement mode="timed-level">EC+EC+ChargeJump+Bash</Requirement>\n          <Requirement mode="timed-level">EC+EC+Grenade+Bash</Requirement>\n          <Requirement mode="lure">EC+EC+EC+EC+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="AboveFourthHealth"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+WallJump</Requirement>\n          <Requirement mode="normal">Bash+Climb</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="speed">WallJump+DoubleJump</Requirement>\n          <Requirement mode="extended">Climb+DoubleJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="RightWallJump"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="lure-hard">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="LeftWallJump"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">Climb</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="lure-hard">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="SpiritCaverns"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+Climb</Requirement>\n          <Requirement mode="normal">KS+KS+WallJump</Requirement>\n          <Requirement mode="normal">KS+KS+ChargeJump</Requirement>\n          <Requirement mode="normal">KS+KS+Bash+Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="GladesLaser"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+Climb</Requirement>\n          <Requirement mode="normal">ChargeJump+WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Bash+DoubleJump+Glide</Requirement>\n          <Requirement mode="normal">Bash+DoubleJump+WallJump</Requirement>\n          <Requirement mode="normal">Bash+DoubleJump+Climb</Requirement>\n          <Requirement mode="normal">Bash+Grenade+Climb</Requirement>\n          <Requirement mode="normal">Bash+Grenade+WallJump</Requirement>\n          <Requirement mode="lure">Bash+WallJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n          <Requirement mode="cdash-farming">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="ChargeFlame"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+Grenade</Requirement>\n          <Requirement mode="normal">WallJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">Climb+Grenade</Requirement>\n          <Requirement mode="normal">Climb+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+Grenade</Requirement>\n          <Requirement mode="normal">ChargeJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="glitched">Dash+Bash+WallJump</Requirement>\n          <Requirement mode="glitched">Dash+Bash+Climb</Requirement>\n          <Requirement mode="glitched">Dash+WallJump+DoubleJump</Requirement>\n          <Requirement mode="glitched">Dash+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="ChargeFlameOrb"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="WallJump"/>\n        <Target name="WallJumpMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="DeathGauntlet">\n    <Locations>\n      <Location>\n        <X>303</X>\n        <Y>-190</Y>\n        <Item>EX100</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="DeathGauntlet"/>\n        <Target name="DeathStomp"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp+Water</Requirement>\n          <Requirement mode="dboost">Stomp</Requirement>\n          <Requirement mode="extended-damage">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DeathGauntlet"/>\n        <Target name="DeathGauntletRoof"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DeathGauntlet"/>\n        <Target name="DeathWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water+EC+EC+EC+EC</Requirement>\n          <Requirement mode="dboost">EC+EC+EC+EC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DeathGauntlet"/>\n        <Target name="MoonGrotto"/>\n        <Requirements>\n          <Requirement mode="dboost-light">WallJump</Requirement>\n          <Requirement mode="dboost-light">Climb</Requirement>\n          <Requirement mode="dboost-light">ChargeJump+Bash</Requirement>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n          <Requirement mode="normal">Climb+DoubleJump+Glide</Requirement>\n          <Requirement mode="normal">WallJump+DoubleJump+Glide</Requirement>\n          <Requirement mode="timed-level">WallJump</Requirement>\n          <Requirement mode="timed-level">Climb</Requirement>\n          <Requirement mode="timed-level">ChargeJump+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DeathGauntlet"/>\n        <Target name="SunkenGladesRunaway"/>\n        <Requirements>\n          <Requirement mode="normal">DoubleJump+EC+EC+EC+EC</Requirement>\n          <Requirement mode="normal">Glide+EC+EC+EC+EC</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="WallJumpMapStone">\n    <Locations>\n      <Location>\n        <X>-81</X>\n        <Y>-248</Y>\n        <Item>MapStone</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="AboveFourthHealth">\n    <Locations>\n      <Location>\n        <X>-48</X>\n        <Y>-166</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightWallJump">\n    <Locations>\n      <Location>\n        <X>-245</X>\n        <Y>-277</Y>\n        <Item>EX200</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LeftWallJump">\n    <Locations>\n      <Location>\n        <X>-336</X>\n        <Y>-288</Y>\n        <Item>EC</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-247</X>\n        <Y>-207</Y>\n        <Item>EX15</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-238</X>\n        <Y>-212</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-184</X>\n        <Y>-227</Y>\n        <Item>MS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SpiritCaverns">\n    <Locations>\n      <Location>\n        <X>-182</X>\n        <Y>-193</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-217</X>\n        <Y>-183</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n      <Location>\n        <X>-177</X>\n        <Y>-154</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="SpiritCaverns"/>\n        <Target name="SpiritCavernsTopLeft"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">DoubleJump</Requirement>\n          <Requirement mode="dboost-light">ChargeJump</Requirement>\n          <Requirement mode="dboost-light">Bash</Requirement>\n          <Requirement mode="extreme">Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiritCaverns"/>\n        <Target name="GladesLaser"/>\n        <Requirements>\n          <Requirement mode="normal">EC+EC+EC+EC+DoubleJump</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+Bash</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+ChargeJump</Requirement>\n          <Requirement mode="cdash-farming">EC+EC+EC+EC+Dash</Requirement>\n          <Requirement mode="extended-damage">EC+EC+EC+EC+WallJump+Glide</Requirement>\n          <Requirement mode="glitched">EC+EC+EC+DoubleJump</Requirement>\n          <Requirement mode="glitched">EC+EC+EC+Bash</Requirement>\n          <Requirement mode="glitched">EC+EC+EC+ChargeJump</Requirement>\n          <Requirement mode="glitched">EC+EC+EC+Dash</Requirement>\n          <Requirement mode="glitched">EC+EC+EC+WallJump+Glide</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiritCaverns"/>\n        <Target name="SpiritCavernsAC"/>\n        <Requirements>\n          <Requirement mode="speed">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiritCaverns"/>\n        <Target name="SpiritTreeRefined"/>\n        <Requirements>\n          <!-- will cause some painted-into-corner scenarios, revisit this if it is too much -->\n          <Requirement mode="normal">KS+KS+KS+KS</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="SpiritCavernsTopLeft">\n    <Locations>\n      <Location>\n        <X>-217</X>\n        <Y>-146</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SpiritCavernsAC">\n    <Locations>\n      <Location>\n        <X>-216</X>\n        <Y>-176</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="GladesLaser">\n    <Locations>\n      <Location>\n        <X>-155</X>\n        <Y>-186</Y>\n        <Item>EC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="GladesLaser"/>\n        <Target name="WallJump"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GladesLaser"/>\n        <Target name="SpiritCaverns"/>\n        <Requirements>\n          <Requirement mode="normal">EC+EC+EC+EC</Requirement>\n          <Requirement mode="timed-level">EC+EC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GladesLaser"/>\n        <Target name="GladesLaserGrenade"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade+Bash+WallJump</Requirement>\n          <Requirement mode="normal">Grenade+Bash+Climb</Requirement>\n          <Requirement mode="extended">Grenade+ChargeJump+Water</Requirement>\n          <Requirement mode="extended-damage">Grenade+ChargeJump</Requirement>\n          <Requirement mode="cdash">Grenade+Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="GladesLaserGrenade">\n    <Locations>\n      <Location>\n        <X>-165</X>\n        <Y>-140</Y>\n        <Item>AC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ChargeFlame">\n    <Locations>\n      <Location>\n        <X>-56</X>\n        <Y>-160</Y>\n        <Item>SKChargeFlame</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="ChargeFlame"/>\n        <Target name="SpiritTreeRefined"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+Grenade</Requirement>\n          <Requirement mode="speed">ChargeJump+Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ChargeFlame"/>\n        <Target name="ChargeFlamePlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash-farming">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ChargeFlame"/>\n        <Target name="WallJump"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="normal">Stomp+WallJump</Requirement>\n          <Requirement mode="normal">Stomp+Climb</Requirement>\n          <Requirement mode="normal">Stomp+DoubleJump</Requirement>\n          <Requirement mode="normal">Stomp+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ChargeFlame"/>\n        <Target name="ChargeFlameOrb"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="ChargeFlamePlant">\n    <Locations>\n      <Location>\n        <X>43</X>\n        <Y>-156</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ChargeFlameOrb">\n    <Locations>\n      <Location>\n        <X>4</X>\n        <Y>-196</Y>\n        <Item>EX100</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Glades</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SpiritTreeRefined">\n    <Locations>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="SpiritTreeRefined"/>\n        <Target name="ChargeFlame"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiritTreeRefined"/>\n        <Target name="ValleyEntry"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="normal">Stomp+WallJump</Requirement>\n          <Requirement mode="normal">Stomp+Climb</Requirement>\n          <Requirement mode="normal">Stomp+DoubleJump</Requirement>\n          <Requirement mode="normal">Stomp+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiritTreeRefined"/>\n        <Target name="ChargeFlameTree"/>\n        <Requirements>\n          <Requirement mode="normal">DoubleJump+Climb</Requirement>\n          <Requirement mode="normal">DoubleJump+WallJump</Requirement>\n          <Requirement mode="normal">ChargeJump+Climb</Requirement>\n          <Requirement mode="normal">ChargeJump+WallJump</Requirement>\n          <Requirement mode="normal">ChargeJump+DoubleJump</Requirement>\n          <Requirement mode="normal">ChargeJump+Glide</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="speed">Dash+WallJump</Requirement>\n          <Requirement mode="speed">Dash+Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiritTreeRefined"/>\n        <Target name="SpiderSac"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame+WallJump</Requirement>\n          <Requirement mode="normal">ChargeFlame+ChargeJump</Requirement>\n          <Requirement mode="normal">ChargeFlame+Climb+DoubleJump</Requirement>\n          <Requirement mode="normal">ChargeFlame+Climb+Glide</Requirement>\n          <Requirement mode="normal">ChargeFlame+Climb+Dash</Requirement>\n          <Requirement mode="normal">Grenade+WallJump</Requirement>\n          <Requirement mode="normal">Grenade+ChargeJump</Requirement>\n          <Requirement mode="normal">Grenade+Climb+DoubleJump</Requirement>\n          <Requirement mode="normal">Grenade+Climb+Glide</Requirement>\n          <Requirement mode="normal">Grenade+Climb+Dash</Requirement>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n          <Requirement mode="extended">ChargeFlame+Climb</Requirement>\n          <Requirement mode="extended">Grenade+Climb</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="ChargeFlameTree">\n    <Locations>\n      <Location>\n        <X>-14</X>\n        <Y>-95</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SpiderSac">\n    <Locations>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="SpiderSacHealth"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="SpiderSacEnergy"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">DoubleJump</Requirement>\n          <Requirement mode="normal">Glide</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="SpiderSacGrenadeDoor"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n          <Requirement mode="normal">Grenade+DoubleJump+WallJump</Requirement>\n          <Requirement mode="normal">Grenade+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="SpiderSacEnergyDoor"/>\n        <Requirements>\n          <Requirement mode="normal">EC+EC+EC+EC</Requirement>\n          <!-- you can level up with the spider exp -->\n          <Requirement mode="timed-level">EC+EC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="HollowGrove"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">DoubleJump</Requirement>\n          <Requirement mode="normal">Glide</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="DeathGauntletRoof"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp+Water</Requirement>\n          <Requirement mode="dboost">Stomp+Bash+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost">Stomp+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="SpiritTreeRefined"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame+WallJump</Requirement>\n          <Requirement mode="normal">ChargeFlame+Climb</Requirement>\n          <Requirement mode="normal">ChargeFlame+ChargeJump</Requirement>\n          <Requirement mode="normal">Grenade+WallJump</Requirement>\n          <Requirement mode="normal">Grenade+Climb</Requirement>\n          <Requirement mode="normal">Grenade+ChargeJump</Requirement>\n          <Requirement mode="normal">Stomp+WallJump</Requirement>\n          <Requirement mode="normal">Stomp+Climb</Requirement>\n          <Requirement mode="normal">Stomp+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SpiderSac"/>\n        <Target name="ChargeFlameTree"/>\n        <Requirements>\n          <Requirement mode="extended">ChargeFlame+Glide</Requirement>\n          <Requirement mode="extended">Grenade+Glide</Requirement>\n          <Requirement mode="extended">Stomp+Glide</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="SpiderSacEnergyDoor">\n    <Locations>\n      <Location>\n        <X>64</X>\n        <Y>-109</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SpiderSacHealth">\n    <Locations>\n      <Location>\n        <X>151</X>\n        <Y>-117</Y>\n        <Item>HC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SpiderSacEnergy">\n    <Locations>\n      <Location>\n        <X>60</X>\n        <Y>-155</Y>\n        <Item>EC</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SpiderSacGrenadeDoor">\n    <Locations>\n      <Location>\n        <X>93</X>\n        <Y>-92</Y>\n        <Item>AC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DashArea">\n    <Locations>\n      <Location>\n        <X>154</X>\n        <Y>-291</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n      <Location>\n        <X>183</X>\n        <Y>-291</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n      <Location>\n        <X>197</X>\n        <Y>-229</Y>\n        <Item>EX100</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n      <Location>\n        <X>292</X>\n        <Y>-256</Y>\n        <Item>SKDash</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="DashArea"/>\n        <Target name="DeathGauntlet"/>\n        <Requirements>\n          <Requirement mode="dboost-light">EC+EC+EC+EC+WallJump</Requirement>\n          <Requirement mode="dboost-light">EC+EC+EC+EC+Climb</Requirement>\n          <Requirement mode="dboost-light">EC+EC+EC+EC+ChargeJump+Bash</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+Grenade+Bash</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+Climb+DoubleJump+Glide</Requirement>\n          <Requirement mode="normal">EC+EC+EC+EC+WallJump+DoubleJump+Glide</Requirement>\n          <Requirement mode="timed-level">EC+EC+WallJump</Requirement>\n          <Requirement mode="timed-level">EC+EC+Climb</Requirement>\n          <Requirement mode="timed-level">EC+EC+ChargeJump+Bash</Requirement>\n          <Requirement mode="timed-level">EC+EC+Grenade+Bash</Requirement>\n          <Requirement mode="lure">EC+EC+EC+EC+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DashArea"/>\n        <Target name="LowerBlackRoot"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp+ChargeJump</Requirement>\n          <Requirement mode="normal">Stomp+Grenade+Bash</Requirement>\n          <Requirement mode="normal">Stomp+Dash+DoubleJump</Requirement>\n          <Requirement mode="normal">Stomp+Dash+Grenade+Bash</Requirement>\n          <Requirement mode="normal">Stomp+Dash</Requirement>\n          <Requirement mode="normal">Stomp+ChargeJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Stomp+Grenade</Requirement>\n          <Requirement mode="normal">Stomp+Grenade+Water</Requirement>\n          <Requirement mode="timed-level">Stomp</Requirement>\n          <Requirement mode="extended">Stomp</Requirement>\n          <Requirement mode="extended">ChargeJump+Climb</Requirement>\n          <Requirement mode="extreme">Bash</Requirement>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DashArea"/>\n        <Target name="RazielNo"/>\n        <Requirements>\n          <Requirement mode="normal">Dash+WallJump</Requirement>\n          <Requirement mode="normal">Dash+ChargeJump</Requirement>\n          <Requirement mode="normal">Dash+Bash+Grenade</Requirement>\n          <Requirement mode="normal">Dash+Climb+DoubleJump</Requirement>\n          <Requirement mode="speed">WallJump</Requirement>\n          <Requirement mode="speed">ChargeJump</Requirement>\n          <Requirement mode="speed">Bash+Grenade</Requirement>\n          <Requirement mode="speed">Climb+DoubleJump</Requirement>\n          <Requirement mode="extended">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DashArea"/>\n        <Target name="BlackrootMap"/>\n        <Requirements>\n          <Requirement mode="normal">Dash</Requirement>\n          <Requirement mode="extended">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DashArea"/>\n        <Target name="DashAreaPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+Climb+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+WallJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">Glide+WallJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+Climb+Grenade</Requirement>\n          <Requirement mode="normal">ChargeJump+WallJump+Grenade</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="normal">Glide+WallJump+Grenade</Requirement>\n          <Requirement mode="extended">DoubleJump+Grenade</Requirement>\n          <Requirement mode="extended">DoubleJump+ChargeFlame</Requirement>\n          <Requirement mode="cdash-farming">ChargeJump+Climb+Dash</Requirement>\n          <Requirement mode="cdash-farming">ChargeJump+WallJump+Dash</Requirement>\n          <Requirement mode="cdash-farming">DoubleJump+Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="DashAreaPlant">\n    <Locations>\n      <Location>\n        <X>313</X>\n        <Y>-232</Y>\n        <Item>Plant</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RazielNo">\n    <Locations>\n      <Location>\n        <X>304</X>\n        <Y>-303</Y>\n        <Item>EX100</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="RazielNo"/>\n        <Target name="BoulderExp"/>\n        <Requirements>\n          <Requirement mode="normal">Dash+Stomp</Requirement>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="RazielNo"/>\n        <Target name="BlackrootGrottoConnection"/>\n        <Requirements>\n          <Requirement mode="normal">Dash+DoubleJump</Requirement>\n          <Requirement mode="normal">Dash+ChargeJump</Requirement>\n          <Requirement mode="normal">Dash+Bash+Grenade</Requirement>\n          <Requirement mode="extended">WallJump</Requirement>\n          <Requirement mode="extended">DoubleJump</Requirement>\n          <Requirement mode="extended">ChargeJump</Requirement>\n          <Requirement mode="extended">Dash</Requirement>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="RazielNo"/>\n        <Target name="GumoHideout"/>\n        <Requirements>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="BlackrootMap">\n    <Locations>\n      <Location>\n        <X>346</X>\n        <Y>-255</Y>\n        <Item>MS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="BlackrootGrottoConnection">\n    <Locations>\n      <Location>\n        <X>394</X>\n        <Y>-309</Y>\n        <Item>HC</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="BlackrootGrottoConnection"/>\n        <Target name="SideFallCell"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="BlackrootGrottoConnection"/>\n        <Target name="BlackrootMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="BlackrootMapStone">\n    <Locations>\n      <Location>\n        <X>418</X>\n        <Y>-291</Y>\n        <Item>MapStone</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="BoulderExp">\n    <Locations>\n      <Location>\n        <X>432</X>\n        <Y>-324</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LowerBlackRoot">\n    <Locations>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="LowerBlackRoot"/>\n        <Target name="LowerBlackRootCell"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerBlackRoot"/>\n        <Target name="FarRightBlackRoot"/>\n        <Requirements>\n          <Requirement mode="speed">Dash+DoubleJump</Requirement>\n          <Requirement mode="normal">Dash+Grenade+Bash</Requirement>\n          <Requirement mode="extended">DoubleJump</Requirement>\n          <Requirement mode="extended">Grenade+Bash</Requirement>\n          <!-- for extended mode, this and the right blackroot connection can be done without dash, using a laser crouch -->\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerBlackRoot"/>\n        <Target name="RightBlackRoot"/>\n        <Requirements>\n          <Requirement mode="normal">Dash</Requirement>\n          <Requirement mode="extended">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerBlackRoot"/>\n        <Target name="LeftBlackRoot"/>\n        <Requirements>\n          <Requirement mode="speed">ChargeJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n           <Requirement mode="timed-level">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerBlackRoot"/>\n        <Target name="BottomBlackRoot"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerBlackRoot"/>\n        <Target name="GrenadeArea"/>\n        <Requirements>\n          <Requirement mode="normal">Dash</Requirement>\n          <Requirement mode="extended">ChargeJump+Climb+Grenade</Requirement>\n          <Requirement mode="extended">Bash+Grenade</Requirement>\n          <Requirement mode="extended">DoubleJump</Requirement>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="GrenadeArea">\n    <Locations>\n      <Location>\n        <X>72</X>\n        <Y>-380</Y>\n        <Item>SKGrenade</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="GrenadeArea"/>\n        <Target name="RightGrenadeArea"/>\n        <Requirements>\n          <Requirement mode="normal">Bash</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">DoubleJump</Requirement>\n          <Requirement mode="normal">Glide</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GrenadeArea"/>\n        <Target name="UpperGrenadeArea"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n          <Requirement mode="normal">Grenade+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="RightGrenadeArea">\n    <Locations>\n      <Location>\n        <X>224</X>\n        <Y>-359</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="UpperGrenadeArea">\n    <Locations>\n      <Location>\n        <X>252</X>\n        <Y>-331</Y>\n        <Item>AC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LowerBlackRootCell">\n    <Locations>\n      <Location>\n        <X>279</X>\n        <Y>-375</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="FarRightBlackRoot">\n    <Locations>\n      <Location>\n        <X>391</X>\n        <Y>-423</Y>\n        <Item>AC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightBlackRoot">\n    <Locations>\n      <Location>\n        <X>339</X>\n        <Y>-418</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LeftBlackRoot">\n    <Locations>\n      <Location>\n        <X>208</X>\n        <Y>-431</Y>\n        <Item>AC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="BottomBlackRoot">\n    <Locations>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="BottomBlackRoot"/>\n        <Target name="FinalBlackRoot"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="extended-damage">Grenade+ChargeJump+Dash+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">Grenade+ChargeJump+Glide+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">Grenade+ChargeJump+DoubleJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="BottomBlackRoot"/>\n        <Target name="BlackRootWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost-hard">HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">HC+HC+HC+HC+HC+HC</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="FinalBlackRoot">\n    <Locations>\n      <Location>\n        <X>459</X>\n        <Y>-506</Y>\n        <Item>AC</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n      <Location>\n        <X>462</X>\n        <Y>-489</Y>\n        <Item>EX100</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n      <Location>\n        <X>307</X>\n        <Y>-525</Y>\n        <Item>EX100</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="BlackRootWater">\n    <Locations>\n      <Location>\n        <X>527</X>\n        <Y>-544</Y>\n        <Item>AC</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Blackroot</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="HollowGrove">\n    <Locations>\n      <Location>\n        <X>300</X>\n        <Y>-94</Y>\n        <Item>MS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="MoonGrotto"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">Climb</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="DeathGauntlet"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">Climb</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="DeathGauntletRoof"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">WallJump+Stomp+Water</Requirement>\n          <Requirement mode="normal">Climb+Stomp+Water</Requirement>\n          <Requirement mode="normal">Bash+Stomp+Water</Requirement>\n          <Requirement mode="dboost">Stomp+Bash+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost">WallJump+Stomp+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost">Climb+Stomp+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">WallJump+Stomp</Requirement>\n          <Requirement mode="extreme">Climb+Stomp</Requirement>\n          <Requirement mode="extreme">WallJump+Bash</Requirement>\n          <Requirement mode="extreme">Climb+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="SpiderSac"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+Bash</Requirement>\n          <Requirement mode="normal">Climb+Bash</Requirement>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Climb+DoubleJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="GroveWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost">HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost">HC+HC+HC+HC+HC+Bash</Requirement>\n          <Requirement mode="extreme">Bash</Requirement>\n          <Requirement mode="extreme">HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="UpperGroveSpiderArea"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+WallJump</Requirement>\n          <Requirement mode="normal">ChargeJump+WallJump+DoubleJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="LeftGinsoCell"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+DoubleJump+Glide</Requirement>\n          <Requirement mode="normal">Wind+Glide</Requirement>\n          <Requirement mode="extended">Grenade+Bash</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="GroveWaterStomp"/>\n        <Requirements>\n          <Requirement mode="normal">Water+Stomp</Requirement>\n          <Requirement mode="dboost">Stomp+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="lure-hard">Bash+Water</Requirement>\n          <Requirement mode="lure-hard">Bash+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">Stomp</Requirement>\n          <Requirement mode="extreme">Bash</Requirement>\n          <Requirement mode="glitched">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="RightGinsoOrb"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade+WallJump</Requirement>\n          <Requirement mode="normal">Grenade+Climb</Requirement>\n          <Requirement mode="normal">Grenade+ChargeJump</Requirement>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="LowerGinsoTree"/>\n        <Requirements>\n          <Requirement mode="normal">GinsoKey+WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">GinsoKey+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="HoruFields"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+DoubleJump</Requirement>\n          <Requirement mode="normal">Bash+Glide</Requirement>\n          <Requirement mode="normal">Stomp+ChargeJump+Glide+WallJump</Requirement>\n          <Requirement mode="normal">Stomp+ChargeJump+Glide+Climb</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="HoruFieldsStomp"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n          <Requirement mode="lure">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="HollowGroveMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="HollowGrovePlants"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash-farming">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HollowGrove"/>\n        <Target name="HollowGroveTree"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Wind+Glide</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="lure">Bash+WallJump</Requirement>\n          <Requirement mode="lure">Bash+Climb</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="MoonGrotto">\n    <Locations>\n      <Location>\n        <X>423</X>\n        <Y>-169</Y>\n        <Item>EC</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>703</X>\n        <Y>-82</Y>\n        <Item>AC</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n      <Location>\n        <X>618</X>\n        <Y>-98</Y>\n        <Item>EX100</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="HollowGrove"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Climb+DoubleJump</Requirement>\n          <Requirement mode="normal">Grenade+Bash</Requirement>\n          <Requirement mode="extended">WallJump</Requirement>\n          <Requirement mode="extended">Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="DeathGauntlet"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="UpperGrottoOrbs"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="extreme">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="UpperGrotto200"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Climb+DoubleJump+ChargeJump</Requirement>\n          <Requirement mode="extended">Grenade+Bash</Requirement>\n          <Requirement mode="dboost">ChargeJump</Requirement>\n          <Requirement mode="extreme">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="MortarCell"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash</Requirement>\n          <Requirement mode="extreme">WallJump+DoubleJump</Requirement>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="SwampGrottoWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="Swamp"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp+ChargeJump</Requirement>\n          <Requirement mode="normal">ChargeJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+Grenade</Requirement>\n          <Requirement mode="lure">Bash+ChargeFlame+Water</Requirement>\n          <Requirement mode="lure">Bash+Grenade+Water</Requirement>\n          <Requirement mode="lure">Bash+Climb</Requirement>\n          <Requirement mode="lure">Bash+WallJump</Requirement>\n          <Requirement mode="lure">Bash+Grenade</Requirement>\n          <Requirement mode="lure">Bash+ChargeJump</Requirement>\n          <Requirement mode="extended">ChargeJump+Climb</Requirement>\n          <Requirement mode="extended">DoubleJump+ChargeFlame+Dash+Water</Requirement>\n          <Requirement mode="extended">DoubleJump+ChargeFlame+Glide+Water</Requirement>\n          <Requirement mode="extended-damage">DoubleJump+ChargeFlame+Water+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">Dash+Stomp+ChargeFlame+Water+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost-hard">DoubleJump+ChargeFlame+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost-hard">Stomp+ChargeFlame+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">DoubleJump+ChargeFlame+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">Stomp+ChargeFlame+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="glitched">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="DrainExp"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade+Climb+ChargeJump</Requirement>\n          <Requirement mode="speed">Grenade+Bash</Requirement>\n          <Requirement mode="extended-damage">ChargeFlame+Climb+ChargeJump</Requirement>\n          <Requirement mode="extended-damage">ChargeFlame+DoubleJump</Requirement>\n          <Requirement mode="dbash">ChargeFlame+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="SwampEnergy"/>\n        <Requirements>\n          <Requirement mode="glitched">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="DrainlessCell"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n          <Requirement mode="extended">ChargeJump+Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="RightGrottoHealth"/>\n        <Requirements>\n          <Requirement mode="normal">DoubleJump+Bash</Requirement>\n          <Requirement mode="normal">DoubleJump+ChargeJump</Requirement>\n          <Requirement mode="normal">Glide+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="MoonGrottoEnergyWater"/>\n        <Requirements>\n          <Requirement mode="normal">EC+EC+Water</Requirement>\n          <Requirement mode="dboost">EC+EC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="MoonGrottoEnergyTop"/>\n        <Requirements>\n          <Requirement mode="normal">EC+EC+ChargeJump</Requirement>\n          <Requirement mode="normal">EC+EC+WallJump+DoubleJump</Requirement>\n          <Requirement mode="speed">EC+EC+WallJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="GumoHideout"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="MoonGrottoAirOrb"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="SwampPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="MoonGrottoStompPlant"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp+ChargeFlame</Requirement>\n          <Requirement mode="normal">Stomp+Grenade</Requirement>\n          <Requirement mode="cdash">Stomp+Dash</Requirement>\n          <Requirement mode="extended">ChargeFlame</Requirement>\n          <Requirement mode="extreme">Bash+Grenade</Requirement>\n          <Requirement mode="extreme">Bash+Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="SwampMortarPlant"/>\n        <Requirements>\n          <Requirement mode="normal">DoubleJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">DoubleJump+Grenade</Requirement>\n          <Requirement mode="normal">ChargeJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+Grenade</Requirement>\n          <Requirement mode="normal">Bash+ChargeFlame</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="normal">Glide+ChargeFlame</Requirement>\n          <Requirement mode="normal">Glide+Grenade</Requirement>\n          <Requirement mode="speed">Dash+ChargeFlame</Requirement>\n          <Requirement mode="speed">Dash+Grenade</Requirement>\n          <Requirement mode="extended">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MoonGrotto"/>\n        <Target name="DeathGauntletRoofPlant"/>\n        <Requirements>\n          <Requirement mode="extended">ChargeFlame+DoubleJump</Requirement>\n          <Requirement mode="extended">ChargeFlame+Bash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="HollowGroveMapStone">\n    <Locations>\n      <Location>\n        <X>351</X>\n        <Y>-119</Y>\n        <Item>MapStone</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="HollowGroveTree">\n    <Locations>\n      <Location>\n        <X>333</X>\n        <Y>-61</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="HollowGrovePlants">\n    <Locations>\n      <Location>\n        <X>365</X>\n        <Y>-119</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n      <Location>\n        <X>330</X>\n        <Y>-78</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SwampPlant">\n    <Locations>\n      <Location>\n        <X>628</X>\n        <Y>-120</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MoonGrottoStompPlant">\n    <Locations>\n      <Location>\n        <X>435</X>\n        <Y>-140</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SwampMortarPlant">\n    <Locations>\n      <Location>\n        <X>515</X>\n        <Y>-100</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="GroveWaterStomp">\n    <Locations>\n      <Location>\n        <X>354</X>\n        <Y>-178</Y>\n        <Item>AC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightGinsoOrb">\n    <Locations>\n      <Location>\n        <X>666</X>\n        <Y>-48</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LeftGinsoCell">\n    <Locations>\n      <Location>\n        <X>409</X>\n        <Y>-34</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="UpperGroveSpiderArea">\n    <Locations>\n      <Location>\n        <X>174</X>\n        <Y>-105</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n      <Location>\n        <X>261</X>\n        <Y>-117</Y>\n        <Item>HC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="UpperGroveSpiderArea"/>\n        <Target name="UpperGroveSpiderEnergy"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="UpperGroveSpiderEnergy">\n    <Locations>\n      <Location>\n        <X>272</X>\n        <Y>-97</Y>\n        <Item>EC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="GroveWater">\n    <Locations>\n      <Location>\n        <X>187</X>\n        <Y>-163</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DeathWater">\n    <Locations>\n      <Location>\n        <X>339</X>\n        <Y>-216</Y>\n        <Item>AC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DeathStomp">\n    <Locations>\n      <Location>\n        <X>356</X>\n        <Y>-207</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="UpperGrottoOrbs">\n    <Locations>\n      <Location>\n        <X>477</X>\n        <Y>-140</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>432</X>\n        <Y>-108</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>365</X>\n        <Y>-109</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n      <Location>\n        <X>581</X>\n        <Y>-67</Y>\n        <Item>HC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="UpperGrottoOrbs"/>\n        <Target name="UpperGrottoOrbsPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="UpperGrottoOrbsPlant">\n    <Locations>\n      <Location>\n        <X>540</X>\n        <Y>-220</Y>\n        <Item>Plant</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="UpperGrotto200">\n    <Locations>\n      <Location>\n        <X>449</X>\n        <Y>-166</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MortarCell">\n    <Locations>\n      <Location>\n        <X>502</X>\n        <Y>-108</Y>\n        <Item>AC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SwampGrottoWater">\n    <Locations>\n      <Location>\n        <X>595</X>\n        <Y>-136</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightGrottoHealth">\n    <Locations>\n      <Location>\n        <X>543</X>\n        <Y>-189</Y>\n        <Item>HC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MoonGrottoEnergyWater">\n    <Locations>\n      <Location>\n        <X>423</X>\n        <Y>-274</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MoonGrottoEnergyTop">\n    <Locations>\n      <Location>\n        <X>424</X>\n        <Y>-220</Y>\n        <Item>HC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MoonGrottoAirOrb">\n    <Locations>\n      <Location>\n        <X>552</X>\n        <Y>-141</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="MoonGrottoAirOrb"/>\n        <Target name="MoonGrottoAirOrbPlant"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp+ChargeFlame+WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Stomp+ChargeFlame+ChargeJump+Glide</Requirement>\n          <Requirement mode="normal">Stomp+ChargeFlame+ChargeJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Stomp+ChargeFlame+ChargeJump+Climb</Requirement>\n          <Requirement mode="normal">Stomp+Grenade</Requirement>\n          <Requirement mode="extended">Grenade</Requirement>\n          <Requirement mode="extended">ChargeFlame+Bash</Requirement>\n          <Requirement mode="extended-damage">ChargeFlame+WallJump+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">ChargeFlame+ChargeJump+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">ChargeFlame+DoubleJump+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">ChargeFlame+Glide+HC+HC+HC+HC</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="MoonGrottoAirOrbPlant">\n    <Locations>\n      <Location>\n        <X>537</X>\n        <Y>-176</Y>\n        <Item>Plant</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SideFallCell">\n    <Locations>\n      <Location>\n        <X>451</X>\n        <Y>-296</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="SideFallCell"/>\n        <Target name="GumoHideout"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SideFallCell"/>\n        <Target name="GumoHideoutPartialMobile"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="SideFallCell"/>\n        <Target name="GumoHideoutRedirectAC"/>\n        <Requirements>\n          <Requirement mode="dboost-light">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="GumoHideout">\n    <Locations>\n      <Location>\n        <X>513</X>\n        <Y>-413</Y>\n        <Item>MS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>620</X>\n        <Y>-404</Y>\n        <Item>KS</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>572</X>\n        <Y>-378</Y>\n        <Item>EX100</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>590</X>\n        <Y>-384</Y>\n        <Item>KS</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="GumoHideout"/>\n        <Target name="DoubleJumpArea"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+WallJump</Requirement>\n          <Requirement mode="dboost-light">KS+KS+Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideout"/>\n        <Target name="MobileGumoHideout"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Climb+ChargeJump</Requirement>\n          <Requirement mode="normal">WallJump+ChargeJump</Requirement>\n          <Requirement mode="extreme">WallJump+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideout"/>\n        <Target name="GumoHideoutPartialMobile"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Climb+ChargeJump</Requirement>\n          <Requirement mode="normal">WallJump+ChargeJump</Requirement>\n          <Requirement mode="normal">Glide+Wind</Requirement>\n          <Requirement mode="extreme">WallJump+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideout"/>\n        <Target name="GumoHideoutRedirectAC"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Climb+ChargeJump</Requirement>\n          <Requirement mode="normal">WallJump+ChargeJump</Requirement>\n          <Requirement mode="normal">Glide+Wind</Requirement>\n          <Requirement mode="extreme">WallJump+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideout"/>\n        <Target name="GumoHideoutMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideout"/>\n        <Target name="LowerBlackRoot"/>\n        <Requirements>\n          <Requirement mode="glitched">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideout"/>\n        <Target name="SideFallCell"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="normal">Glide+Wind</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="GumoHideoutPartialMobile">\n    <Locations>\n      <Location>\n        <X>496</X>\n        <Y>-369</Y>\n        <Item>EX15</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>467</X>\n        <Y>-369</Y>\n        <Item>EX15</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="GumoHideoutPartialMobile"/>\n        <Target name="MobileGumoHideoutPlants"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideoutPartialMobile"/>\n        <Target name="GumoHideoutWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideoutPartialMobile"/>\n        <Target name="HideoutRedirect"/>\n        <Requirements>\n          <Requirement mode="normal">EC+EC+EC+EC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="GumoHideoutPartialMobile"/>\n        <Target name="GumoHideoutRedirectAC"/>\n        <Requirements>\n          <Requirement mode="dboost-light">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="GumoHideoutRedirectAC">\n    <Locations>\n      <Location>\n        <X>449</X>\n        <Y>-430</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="GumoHideoutMapStone">\n    <Locations>\n      <Location>\n        <X>477</X>\n        <Y>-389</Y>\n        <Item>MapStone</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DoubleJumpArea">\n    <Locations>\n      <Location>\n        <X>784</X>\n        <Y>-412</Y>\n        <Item>SKDoubleJump</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="DoubleJumpArea"/>\n        <Target name="MobileDoubleJumpArea"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash</Requirement>\n          <Requirement mode="normal">Climb+DoubleJump</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="MobileDoubleJumpArea">\n    <Locations>\n      <Location>\n        <X>759</X>\n        <Y>-398</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MobileGumoHideout">\n    <Locations>\n      <Location>\n        <X>545</X>\n        <Y>-357</Y>\n        <Item>EC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>567</X>\n        <Y>-246</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>0</X>\n        <Y>0</Y>\n        <Item>EVGinsoKey</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>406</X>\n        <Y>-386</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>393</X>\n        <Y>-375</Y>\n        <Item>HC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>328</X>\n        <Y>-353</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="MobileGumoHideout"/>\n        <Target name="MoonGrotto"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MobileGumoHideout"/>\n        <Target name="GumoHideoutWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MobileGumoHideout"/>\n        <Target name="HideoutRedirect"/>\n        <Requirements>\n          <Requirement mode="normal">EC+EC+EC+EC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MobileGumoHideout"/>\n        <Target name="MobileGumoHideoutPlants"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="MobileGumoHideoutPlants">\n    <Locations>\n      <Location>\n        <X>447</X>\n        <Y>-368</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>439</X>\n        <Y>-344</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>492</X>\n        <Y>-400</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="GumoHideoutWater">\n    <Locations>\n      <Location>\n        <X>397</X>\n        <Y>-411</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="HideoutRedirect">\n    <Locations>\n      <Location>\n        <X>515</X>\n        <Y>-441</Y>\n        <Item>EC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n      <Location>\n        <X>505</X>\n        <Y>-439</Y>\n        <Item>EX200</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grotto</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DrainlessCell">\n    <Locations>\n      <Location>\n        <X>643</X>\n        <Y>-127</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DeathGauntletRoof">\n    <Locations>\n      <Location>\n        <X>321</X>\n        <Y>-179</Y>\n        <Item>HC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="DeathGauntletRoof"/>\n        <Target name="DeathGauntlet"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="DeathGauntletRoof"/>\n        <Target name="DeathGauntletRoofPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="DeathGauntletRoofPlant">\n    <Locations>\n      <Location>\n        <X>342</X>\n        <Y>-179</Y>\n        <Item>Plant</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LowerGinsoTree">\n    <Locations>\n      <Location>\n        <X>523</X>\n        <Y>142</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>531</X>\n        <Y>267</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>540</X>\n        <Y>277</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>508</X>\n        <Y>304</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>529</X>\n        <Y>297</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="LowerGinsoTree"/>\n        <Target name="BashTree"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+KS+KS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerGinsoTree"/>\n        <Target name="LowerGinsoTreePlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerGinsoTree"/>\n        <Target name="Horu"/>\n        <Requirements>\n          <Requirement mode="glitched">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="LowerGinsoTreePlant">\n    <Locations>\n      <Location>\n        <X>540</X>\n        <Y>101</Y>\n        <Item>Plant</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="BashTree">\n    <Locations>\n      <Location>\n        <X>532</X>\n        <Y>328</Y>\n        <Item>SKBash</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="BashTree"/>\n        <Target name="UpperGinsoTree"/>\n        <Requirements>\n          <Requirement mode="normal">Bash</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="UpperGinsoTree">\n    <Locations>\n      <Location>\n        <X>518</X>\n        <Y>339</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>507</X>\n        <Y>476</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>535</X>\n        <Y>488</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>531</X>\n        <Y>502</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>508</X>\n        <Y>498</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="UpperGinsoTree"/>\n        <Target name="TopGinsoTree"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+KS+KS+Bash+WallJump</Requirement>\n          <Requirement mode="normal">KS+KS+KS+KS+Bash+Climb</Requirement>\n          <Requirement mode="normal">KS+KS+KS+KS+Bash+ChargeJump</Requirement>\n          <Requirement mode="dboost">KS+KS+KS+KS+ChargeJump+WallJump+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost">KS+KS+KS+KS+ChargeJump+Climb+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">KS+KS+KS+KS+ChargeJump+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">KS+KS+KS+KS+ChargeJump+DoubleJump</Requirement>\n          <Requirement mode="extreme">WallJump+DoubleJump+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <!-- this can be reached with chargejump only due to a micro ledge-->\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="UpperGinsoTree"/>\n        <Target name="UpperGinsoFloors"/>\n        <Requirements>\n          <Requirement mode="normal">Bash</Requirement>\n          <Requirement mode="normal">Stomp</Requirement>\n          <Requirement mode="extended">ChargeFlame</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="UpperGinsoFloors">\n    <Locations>\n      <Location>\n        <X>517</X>\n        <Y>384</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>530</X>\n        <Y>407</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>536</X>\n        <Y>434</Y>\n        <Item>EC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="TopGinsoTree">\n    <Locations>\n      <Location>\n        <X>456</X>\n        <Y>566</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>471</X>\n        <Y>614</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="TopGinsoTree"/>\n        <Target name="GinsoEscape"/>\n        <Requirements>\n          <Requirement mode="normal">Bash</Requirement>\n          <Requirement mode="speed">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="TopGinsoTree"/>\n        <Target name="TopGinsoTreePlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="TopGinsoTreePlant">\n    <Locations>\n      <Location>\n        <X>610</X>\n        <Y>611</Y>\n        <Item>Plant</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="GinsoEscape">\n    <Locations>\n      <Location>\n        <X>534</X>\n        <Y>661</Y>\n        <Item>EX200</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>537</X>\n        <Y>733</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>533</X>\n        <Y>827</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>519</X>\n        <Y>867</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n      <Location>\n        <X>0</X>\n        <Y>4</Y>\n        <Item>EVWater</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Ginso</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="Swamp">\n    <Locations>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="Swamp"/>\n        <Target name="DrainlessCell"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n          <Requirement mode="extended">ChargeJump+Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Swamp"/>\n        <Target name="SwampWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="extreme">HC+HC+HC+HC+HC+HC+HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Swamp"/>\n        <Target name="DrainExp"/>\n        <Requirements>\n          <Requirement mode="normal">Water+Climb+ChargeJump</Requirement>\n          <Requirement mode="normal">Water+DoubleJump</Requirement>\n          <Requirement mode="normal">Water+Glide</Requirement>\n          <Requirement mode="normal">Water+Dash</Requirement>\n          <Requirement mode="normal">Water+Bash+Grenade</Requirement>\n          <Requirement mode="dbash">Water+Bash</Requirement>\n          <Requirement mode="extreme">HC+HC+HC+HC+HC+HC+HC+Climb+ChargeJump</Requirement>\n          <Requirement mode="extreme">HC+HC+HC+HC+HC+HC+HC+DoubleJump</Requirement>\n          <Requirement mode="extreme">HC+HC+HC+HC+HC+HC+HC+Glide</Requirement>\n          <Requirement mode="extreme">HC+HC+HC+HC+HC+HC+HC+Dash</Requirement>\n          <Requirement mode="extreme">HC+HC+HC+HC+HC+HC+HC+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Swamp"/>\n        <Target name="SwampStomp"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n          <Requirement mode="extended">Climb+ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Swamp"/>\n        <Target name="SwampEnergy"/>\n        <Requirements>\n          <Requirement mode="normal">Wind+Glide</Requirement>\n          <Requirement mode="normal">ChargeJump+Climb+Glide</Requirement>\n          <Requirement mode="normal">ChargeJump+Climb+DoubleJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n          <!-- dbash here requires dboosting, but only 2 if done right -->\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Swamp"/>\n        <Target name="RightSwamp"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+WallJump</Requirement>\n          <Requirement mode="normal">KS+KS+Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Swamp"/>\n        <Target name="SwampMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="SwampMapStone">\n    <Locations>\n      <Location>\n        <X>677</X>\n        <Y>-129</Y>\n        <Item>MapStone</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DrainExp">\n    <Locations>\n      <Location>\n        <X>636</X>\n        <Y>-162</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SwampWater">\n    <Locations>\n      <Location>\n        <X>761</X>\n        <Y>-173</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n      <Location>\n        <X>684</X>\n        <Y>-205</Y>\n        <Item>KS</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n      <Location>\n        <X>766</X>\n        <Y>-183</Y>\n        <Item>KS</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n      <Location>\n        <X>796</X>\n        <Y>-210</Y>\n        <Item>MS</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SwampStomp">\n    <Locations>\n      <Location>\n        <X>770</X>\n        <Y>-148</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SwampEnergy">\n    <Locations>\n      <Location>\n        <X>722</X>\n        <Y>-95</Y>\n        <Item>EC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightSwamp">\n    <Locations>\n      <Location>\n        <X>860</X>\n        <Y>-96</Y>\n        <Item>SKStomp</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="RightSwamp"/>\n        <Target name="RightSwampStomp"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n          <Requirement mode="normal">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="RightSwamp"/>\n        <Target name="RightSwampCJump"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="RightSwamp"/>\n        <Target name="RightSwampGrenade"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade+Water</Requirement>\n          <Requirement mode="dboost">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="RightSwampCJump">\n    <Locations>\n      <Location>\n        <X>914</X>\n        <Y>-71</Y>\n        <Item>EX200</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightSwampStomp">\n    <Locations>\n      <Location>\n        <X>884</X>\n        <Y>-98</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightSwampGrenade">\n    <Locations>\n      <Location>\n        <X>874</X>\n        <Y>-143</Y>\n        <Item>EX200</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Swamp</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="HoruFields">\n    <Locations>\n      <Location>\n        <X>97</X>\n        <Y>-37</Y>\n        <Item>EX200</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n      <Location>\n        <X>176</X>\n        <Y>-34</Y>\n        <Item>AC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="HoruFields"/>\n        <Target name="HoruFieldsEnergy"/>\n        <Requirements>\n          <Requirement mode="normal">Bash</Requirement>\n          <Requirement mode="normal">DoubleJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HoruFields"/>\n        <Target name="Horu"/>\n        <Requirements>\n          <Requirement mode="normal">HoruKey+Bash+DoubleJump+Glide+WallJump</Requirement>\n          <Requirement mode="normal">HoruKey+Bash+DoubleJump+ChargeJump+WallJump</Requirement>\n          <Requirement mode="normal">HoruKey+Bash+Glide+ChargeJump+WallJump</Requirement>\n          <Requirement mode="normal">HoruKey+Bash+DoubleJump+Glide+Climb</Requirement>\n          <Requirement mode="normal">HoruKey+Bash+DoubleJump+ChargeJump+Climb</Requirement>\n          <Requirement mode="normal">HoruKey+Bash+Glide+ChargeJump+Climb</Requirement>\n          <Requirement mode="extended">HoruKey+Bash+Grenade+WallJump</Requirement>\n          <Requirement mode="extended">HoruKey+Bash+Grenade+Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HoruFields"/>\n        <Target name="DoorWarp"/>\n        <Requirements>\n          <Requirement mode="extended">HoruKey</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="HoruFieldsEnergy">\n    <Locations>\n      <Location>\n        <X>175</X>\n        <Y>1</Y>\n        <Item>EC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="HoruFieldsEnergy"/>\n        <Target name="HoruFieldsEnergyPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="HoruFieldsEnergyPlant">\n    <Locations>\n      <Location>\n        <X>124</X>\n        <Y>21</Y>\n        <Item>Plant</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="HoruFieldsStomp">\n    <Locations>\n      <Location>\n        <X>160</X>\n        <Y>-78</Y>\n        <Item>HC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Grove</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="Horu">\n    <Locations>\n      <Location>\n        <X>193</X>\n        <Y>384</Y>\n        <Item>EX100</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>148</X>\n        <Y>363</Y>\n        <Item>MS</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>249</X>\n        <Y>403</Y>\n        <Item>EC</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="Horu"/>\n        <Target name="HoruStomp"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Horu"/>\n        <Target name="HoruMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Horu"/>\n        <Target name="LowerGinsoTree"/>\n        <Requirements>\n          <Requirement mode="glitched">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="HoruMapStone">\n    <Locations>\n      <Location>\n        <X>56</X>\n        <Y>343</Y>\n        <Item>MapStone</Item>\n        <Difficulty>6</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="HoruStomp">\n    <Locations>\n      <Location>\n        <X>191</X>\n        <Y>165</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>253</X>\n        <Y>194</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>163</X>\n        <Y>136</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>-191</X>\n        <Y>194</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>-29</X>\n        <Y>148</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>13</X>\n        <Y>164</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>129</X>\n        <Y>165</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n      <Location>\n        <X>98</X>\n        <Y>130</Y>\n        <Item>EX200</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="HoruStomp"/>\n        <Target name="HoruStompPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HoruStomp"/>\n        <Target name="End"/>\n        <Requirements>\n          <Requirement mode="normal">Climb+Dash+Stomp+Glide+Bash+ChargeJump+Grenade+GinsoKey+ForlornKey+HoruKey</Requirement>\n          <Requirement mode="extended">Dash+Stomp+Glide+Bash+ChargeJump+Grenade+GinsoKey+ForlornKey+HoruKey</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="HoruStomp"/>\n        <Target name="DoorWarp"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="HoruStompPlant">\n    <Locations>\n      <Location>\n        <X>318</X>\n        <Y>245</Y>\n        <Item>Plant</Item>\n        <Difficulty>7</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="DoorWarp">\n    <Locations>\n      <Location>\n        <X>106</X>\n        <Y>112</Y>\n        <Item>EX200</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>  \n  <Area name="End">\n    <Locations>\n      <Location>\n        <X>0</X>\n        <Y>20</Y>\n        <Item>EVWarmth</Item>\n        <Difficulty>0</Difficulty>\n        <Zone>Horu</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ValleyEntry">\n    <Locations>\n      <Location>\n        <X>-205</X>\n        <Y>-113</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="ValleyEntry"/>\n        <Target name="ValleyEntryTree"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">Bash+Climb</Requirement>\n          <Requirement mode="normal">DoubleJump+Climb</Requirement>\n          <Requirement mode="normal">ChargeJump+Climb</Requirement>\n          <Requirement mode="lure">Bash</Requirement>\n          <Requirement mode="dboost">ChargeJump+HC+HC+HC+HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyEntry"/>\n        <Target name="ValleyRight"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp+Bash+WallJump</Requirement>\n          <Requirement mode="normal">Stomp+Bash+DoubleJump</Requirement>\n          <Requirement mode="normal">Stomp+Bash+Climb+ChargeJump</Requirement>\n          <Requirement mode="normal">Stomp+Bash+Grenade</Requirement>\n          <Requirement mode="extended">Bash+DoubleJump</Requirement>\n          <Requirement mode="extended">Bash+Climb+ChargeJump</Requirement>\n          <Requirement mode="extended">Bash+WallJump</Requirement>\n          <Requirement mode="extended">Bash+Grenade</Requirement>\n          <Requirement mode="extended-damage">Stomp+ChargeJump+DoubleJump+WallJump+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n          <Requirement mode="extreme">Stomp+WallJump+DoubleJump+ChargeJump</Requirement>\n          <Requirement mode="extreme">Stomp+WallJump+DoubleJump+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyEntry"/>\n        <Target name="ValleyEntryTreePlant"/>\n        <Requirements>\n          <Requirement mode="extended">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyEntry"/>\n        <Target name="ValleyWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water+Stomp+WallJump+DoubleJump</Requirement>\n          <Requirement mode="normal">Water+Stomp+WallJump+Bash</Requirement>\n          <Requirement mode="normal">Water+Stomp+WallJump+ChargeJump</Requirement>\n          <Requirement mode="normal">Water+Stomp+Climb+ChargeJump</Requirement>\n          <Requirement mode="normal">Water+Stomp+Climb+DoubleJump</Requirement>\n          <Requirement mode="dboost">Stomp+WallJump+DoubleJump</Requirement>\n          <Requirement mode="dboost">Stomp+WallJump+Bash</Requirement>\n          <Requirement mode="dboost">Stomp+WallJump+ChargeJump</Requirement>\n          <Requirement mode="dboost">Stomp+Climb+ChargeJump</Requirement>\n          <Requirement mode="dboost">Stomp+Climb+DoubleJump</Requirement>\n          <Requirement mode="extended">Bash+Water</Requirement>\n          <Requirement mode="extended-damage">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyEntry"/>\n        <Target name="SpiritTreeRefined"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="ValleyEntryTree">\n    <Locations>\n      <Location>\n        <X>-221</X>\n        <Y>-84</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="ValleyEntryTree"/>\n        <Target name="ValleyGrenadeWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water+Grenade</Requirement>\n          <Requirement mode="dboost-hard">Grenade+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost-hard">Grenade+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC+Bash</Requirement>\n          <Requirement mode="extreme">Grenade+HC+HC+HC+HC+HC+HC+HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyEntryTree"/>\n        <Target name="ValleyEntryTreePlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+Climb+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+Climb+Grenade</Requirement>\n          <Requirement mode="normal">ChargeJump+DoubleJump+ChargeFlame</Requirement>\n          <Requirement mode="normal">ChargeJump+DoubleJump+Grenade</Requirement>\n          <Requirement mode="normal">Bash+ChargeFlame</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n          <Requirement mode="normal">Glide+ChargeFlame</Requirement>\n          <Requirement mode="normal">Glide+Grenade</Requirement>\n          <Requirement mode="cdash-farming">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="ValleyEntryTreePlant">\n    <Locations>\n      <Location>\n        <X>-179</X>\n        <Y>-88</Y>\n        <Item>Plant</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ValleyGrenadeWater">\n    <Locations>\n      <Location>\n        <X>-320</X>\n        <Y>-162</Y>\n        <Item>EC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ValleyRight">\n    <Locations>\n      <Location>\n        <X>-355</X>\n        <Y>65</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n      <Location>\n        <X>-418</X>\n        <Y>67</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="ValleyRight"/>\n        <Target name="ValleyMain"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+Stomp</Requirement>\n          <Requirement mode="extended">Dash+Bash</Requirement>\n          <Requirement mode="extended">Dash+Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyRight"/>\n        <Target name="BirdStompCell"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+Climb</Requirement>\n          <Requirement mode="speed">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="BirdStompCell">\n    <Locations>\n      <Location>\n        <X>-292</X>\n        <Y>20</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ValleyMain">\n    <Locations>\n      <Location>\n        <X>-460</X>\n        <Y>-20</Y>\n        <Item>SKGlide</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n      <Location>\n        <X>-546</X>\n        <Y>54</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n     <Location>\n        <X>-678</X>\n        <Y>-29</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-822</X>\n        <Y>-9</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="PreSorrowOrb"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="Sorrow"/>\n        <Requirements>\n          <Requirement mode="normal">Wind+Glide</Requirement>\n          <Requirement mode="speed">Glide+DoubleJump+Bash+Dash</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n          <Requirement mode="extended-damage">ChargeJump+DoubleJump+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">ChargeJump+Glide+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extended-damage">ChargeJump+Dash+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">ChargeJump+DoubleJump+HC+HC+HC+HC+HC+HC+HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="Misty"/>\n        <Requirements>\n          <Requirement mode="normal">Glide</Requirement>\n          <Requirement mode="dboost">DoubleJump+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">DoubleJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="Forlorn"/>\n        <Requirements>\n          <Requirement mode="normal">ForlornKey</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="RightForlorn"/>\n        <Requirements>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="OutsideForlornGrenade"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="ValleyMainFACS"/>\n        <Requirements>\n          <Requirement mode="normal">Climb+ChargeJump</Requirement>\n          <Requirement mode="extended">Bash+Glide</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="ValleyMainPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="ValleyMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ValleyMain"/>\n        <Target name="LowerValley"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="ValleyMapStone">\n    <Locations>\n      <Location>\n        <X>-408</X>\n        <Y>-170</Y>\n        <Item>MapStone</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ValleyMainPlant">\n    <Locations>\n      <Location>\n        <X>-468</X>\n        <Y>-67</Y>\n        <Item>Plant</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="PreSorrowOrb">\n    <Locations>\n      <Location>\n        <X>-572</X>\n        <Y>157</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ValleyWater">\n    <Locations>\n      <Location>\n        <X>-359</X>\n        <Y>-87</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ValleyMainFACS">\n    <Locations>\n      <Location>\n        <X>-415</X>\n        <Y>-80</Y>\n        <Item>AC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="OutsideForlornGrenade">\n    <Locations>\n      <Location>\n        <X>-460</X>\n        <Y>-187</Y>\n        <Item>AC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LowerValley">\n    <Locations>\n      <Location>\n        <X>-350</X>\n        <Y>-98</Y>\n        <Item>AC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n      <Location>\n        <X>-561</X>\n        <Y>-89</Y>\n        <Item>MS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n      <Location>\n        <X>-538</X>\n        <Y>-104</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="LowerValley"/>\n        <Target name="ValleyMainFACS"/>\n        <Requirements>\n          <Requirement mode="normal">Climb+ChargeJump</Requirement>\n          <Requirement mode="extended">Bash+Glide</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerValley"/>\n        <Target name="LowerValleyPlantApproach"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+DoubleJump</Requirement>\n          <Requirement mode="normal">Bash+Glide</Requirement>\n          <Requirement mode="normal">ChargeJump+DoubleJump</Requirement>\n          <Requirement mode="normal">ChargeJump+Glide</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LowerValley"/>\n        <Target name="ValleyEntry"/>\n        <Requirements>\n          <Requirement mode="normal">Bash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="LowerValleyPlantApproach">\n    <Locations>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="LowerValleyPlantApproach"/>\n        <Target name="ValleyMainPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>    \n    </Connections>\n  </Area>\n  <Area name="OutsideForlorn">\n    <Locations>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="OutsideForlorn"/>\n        <Target name="OutsideForlornTree"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">Climb</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="OutsideForlorn"/>\n        <Target name="OutsideForlornWater"/>\n        <Requirements>\n          <Requirement mode="normal">Water</Requirement>\n          <Requirement mode="dboost">HC+HC+HC+HC</Requirement>\n          <Requirement mode="dboost">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="OutsideForlorn"/>\n        <Target name="OutsideForlornCliff"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump+ChargeJump</Requirement>\n          <Requirement mode="normal">Climb+ChargeJump</Requirement>\n          <Requirement mode="normal">Bash+Glide</Requirement>\n          <Requirement mode="normal">Bash+DoubleJump</Requirement>\n          <Requirement mode="normal">Bash+Grenade</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="OutsideForlornTree">\n    <Locations>\n      <Location>\n        <X>-460</X>\n        <Y>-255</Y>\n        <Item>EX100</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="OutsideForlornWater">\n    <Locations>\n      <Location>\n        <X>-514</X>\n        <Y>-277</Y>\n        <Item>EX100</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="OutsideForlornCliff">\n    <Locations>\n      <Location>\n        <X>-538</X>\n        <Y>-234</Y>\n        <Item>EX200</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="OutsideForlornCliff"/>\n        <Target name="OutsideForlornGrenade"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+Stomp+Grenade</Requirement>\n          <Requirement mode="extreme">Bash+Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="OutsideForlornCliff"/>\n        <Target name="ValleyMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS+Bash+Stomp</Requirement>\n          <Requirement mode="extreme">MS+Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="OutsideForlornCliff"/>\n        <Target name="OutsideForlornMS"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+Stomp</Requirement>\n          <Requirement mode="extreme">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="OutsideForlornCliff"/>\n        <Target name="LowerValley"/>\n        <Requirements>\n          <Requirement mode="normal">Bash+ChargeJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="OutsideForlornMS">\n    <Locations>\n      <Location>\n        <X>-443</X>\n        <Y>-152</Y>\n        <Item>MS</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Valley</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="Forlorn">\n    <Locations>\n      <Location>\n        <X>-703</X>\n        <Y>-390</Y>\n        <Item>EX200</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n      <Location>\n        <X>-841</X>\n        <Y>-350</Y>\n        <Item>EX100</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n      <Location>\n        <X>-858</X>\n        <Y>-353</Y>\n        <Item>KS</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n      <Location>\n        <X>-892</X>\n        <Y>-328</Y>\n        <Item>KS</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n      <Location>\n        <X>-888</X>\n        <Y>-251</Y>\n        <Item>KS</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n      <Location>\n        <X>-869</X>\n        <Y>-255</Y>\n        <Item>KS</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="Forlorn"/>\n        <Target name="RightForlorn"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+KS+KS+Glide+Stomp+Bash+WallJump</Requirement>\n          <Requirement mode="normal">KS+KS+KS+KS+Glide+Stomp+Bash+Climb</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Forlorn"/>\n        <Target name="ForlornPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Forlorn"/>\n        <Target name="ForlornMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Forlorn"/>\n        <Target name="OutsideForlorn"/>\n        <Requirements>\n          <Requirement mode="normal">WallJump</Requirement>\n          <Requirement mode="normal">Climb</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="ForlornMapStone">\n    <Locations>\n      <Location>\n        <X>-843</X>\n        <Y>-308</Y>\n        <Item>MapStone</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="ForlornPlant">\n    <Locations>\n      <Location>\n        <X>-815</X>\n        <Y>-266</Y>\n        <Item>Plant</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="RightForlorn">\n    <Locations>\n      <Location>\n        <X>-625</X>\n        <Y>-315</Y>\n        <Item>HC</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n      <Location>\n        <X>0</X>\n        <Y>12</Y>\n        <Item>EVWind</Item>\n        <Difficulty>6</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="RightForlorn"/>\n        <Target name="RightForlornPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="RightForlornPlant">\n    <Locations>\n      <Location>\n        <X>-607</X>\n        <Y>-314</Y>\n        <Item>Plant</Item>\n        <Difficulty>6</Difficulty>\n        <Zone>Forlorn</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="Sorrow">\n    <Locations>\n      <Location>\n        <X>-510</X>\n        <Y>204</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-485</X>\n        <Y>323</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-503</X>\n        <Y>274</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-514</X>\n        <Y>303</Y>\n        <Item>KS</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-596</X>\n        <Y>229</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="LeftSorrow"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+KS+KS+Glide</Requirement>\n          <Requirement mode="extreme">KS+KS+KS+KS+Bash</Requirement>\n          <Requirement mode="extreme">KS+KS+KS+KS+ChargeJump+Climb+DoubleJump+HC+HC+HC+HC+HC+HC+HC+HC+HC+HC</Requirement>\n          <Requirement mode="extreme">KS+KS+KS+KS+ChargeJump+Dash+WallJump+DoubleJump+HC</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="SorrowHealth"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="SorrowMapFragment"/>\n        <Requirements>\n          <Requirement mode="normal">Bash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="SorrowMapStone"/>\n        <Requirements>\n          <Requirement mode="normal">MS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="Horu"/>\n        <Requirements>\n          <Requirement mode="glitched">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="ValleyMain"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="ValleyMain"/>\n        <Requirements>\n          <Requirement mode="normal">Stomp</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sorrow"/>\n        <Target name="PreSorrowOrb"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n          <Requirement mode="dbash">Bash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="SorrowMapStone">\n    <Locations>\n      <Location>\n        <X>-451</X>\n        <Y>284</Y>\n        <Item>MapStone</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SorrowMapFragment">\n    <Locations>\n      <Location>\n        <X>-435</X>\n        <Y>322</Y>\n        <Item>MS</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="SorrowHealth">\n    <Locations>\n      <Location>\n        <X>-609</X>\n        <Y>299</Y>\n        <Item>HC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LeftSorrow">\n    <Locations>\n      <Location>\n        <X>-671</X>\n        <Y>289</Y>\n        <Item>AC</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-608</X>\n        <Y>329</Y>\n        <Item>KS</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-612</X>\n        <Y>347</Y>\n        <Item>KS</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-604</X>\n        <Y>361</Y>\n        <Item>KS</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-613</X>\n        <Y>371</Y>\n        <Item>KS</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-627</X>\n        <Y>393</Y>\n        <Item>EC</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="LeftSorrow"/>\n        <Target name="LeftSorrowGrenade"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LeftSorrow"/>\n        <Target name="UpperSorrow"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+KS+KS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="LeftSorrow"/>\n        <Target name="LeftSorrowPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="LeftSorrowPlant">\n    <Locations>\n      <Location>\n        <X>-630</X>\n        <Y>249</Y>\n        <Item>Plant</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="LeftSorrowGrenade">\n    <Locations>\n      <Location>\n        <X>-677</X>\n        <Y>269</Y>\n        <Item>EX200</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="UpperSorrow">\n    <Locations>\n      <Location>\n        <X>-456</X>\n        <Y>419</Y>\n        <Item>KS</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-414</X>\n        <Y>429</Y>\n        <Item>KS</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-514</X>\n        <Y>427</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-545</X>\n        <Y>409</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n      <Location>\n        <X>-592</X>\n        <Y>445</Y>\n        <Item>KS</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="UpperSorrow"/>\n        <Target name="ChargeJump"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+KS+KS</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="UpperSorrow"/>\n        <Target name="Sorrow"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="ChargeJump">\n    <Locations>\n      <Location>\n        <X>-696</X>\n        <Y>408</Y>\n        <Item>SKChargeJump</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="ChargeJump"/>\n        <Target name="Sunstone"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump+Climb</Requirement>\n          <Requirement mode="extended">Bash+Glide</Requirement>\n          <Requirement mode="extended">Bash+Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="ChargeJump"/>\n        <Target name="AboveChargeJump"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="AboveChargeJump">\n    <Locations>\n      <Location>\n        <X>-646</X>\n        <Y>473</Y>\n        <Item>AC</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="Sunstone">\n    <Locations>\n      <Location>\n        <X>0</X>\n        <Y>16</Y>\n        <Item>EVHoruKey</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="Sunstone"/>\n        <Target name="SunstonePlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Sunstone"/>\n        <Target name="UpperSorrow"/>\n        <Requirements>\n          <Requirement mode="normal">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="SunstonePlant">\n    <Locations>\n      <Location>\n        <X>-478</X>\n        <Y>586</Y>\n        <Item>Plant</Item>\n        <Difficulty>4</Difficulty>\n        <Zone>Sorrow</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="Misty">\n    <Locations>\n      <Location>\n        <X>-979</X>\n        <Y>23</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-1075</X>\n        <Y>-2</Y>\n        <Item>AC</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-1082</X>\n        <Y>8</Y>\n        <Item>EX100</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-1009</X>\n        <Y>-35</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-1076</X>\n        <Y>32</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-1188</X>\n        <Y>-100</Y>\n        <Item>SKClimb</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="Misty"/>\n        <Target name="MistyPostClimb"/>\n        <Requirements>\n          <Requirement mode="normal">Climb+DoubleJump</Requirement>\n          <Requirement mode="normal">ChargeJump</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Misty"/>\n        <Target name="MistyPlant"/>\n        <Requirements>\n          <Requirement mode="normal">ChargeFlame</Requirement>\n          <Requirement mode="normal">Grenade</Requirement>\n          <Requirement mode="cdash">Dash</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Misty"/>\n        <Target name="Forlorn"/>\n        <Requirements>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="Misty"/>\n        <Target name="RightForlorn"/>\n        <Requirements>\n          <Requirement mode="glitched">Free</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="MistyPlant">\n    <Locations>\n      <Location>\n        <X>-1102</X>\n        <Y>-67</Y>\n        <Item>Plant</Item>\n        <Difficulty>2</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MistyPostClimb">\n    <Locations>\n      <Location>\n        <X>-837</X>\n        <Y>-123</Y>\n        <Item>EX100</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-796</X>\n        <Y>-144</Y>\n        <Item>EX200</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-912</X>\n        <Y>-36</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n      <Location>\n        <X>-768</X>\n        <Y>-144</Y>\n        <Item>KS</Item>\n        <Difficulty>1</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n      <Connection>\n        <Home name="MistyPostClimb"/>\n        <Target name="MistyEndGrenade"/>\n        <Requirements>\n          <Requirement mode="normal">Grenade</Requirement>\n        </Requirements>\n      </Connection>\n      <Connection>\n        <Home name="MistyPostClimb"/>\n        <Target name="MistyEnd"/>\n        <Requirements>\n          <Requirement mode="normal">KS+KS+KS+KS</Requirement>\n        </Requirements>\n      </Connection>\n    </Connections>\n  </Area>\n  <Area name="MistyEnd">\n    <Locations>\n      <Location>\n        <X>0</X>\n        <Y>8</Y>\n        <Item>EVForlornKey</Item>\n        <Difficulty>3</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n  <Area name="MistyEndGrenade">\n    <Locations>\n      <Location>\n        <X>-671</X>\n        <Y>-39</Y>\n        <Item>EX200</Item>\n        <Difficulty>5</Difficulty>\n        <Zone>Misty</Zone>\n      </Location>\n    </Locations>\n    <Connections>\n    </Connections>\n  </Area>\n</Areas>\n'['$$split']('\n');
		i = 0;
		while ($p['bool'](($p['cmp'](i, $p['len'](lines)) == -1))) {
			match = $m['re']['match']('.*<Area name="(.+)".*', lines.__getitem__(i));
			if ($p['bool'](match)) {
				area = $m['Area'](match['group'](1));
				$m['areaList']['append'](match['group'](1));
				i = $p['__op_add']($add165=i,$add166=1);
				continue;
			}
			match = $m['re']['match']('.*<Location>.*', lines.__getitem__(i));
			if ($p['bool'](match)) {
				loc = $m['Location']($p['float_int']($m['selectText']('<X>', '</X>', lines.__getitem__($p['__op_add']($add167=i,$add168=1)))), $p['float_int']($m['selectText']('<Y>', '</Y>', lines.__getitem__($p['__op_add']($add169=i,$add170=2)))), $p['getattr'](area, '$$name'), $m['selectText']('<Item>', '</Item>', lines.__getitem__($p['__op_add']($add171=i,$add172=3))), $p['float_int']($m['selectText']('<Difficulty>', '</Difficulty>', lines.__getitem__($p['__op_add']($add173=i,$add174=4)))), $m['selectText']('<Zone>', '</Zone>', lines.__getitem__($p['__op_add']($add175=i,$add176=5))));
				i = $p['__op_add']($add177=i,$add178=6);
				if ($p['bool'](!$p['bool'](includePlants))) {
					if ($p['bool']($m['re']['match']('.*Plant.*', $p['getattr'](area, '$$name')))) {
						plants['append'](loc);
						continue;
					}
				}
				area['add_location'](loc);
				continue;
			}
			match = $m['re']['match']('.*<Connection>.*', lines.__getitem__(i));
			if ($p['bool'](match)) {
				connection = $m['Connection']($m['selectText']('"', '"', lines.__getitem__($p['__op_add']($add179=i,$add180=1))), $m['selectText']('"', '"', lines.__getitem__($p['__op_add']($add181=i,$add182=2))));
				i = $p['__op_add']($add183=i,$add184=4);
				if ($p['bool'](!$p['bool'](includePlants))) {
					if ($p['bool']($m['re']['match']('.*Plant.*', $p['getattr'](connection, 'target')))) {
						currentConnection = null;
						continue;
					}
				}
				currentConnection = connection;
				continue;
			}
			match = $m['re']['match']('.*<Requirement mode=.*', lines.__getitem__(i));
			if ($p['bool'](($p['bool']($and15=match)?currentConnection:$and15))) {
				mode = $m['selectText']('"', '"', lines.__getitem__(i));
				if ($p['bool'](modes.__contains__(mode))) {
					currentConnection['add_requirements']($m['selectText']('>', '</Requirement>', lines.__getitem__(i))['$$split']('+'), difficultyMap.__getitem__(mode));
				}
				i = $p['__op_add']($add185=i,$add186=1);
				continue;
			}
			match = $m['re']['match']('.*</Requirements>.*', lines.__getitem__(i));
			if ($p['bool'](($p['bool']($and17=match)?currentConnection:$and17))) {
				area['add_connection'](currentConnection);
				i = $p['__op_add']($add187=i,$add188=1);
				continue;
			}
			match = $m['re']['match']('.*</Area>.*', lines.__getitem__(i));
			if ($p['bool'](match)) {
				$m['areas'].__setitem__($p['getattr'](area, '$$name'), area);
				i = $p['__op_add']($add189=i,$add190=1);
				continue;
			}
			i = $p['__op_add']($add191=i,$add192=1);
		}
		$m['outputStr'] = $p['__op_add']($add199=$m['outputStr'],$add200=$p['__op_add']($add197=$p['__op_add']($add195=$p['__op_add']($add193=flags,$add194='|'),$add196=$p['str'](seed)),$add198='\r\n'));
		$m['outputStr'] = $p['__op_add']($add201=$m['outputStr'],$add202='-280256|EC|1|Glades\r\n');
		$m['outputStr'] = $p['__op_add']($add203=$m['outputStr'],$add204='-1680104|EX|100|Grove\r\n');
		$m['outputStr'] = $p['__op_add']($add205=$m['outputStr'],$add206='-12320248|EX|100|Forlorn\r\n');
		$m['outputStr'] = $p['__op_add']($add207=$m['outputStr'],$add208='-10440008|EX|100|Misty\r\n');
		if ($p['bool'](!$p['bool'](includePlants))) {
			$iter23_iter = plants;
			$iter23_nextval=$p['__iter_prepare']($iter23_iter,false);
			while (typeof($p['__wrapped_next']($iter23_nextval).$nextval) != 'undefined') {
				location = $iter23_nextval.$nextval;
				$m['outputStr'] = $p['__op_add']($add211=$m['outputStr'],$add212=$p['__op_add']($add209=$p['str'](location['get_key']()),$add210='|NO|0\r\n'));
			}
		}
		locationsToAssign = $p['list']([]);
		$m['connectionQueue'] = $p['list']([]);
		$m['reservedLocations'] = $p['list']([]);
		$m['skillCount'] = 10;
		$m['mapstonesAssigned'] = 0;
		$m['expSlots'] = $m['itemPool'].__getitem__('EX*');
		while ($p['bool'](($p['cmp']($m['itemCount'], 0) == 1))) {
			$m['assignQueue'] = $p['list']([]);
			$m['doorQueue'] = $p['dict']([]);
			$m['mapQueue'] = $p['dict']([]);
			spoilerPath = '';
			$m['spoilerGroup'] = $p['dict']([['MS', $p['list']([])], ['KS', $p['list']([])], ['EC', $p['list']([])], ['HC', $p['list']([])]]);
			opening = true;
			while ($p['bool'](opening)) {
				var $tupleassign1 = $p['__ass_unpack']($m['open_free_connections'](), 3, null);
				opening = $tupleassign1[0];
				keys = $tupleassign1[1];
				mapstones = $tupleassign1[2];
				keystoneCount = $p['__op_add']($add213=keystoneCount,$add214=keys);
				mapstoneCount = $p['__op_add']($add215=mapstoneCount,$add216=mapstones);
				$iter24_iter = $m['connectionQueue'];
				$iter24_nextval=$p['__iter_prepare']($iter24_iter,false);
				while (typeof($p['__wrapped_next']($iter24_nextval).$nextval) != 'undefined') {
					connection = $iter24_nextval.$nextval;
					$m['areas'].__getitem__(connection.__getitem__(0))['remove_connection'](connection.__getitem__(1));
				}
				$m['connectionQueue'] = $p['list']([]);
			}
			locationsToAssign = $m['get_all_accessible_locations']();
			if ($p['bool'](($p['bool']($and19=!$p['bool']($m['doorQueue']))?!$p['bool']($m['mapQueue']):$and19))) {
				spoilerPath = $m['prepare_path']($p['len'](locationsToAssign));
				if ($p['bool'](!$p['bool']($m['assignQueue']))) {
					if ($p['bool'](!$p['bool']($m['reservedLocations']))) {
						return $m['placeItems'](seed, expPool, hardMode, includePlants, shardsMode, limitkeysMode, cluesMode, noTeleporters, modes, flags, starvedMode, preferPathDifficulty, setNonProgressiveMapstones);
					}
					locationsToAssign['append']($m['reservedLocations']['pop'](0));
					locationsToAssign['append']($m['reservedLocations']['pop'](0));
					spoilerPath = $m['prepare_path']($p['len'](locationsToAssign));
				}
			}
			itemsToAssign = $p['list']([]);
			if ($p['bool'](($p['cmp']($p['len'](locationsToAssign), $p['__op_sub']($sub37=$p['__op_add']($add219=$p['__op_sub']($sub35=$p['__op_add']($add217=$p['len']($m['assignQueue']),$add218=keystoneCount),$sub36=$m['inventory'].__getitem__('KS')),$add220=mapstoneCount),$sub38=$m['inventory'].__getitem__('MS'))) == -1))) {
				if ($p['bool'](!$p['bool']($m['reservedLocations']))) {
					return $m['placeItems'](seed, expPool, hardMode, includePlants, shardsMode, limitkeysMode, cluesMode, noTeleporters, modes, flags, starvedMode, preferPathDifficulty, setNonProgressiveMapstones);
				}
				locationsToAssign['append']($m['reservedLocations']['pop'](0));
				locationsToAssign['append']($m['reservedLocations']['pop'](0));
			}
			$iter25_iter = $p['range'](0, $p['len'](locationsToAssign));
			$iter25_nextval=$p['__iter_prepare']($iter25_iter,false);
			while (typeof($p['__wrapped_next']($iter25_nextval).$nextval) != 'undefined') {
				i = $iter25_nextval.$nextval;
				if ($p['bool']($m['assignQueue'])) {
					itemsToAssign['append']($m['assign']($m['assignQueue']['pop'](0)));
				}
				else if ($p['bool'](($p['cmp']($m['inventory'].__getitem__('KS'), keystoneCount) == -1))) {
					itemsToAssign['append']($m['assign']('KS'));
				}
				else if ($p['bool'](($p['cmp']($m['inventory'].__getitem__('MS'), mapstoneCount) == -1))) {
					itemsToAssign['append']($m['assign']('MS'));
				}
				else {
					itemsToAssign['append']($m['assign_random']());
				}
				$m['itemCount'] = $p['__op_sub']($sub39=$m['itemCount'],$sub40=1);
			}
			if ($p['bool']($m['pathDifficulty'])) {
				$iter26_iter = $p['list'](itemsToAssign);
				$iter26_nextval=$p['__iter_prepare']($iter26_iter,false);
				while (typeof($p['__wrapped_next']($iter26_nextval).$nextval) != 'undefined') {
					item = $iter26_nextval.$nextval;
					if ($p['bool'](($p['bool']($or12=$m['skillsOutput'].__contains__(item))?$or12:$m['eventsOutput'].__contains__(item)))) {
						$m['preferred_difficulty_assign'](item, locationsToAssign);
						itemsToAssign['remove'](item);
					}
				}
			}
			$m.random['shuffle'](itemsToAssign);
			$iter27_iter = $p['range'](0, $p['len'](locationsToAssign));
			$iter27_nextval=$p['__iter_prepare']($iter27_iter,false);
			while (typeof($p['__wrapped_next']($iter27_nextval).$nextval) != 'undefined') {
				i = $iter27_nextval.$nextval;
				$m['assign_to_location'](itemsToAssign.__getitem__(i), locationsToAssign.__getitem__(i));
			}
			if ($p['bool']($m['currentAreas'])) {
				groupDepth = $p['__op_add']($add221=groupDepth,$add222=1);
				$m['currentAreas']['sort']();
				spoilerStr = $p['__op_add']($add229=spoilerStr,$add230=$p['__op_add']($add227=$p['__op_add']($add225=$p['__op_add']($add223=$p['str'](groupDepth),$add224=': '),$add226=$p['str']($m['currentAreas'])),$add228=' {\r\n'));
				if ($p['bool'](spoilerPath)) {
					spoilerStr = $p['__op_add']($add235=spoilerStr,$add236=$p['__op_add']($add233=$p['__op_add']($add231='    Forced pickups: ',$add232=$p['str'](spoilerPath)),$add234='\r\n'));
				}
				$iter28_iter = $m['skillsOutput'];
				$iter28_nextval=$p['__iter_prepare']($iter28_iter,false);
				while (typeof($p['__wrapped_next']($iter28_nextval).$nextval) != 'undefined') {
					skill = $iter28_nextval.$nextval;
					if ($p['bool']($m['spoilerGroup'].__contains__(skill))) {
						$iter29_iter = $m['spoilerGroup'].__getitem__(skill);
						$iter29_nextval=$p['__iter_prepare']($iter29_iter,false);
						while (typeof($p['__wrapped_next']($iter29_nextval).$nextval) != 'undefined') {
							instance = $iter29_nextval.$nextval;
							spoilerStr = $p['__op_add']($add239=spoilerStr,$add240=$p['__op_add']($add237='    ',$add238=instance));
						}
						if ($p['bool'](seedDifficultyMap.__contains__(skill))) {
							$m['seedDifficulty'] = $p['__op_add']($add241=$m['seedDifficulty'],$add242=(typeof ($mul37=groupDepth)==typeof ($mul38=seedDifficultyMap.__getitem__(skill)) && typeof $mul37=='number'?
								$mul37*$mul38:
								$p['op_mul']($mul37,$mul38)));
						}
					}
				}
				$iter30_iter = $m['eventsOutput'];
				$iter30_nextval=$p['__iter_prepare']($iter30_iter,false);
				while (typeof($p['__wrapped_next']($iter30_nextval).$nextval) != 'undefined') {
					event = $iter30_nextval.$nextval;
					if ($p['bool']($m['spoilerGroup'].__contains__(event))) {
						$iter31_iter = $m['spoilerGroup'].__getitem__(event);
						$iter31_nextval=$p['__iter_prepare']($iter31_iter,false);
						while (typeof($p['__wrapped_next']($iter31_nextval).$nextval) != 'undefined') {
							instance = $iter31_nextval.$nextval;
							spoilerStr = $p['__op_add']($add245=spoilerStr,$add246=$p['__op_add']($add243='    ',$add244=instance));
						}
					}
				}
				$iter32_iter = $m['spoilerGroup'];
				$iter32_nextval=$p['__iter_prepare']($iter32_iter,false);
				while (typeof($p['__wrapped_next']($iter32_nextval).$nextval) != 'undefined') {
					key = $iter32_nextval.$nextval;
					if ($p['bool']($p['op_eq']($p['__getslice'](key, 0, 2), 'TP'))) {
						$iter33_iter = $m['spoilerGroup'].__getitem__(key);
						$iter33_nextval=$p['__iter_prepare']($iter33_iter,false);
						while (typeof($p['__wrapped_next']($iter33_nextval).$nextval) != 'undefined') {
							instance = $iter33_nextval.$nextval;
							spoilerStr = $p['__op_add']($add249=spoilerStr,$add250=$p['__op_add']($add247='    ',$add248=instance));
						}
					}
				}
				$iter34_iter = $m['spoilerGroup'].__getitem__('MS');
				$iter34_nextval=$p['__iter_prepare']($iter34_iter,false);
				while (typeof($p['__wrapped_next']($iter34_nextval).$nextval) != 'undefined') {
					instance = $iter34_nextval.$nextval;
					spoilerStr = $p['__op_add']($add253=spoilerStr,$add254=$p['__op_add']($add251='    ',$add252=instance));
				}
				$iter35_iter = $m['spoilerGroup'].__getitem__('KS');
				$iter35_nextval=$p['__iter_prepare']($iter35_iter,false);
				while (typeof($p['__wrapped_next']($iter35_nextval).$nextval) != 'undefined') {
					instance = $iter35_nextval.$nextval;
					spoilerStr = $p['__op_add']($add257=spoilerStr,$add258=$p['__op_add']($add255='    ',$add256=instance));
				}
				$iter36_iter = $m['spoilerGroup'].__getitem__('HC');
				$iter36_nextval=$p['__iter_prepare']($iter36_iter,false);
				while (typeof($p['__wrapped_next']($iter36_nextval).$nextval) != 'undefined') {
					instance = $iter36_nextval.$nextval;
					spoilerStr = $p['__op_add']($add261=spoilerStr,$add262=$p['__op_add']($add259='    ',$add260=instance));
				}
				$iter37_iter = $m['spoilerGroup'].__getitem__('EC');
				$iter37_nextval=$p['__iter_prepare']($iter37_iter,false);
				while (typeof($p['__wrapped_next']($iter37_nextval).$nextval) != 'undefined') {
					instance = $iter37_nextval.$nextval;
					spoilerStr = $p['__op_add']($add265=spoilerStr,$add266=$p['__op_add']($add263='    ',$add264=instance));
				}
				spoilerStr = $p['__op_add']($add267=spoilerStr,$add268='}\r\n');
			}
			$m['currentAreas'] = $p['list']([]);
			$iter38_iter = $m['doorQueue']['keys']();
			$iter38_nextval=$p['__iter_prepare']($iter38_iter,false);
			while (typeof($p['__wrapped_next']($iter38_nextval).$nextval) != 'undefined') {
				area = $iter38_nextval.$nextval;
				if ($p['bool'](!$m['areasReached'].__contains__($p['getattr']($m['doorQueue'].__getitem__(area), 'target')))) {
					$m['currentAreas']['append']($p['getattr']($m['doorQueue'].__getitem__(area), 'target'));
					difficulty = $m['doorQueue'].__getitem__(area)['cost']().__getitem__(2);
					$m['seedDifficulty'] = $p['__op_add']($add269=$m['seedDifficulty'],$add270=(typeof ($mul39=difficulty)==typeof ($mul40=difficulty) && typeof $mul39=='number'?
						$mul39*$mul40:
						$p['op_mul']($mul39,$mul40)));
				}
				$m['areasReached'].__setitem__($p['getattr']($m['doorQueue'].__getitem__(area), 'target'), true);
				$m['areas'].__getitem__(area)['remove_connection']($m['doorQueue'].__getitem__(area));
			}
			$iter39_iter = $m['mapQueue']['keys']();
			$iter39_nextval=$p['__iter_prepare']($iter39_iter,false);
			while (typeof($p['__wrapped_next']($iter39_nextval).$nextval) != 'undefined') {
				area = $iter39_nextval.$nextval;
				if ($p['bool'](!$m['areasReached'].__contains__($p['getattr']($m['mapQueue'].__getitem__(area), 'target')))) {
					$m['currentAreas']['append']($p['getattr']($m['mapQueue'].__getitem__(area), 'target'));
					difficulty = $m['mapQueue'].__getitem__(area)['cost']().__getitem__(2);
					$m['seedDifficulty'] = $p['__op_add']($add271=$m['seedDifficulty'],$add272=(typeof ($mul41=difficulty)==typeof ($mul42=difficulty) && typeof $mul41=='number'?
						$mul41*$mul42:
						$p['op_mul']($mul41,$mul42)));
				}
				$m['areasReached'].__setitem__($p['getattr']($m['mapQueue'].__getitem__(area), 'target'), true);
				$m['areas'].__getitem__(area)['remove_connection']($m['mapQueue'].__getitem__(area));
			}
			locationsToAssign = $p['list']([]);
		}
		spoilerStr = $p['__op_add']($add285=$p['__op_add']($add283=$p['__op_add']($add281=$p['__op_add']($add279=$p['__op_add']($add277=$p['__op_add']($add275=$p['__op_add']($add273=flags,$add274='|'),$add276=$p['str'](seed)),$add278='\r\n'),$add280='Difficulty Rating: '),$add282=$p['str']($m['seedDifficulty'])),$add284='\r\n'),$add286=spoilerStr);
		$m.random['shuffle']($m['eventList']);
		$iter40_iter = $m['eventList'];
		$iter40_nextval=$p['__iter_prepare']($iter40_iter,false);
		while (typeof($p['__wrapped_next']($iter40_nextval).$nextval) != 'undefined') {
			event = $iter40_nextval.$nextval;
			$m['outputStr'] = $p['__op_add']($add287=$m['outputStr'],$add288=event);
		}
		return $p['tuple']([$m['outputStr'], spoilerStr]);
	};
	$m['placeItems'].__name__ = 'placeItems';

	$m['placeItems'].__bind_type__ = 0;
	$m['placeItems'].__args__ = [null,null,['seed'],['expPool'],['hardMode'],['includePlants'],['shardsMode'],['limitkeysMode'],['cluesMode'],['noTeleporters'],['modes'],['flags'],['starvedMode'],['preferPathDifficulty'],['setNonProgressiveMapstones']];
	$m['pyjd'] = $p['___import___']('pyjd', null);
	$m['RootPanel'] = $p['___import___']('pyjamas.ui.RootPanel.RootPanel', null, null, false);
	$m['VerticalPanel'] = $p['___import___']('pyjamas.ui.VerticalPanel.VerticalPanel', null, null, false);
	$m['HorizontalPanel'] = $p['___import___']('pyjamas.ui.HorizontalPanel.HorizontalPanel', null, null, false);
	$m['DisclosurePanel'] = $p['___import___']('pyjamas.ui.DisclosurePanel.DisclosurePanel', null, null, false);
	$m['HasAlignment'] = $p['___import___']('pyjamas.ui.HasAlignment', null, null, false);
	$m['Button'] = $p['___import___']('pyjamas.ui.Button.Button', null, null, false);
	$m['RadioButton'] = $p['___import___']('pyjamas.ui.RadioButton.RadioButton', null, null, false);
	$m['CheckBox'] = $p['___import___']('pyjamas.ui.CheckBox.CheckBox', null, null, false);
	$m['HTML'] = $p['___import___']('pyjamas.ui.HTML.HTML', null, null, false);
	$m['ListBox'] = $p['___import___']('pyjamas.ui.ListBox.ListBox', null, null, false);
	$m['TextBox'] = $p['___import___']('pyjamas.ui.TextBox.TextBox', null, null, false);
	$m['DOM'] = $p['___import___']('pyjamas.DOM', null, null, false);
	$m['LogicListener'] = (function(){
		var $cls_definition = new Object();
		var $method;
		$cls_definition.__module__ = 'web_seed_generator';
		$method = $pyjs__bind_method2('__init__', function(element) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				element = arguments[1];
			}

			element['addChangeListener'](self);
			return null;
		}
	, 1, [null,null,['self'],['element']]);
		$cls_definition['__init__'] = $method;
		$method = $pyjs__bind_method2('onChange', function(sender) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				sender = arguments[1];
			}
			var index;
			index = sender['getSelectedIndex']();
			$m.pathNormal['setChecked'](true);
			$m.pathSpeed['setChecked'](false);
			$m.pathDBoostLight['setChecked'](false);
			$m.pathDBoost['setChecked'](false);
			$m.pathDBoostHard['setChecked'](false);
			$m.pathLure['setChecked'](false);
			$m.pathLureHard['setChecked'](false);
			$m.pathDBash['setChecked'](false);
			$m.pathCDash['setChecked'](false);
			$m.pathCDashFarming['setChecked'](false);
			$m.pathExtended['setChecked'](false);
			$m.pathExtendedDamage['setChecked'](false);
			$m.pathExtreme['setChecked'](false);
			$m.pathTimedLevel['setChecked'](false);
			$m.pathGlitched['setChecked'](false);
			$m.diffSelection['setSelectedIndex'](1);
			$m.hardBox['setChecked'](false);
			$m.starvedBox['setChecked'](false);
			$m.ohkoBox['setChecked'](false);
			$m.zeroBox['setChecked'](false);
			$m.noPlantsBox['setChecked'](false);
			if ($p['bool']($p['op_eq'](index, 0))) {
				$m.pathDBoostLight['setChecked'](true);
			}
			else if ($p['bool']($p['op_eq'](index, 1))) {
				$m.pathSpeed['setChecked'](true);
				$m.pathDBoostLight['setChecked'](true);
				$m.pathLure['setChecked'](true);
			}
			else if ($p['bool']($p['op_eq'](index, 2))) {
				$m.pathSpeed['setChecked'](true);
				$m.pathDBoostLight['setChecked'](true);
				$m.pathDBoost['setChecked'](true);
				$m.pathLure['setChecked'](true);
				$m.pathCDash['setChecked'](true);
				$m.pathExtended['setChecked'](true);
				$m.pathExtendedDamage['setChecked'](true);
			}
			else if ($p['bool']($p['op_eq'](index, 3))) {
				$m.pathSpeed['setChecked'](true);
				$m.pathDBoostLight['setChecked'](true);
				$m.pathDBoost['setChecked'](true);
				$m.pathDBoostHard['setChecked'](true);
				$m.pathLure['setChecked'](true);
				$m.pathLureHard['setChecked'](true);
				$m.pathDBash['setChecked'](true);
				$m.pathCDash['setChecked'](true);
				$m.pathExtended['setChecked'](true);
				$m.pathExtendedDamage['setChecked'](true);
				$m.pathExtreme['setChecked'](true);
				$m.starvedBox['setChecked'](true);
				$m.diffSelection['setSelectedIndex'](2);
			}
			else if ($p['bool']($p['op_eq'](index, 4))) {
				$m.pathSpeed['setChecked'](true);
				$m.pathDBoostLight['setChecked'](true);
				$m.pathLure['setChecked'](true);
				$m.pathDBash['setChecked'](true);
				$m.pathCDash['setChecked'](true);
				$m.pathExtended['setChecked'](true);
				$m.hardBox['setChecked'](true);
			}
			else if ($p['bool']($p['op_eq'](index, 5))) {
				$m.pathSpeed['setChecked'](true);
				$m.pathLure['setChecked'](true);
				$m.pathDBash['setChecked'](true);
				$m.pathCDash['setChecked'](true);
				$m.pathExtended['setChecked'](true);
				$m.hardBox['setChecked'](true);
				$m.ohkoBox['setChecked'](true);
			}
			else if ($p['bool']($p['op_eq'](index, 6))) {
				$m.pathSpeed['setChecked'](true);
				$m.pathDBoostLight['setChecked'](true);
				$m.pathLure['setChecked'](true);
				$m.hardBox['setChecked'](true);
				$m.zeroBox['setChecked'](true);
			}
			else if ($p['bool']($p['op_eq'](index, 7))) {
				$m.pathSpeed['setChecked'](true);
				$m.pathDBoostLight['setChecked'](true);
				$m.pathDBoost['setChecked'](true);
				$m.pathDBoostHard['setChecked'](true);
				$m.pathLure['setChecked'](true);
				$m.pathLureHard['setChecked'](true);
				$m.pathDBash['setChecked'](true);
				$m.pathCDash['setChecked'](true);
				$m.pathCDashFarming['setChecked'](true);
				$m.pathExtended['setChecked'](true);
				$m.pathExtendedDamage['setChecked'](true);
				$m.pathExtreme['setChecked'](true);
				$m.pathTimedLevel['setChecked'](true);
				$m.pathGlitched['setChecked'](true);
				$m.diffSelection['setSelectedIndex'](2);
			}
			return null;
		}
	, 1, [null,null,['self'],['sender']]);
		$cls_definition['onChange'] = $method;
		var $bases = new Array(pyjslib.object);
		var $data = $p['dict']();
		for (var $item in $cls_definition) { $data.__setitem__($item, $cls_definition[$item]); }
		return $p['_create_class']('LogicListener', $p['tuple']($bases), $data);
	})();
	$m['CustomPathListener'] = (function(){
		var $cls_definition = new Object();
		var $method;
		$cls_definition.__module__ = 'web_seed_generator';
		$method = $pyjs__bind_method2('__init__', function() {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
			}

 			return null;
		}
	, 1, [null,null,['self']]);
		$cls_definition['__init__'] = $method;
		$method = $pyjs__bind_method2('onClick', function(sender) {
			if (this.__is_instance__ === true) {
				var self = this;
			} else {
				var self = arguments[0];
				sender = arguments[1];
			}
			if (typeof sender == 'undefined') sender=arguments.callee.__args__[3][1];

			$m.logicSelection['setSelectedIndex'](8);
			return null;
		}
	, 1, [null,null,['self'],['sender', null]]);
		$cls_definition['onClick'] = $method;
		var $bases = new Array(pyjslib.object);
		var $data = $p['dict']();
		for (var $item in $cls_definition) { $data.__setitem__($item, $cls_definition[$item]); }
		return $p['_create_class']('CustomPathListener', $p['tuple']($bases), $data);
	})();
	$m['seed_hash'] = function(seed) {
		var index,$iter41_array,$add290,$add289,value,$iter41_type,$iter41_nextval,$sub41,$iter41_iter,$iter41_idx,$sub42;
		value = 0;
		$iter41_iter = $p['range']($p['len'](seed));
		$iter41_nextval=$p['__iter_prepare']($iter41_iter,false);
		while (typeof($p['__wrapped_next']($iter41_nextval).$nextval) != 'undefined') {
			index = $iter41_nextval.$nextval;
			value = $p['__op_add']($add289=$p['__op_sub']($sub41=(value)<<(5),$sub42=value),$add290=$p['ord'](seed.__getitem__(index)));
		}
		return (4294967295)&(value);
	};
	$m['seed_hash'].__name__ = 'seed_hash';

	$m['seed_hash'].__bind_type__ = 0;
	$m['seed_hash'].__args__ = [null,null,['seed']];
	$m['generate'] = function() {
		var prefer_path_difficulty,non_progressive_mapstones,hard,dl,exp_pool,seed,$add319,limitkeys,$add311,$mul44,$add292,$mul43,$add310,nobonus,$add312,$add313,$add314,$add315,$add316,$add317,$add318,$add307,$add306,$add295,$add294,$add297,$add296,$add291,$add305,$add293,includePlants,$add328,$add299,$add298,no_teleporters,clues,zeroxp,$add327,$add326,placement,modes,ohko,force_trees,shards,element,$add303,$add302,$add301,$add300,flags,mode,starved,$add304,$add325,$add324,$add309,$add308,$add321,$add320,$add323,$add322;
		$m.genButton['setText']('Generating...');
		seed = $m.seedSelection['getText']();
		if ($p['bool']($p['op_eq'](seed, ''))) {
			seed = $p['str']((2147483647)&((typeof ($mul43=$m['time']['time']())==typeof ($mul44=1000) && typeof $mul43=='number'?
				$mul43*$mul44:
				$p['op_mul']($mul43,$mul44))));
		}
		hard = $m.hardBox['isChecked']();
		exp_pool = 10000;
		if ($p['bool'](hard)) {
			exp_pool = 5000;
		}
		includePlants = !$p['bool']($m.noPlantsBox['isChecked']());
		shards = $p['op_eq']($m.modeSelection['getSelectedIndex'](), 1);
		limitkeys = $p['op_eq']($m.modeSelection['getSelectedIndex'](), 2);
		clues = $p['op_eq']($m.modeSelection['getSelectedIndex'](), 3);
		no_teleporters = $m.noTeleBox['isChecked']();
		mode = $m.logicSelection['getItemText']($m.logicSelection['getSelectedIndex']());
		modes = $p['list']([]);
		if ($p['bool']($m.pathNormal['isChecked']())) {
			modes['append']('normal');
		}
		if ($p['bool']($m.pathSpeed['isChecked']())) {
			modes['append']('speed');
		}
		if ($p['bool']($m.pathDBoostLight['isChecked']())) {
			modes['append']('dboost-light');
		}
		if ($p['bool']($m.pathDBoost['isChecked']())) {
			modes['append']('dboost');
		}
		if ($p['bool']($m.pathDBoostHard['isChecked']())) {
			modes['append']('dboost-hard');
		}
		if ($p['bool']($m.pathLure['isChecked']())) {
			modes['append']('lure');
		}
		if ($p['bool']($m.pathLureHard['isChecked']())) {
			modes['append']('lure-hard');
		}
		if ($p['bool']($m.pathDBash['isChecked']())) {
			modes['append']('dbash');
		}
		if ($p['bool']($m.pathCDash['isChecked']())) {
			modes['append']('cdash');
		}
		if ($p['bool']($m.pathCDashFarming['isChecked']())) {
			modes['append']('cdash-farming');
		}
		if ($p['bool']($m.pathExtended['isChecked']())) {
			modes['append']('extended');
		}
		if ($p['bool']($m.pathExtendedDamage['isChecked']())) {
			modes['append']('extended-damage');
		}
		if ($p['bool']($m.pathExtreme['isChecked']())) {
			modes['append']('extreme');
		}
		if ($p['bool']($m.pathTimedLevel['isChecked']())) {
			modes['append']('timed-level');
		}
		if ($p['bool']($m.pathGlitched['isChecked']())) {
			modes['append']('glitched');
		}
		starved = $m.starvedBox['isChecked']();
		prefer_path_difficulty = $m.diffSelection['getItemText']($m.diffSelection['getSelectedIndex']())['lower']();
		if ($p['bool']($p['op_eq'](prefer_path_difficulty, 'normal'))) {
			prefer_path_difficulty = null;
		}
		non_progressive_mapstones = $m.nonProgMapBox['isChecked']();
		ohko = $m.ohkoBox['isChecked']();
		zeroxp = $m.zeroBox['isChecked']();
		nobonus = $m.noBonusBox['isChecked']();
		force_trees = $m.forceBox['isChecked']();
		flags = '';
		flags = $p['__op_add']($add293=flags,$add294=$p['__op_add']($add291=mode,$add292=','));
		if ($p['bool'](limitkeys)) {
			flags = $p['__op_add']($add295=flags,$add296='limitkeys,');
		}
		if ($p['bool'](shards)) {
			flags = $p['__op_add']($add297=flags,$add298='shards,');
		}
		if ($p['bool'](clues)) {
			flags = $p['__op_add']($add299=flags,$add300='clues,');
		}
		if ($p['bool'](starved)) {
			flags = $p['__op_add']($add301=flags,$add302='starved,');
		}
		if ($p['bool'](prefer_path_difficulty)) {
			flags = $p['__op_add']($add307=flags,$add308=$p['__op_add']($add305=$p['__op_add']($add303='prefer_path_difficulty=',$add304=prefer_path_difficulty),$add306=','));
		}
		if ($p['bool'](hard)) {
			flags = $p['__op_add']($add309=flags,$add310='hard,');
		}
		if ($p['bool'](ohko)) {
			flags = $p['__op_add']($add311=flags,$add312='OHKO,');
		}
		if ($p['bool'](zeroxp)) {
			flags = $p['__op_add']($add313=flags,$add314='0XP,');
		}
		if ($p['bool'](nobonus)) {
			flags = $p['__op_add']($add315=flags,$add316='NoBonus,');
		}
		if ($p['bool'](!$p['bool'](includePlants))) {
			flags = $p['__op_add']($add317=flags,$add318='NoPlants,');
		}
		if ($p['bool'](force_trees)) {
			flags = $p['__op_add']($add319=flags,$add320='ForceTrees,');
		}
		if ($p['bool'](non_progressive_mapstones)) {
			flags = $p['__op_add']($add321=flags,$add322='NonProgressMapStones,');
		}
		if ($p['bool'](no_teleporters)) {
			flags = $p['__op_add']($add323=flags,$add324='NoTeleporters,');
		}
		flags = $p['__getslice'](flags, 0, (typeof ($usub1=1)=='number'?
			-$usub1:
			$p['op_usub']($usub1)));
		$m.random['seed'](seed);
		placement = $m['placeItems'](seed, exp_pool, hard, includePlants, shards, limitkeys, clues, no_teleporters, modes, flags, starved, prefer_path_difficulty, non_progressive_mapstones);
		$m.genButton['setText']('Generate');
		element = $m['DOM']['createElement']('a');
		element['setAttribute']('href', $p['__op_add']($add325='data:text/plain;charset=utf-8,',$add326=(typeof encodeURIComponent == "undefined"?$m.encodeURIComponent:encodeURIComponent)(placement.__getitem__(1))));
		element['setAttribute']('download', 'spoiler.txt');
		$p['getattr'](element, 'style').display = 'none';
		dl = $m['DOM']['getElementById']('dl');
		$m['DOM']['appendChild'](dl, element);
		element['click']();
		element['setAttribute']('href', $p['__op_add']($add327='data:text/plain;charset=utf-8,',$add328=(typeof encodeURIComponent == "undefined"?$m.encodeURIComponent:encodeURIComponent)(placement.__getitem__(0))));
		element['setAttribute']('download', 'randomizer.dat');
		element['click']();
		$m['DOM']['removeChild'](dl, element);
		return null;
	};
	$m['generate'].__name__ = 'generate';

	$m['generate'].__bind_type__ = 0;
	$m['generate'].__args__ = [null,null];
	$m['main'] = function() {
		var modeText,variations1,variations3,logicText,paths3,row1_2,row1_3,title,seedText,seedPanel,variationPanel,paths5,variations2,diffText,logicListener,paths2,pathsPanel,paths1,paths4,panel,row0,row1,row2,row3,row4,row1_1,variationText,customPathListener;
		$m['pyjd']['setup']('public/web_seed_generator.html');
		$m['itemList'] = $p['list'](['EX1', 'EX*', 'KS', 'MS', 'AC', 'EC', 'HC', 'WallJump', 'ChargeFlame', 'Dash', 'Stomp', 'DoubleJump', 'Glide', 'Bash', 'Climb', 'Grenade', 'ChargeJump', 'GinsoKey', 'ForlornKey', 'HoruKey', 'Water', 'Wind', 'Warmth', 'RB0', 'RB1', 'RB6', 'RB8', 'RB9', 'RB10', 'RB11', 'RB12', 'RB13', 'RB15', 'WaterVeinShard', 'GumonSealShard', 'SunstoneShard', 'TPForlorn', 'TPGrotto', 'TPSorrow', 'TPGrove', 'TPSwamp', 'TPValley']);
		$m['random'] = $m['Random']();
		panel = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{HorizontalAlignment:$p['getattr']($m['HasAlignment'], 'ALIGN_CENTER'), StyleName:'main'}]);
		row0 = $pyjs_kwargs_call(null, $m['HorizontalPanel'], null, null, [{HorizontalAlignment:$p['getattr']($m['HasAlignment'], 'ALIGN_LEFT')}]);
		row1 = $pyjs_kwargs_call(null, $m['HorizontalPanel'], null, null, [{HorizontalAlignment:$p['getattr']($m['HasAlignment'], 'ALIGN_LEFT'), StyleName:'row'}]);
		row2 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{HorizontalAlignment:$p['getattr']($m['HasAlignment'], 'ALIGN_LEFT'), StyleName:'row'}]);
		row3 = $pyjs_kwargs_call(null, $m['DisclosurePanel'], null, null, [{StyleName:'row'}, 'Logic Paths']);
		row4 = $pyjs_kwargs_call(null, $m['HorizontalPanel'], null, null, [{HorizontalAlignment:$p['getattr']($m['HasAlignment'], 'ALIGN_LEFT'), StyleName:'row'}]);
		panel['add'](row0);
		panel['add'](row1);
		panel['add'](row2);
		panel['add'](row3);
		panel['add'](row4);
		title = $pyjs_kwargs_call(null, $m['HTML'], null, null, [{StyleName:'title'}, 'Ori DE Randomizer (v2.0)']);
		row0['add'](title);
		row1_1 = $pyjs_kwargs_call(null, $m['HorizontalPanel'], null, null, [{StyleName:'inner_row'}]);
		row1_2 = $pyjs_kwargs_call(null, $m['HorizontalPanel'], null, null, [{StyleName:'inner_row'}]);
		row1_3 = $pyjs_kwargs_call(null, $m['HorizontalPanel'], null, null, [{StyleName:'inner_row'}]);
		row1['add'](row1_1);
		row1['add'](row1_2);
		row1['add'](row1_3);
		logicText = $pyjs_kwargs_call(null, $m['HTML'], null, null, [{StyleName:'label'}, 'Logic']);
		$m['logicSelection'] = $pyjs_kwargs_call(null, $m['ListBox'], null, null, [{VisibleItemCount:1, StyleName:'dropdown'}]);
		$m['logicSelection']['addItem']('Casual');
		$m['logicSelection']['addItem']('Standard');
		$m['logicSelection']['addItem']('Expert');
		$m['logicSelection']['addItem']('Master');
		$m['logicSelection']['addItem']('Hard');
		$m['logicSelection']['addItem']('OHKO');
		$m['logicSelection']['addItem']('0 XP');
		$m['logicSelection']['addItem']('Glitched');
		$m['logicSelection']['addItem']('Custom');
		$m['logicSelection']['setSelectedIndex'](1);
		logicListener = $m['LogicListener']($m['logicSelection']);
		row1_1['add'](logicText);
		row1_1['add']($m['logicSelection']);
		modeText = $pyjs_kwargs_call(null, $m['HTML'], null, null, [{StyleName:'label'}, 'Mode']);
		$m['modeSelection'] = $pyjs_kwargs_call(null, $m['ListBox'], null, null, [{VisibleItemCount:1, StyleName:'dropdown'}]);
		$m['modeSelection']['addItem']('Default');
		$m['modeSelection']['addItem']('Shards');
		$m['modeSelection']['addItem']('Limitkeys');
		$m['modeSelection']['addItem']('Clues');
		$m['modeSelection']['setSelectedIndex'](1);
		row1_2['add'](modeText);
		row1_2['add']($m['modeSelection']);
		diffText = $pyjs_kwargs_call(null, $m['HTML'], null, null, [{StyleName:'label'}, 'Path Difficulty']);
		$m['diffSelection'] = $pyjs_kwargs_call(null, $m['ListBox'], null, null, [{VisibleItemCount:1, StyleName:'dropdown'}]);
		$m['diffSelection']['addItem']('Easy');
		$m['diffSelection']['addItem']('Normal');
		$m['diffSelection']['addItem']('Hard');
		$m['diffSelection']['setSelectedIndex'](1);
		row1_3['add'](diffText);
		row1_3['add']($m['diffSelection']);
		variationText = $pyjs_kwargs_call(null, $m['HTML'], null, null, [{StyleName:'section'}, 'Variations']);
		variationPanel = $m['HorizontalPanel']();
		row2['add'](variationText);
		row2['add'](variationPanel);
		variations1 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'var_column'}]);
		variations2 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'var_column'}]);
		variations3 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'var_column'}]);
		variationPanel['add'](variations1);
		variationPanel['add'](variations2);
		variationPanel['add'](variations3);
		$m['forceBox'] = $m['CheckBox']('Force Trees');
		$m['hardBox'] = $m['CheckBox']('Hard Mode');
		$m['noTeleBox'] = $m['CheckBox']('No Teleporters');
		$m['forceBox']['setChecked'](true);
		variations1['add']($m['forceBox']);
		variations1['add']($m['hardBox']);
		variations1['add']($m['noTeleBox']);
		$m['starvedBox'] = $m['CheckBox']('Starved');
		$m['ohkoBox'] = $m['CheckBox']('OHKO');
		$m['noPlantsBox'] = $m['CheckBox']('No Plants');
		variations2['add']($m['starvedBox']);
		variations2['add']($m['ohkoBox']);
		variations2['add']($m['noPlantsBox']);
		$m['nonProgMapBox'] = $m['CheckBox']('Discrete Mapstones');
		$m['zeroBox'] = $m['CheckBox']('0 XP');
		$m['noBonusBox'] = $m['CheckBox']('No Bonuses');
		variations3['add']($m['nonProgMapBox']);
		variations3['add']($m['zeroBox']);
		variations3['add']($m['noBonusBox']);
		pathsPanel = $m['HorizontalPanel']();
		row3['add'](pathsPanel);
		paths1 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'logic_column'}]);
		paths2 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'logic_column'}]);
		paths3 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'logic_column'}]);
		paths4 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'logic_column'}]);
		paths5 = $pyjs_kwargs_call(null, $m['VerticalPanel'], null, null, [{StyleName:'logic_column'}]);
		pathsPanel['add'](paths1);
		pathsPanel['add'](paths2);
		pathsPanel['add'](paths3);
		pathsPanel['add'](paths4);
		pathsPanel['add'](paths5);
		customPathListener = $m['CustomPathListener']();
		$m['pathNormal'] = $m['CheckBox']('Normal');
		$m['pathLure'] = $m['CheckBox']('Lure');
		$m['pathExtended'] = $m['CheckBox']('Extended');
		$m['pathNormal']['setChecked'](true);
		$m['pathLure']['setChecked'](true);
		$m['pathNormal']['addClickListener'](customPathListener);
		$m['pathLure']['addClickListener'](customPathListener);
		$m['pathExtended']['addClickListener'](customPathListener);
		paths1['add']($m['pathNormal']);
		paths1['add']($m['pathLure']);
		paths1['add']($m['pathExtended']);
		$m['pathSpeed'] = $m['CheckBox']('Speed');
		$m['pathLureHard'] = $m['CheckBox']('Lure-Hard');
		$m['pathExtendedDamage'] = $m['CheckBox']('Extended-Damage');
		$m['pathSpeed']['setChecked'](true);
		$m['pathSpeed']['addClickListener'](customPathListener);
		$m['pathLureHard']['addClickListener'](customPathListener);
		$m['pathExtendedDamage']['addClickListener'](customPathListener);
		paths2['add']($m['pathSpeed']);
		paths2['add']($m['pathLureHard']);
		paths2['add']($m['pathExtendedDamage']);
		$m['pathDBoostLight'] = $m['CheckBox']('DBoost-Light');
		$m['pathDBash'] = $m['CheckBox']('DBash');
		$m['pathExtreme'] = $m['CheckBox']('Extreme');
		$m['pathDBoostLight']['setChecked'](true);
		$m['pathDBoostLight']['addClickListener'](customPathListener);
		$m['pathDBash']['addClickListener'](customPathListener);
		$m['pathExtreme']['addClickListener'](customPathListener);
		paths3['add']($m['pathDBoostLight']);
		paths3['add']($m['pathDBash']);
		paths3['add']($m['pathExtreme']);
		$m['pathDBoost'] = $m['CheckBox']('DBoost');
		$m['pathCDash'] = $m['CheckBox']('CDash');
		$m['pathTimedLevel'] = $m['CheckBox']('Timed-Level');
		$m['pathDBoost']['addClickListener'](customPathListener);
		$m['pathCDash']['addClickListener'](customPathListener);
		$m['pathTimedLevel']['addClickListener'](customPathListener);
		paths4['add']($m['pathDBoost']);
		paths4['add']($m['pathCDash']);
		paths4['add']($m['pathTimedLevel']);
		$m['pathDBoostHard'] = $m['CheckBox']('DBoost-Hard');
		$m['pathCDashFarming'] = $m['CheckBox']('CDash-Farming');
		$m['pathGlitched'] = $m['CheckBox']('Glitched');
		$m['pathDBoostHard']['addClickListener'](customPathListener);
		$m['pathCDashFarming']['addClickListener'](customPathListener);
		$m['pathGlitched']['addClickListener'](customPathListener);
		paths5['add']($m['pathDBoostHard']);
		paths5['add']($m['pathCDashFarming']);
		paths5['add']($m['pathGlitched']);
		seedPanel = $m['HorizontalPanel']('inner_row');
		seedText = $pyjs_kwargs_call(null, $m['HTML'], null, null, [{StyleName:'label'}, 'Seed']);
		$m['seedSelection'] = $pyjs_kwargs_call(null, $m['TextBox'], null, null, [{StyleName:'seed', MaxLength:10}]);
		$m['genButton'] = $pyjs_kwargs_call(null, $m['Button'], null, null, [{StyleName:'button'}, 'Generate', $m['generate']]);
		seedPanel['add'](seedText);
		seedPanel['add']($m['seedSelection']);
		row4['add'](seedPanel);
		row4['add']($m['genButton']);
		$m['RootPanel']()['add'](panel);
		$m['pyjd']['run']();
		return null;
	};
	$m['main'].__name__ = 'main';

	$m['main'].__bind_type__ = 0;
	$m['main'].__args__ = [null,null];
	if ($p['bool']($p['op_eq']((typeof __name__ == "undefined"?$m.__name__:__name__), '__main__'))) {
		$m['main']();
	}
	return this;
}; /* end web_seed_generator */


/* end module: web_seed_generator */


/*
PYJS_DEPS: ['re', 'math', 'time', 'pyjd', 'pyjamas.ui.RootPanel.RootPanel', 'pyjamas', 'pyjamas.ui', 'pyjamas.ui.RootPanel', 'pyjamas.ui.VerticalPanel.VerticalPanel', 'pyjamas.ui.VerticalPanel', 'pyjamas.ui.HorizontalPanel.HorizontalPanel', 'pyjamas.ui.HorizontalPanel', 'pyjamas.ui.DisclosurePanel.DisclosurePanel', 'pyjamas.ui.DisclosurePanel', 'pyjamas.ui.HasAlignment', 'pyjamas.ui.Button.Button', 'pyjamas.ui.Button', 'pyjamas.ui.RadioButton.RadioButton', 'pyjamas.ui.RadioButton', 'pyjamas.ui.CheckBox.CheckBox', 'pyjamas.ui.CheckBox', 'pyjamas.ui.HTML.HTML', 'pyjamas.ui.HTML', 'pyjamas.ui.ListBox.ListBox', 'pyjamas.ui.ListBox', 'pyjamas.ui.TextBox.TextBox', 'pyjamas.ui.TextBox', 'pyjamas.DOM']
*/
