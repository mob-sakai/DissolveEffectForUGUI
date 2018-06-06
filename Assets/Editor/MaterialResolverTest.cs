using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Coffee.UIExtensions;

public class NewEditorTest {

	[Test]
	public void EditorTest() {
		Debug.Log (MaterialResolver.GetVariantName(Shader.Find(UIDissolve.shaderName), ColorMode.Add));

	}
}
