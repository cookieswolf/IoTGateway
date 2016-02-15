﻿using System;
using System.Collections.Generic;
using System.Text;
using Waher.Script.Model;

namespace Waher.Script.Operators.Vectors
{
	/// <summary>
	/// To-Vector operator.
	/// </summary>
	public class ToVector : UnaryOperator 
	{
		/// <summary>
		/// To-Vector operator.
		/// </summary>
		/// <param name="Operand">Operand.</param>
		/// <param name="Start">Start position in script expression.</param>
		/// <param name="Length">Length of expression covered by node.</param>
		public ToVector(ScriptNode Operand, int Start, int Length)
			: base(Operand, Start, Length)
		{
		}
	}
}