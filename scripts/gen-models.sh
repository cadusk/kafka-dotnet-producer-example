#!/bin/sh

echo "Recreating model classes..."

# Models are generated to /tmp and then moved to
# the project folder just for simplicity to avoid
# long nested folders due to avrogen's namespaces
# and folder structure relationship.
avrogen -s ./schemas/user.avsc /tmp
mv $(find /tmp/ -name '*.cs') ./src/Models/
