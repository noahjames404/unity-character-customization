#!/bin/bash

# Define the Mesh values
mesh_values=( "Skin" "Eyes" "Top Clothes" "Armor" "Hair" "Head Gear" "Lower Clothes" "Boots" "Gauntlet" "Tasset" )

# Define the length of the Mesh column strings
mesh_length=2

# Define the length of the Base Model and Reference Model column strings
model_length=20

# Define the input parameters for $1 and $2
base_model_input="00000000000000000000"
reference_model_input="00000000000000000000"

# If the script is run with command line arguments, use them for $1 and $2
if [[ $# -eq 2 ]]; then
    base_model_input=$1
    reference_model_input=$2
fi

# Print the table header
printf "%-${model_length}s\t%-20s\t%-20s\n" "Mesh" "Base Model" "Reference Model"
printf "%-${model_length}s\t%-20s\t%-20s\n" "-------------------" "-------------------" "-------------------"

# Loop through the Mesh values and print the rows
for (( i=0; i<${#mesh_values[@]}; i++ )); do
    mesh=${mesh_values[$i]}
    mesh_code=${base_model_input:$((i*mesh_length)):mesh_length}
    # start_index=1+$i*2
    # end_index=2+$i*2
    start_index=$(expr 1 + $i \* 2)
    end_index=$(expr 2 + $i \* 2)
    base_model=$(echo $base_model_input | cut -b $start_index-$end_index)
    reference_model=$(echo $reference_model_input | cut -b $start_index-$end_index)
    printf "%-${model_length}s\t%-20s\t%-20s\n" "$mesh" "$base_model" "$reference_model"
done
