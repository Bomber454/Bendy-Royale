using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextVertexSlowFadeIn : BaseMeshEffect
{

	public Text textField;
	//public int vertIndex;
	//public int vertMax;
	[Range(0,1)]
	public float trail = 0.5f;

	[Range(0,1)]
	public float progression;






	public override void ModifyMesh(VertexHelper helper)
	{

		//textField.color = Color.white;

		if (!IsActive() || helper.currentVertCount == 0)
			return;

		List<UIVertex> vertices = new List<UIVertex>();
		helper.GetUIVertexStream(vertices);

		//vertMax = Mathf.RoundToInt(helper.currentVertCount);
		//vertIndex = Mathf.Clamp (vertIndex,0,vertMax);

		UIVertex v = new UIVertex();

		//print ("COUNT: " + Mathf.RoundToInt(helper.currentVertCount)); 

		for (int i = 0; i < textField.text.Length; i++)
		{
			
			Color progressionColor = Color.Lerp (Color.clear,Color.white,

				getProgression ((i*4.0f)/((textField.text.Length-1)*4))
			
			)*textField.color;
				
			Color progressionColorB = Color.Lerp (Color.clear,Color.white,

				getProgression (Mathf.Clamp((1+(i*4.0f))/((textField.text.Length-1)*4),0,1))

			)*textField.color;

			helper.PopulateUIVertex(ref v, Mathf.RoundToInt(i*4.0f));
			v.color = progressionColor;
			helper.SetUIVertex(v, Mathf.RoundToInt(i*4.0f));

			helper.PopulateUIVertex(ref v, Mathf.RoundToInt(i*4.0f)+3);
			v.color = progressionColor;
			helper.SetUIVertex(v, Mathf.RoundToInt(i*4.0f)+3);

			helper.PopulateUIVertex(ref v, Mathf.RoundToInt(i*4.0f)+1);
			v.color = progressionColorB;
			helper.SetUIVertex(v, Mathf.RoundToInt(i*4.0f)+1);

			helper.PopulateUIVertex(ref v, Mathf.RoundToInt(i*4.0f)+2);
			v.color = progressionColorB;
			helper.SetUIVertex(v, Mathf.RoundToInt(i*4.0f)+2);


		}

	}

	float getProgression (float input)	{

		var max = Mathf.Lerp (0 - trail, 1, progression);
		var min = Mathf.Lerp (0,1+trail,progression);

		//debugMax = max;

		//print (Mathf.Clamp (Mathf.InverseLerp(min, max, input),0,1));

		return Mathf.Clamp (Mathf.InverseLerp(min, max, input),0,1);




	}




}
