#! /bin/bash
#
# rename-solution
#
# Renames the solution. This script will rename the solution file and it will rename the root namespace (which should be equal to 
# the solution) of every project in the solution. This of course includes the project files, user files if they exist, project directories, 
# and the project references in the solution.
#
# Before running, make sure to close the solution in all IDEs that have it open. This script will also do a clean of the obj and bin 
# directories before running.
# 
# This script will NOT be able to rename the root namespace in your C# files. Be sure to refactor your code and rename all 
# references to the old namespace to match the new namespace.
#
# Usage: rename-solution.sh -s <new_solution_name>
#

while getopts s: flag; do
  case "${flag}" in
    s) new_solution_name=${OPTARG};;
  esac
done

if [ -z "$new_solution_name" ]; then
  echo Parameter \'new_solution_name\' is required. Please try again with \'-s \<new_solution_name\>\'
  exit 1
fi

script_dir="$(dirname "$0")"
root_dir="$script_dir/../.."
solution_path="$(find "$root_dir" -maxdepth 1 -type f -name '*.sln' | head -n 1)"
solution_name=$(basename "$solution_path" .sln)
new_solution_path="$root_dir/${new_solution_name}.sln"

# Clean obj and bin
echo Cleaning obj and bin directories
"$script_dir"/clean-obj-and-bin.sh

# Rename solution
echo Renaming solution file from \"$solution_path\" to \"$new_solution_path\"
mv "$solution_path" "$new_solution_path"

# Rename projects
echo Renaming projects:
mapfile -t project_paths < <(find "$root_dir" -type f -regextype grep -regex ".*/$solution_name\..*csproj")
for project_path in "${project_paths[@]}"; do
  # Remove old project reference
  echo Removing reference to \"$project_path\" from solution
  dotnet sln "$new_solution_path" remove "$project_path"

  project_name="^$(basename "$project_path" .csproj)$"
  project_dir="$(dirname "$project_path")"
  user_path="$(find "$project_dir" -maxdepth 1 -type f -name "*.csproj.user")"

  new_project_name="${project_name//^$solution_name./^$new_solution_name.}"
  new_project_name="${new_project_name//^$solution_name$/^$new_solution_name$}"
  new_project_name="${new_project_name//^}"
  new_project_name="${new_project_name//$}"

  new_project_path="$project_dir/$new_project_name.csproj"

  # Rename project file
  echo Renaming \"$project_path\" as \"$new_project_path\"
  mv "$project_path" "$new_project_path"

  # Rename project user file, if it exists
  if [ -n "$user_path" ]; then
    new_user_path="$project_dir/$new_project_name.csproj.user"
    echo Renaming \"$user_path\" as \"$new_user_path\"
    mv "$user_path" "$new_user_path"
  fi

  # Rename project directory
  parent_dir="$(dirname "$project_dir")"
  new_project_dir="$parent_dir/$new_project_name"
  echo Renaming project folder \"$project_dir/\" to the new project folder \"$new_project_dir/\"
  mv "$project_dir" "$new_project_dir"
  
  # Add new project reference
  new_project_path="$new_project_dir/$new_project_name.csproj"
  echo Adding reference to \"$new_project_path\" to solution
  dotnet sln "$new_solution_path" add "$new_project_path"
done

echo Done
