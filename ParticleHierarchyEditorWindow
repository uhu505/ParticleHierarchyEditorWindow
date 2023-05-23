using UnityEngine;
using UnityEditor;

public class ParticleHierarchyEditorWindow : EditorWindow
{
    private GameObject selectedObject;
    private bool isObjectSelected;
    private string projectName = "";
    private string childObjectName = "";
    private GameObject particleProperties;
    private bool hasParticleProperties;

    [MenuItem("Window/Particle Hierarchy Editor")]
    static void Init()
    {
        ParticleHierarchyEditorWindow window = (ParticleHierarchyEditorWindow)EditorWindow.GetWindow(typeof(ParticleHierarchyEditorWindow));
        window.Show();
        EditorApplication.update += window.UpdateSelection;
    }

    void OnDestroy()
    {
        EditorApplication.update -= UpdateSelection;
    }

    void UpdateSelection()
    {
        GameObject currentSelectedObject = Selection.activeGameObject;

        if (currentSelectedObject != selectedObject)
        {
            selectedObject = currentSelectedObject;
            isObjectSelected = (selectedObject != null);

            if (isObjectSelected)
            {
                projectName = selectedObject.name;
            }
            else
            {
                projectName = "";
            }

            Repaint();
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Particle Hierarchy Editor", EditorStyles.boldLabel);

        particleProperties = EditorGUILayout.ObjectField("Particle Properties: ", particleProperties, typeof(GameObject), true) as GameObject;
        hasParticleProperties = (particleProperties != null);

        if (!hasParticleProperties)
        {
            EditorGUILayout.HelpBox("Please assign a particle properties object.", MessageType.Warning);
            return;
        }

        if (isObjectSelected)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextField("Project Name: ", projectName);
            EditorGUI.EndDisabledGroup();

            childObjectName = EditorGUILayout.TextField("Child Object Name: ", childObjectName);

            if (GUILayout.Button("Create"))
            {
                if (selectedObject != null && hasParticleProperties)
                {
                    if (!string.IsNullOrEmpty(childObjectName))
                    {
                        GameObject childObject = Instantiate(particleProperties, selectedObject.transform);
                        childObject.name = childObjectName;

                        Debug.Log("Child object created: " + childObjectName);
                    }
                }
            }
        }
        else
        {
            projectName = EditorGUILayout.TextField("Project Name: ", projectName);
            childObjectName = EditorGUILayout.TextField("Child Object Name: ", childObjectName);

            if (GUILayout.Button("Create"))
            {
                if (hasParticleProperties)
                {
                    GameObject parentObject = Instantiate(particleProperties);
                    parentObject.name = projectName;

                    if (!string.IsNullOrEmpty(childObjectName))
                    {
                        GameObject childObject = Instantiate(particleProperties, parentObject.transform);
                        childObject.name = childObjectName;

                        Debug.Log("Child object created: " + childObjectName);
                    }

                    Debug.Log("Project object created: " + projectName);
                }
            }
        }

        if (GUILayout.Button("Clear"))
        {
            selectedObject = null;
            isObjectSelected = false;
            projectName = "";
            childObjectName = "";
            particleProperties = null;
            hasParticleProperties = false;
        }

        if (particleProperties == null)
        {
            EditorGUILayout.HelpBox("Please assign a particle properties object.", MessageType.Warning);
            selectedObject = null;
            isObjectSelected = false;
            projectName = "";
            childObjectName = "";
        }

    }
}
