#!/bin/bash

for file in *.yaml; do
    # make sure its a .yaml file in the root, not a subfolder
    if [ -f "$file" ]; then
        bzt "$file"
    fi
done