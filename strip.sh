#!/bin/bash

cd bin/Release
rm -rf stripped
mkdir stripped
cp *-Signed.apk stripped
cd stripped
unzip *-Signed.apk
rm *-Signed.apk
mono-cil-strip assemblies/supersecretlib.dll
zip -0 -r -D new.apk .
jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore ~/.local/share/Xamarin/Mono\ for\ Android/debug.keystore  -storepass android new.apk androiddebugkey
zipalign -f -v 4 new.apk zippy.apk
adb devices
adb uninstall com.wasi.aotstriptest
adb install zippy.apk 
adb shell monkey -p com.wasi.aotstriptest -c android.intent.category.LAUNCHER 1
