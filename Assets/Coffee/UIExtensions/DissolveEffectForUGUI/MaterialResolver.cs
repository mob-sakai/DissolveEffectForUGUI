#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System.Linq;

namespace Coffee.UIExtensions
{
	public class MaterialResolver
	{

		public static Material GetOrGenerateMaterialVariant (Shader shader, ToneMode tone, ColorMode color, BlurMode blur)
		{
			if (!shader)
				return null;

			Material mat = GetMaterial (shader, tone, color, blur);

			if (!mat) {
				Debug.Log ("Generate material : " + GetVariantName (shader, tone, color, blur));
				mat = new Material (shader);

				if (0 < tone)
					mat.EnableKeyword ("UI_TONE_" + tone.ToString ().ToUpper ());
				if (0 < color)
					mat.EnableKeyword ("UI_COLOR_" + color.ToString ().ToUpper ());
				if (0 < blur)
					mat.EnableKeyword ("UI_BLUR_" + blur.ToString ().ToUpper ());

				mat.name = GetVariantName (shader, tone, color, blur);
				mat.hideFlags |= HideFlags.NotEditable;

#if UIEFFECT_SEPARATE
				bool isMainAsset = true;
				string dir = Path.GetDirectoryName(GetDefaultMaterialPath (shader));
				string materialPath = Path.Combine(Path.Combine(dir, "Separated"), mat.name + ".mat");
#else
				bool isMainAsset = (0 == tone) && (0 == color) && (0 == blur);
				string materialPath = GetDefaultMaterialPath (shader);
#endif
				if (isMainAsset) {
					Directory.CreateDirectory (Path.GetDirectoryName (materialPath));
					AssetDatabase.CreateAsset (mat, materialPath);
					AssetDatabase.SaveAssets ();
				} else {
					mat.hideFlags |= HideFlags.HideInHierarchy;
					AssetDatabase.AddObjectToAsset (mat, materialPath);
				}
			}
			return mat;
		}

		public static Material GetMaterial (Shader shader, ToneMode tone, ColorMode color, BlurMode blur)
		{
			string variantName = GetVariantName (shader, tone, color, blur);
			return AssetDatabase.FindAssets ("t:Material " + Path.GetFileName (shader.name))
			.Select (x => AssetDatabase.GUIDToAssetPath (x))
			.SelectMany (x => AssetDatabase.LoadAllAssetsAtPath (x))
			.OfType<Material> ()
			.FirstOrDefault (x => x.name == variantName);
		}

		public static string GetDefaultMaterialPath (Shader shader)
		{
			var name = Path.GetFileName (shader.name);
			return AssetDatabase.FindAssets ("t:Material " + name)
			.Select (x => AssetDatabase.GUIDToAssetPath (x))
			.FirstOrDefault (x => Path.GetFileNameWithoutExtension (x) == name)
			?? ("Assets/Coffee/UIExtensions/UIEffect/Materials/" + name + ".mat");
		}

		public static string GetVariantName (Shader shader, ToneMode tone, ColorMode color, BlurMode blur)
		{
			return
			#if UIEFFECT_SEPARATE
			"[Separated] " + Path.GetFileName(shader.name)
			#else
			Path.GetFileName (shader.name)
			#endif
			+ (0 < tone ? "-" + tone : "")
			+ (0 < color ? "-" + color : "")
			+ (0 < blur ? "-" + blur : "");
		}
	}
}
#endif
