using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using System.IO;
using System.Linq;
using UnityEditor;
#endif

namespace Coffee.UIExtensions
{
	/// <summary>
	/// UIDissolve.
	/// </summary>
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class UIDissolve : BaseMeshEffect
#if UNITY_EDITOR
		, ISerializationCallbackReceiver
#endif
	{
		//################################
		// Constant or Static Members.
		//################################
		public const string shaderName = "UI/Hidden/UI-Effect-Dissolve";

		/// <summary>
		/// Color effect mode.
		/// </summary>
		public enum ColorMode
		{
			None = 0,
			Set,
			Add,
			Sub,
		}

		//################################
		// Serialize Members.
		//################################
		[SerializeField] [Range(0, 1)] float m_Location = 0.5f;
		[SerializeField] [Range(0, 1)] float m_Width = 0.5f;
		[SerializeField] [Range(0, 1)] float m_Softness = 0.5f;
		[SerializeField] [ColorUsage(false)] Color m_Color = new Color(0.0f, 0.25f, 1.0f);
		[SerializeField] ColorMode m_ColorMode = ColorMode.Add;
		[SerializeField] Material m_EffectMaterial;
		

		//################################
		// Public Members.
		//################################
		/// <summary>
		/// Graphic affected by effect.
		/// </summary>
		new public Graphic graphic { get { return base.graphic; } }

		/// <summary>
		/// Location for effect.
		/// </summary>
		public float location { get { return m_Location; } set { m_Location = Mathf.Clamp(value, 0, 1); _SetDirty(); } }

		/// <summary>
		/// Edge width.
		/// </summary>
		public float width { get { return m_Width; } set { m_Width = Mathf.Clamp(value, 0, 1); _SetDirty(); } }

		/// <summary>
		/// Edge softness.
		/// </summary>
		public float softness { get { return m_Softness; } set { m_Softness = Mathf.Clamp(value, 0, 1); _SetDirty(); } }

		/// <summary>
		/// Edge color.
		/// </summary>
		public Color color { get { return m_Color; } set { m_Color = value; _SetDirty(); } }

		/// <summary>
		/// Color effect mode.
		/// </summary>
		public ColorMode colorMode { get { return m_ColorMode; } }

		/// <summary>
		/// Effect material.
		/// </summary>
		public virtual Material effectMaterial { get { return m_EffectMaterial; } }

		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		protected override void OnEnable()
		{
			graphic.material = effectMaterial;
			base.OnEnable();
		}

		/// <summary>
		/// This function is called when the behaviour becomes disabled () or inactive.
		/// </summary>
		protected override void OnDisable()
		{
			graphic.material = null;
			base.OnDisable();
		}

#if UNITY_EDITOR
		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			var obj = this;
			EditorApplication.delayCall += () =>
			{
				if (Application.isPlaying || !obj || !obj.graphic)
					return;
				
				var mat = GetOrGenerateMaterialVariant(Shader.Find(shaderName), m_ColorMode);

				if (m_EffectMaterial == mat && graphic.material == mat)
					return;

				graphic.material = m_EffectMaterial = mat;
				EditorUtility.SetDirty(this);
				EditorUtility.SetDirty(graphic);
				EditorApplication.delayCall += AssetDatabase.SaveAssets;
			};
		}

		public static Material GetMaterial(Shader shader, ColorMode color)
		{
			string variantName = GetVariantName(shader, color);
			return AssetDatabase.FindAssets("t:Material " + Path.GetFileName(shader.name))
				.Select(x => AssetDatabase.GUIDToAssetPath(x))
				.SelectMany(x => AssetDatabase.LoadAllAssetsAtPath(x))
				.OfType<Material>()
				.FirstOrDefault(x => x.name == variantName);
		}


		public static Material GetOrGenerateMaterialVariant(Shader shader, ColorMode color)
		{
			if (!shader)
				return null;

			Material mat = GetMaterial(shader, color);

			if (!mat)
			{
				Debug.Log("Generate material : " + GetVariantName(shader, color));
				mat = new Material(shader);
				
				if (0 < color)
					mat.EnableKeyword("UI_COLOR_" + color.ToString().ToUpper());

				mat.name = GetVariantName(shader, color);
				mat.hideFlags |= HideFlags.NotEditable;

#if UIEFFECT_SEPARATE
				bool isMainAsset = true;
				string dir = Path.GetDirectoryName(GetDefaultMaterialPath (shader));
				string materialPath = Path.Combine(Path.Combine(dir, "Separated"), mat.name + ".mat");
#else
				bool isMainAsset = (0 == color);
				string materialPath = GetDefaultMaterialPath(shader);
#endif
				if (isMainAsset)
				{
					Directory.CreateDirectory(Path.GetDirectoryName(materialPath));
					AssetDatabase.CreateAsset(mat, materialPath);
					AssetDatabase.SaveAssets();
				}
				else
				{
					mat.hideFlags |= HideFlags.HideInHierarchy;
					AssetDatabase.AddObjectToAsset(mat, materialPath);
				}
			}
			return mat;
		}

		public static string GetDefaultMaterialPath(Shader shader)
		{
			var name = Path.GetFileName(shader.name);
			return AssetDatabase.FindAssets("t:Material " + name)
				.Select(x => AssetDatabase.GUIDToAssetPath(x))
				.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == name)
				?? ("Assets/DissolveEffectForUGUI/" + name + ".mat");
		}

		public static string GetVariantName(Shader shader, ColorMode color)
		{
			return
#if UIEFFECT_SEPARATE
				"[Separated] " + Path.GetFileName(shader.name)
#else
				Path.GetFileName(shader.name)
#endif
				+ (0 < color ? "-" + color : "");
		}
#endif

		/// <summary>
		/// Modifies the mesh.
		/// </summary>
		public override void ModifyMesh(VertexHelper vh)
		{

			if (!IsActive())
				return;

			// rect.
			Rect rect = graphic.rectTransform.rect;

			// Calculate vertex position.
			UIVertex vertex = default(UIVertex);
			for (int i = 0; i < vh.currentVertCount; i++)
			{
				vh.PopulateUIVertex(ref vertex, i);

				var x = Mathf.Clamp01 (vertex.position.x / rect.width + 0.5f);
				var y = Mathf.Clamp01 (vertex.position.y / rect.height + 0.5f);
				vertex.uv1 = new Vector2 (_PackToFloat (x, y, location, m_Width), _PackToFloat(m_Color.r, m_Color.g, m_Color.b, m_Softness));

				vh.SetUIVertex(vertex, i);
			}
		}

		//################################
		// Private Members.
		//################################
		/// <summary>
		/// Mark the graphic as dirty.
		/// </summary>
		void _SetDirty()
		{
			if(graphic)
				graphic.SetVerticesDirty();
		}

		/// <summary>
		/// Pack 3 low-precision [0-1] floats values to a float.
		/// Each value [0-1] has 256 steps(8 bits).
		/// </summary>
		static float _PackToFloat(float x, float y, float z)
		{
			const int PRECISION = (1 << 8) - 1;
			return (Mathf.FloorToInt(z * PRECISION) << 16)
			+ (Mathf.FloorToInt(y * PRECISION) << 8)
			+ Mathf.FloorToInt(x * PRECISION);
		}

		/// <summary>
		/// Pack 4 low-precision [0-1] floats values to a float.
		/// Each value [0-1] has 64 steps(6 bits).
		/// </summary>
		static float _PackToFloat(float x, float y, float z, float w)
		{
			const int PRECISION = (1 << 6) - 1;
			return (Mathf.FloorToInt(w * PRECISION) << 18)
			+ (Mathf.FloorToInt(z * PRECISION) << 12)
			+ (Mathf.FloorToInt(y * PRECISION) << 6)
			+ Mathf.FloorToInt(x * PRECISION);
		}
	}
}
