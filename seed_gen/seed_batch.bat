
mkdir seeds
mkdir spoilers

mkdir seeds\casual
mkdir spoilers\casual

python seed_generator.py --preset casual --count 99
move randomizer*.dat seeds/casual/
move spoiler* spoilers/casual/

mkdir seeds\casual-shards
mkdir spoilers\casual-shards

python seed_generator.py --preset casual --shards --count 99
move randomizer*.dat seeds/casual-shards/
move spoiler* spoilers/casual-shards/

mkdir seeds\casual-limitkeys
mkdir spoilers\casual-limitkeys

python seed_generator.py --preset casual --limitkeys --count 99
move randomizer*.dat seeds/casual-limitkeys/
move spoiler* spoilers/casual-limitkeys/

mkdir seeds\standard
mkdir spoilers\standard

python seed_generator.py --preset standard --count 999 --force-trees
move randomizer*.dat seeds/standard/
move spoiler* spoilers/standard/

mkdir seeds\standard-shards
mkdir spoilers\standard-shards

python seed_generator.py --preset standard --shards --count 999 --force-trees
move randomizer*.dat seeds/standard-shards/
move spoiler* spoilers/standard-shards/

mkdir seeds\standard-limitkeys
mkdir spoilers\standard-limitkeys

python seed_generator.py --preset standard --limitkeys --count 999 --force-trees
move randomizer*.dat seeds/standard-limitkeys/
move spoiler* spoilers/standard-limitkeys/

mkdir seeds\expert
mkdir spoilers\expert

python seed_generator.py --preset expert --count 999 --force-trees
move randomizer*.dat seeds/expert/
move spoiler* spoilers/expert/

mkdir seeds\expert-shards
mkdir spoilers\expert-shards

python seed_generator.py --preset expert --count 999 --shards --force-trees
move randomizer*.dat seeds/expert-shards/
move spoiler* spoilers/expert-shards/

mkdir seeds\expert-limitkeys
mkdir spoilers\expert-limitkeys

python seed_generator.py --preset expert --count 999 --limitkeys --force-trees
move randomizer*.dat seeds/expert-limitkeys/
move spoiler* spoilers/expert-limitkeys/

mkdir seeds\master-shards
mkdir spoilers\master-shards

python seed_generator.py --preset master --count 999 --force-trees --prefer-path-difficulty hard --starved
move randomizer*.dat seeds/master-shards/
move spoiler* spoilers/master-shards/

mkdir seeds\hard
mkdir spoilers\hard

python seed_generator.py --preset hard --count 99 --hard --exp-pool 5000
move randomizer*.dat seeds/hard/
move spoiler* spoilers/hard/

mkdir seeds\ohko
mkdir spoilers\ohko

python seed_generator.py --preset ohko --count 99 --ohko --hard --exp-pool 5000
move randomizer*.dat seeds/ohko/
move spoiler* spoilers/ohko/

mkdir seeds\0xp
mkdir spoilers\0xp

python seed_generator.py --preset 0xp --count 99 --hard --zeroxp --noplants
move randomizer*.dat seeds/0xp/
move spoiler* spoilers/0xp/
