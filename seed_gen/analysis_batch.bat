
python seed_generator.py --loc-analysis --preset standard --shards --count 10000 > standard_shards.csv
python seed_generator.py --loc-analysis --preset standard --limitkeys --count 10000 > standard_limitkeys.csv
python seed_generator.py --loc-analysis --preset standard --clues --count 10000 > standard_clues.csv

python seed_generator.py --loc-analysis --preset expert --shards --count 10000 > expert_shards.csv
python seed_generator.py --loc-analysis --preset expert --limitkeys --count 10000 > expert_limitkeys.csv
python seed_generator.py --loc-analysis --preset expert --clues --count 10000 > expert_clues.csv

python seed_generator.py --loc-analysis --preset master --starved --prefer-path-difficulty hard --shards --count 10000 > master_shards.csv
python seed_generator.py --loc-analysis --preset master --starved --prefer-path-difficulty hard --limitkeys --count 10000 > master_limitkeys.csv
python seed_generator.py --loc-analysis --preset master --starved --prefer-path-difficulty hard --clues --count 10000 > master_clues.csv
