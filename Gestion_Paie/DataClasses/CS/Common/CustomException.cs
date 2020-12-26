/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 13/09/2006 11:57:31 AM
			Generator name: <Developer Name Here>
			Template last update: 24/06/2002 1:53:57 AM
			Template revision: 15083637

			SQL Server version: 08.00.0194
			Server: andre
			Database: [Gestion_Paie]

	WARNING: This source is provided "AS IS" without warranty of any kind.
	The author disclaims all warranties, either express or implied, including
	the warranties of merchantability and fitness for a particular purpose.
	In no event shall the author or its suppliers be liable for any damages
	whatsoever including direct, indirect, incidental, consequential, loss of
	business profits or special damages, even if the author or its suppliers
	have been advised of the possibility of such damages.
*/

namespace Gestion_Paie.DataClasses {

	/// <summary>
	/// Represents a custom exception. This exception can be thrown by any class of the Gestion_Paie namespace.
	/// </summary>
	public sealed class CustomException : System.Exception	{

		private IParameter parameter;
		private string className;
		private string methodName;
		
		/// <summary>
		/// Initializes a new instance of the CustomException class.
		/// </summary>
		/// <param name="parameter">IParameter object involved when the exception has been thrown.</param>
		/// <param name="className">Name of the class where the exception has been thrown.</param>
		/// <param name="methodName">Name of the method where the exception has been thrown.</param>
		public CustomException(IParameter parameter, string className, string methodName) {

			this.parameter = parameter;
			this.className = className;
			this.methodName = methodName;
		}
		
		/// <summary>
		/// IParameter object involved when the exception has been thrown.
		/// </summary>
		public IParameter Parameter {

			get {

				return(this.parameter);
			}
		}

		/// <summary>
		/// Name of the class where the exception has been thrown.
		/// </summary>
		public string ClassName {

			get {

				return(this.className);
			}
		}

		/// <summary>
		/// Name of the method where the exception has been thrown.
		/// </summary>
		public string MethodName {

			get {

				return(this.methodName);
			}
		}
	}
}
