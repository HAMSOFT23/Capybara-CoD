using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;

namespace MaxyGames.UNode.Editors {
	[NodeCustomEditor(typeof(Nodes.ManualEvent))]
	public class ManualEventView : BaseNodeView {
		protected override void InitializeView() {
			base.InitializeView();
			Nodes.ManualEvent node = targetNode as Nodes.ManualEvent;
			ControlView control = new ControlView();
			control.style.alignSelf = Align.Center;
			control.Add(new Button(() => {
				var target = graphData.debugTarget;
				if(target == null) {
					uNodeEditorUtility.DisplayErrorMessage("No selected instance, please select the instance from the `Debug` menu");
				}
				else {
					if(target is IInstancedGraph instancedGraph) {
						GraphInstance instance;
						if(instancedGraph.Instance != null) {
							instance = instancedGraph.Instance;
						}
						else {
							instance = RuntimeGraphUtility.GetObjectGraphInstance(node.nodeObject.graphContainer, instancedGraph);
							if(target is IRuntimeGraphWrapper wrapper) {
								RuntimeGraphUtility.InitializeInstanceGraphValue(node.nodeObject.graphContainer, instance, wrapper.WrappedVariables);
							}
						}
						node.Trigger(instance);
						//instance.eventData.ExecuteCustomEvent("@ManualEvent_" + node.id, instance);
					}
					else if(target is IRuntimeClass runtime) {
						runtime.InvokeFunction("M_ManualEvent_" + node.id, null);
					}
				}
			}) { text = "Trigger" });
			AddControl(Direction.Input, control);
		}
	}
}