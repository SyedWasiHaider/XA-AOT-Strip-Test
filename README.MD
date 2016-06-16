# Android AOT + Partial IL Stripping Example

This project is an example of how one could AOT their Android project and IL strip _some_ of their DLLs. _Some_ because this process only seems to work when we're IL stripping platform-independent code.

### Let's see this in action

1. Open up the solution (aotstriptest.sln) in Xamarin Studio
2. Ensure the configuration is correct. (This should already be configured but just in case):
    * Double click on the Android project
    * Select "Android Build" from the left panel
    * Change the configuration dropdown on the top to say "Release"
    * On the general tab make sure everything except for "Enable AOT (Experimental)" is selected. [AOT+LLVM](https://developer.xamarin.com/releases/android/xamarin.android_6/xamarin.android_6.1/#Known_Issues) does not work
    * On the advanced tab, select the ABI's you wish to support. Note that x86_64 is not currently supported.
    * Click ok

It should look like this:

![alt options](https://gist.github.com/SyedWasiHaider/d22cb78feebe6342006d738ac72be1d7/raw/6284f50830d1acbf9b533e434e8c11bcedb26ac3/z-options.png)

3. Build and deploy the project for Release

At this point you should see a very simple app in your emulator/device. Click the button on the screen and you should see the text change.

![alt options](https://gist.github.com/SyedWasiHaider/d22cb78feebe6342006d738ac72be1d7/raw/6284f50830d1acbf9b533e434e8c11bcedb26ac3/z-emulator.png)

4. Go to your terminal and navigate to the project root.
5. Run the strip.sh script

Essentially what it does is :
* Unzip the apk
* Strip the platform-independent assembly using mono-cil-strip
* Repackage the apk
* Uninstalls the old apk and reinstalls the new one.
* Launch the app.

At this point you can try and click on the button again and you can see that it is still working.


### What did we actually strip?

Lets look at the IL for the unstripped version.

    //Assuming you're at the root of the project
    $ monodis bin/Release/supersecretlib.dll > unstripped-lib.il

Looking inside we see:

[unstripped-lib.il](https://gist.github.com/SyedWasiHaider/d22cb78feebe6342006d738ac72be1d7#file-unstripped-lib-il)

Ok now let's disassemble the stripped version:

    $ monodis bin/Release/stripped/assemblies/supersecretlib.dll > stripped-lib.il
    
Looking inside we see only references to class names and members remain.

[stripped-lib.il](https://gist.github.com/SyedWasiHaider/d22cb78feebe6342006d738ac72be1d7#file-stripped-lib-il)


