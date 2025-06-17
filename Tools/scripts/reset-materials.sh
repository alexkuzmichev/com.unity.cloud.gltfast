#!/bin/sh

set -e

pwd=$(cd -P -- "$(dirname -- "$0")" && printf '%s\n' "$(pwd -P)")
source "$pwd/common.sh"

reset_materials
