#!/usr/bin/env bash
windows_favicon=favicon.png
mac_favicon=favicon.mac
rm -f $mac_favicon
sips -i $windows_favicon
DeRez -only icns $windows_favicon > favicon.rsrc
touch $mac_favicon
Rez -append favicon.rsrc -o $mac_favicon
SetFile -a C $mac_favicon
rm favicon.rsrc