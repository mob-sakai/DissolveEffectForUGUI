using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIExtensions
{
	public static class MaterialBundle
	{
		[MenuItem("UIEffect/Generate Material Bundle")]
		static void Generate()
		{
#if UIEFFECT_SEPARATE
			// On "UIEFFECT_SEPARATE" mode, generate effect materials on demand.
			return;
#endif

			// Export materials.
			AssetDatabase.StartAssetEditing();

			GenerateMaterialVariants(
				Shader.Find(UIDissolve.shaderName)
				, (ColorMode[])Enum.GetValues(typeof(ColorMode))
			);

			AssetDatabase.StopAssetEditing();
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		static void GenerateMaterialVariants(Shader shader, ColorMode[] colors)
		{
			for (int i = 0; i < colors.Length; i++)
			{
				var name = MaterialResolver.GetVariantName(shader, colors[i]);
				EditorUtility.DisplayProgressBar("Genarate Effect Material Bundle", name, (float)i / colors.Length);

				MaterialResolver.GetOrGenerateMaterialVariant(shader, colors[i]);
			}
			EditorUtility.ClearProgressBar();
		}
	}
}