# Template-UnityPackage

Use this template repository to start a new project that you want to use as a Unity Package.  The template is already setup with these key features:
- Follows Unity requirements and recommendations for how to structure a package that works with the Unity Package Manager.  This package can be installed / removed from a Unity project using the Package Manager, and all the pieces are in the correct place for the Package Manager UI to work (i.e., clicking the View Documentation link works, clicking View License and View Changelog works, installing any Samples included with the package works.
- Follows IV/LAB conventions for naming so all packages produced by the lab show up in the same place within the Package Manager.
- Installation instructions describe the lab's current best practices for real-only and development use.
- Includes separate C# assemblies for Runtime, Editor, and Samples so these can be included individually within projects.
- Comes pre-configured for generating a documentation website using [DocFx](https://dotnet.github.io/docfx/index.html) that, depending on where your repo is hosted, can be served on either pages.github.com or pages.github.umn.edu.


## Background on Unity Packages

You can find more instructions and lab notes on working with Unity packages in the [Making Unity Packages](https://docs.google.com/document/d/1BWo-OIJx3uG72XyvIiO-t1jVDnXKFhoxj-o5VYO5Gq0/edit?usp=sharing) document in the ivlab-drive.  Note that Unity's handling of Packages is still relatively new and has evolved a lot over the past years.  So, you will see evidence in the notes from these lab meetings of us trying to make sense of the best way for us to work with them, and some of the information may be out of date.  It is safe to assume that what you see in this repository reflects the latest thinking in the lab :)

When converting an existing Unity project to a package, the most important change is to remember that you need to put any Editor scripts in a separate assembly.  In other words, most of the scripts you would normally put in Assets/Scripts should just be copied directly to Runtime/Scripts, and that's all you need to do to convert them into a package.  However, if you have any Editor directories that you would normally store under Assets/Scripts/**/Editor, those now need to go inside Editor/Scripts, which will be in the package's Editor (not Runtime) assembly.  Packages will not compile correctly if you mix the Editor and Runtime scripts in the same assembly.  

The difference between the Samples assembly and the Runtime assembly is more of a conceptual difference.  The Runtime assembly should be like a library of code that we expect to reuse in several projects.  The Samples assembly includes one or more examples of how that library could be used.  So, generally speaking, Samples is the place where you are likely to see Unity scene files and maybe a few application-specific scripts.  And, Runtime is the place where you are likely to see lower-level scripts and prefabs that could be reused in multiple Unity scenes.


## Using the Template to Create Your Package

Before getting started, think of a name for your package. IVLab Unity package names should follow the convention "YourPackage-UnityPackage", where "YourPackage" is the name you have picked - for example, "OBJImport-UnityPackage".  

Once you have a name in mind, click the "Use this template" button in this GitHub repository, and name your new repo accordingly.

Now, clone your repository on your local computer and make the following edits.  Generally speaking, we want to replace the places where you see "Template" with "YourPackage".  These steps highlight the important areas where you need to be sure to do this:

1. In `package.json`:
    - For the "name" field, replace "edu.umn.cs.ivlab.template" with "edu.umn.cs.ivlab.yourpackage".
    - For the "displayName" field, replace "Template" with "Your Package"
    - If your package requires a different version of Unity, feel free to edit that field to point to the minimal version of Unity that is supported.
    - For the "author" field, you can switch the contact email to be your own if you like, but please leave the author and url as the default IV/LAB ones so that all the lab's software will show up under the same heading in Unity's Package Manager.
    - Finally, fill in the "description" field with something useful.
2. Rename `Runtime/IVLab.Template.Runtime.asmdef` and its `.meta` file to match your package name (only change the `Template` part, but you can add namespaces with extra dots if you need).  To do this with git, use ```git mv Runtime/IVLab.Template/Runtime.asmdef Runtime/IVLab.<YourPackage>.Runtime.asmdef```
3. Open the new `Runtime/IVLab.<YourPackage>.Runtime.asmdef` file in a text editor and edit the assembly `name` to match the asmdef file name.
4. Divide the scripts and other assets you want to include in your package between the Runtime, Editor, and Samples~ directories, using the guidelines described above for what should go where.  You can remove or rename and edit the placeholder files in these directories, like ExampleClass.cs if you want.  It's a good idea to make sure all your code is defined within a namespace, like IVLab.YourPackage.  The template includes an example of using a IVLab.Template namespace in  [ExampleClass.cs](Runtime/Scripts/ExampleClass.cs).
5. Before committing your package to github, start a new Unity project and just move the entire package repo folder into the new project's Assets folder.  Open or switch to Unity and let it load and compile the scripts in your package.   This serves two purposes: (1) You can make sure there are no errors in your scripts.  (2) This forces Unity to generate .meta files for all of the files in your package.   *When you push your package up to github, you WILL want to add the .meta files that Unity automatically generates to your github commit.*  You do not see those files in this template already because they are supposed to hold a unique id, and that id will not be unique if we put it into a template that gets copied to create all of our various packages!
6. After your meta files are generated, use `git add`, `git commit`, and `git push` to update your package repo on github.  Then, you are ready for your first test of installing the package via the Unity package manager.  Follow the instructions in [README_INSTALL.md](README_INSTALL.md) to try installing the package the same way you will ask your users to.
7. When you are ready to turn to writing some documentation for your package, follow the instructions in [README_DOCUMENTATION.md](README_DOCUMENTATION.md).  You will need to change a few more instances of "Template" to "YourProject" inside the DocumentationSrc~ directory and setup github pages to host your site.
8. After you get your package working and are ready to share it with others, you will probably want to delete the instructions in this file and replace them with your own readme info.  You may wish to keep the instructions in [README_INSTALL.md](README_INSTALL.md) and [README_DOCUMENTATION.md](README_DOCUMENTATION.md) as guides for users and developers.
    
    
Additional Notes: 
- If you do not want to include the documentation, editor assembly, or samples assembly in your package, you can safely remove those directories from your git repo.  They can be challenging to setup, so it is useful to default to including them in the template, but the only required part of the package is the Runtime assembly.
- The template includes placeholder [LICENSE.md](LICENSE.md) and [CHANGELOG.md](CHANGELOG.md) files that are loaded when you click the "View Licences" and "View Changelog" links in Unity's Package Manager.  
    - The one-line placeholder license is really a copyright statement that the UMN Office of Tech Commercialization (OTC) recommends as a default when you are not sure if/how you would like to license the code.  Before changing this and releasing the code publicly, please discuss this with Dan so that we can follow the latest recommendations on open source licensing from the OTC.
    - A changelog will likely be overkill for many of our smaller packages, but it is nice to have a placeholder to avoid an error when clicking the "View changelog" link that Unity enables for every package.


## Modifying This Template

- For the reason described above, be careful not to commit any .meta files to the original template repository used by the whole lab.
