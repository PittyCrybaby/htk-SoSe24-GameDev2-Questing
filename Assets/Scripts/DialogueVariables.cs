using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.Windows;
using System.IO;
using File = System.IO.File;
using Object = Ink.Runtime.Object;

public class DialogueVariables
{
    private Dictionary<string, Ink.Runtime.Object> _variables;

    public DialogueVariables(string globalsFilePath)
    {
        
        string inkFileContents = File.ReadAllText(globalsFilePath);
        Ink.Compiler compiler = new Ink.Compiler(inkFileContents);
        Story globalVaraiblesStory = compiler.Compile();
        

        _variables = new Dictionary<string, Object>();
        foreach (string name in globalVaraiblesStory.variablesState)
        {
            Object value = globalVaraiblesStory.variablesState.GetVariableWithName(name);
            _variables.Add(name, value);
            Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }
    public void StartListening(Story story)
    {
        VariablesToStrory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListeting(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }
    
    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        Debug.Log("Variable Changed: " + name + " = " + value);
        if (_variables.ContainsKey(name))
        {
            _variables.Remove(name);
            _variables.Add(name, value);
        }
    }

    private void VariablesToStrory(Story story)
    {
        foreach (KeyValuePair<string, Object> variable in _variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
