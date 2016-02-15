﻿using System;
using System.Collections.Generic;
using System.Text;
using Waher.Script.Model;

namespace Waher.Script.Operators.Assignments
{
	/// <summary>
	/// Logical And with self operator.
	/// </summary>
	public class LogicalAndWithSelf : Assignment 
	{
		/// <summary>
		/// Logical And with self operator.
		/// </summary>
		/// <param name="VariableName">Variable name..</param>
		/// <param name="Operand">Operand.</param>
		/// <param name="Start">Start position in script expression.</param>
		/// <param name="Length">Length of expression covered by node.</param>
		public LogicalAndWithSelf(string VariableName, ScriptNode Operand, int Start, int Length)
			: base(VariableName, Operand, Start, Length)
		{
		}
	}
}