# clean-obj-and-bin
#
# Deletes all the obj and bin directories in the entire solution, forcing .NET to rebuild everything fresh. This can be useful as 
# dotnet clean does not delete these directories entirely and deleting them completely may fix certain build issues you are facing.
#
# These directories are the results of builds in .NET and will get regenerated.
#
# Usage: clean-obj-and-bin.ps1
#

sh shell\clean-obj-and-bin.sh
