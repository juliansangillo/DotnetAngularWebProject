:: rename-solution
::
:: Renames the solution. This script will rename the solution file and it will rename the 
:: root namespace (which should be equal to the solution) of every project in the solution. 
:: This of course includes the project files, user files if they exist, project directories, 
:: and the project references in the solution.
::
:: Before running, make sure to close the solution in all IDEs that have it open. This script 
:: will also do a clean of the obj and bin directories before running.
::
:: This script will NOT be able to rename the root namespace in your C# files. Be sure to 
:: refactor your code and rename all references to the old namespace to match the new 
:: namespace.
::
:: Usage: rename-solution.cmd -Solution <new_solution_name>
::

powershell .\rename-solution.ps1 %*
