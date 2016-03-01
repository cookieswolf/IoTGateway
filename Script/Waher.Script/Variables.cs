﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Waher.Script.Exceptions;

namespace Waher.Script
{
	/// <summary>
	/// Collection of variables.
	/// </summary>
	public class Variables
	{
		private Dictionary<string, Variable> variables = new Dictionary<string, Variable>();
        private Stack<Dictionary<string, Variable>> stack = null;
        private TextWriter consoleOut = Console.Out;

        /// <summary>
        /// Collection of variables.
        /// </summary>
        public Variables(params Variable[] Variables)
		{
			foreach (Variable Variable in Variables)
				this.variables[Variable.Name] = Variable;
		}

		/// <summary>
		/// Tries to get a variable object, given its name.
		/// </summary>
		/// <param name="Name">Variable name.</param>
		/// <param name="Variable">Variable, if found, or null otherwise.</param>
		/// <returns>If a variable with the corresponding name was found.</returns>
		public bool TryGetVariable(string Name, out Variable Variable)
		{
			lock (this.variables)
			{
				return this.variables.TryGetValue(Name, out Variable);
			}
		}

		/// <summary>
		/// Access to variable values through the use of their names.
		/// </summary>
		/// <param name="Name">Variable name.</param>
		/// <returns>Associated variable object value.</returns>
		public object this[string Name]
		{
			get
			{
				Variable v;

				lock (this.variables)
				{
					if (this.variables.TryGetValue(Name, out v))
						return v.ValueObject;
					else
						return null;
				}
			}

			set
			{
				Variable v;

				lock (this.variables)
				{
					if (this.variables.TryGetValue(Name, out v))
						v.SetValue(value);
					else
						this.variables[Name] = new Variable(Name, value);
				}
			}
		}

        /// <summary>
        /// Removes a varaiable from the collection.
        /// </summary>
        /// <param name="VariableName">Name of variable.</param>
        /// <returns>If the variable was found and removed.</returns>
        public bool Remove(string VariableName)
        {
            lock(this.variables)
            {
                return this.variables.Remove(VariableName);
            }
        }

        /// <summary>
        /// Pushes the current set of variables to the stack. This state is restored by calling <see cref="Pop"/>.
        /// Each call to this method must be followed by exactly one call to <see cref="Pop"/>.
        /// </summary>
        public void Push()
        {
            if (this.stack == null)
                this.stack = new Stack<Dictionary<string, Variable>>();

            this.stack.Push(this.variables);

            Dictionary<string, Variable> Clone = new Dictionary<string, Variable>();
            foreach (KeyValuePair<string, Variable> P in this.variables)
                Clone[P.Key] = P.Value;

            this.variables = Clone;
        }

        /// <summary>
        /// Pops a previously stored set of variables from the stack. Variables are stored on the stack by calling <see cref="Push"/>.
        /// </summary>
        public void Pop()
        {
            if (this.stack == null)
                throw new ScriptException("Stack is empty.");

            this.variables = this.stack.Pop();
        }

        /// <summary>
        /// Console out interface. Can be used by functions and script to output data to the console.
        /// </summary>
        public TextWriter ConsoleOut
        {
            get { return this.consoleOut; }
            set { this.consoleOut = value; }
        }

	}
}