:: configure-hooks
::
:: Runs git config and sets core.hookpaths to the .githooks folder in the root of the repository.
:: This script must be run on a fresh clone of the repository to make use of the hooks in this folder.
::
:: Usage: configure-hooks.cmd
::

powershell .\configure-hooks.ps1
