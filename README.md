# IVLab-Template-UnityPackage

This template repository is a good starting point for creating an IV/LAB Unity package, including:
- A [Runtime assembly](Runtime) where most of your work will go.
- A pre-configured way to auto-build API documentation for your package using [DocFx](https://dotnet.github.io/docfx/index.html).

You can find more instructions and lab notes on working with Unity packages in the [Making Unity Packages](https://docs.google.com/document/d/1BWo-OIJx3uG72XyvIiO-t1jVDnXKFhoxj-o5VYO5Gq0/edit?usp=sharing) document in the ivlab-drive.

Note that if your package requires editor scripts, these should not go in the Runtime assembly, they need to go in their own Editor assembly.  The easiest way to create this is to make a copy of the Runtime directory and name it Editor.  Then, edit the .asmdef file, replacing any text that says Runtime with Editor.

    
## Getting Started

Before getting started, think of a name for your package. IVLab Unity package names should follow the convention "<YourPackage>-UnityPackage" - for example, "OBJImport-UnityPackage".  

Once you have a name in mind, click the "Use this template" button in this GitHub repository, and name your new repo accordingly.
    
Now, clone your repository on your local computer and make the following edits.  Generally speaking, we want to replace the places where the template uses "Template" with "YourPackage".
    
1. In `package.json`:
    - For the "name" field, replace "edu.umn.cs.ivlab.template" with "edu.umn.cs.ivlab.yourpackage".
    - For the "displayName" field, replace "Template" with "Your Package"
    - If your package requires a different version of Unity, feel free to edit that field to point to the minimal version of Unity that is supported.
    - For the "author" field, you can swith the contact email to be your own if you like, but please leave the author and url as the default IV/LAB ones so that all of our software will show up under the same heading in Unity's Package Manager.
    - Finally, fill in the "description" field with something useful.
2. Rename `Runtime/IVLab.Template.Runtime.asmdef` to match your package name (only change the `Template` part, and add namespaces with extra dots if you need).  To do this with git, use ```git mv Runtime/IVLab.Template/Runtime.asmdef Runtime/IVLab.<YourPackage>.Runtime.asmdef```
3. In the new `Runtime/IVLab.<YourPackage>.Runtime.asmdef`, edit the assembly `name` to match the asmdef file name.
4. Create your package, whilst following lab guidelines on Unity packages.
5. Make sure to document your code as you write it (using [C# XML comments](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments)), as shown in `Runtime/Scripts/TemplateExample.cs`.
6. Generate the documentation for your package using the instructions found in [Documentation](./Documentation).
7. After you get it working, you will probably want to delete the instructions up to this point.  You may wish to keep the instructions below in your README.md as a guide for users of YourPackage.

---

# To install `YourPackage` in a Unity Project

## Prereqs: SSH access to github.umn.edu and being a member of the IV/LAB Organization on github.umn.edu.
1. Create a [GitHub SSH key](https://docs.github.com/en/github-ae@latest/github/authenticating-to-github/connecting-to-github-with-ssh/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent) for your UMN GitHub account on your development machine.  Unity has trouble sshing with passwords; just leave the password for this key blank.
2. If you cannot see the [IV/LAB Organization on github.umn.edu](https://github.umn.edu/ivlab-cs), then ask the [Current Lab GitHub and Software Development Czar](https://docs.google.com/document/d/1p3N2YOQLKyyNpSSTtALgtXoB3Tchy4BVgEEbAG6KYfg/edit?skip_itp2_check=true&pli=1) to please add you to the org.
    
## To use the package in a read-only mode, the same way you would for packages downloaded directly from Unity
1. In Unity, open Window -> Package Manager. 
2. Click the ```+``` button
3. Select ```Add package from git URL```
4. Paste ```git@github.umn.edu:ivlab-cs/IVLab-YourPackage-UnityPackage.git``` for the latest package
5. (If YourPackage depends on other packages, then) Repeat steps 2-4 for each of these additional dependencies (list the URLs to paste).
    
## To switch to development mode so you can edit code within the package
Note: Collectively, the lab now recommends a development process where you start by adding the package to your project in read-only mode, as described above.  This way, your Unity project files will always maintain a link to download the latest version of the package from git whenever the project is loaded, and all users of the package will be including it the same way.  If/when you have a need to edit the package, the process is then to "temporarily" switch into development mode by cloning a temporary copy of the package, then edit the source as needed, test your edits for as long as you like, etc.  Finally, when you get to a good stopping point, commit and push the changes to github.  Once the latest version of your package is on github, you can then switch out of development mode.  This will cause Unity to revert to using the read-only version of the package, and since Unity knows where to access this on github, it is easy to tell Unity to use the latest available version.
    
0. Follow the read-only mode steps above.
1. Navigate your terminal or Git tool into your Unity project's main folder and clone this repository into the packages folder, e.g., ```cd Packages; git clone git@github.umn.edu:ivlab-cs/IVLab-YourPackage-UnityPackage.git YourPackage```.  This will create a YourPackage folder that contains all the sourcecode in the package.
2. Go for it.  Edit the source you just checked out; add files, etc.  However, BE VERY CAREFUL NOT TO ADD THE YourPackage FOLDER TO YOUR PROJECT'S GIT REPO.  We are essentially cloning one git repo inside another here, but we do not want to add the package repo as a submodule or subdirectory of the project's repo, we just want to temporarily work with the source.
3. When you are ready to commit and push changes to the package repo, go for it.  JUST MAKE SURE YOU DO THIS FROM WITHIN THE Packages/YourPackage DIRECTORY!  
4. Once these changes are up on github, you can switch out of "development mode" by simply deleting the YourPackage directory.  The presence of that directory is like a temporary override.  Once it is done, Unity will revert back to using the cached version of YourPackage that it originally downloaded from git.
5. The final step is to force a refresh of this cache so that you can pull in the new version of the package you just saved to github.  To do this, simply delete the [package-lock.json](https://docs.unity3d.com/Manual/upm-conflicts-auto.html) file inside your project's Packages folder.
    
    
