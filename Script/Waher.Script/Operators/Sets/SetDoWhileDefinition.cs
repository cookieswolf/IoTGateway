﻿using System;
using System.Collections.Generic;
using System.Text;
using Waher.Script.Model;
using Waher.Script.Operators.Conditional;

namespace Waher.Script.Operators.Sets
{
	/// <summary>
	/// Creates a set using a DO-WHILE statement.
	/// </summary>
	public class SetDoWhileDefinition : ScriptNode
	{
		private DoWhile elements;

		/// <summary>
		/// Creates a set using a DO-WHILE statement.
		/// </summary>
		/// <param name="Rows">Row vectors.</param>
		/// <param name="Start">Start position in script expression.</param>
		/// <param name="Length">Length of expression covered by node.</param>
		public SetDoWhileDefinition(DoWhile Elements, int Start, int Length)
			: base(Start, Length)
		{
			this.elements = Elements;
		}

		/// <summary>
		/// Elements
		/// </summary>
		public DoWhile Elements
		{
			get { return this.elements; }
		}

	}
}