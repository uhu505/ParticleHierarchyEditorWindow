# ParticleHierarchyEditorWindow
This code provides a tool to manipulate the Particle Hierarchy in Unity Editor. Below are explanations of what the code does and how it benefits:

1. The code creates a custom window called "ParticleHierarchyEditorWindow", which is a subclass of EditorWindow. This window provides a user interface within the Unity Editor and is used to process selected GameObjects.

2. The window offers convenience to the user when working with selected GameObjects. If an object is selected, the user can define the project name and child object name, and create child objects under the selected GameObject using Particle Properties.

3. If no Particle Properties object is assigned, the code prompts the user to make an appropriate assignment and displays a warning.

4. If an object is selected, the project name is automatically populated with the name of the selected object, and the user can enter the child object name. When the "Create" button is clicked, a child object is created under the selected object using the Particle Properties.

5. If no object is selected, the user can enter their own project name and child object name. When the "Create" button is clicked, a new GameObject is created and assigned the project name. If Particle Properties is assigned, a child object is created under this new GameObject with the given child object name.

6. Clicking the "Clear" button resets the selected object, project name, child object name, and Particle Properties to their default values.

This code enables users to easily manage the Particle Hierarchy and streamlines the workflow when creating child objects using Particle Properties.


*How to Install?*

1. Download the ParticleHierarchyEditor C# file.

2. Drag and drop the file to any location in the Unity Project window.

![Ekran görüntüsü 2023-05-23 232403](https://github.com/uhu505/ParticleHierarchyEditorWindow/assets/68116848/090be77f-ec43-43ef-985b-7ea207fb5bce)

3.Select "Window" and then "Particle Hierarchy Editor" to open the window, and place it wherever you prefer.

![Ekran görüntüsü 2023-05-23 232502](https://github.com/uhu505/ParticleHierarchyEditorWindow/assets/68116848/795625a3-db2b-4425-b708-0d71f9d21a18)

4.Create a particle system object in the hierarchy and customize the desired properties to be used as the default settings.

5.Whether you make this object a prefab or use it directly in the scene, make sure to assign it to the Particle Properties field.

![Screenshot_2](https://github.com/uhu505/ParticleHierarchyEditorWindow/assets/68116848/e8699e70-515f-4852-8a8e-25428d728be6)

![Screenshot_1](https://github.com/uhu505/ParticleHierarchyEditorWindow/assets/68116848/0de16076-438d-4720-a10b-697c18ed7415)

29.05.2023 Updated!

You can now add multiple child objects to the selected object or the project you're creating within the hierarchy!


https://github.com/uhu505/ParticleHierarchyEditorWindow/assets/68116848/32d48d45-1836-4f18-bcfe-7b5d8a35c1e6



How to use?
https://vimeo.com/829587150?share=copy

Lastly, please be cautious when using the tool in your personal projects as you may experience crashes. I haven't taken extensive precautions against potential issues that may arise from modifications beyond what I specified in the plugin description. Thank you.

*License

This project is distributed under the GNU General Public License (GPL) v3. For the full text of the license, please refer to the LICENSE file.
