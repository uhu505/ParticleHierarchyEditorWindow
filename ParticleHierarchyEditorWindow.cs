using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ParticleHierarchyEditorWindow : EditorWindow
{
    private GameObject selectedObject;
    private bool isObjectSelected;
    private string projectName = "";
    private List<string> childObjectNames = new List<string>();
    private GameObject particleProperties;
    private bool hasParticleProperties;
    private string debugWarning = "";
    private bool showWarning;

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
                UpdateChildObjectNames();
            }
            else
            {
                projectName = "";
                childObjectNames.Clear();
            }

            Repaint();
        }
    }

    void UpdateChildObjectNames()
    {
        childObjectNames.Clear();

        if (isObjectSelected)
        {
            Transform selectedTransform = selectedObject.transform;
            for (int i = 0; i < selectedTransform.childCount; i++)
            {
                Transform childTransform = selectedTransform.GetChild(i);
                childObjectNames.Add(childTransform.name);
            }
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
        }
        else
        {
            projectName = EditorGUILayout.TextField("Project Name: ", projectName);
        }

        EditorGUILayout.LabelField("Child Objects:");

        // Child Object listesi için GUI çizimi
        for (int i = 0; i < childObjectNames.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            childObjectNames[i] = EditorGUILayout.TextField("Name: ", childObjectNames[i]);
            if (GUILayout.Button("Remove"))
            {
                childObjectNames.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        // Yeni Child Object ekleme butonu
        if (GUILayout.Button("Add Child Object"))
        {
            childObjectNames.Add("");
        }

        if (GUILayout.Button("Create"))
        {
            if (childObjectNames.Count == 0 && isObjectSelected)
            {
                showWarning = true;
                debugWarning = "Please add at least one child object.";
                EditorGUILayout.HelpBox(debugWarning, MessageType.Warning);
                return;
            }

            if (string.IsNullOrEmpty(projectName))
            {
                showWarning = true;
                debugWarning = "Please fill in the project name.";
                EditorGUILayout.HelpBox(debugWarning, MessageType.Warning);
                return;
            }

            bool hasEmptyChildNames = false;
            foreach (string childObjectName in childObjectNames)
            {
                if (string.IsNullOrEmpty(childObjectName))
                {
                    hasEmptyChildNames = true;
                    break;
                }
            }

            if (hasEmptyChildNames)
            {
                showWarning = true;
                debugWarning = "Please fill in all child object names.";
                EditorGUILayout.HelpBox(debugWarning, MessageType.Warning);
                return;
            }

            if (hasParticleProperties)
            {
                if (isObjectSelected)
                {
                    CreateChildObjects(selectedObject.transform);
                }
                else
                {
                    CreateParentObject();
                }

                showWarning = false;
            }
        }

        if (GUILayout.Button("Clear"))
        {
            ClearFields();
        }

        if (particleProperties == null)
        {
            EditorGUILayout.HelpBox("Please assign a particle properties object.", MessageType.Warning);
            ClearFields();
        }

        if (showWarning)
        {
            EditorGUILayout.HelpBox(debugWarning, MessageType.Warning);
        }
    }

    void CreateParentObject()
    {
        GameObject parentObject = Instantiate(particleProperties);
        parentObject.name = projectName;

        CreateChildObjects(parentObject.transform);

        Debug.Log("Project object created: " + projectName);
    }

    void CreateChildObjects(Transform parentTransform)
    {
        foreach (string childObjectName in childObjectNames)
        {
            if (!string.IsNullOrEmpty(childObjectName))
            {
                GameObject childObject = Instantiate(particleProperties, parentTransform);
                childObject.name = childObjectName;

                Debug.Log("Child object created: " + childObjectName);
            }
        }
    }

    void ClearFields()
    {
        selectedObject = null;
        isObjectSelected = false;
        projectName = "";
        childObjectNames.Clear();
        particleProperties = null;
        hasParticleProperties = false;
        showWarning = false;
    }
}
