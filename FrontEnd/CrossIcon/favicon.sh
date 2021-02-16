#!/usr/bin/env bash

windows_favicon=favicon.png

extract_location=favicon.rsrc
mac_favicon=favicon.mac
rm -f $mac_favicon
sips -i $windows_favicon
DeRez -only icns $windows_favicon > $extract_location
touch $mac_favicon
Rez -append $extract_location -o $mac_favicon
SetFile -a C $mac_favicon
rm $extract_location