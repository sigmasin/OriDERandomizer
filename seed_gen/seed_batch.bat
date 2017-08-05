
mkdir seeds
mkdir spoilers

mkdir seeds/casual
mkdir spoilers/casual

python seed_generator.py --logic casual --count 99
move randomizer*.dat seeds/casual/
move spoiler* spoilers/casual/

mkdir seeds/casual-shards
mkdir spoilers/casual-shards

python seed_generator.py --logic casual --shards --count 99
move randomizer*.dat seeds/casual-shards/
move spoiler* spoilers/casual-shards/

mkdir seeds/casual-limitkeys
mkdir spoilers/casual-limitkeys

python seed_generator.py --logic casual --limitkeys --count 99
move randomizer*.dat seeds/casual-limitkeys/
move spoiler* spoilers/casual-limitkeys/

mkdir seeds/normal
mkdir spoilers/normal

python seed_generator.py --logic normal --count 999 --force-trees
move randomizer*.dat seeds/normal/
move spoiler* spoilers/normal/

mkdir seeds/normal-shards
mkdir spoilers/normal-shards

python seed_generator.py --logic normal --shards --count 999 --force-trees
move randomizer*.dat seeds/normal-shards/
move spoiler* spoilers/normal-shards/

mkdir seeds/normal-limitkeys
mkdir spoilers/normal-limitkeys

python seed_generator.py --logic normal --limitkeys --count 999 --force-trees
move randomizer*.dat seeds/normal-limitkeys/
move spoiler* spoilers/normal-limitkeys/

mkdir seeds/extended
mkdir spoilers/extended

python seed_generator.py --logic extended --count 999 --force-trees
move randomizer*.dat seeds/extended/
move spoiler* spoilers/extended/

mkdir seeds/extended-shards
mkdir spoilers/extended-shards

python seed_generator.py --logic extended --count 999 --shards --force-trees
move randomizer*.dat seeds/extended-shards/
move spoiler* spoilers/extended-shards/

mkdir seeds/extended-limitkeys
mkdir spoilers/extended-limitkeys

python seed_generator.py --logic extended --count 999 --limitkeys --force-trees
move randomizer*.dat seeds/extended-limitkeys/
move spoiler* spoilers/extended-limitkeys/

python seed_generator.py --logic hard --count 99 --hard --exp-pool 5000
move randomizer*.dat seeds/hard/
move spoiler* spoilers/hard/

python seed_generator.py --logic ohko --count 99 --ohko --hard --exp-pool 5000
move randomizer*.dat seeds/ohko/
move spoiler* spoilers/ohko/

python seed_generator.py --logic 0xp --count 99 --hard --zeroxp --noplants
move randomizer*.dat seeds/0xp/
move spoiler* spoilers/0xp/
