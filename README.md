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
2. Rename `Runtime/IVLab.Template.Runtime.asmdef` and its `.meta` file to match your package name (only change the `Template` part, but you can add namespaces with extra dots if you need).  To do this with git, use ```git mv Runtime/IVLab.Template/Runtime.asmdef Runtime/IVLab.<YourPackage>.Runtime.asmdef```
3. In the new `Runtime/IVLab.<YourPackage>.Runtime.asmdef`, edit the assembly `name` to match the asmdef file name.
4. Create your package, whilst following lab guidelines on Unity packages.
5. Make sure to document your code as you write it (using [C# XML comments](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments)), as shown in `Runtime/Scripts/TemplateExample.cs`.
6. Generate the documentation for your package using the instructions found in [Documentation](Documentation).
7. After you get it working, you will probably want to delete the instructions up to this point.  You may wish to keep the instructions in [README_INSTALL.md](README_INSTALL.md) as a guide for users of YourPackage.
