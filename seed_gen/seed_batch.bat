python seed_generator.py --logic casual --count 999
move randomizer*.dat seeds/casual/
move spoiler* spoilers/casual/

python seed_generator.py --logic normal --count 999
move randomizer*.dat seeds/normal/
move spoiler* spoilers/normal/

python seed_generator.py --logic extended --count 999
move randomizer*.dat seeds/extended/
move spoiler* spoilers/extended/

python seed_generator.py --logic hard --count 999 --hard
move randomizer*.dat seeds/hard/
move spoiler* spoilers/hard/

python seed_generator.py --logic ohko --count 999 --ohko --hard
move randomizer*.dat seeds/ohko/
move spoiler* spoilers/ohko/

python seed_generator.py --logic 0xp --count 999 --hard --zeroxp --noplants
move randomizer*.dat seeds/0xp/
move spoiler* spoilers/0xp/
