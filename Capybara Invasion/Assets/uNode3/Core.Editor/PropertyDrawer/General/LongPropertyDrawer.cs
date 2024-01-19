﻿using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MaxyGames.UNode.Editors.Drawer {
	class LongPropertyDrawer : UPropertyDrawer<long> {
		public override void Draw(Rect position, DrawerOption option) {
			EditorGUI.BeginChangeCheck();
			var fieldValue = GetValue(option.property);
			fieldValue = EditorGUI.LongField(position, option.label, fieldValue);
			if(EditorGUI.EndChangeCheck()) {
				option.property.value = fieldValue;
			}
		}
	}
}