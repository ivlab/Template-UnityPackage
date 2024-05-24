# To install `Template` in a Unity Project

## Install via the Unity Package Manager
To use the package in a read-only mode, the same way you would for packages downloaded directly from Unity:
1. In Unity, open Window -> Package Manager.
2. Click the ```+``` button
3. Select ```Add package from git URL```
4. Paste ```https://github.com/ivlab/Template-UnityPackage.git``` for the latest package
5. [If needed] Repeat steps 2-4 for each of these additional package dependencies:
  - ```https://github.com/ivlab/TemplateDependency1-UnityPackage.git```
  - ```https://github.com/ivlab/TemplateDependency2-UnityPackage.git```
  - ...

## Development Mode
Collectively, the lab now recommends a development process where you start by adding the package to your project in read-only mode, as described above.  This way, your Unity project files will always maintain a link to download the latest version of the package from git whenever the project is loaded, and all users of the package will be including it the same way.  If/when you have a need to edit the package, the process is then to "temporarily" switch into development mode by cloning a temporary copy of the package.  Then, edit this source as needed, test your edits for as long as you like, etc.  When you get to a good stopping point, commit and push the changes to github *from within this temporary clone inside the Packages directory*.  Once the latest version of your package is on github, you can then "switch out of development mode" by deleting the cloned repo.  This will cause Unity to revert to using the read-only version of the package, which it keeps in its internal package cache, and we can trigger Unity to update this version to the latest by removing the packages-lock.json file.  In summary:

0. Follow the read-only mode steps above.
1. Navigate your terminal or Git tool into your Unity project's main folder and clone this repository into the packages folder, e.g., ```cd Packages; git clone https://github.com/ivlab/MyPackage-UnityPackage.git```.  This will create a folder that contains all the sourcecode in the package.
2. Go for it.  Edit the source you just checked out; add files, etc.  However, BE VERY CAREFUL NOT TO ADD THE Template-UnityPackage FOLDER TO YOUR PROJECT'S GIT REPO.  We are essentially cloning one git repo inside another here, but we do not want to add the package repo as a submodule or subdirectory of the project's repo, we just want to temporarily work with the source.
3. When you are ready to commit and push changes to the package repo, go for it.  JUST MAKE SURE YOU DO THIS FROM WITHIN THE Packages/MyPackage-UnityPackage DIRECTORY!  
4. Once these changes are up on github, you can switch out of "development mode" by simply deleting the Template-UnityPackage directory.  The presence of that directory is like a temporary override.  Once it is gone, Unity will revert back to using the cached version of Template that it originally downloaded from git.
5. The final step is to force a refresh of the package cache so that Unity will pull in the new version of the package you just saved to github.  To do this, simply delete the [packages-lock.json](https://docs.unity3d.com/Manual/upm-conflicts-auto.html) file inside your project's Packages folder.
