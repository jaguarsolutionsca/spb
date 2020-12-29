﻿/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 10/10/2006 1:55:58 PM
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

using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spU_Indexation'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/10/10 17:55:58", SqlObjectDependancyName="spU_Indexation", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spU_Indexation : MarshalByRefObject, IDisposable, IParameter {

		private ErrorSource errorSource = ErrorSource.NotAvailable;
		private System.Data.SqlClient.SqlException sqlException = null;
		private System.Exception otherException = null;
		private string connectionString = String.Empty;
		private System.Data.SqlClient.SqlConnection sqlConnection = null;
		private System.Data.SqlClient.SqlTransaction sqlTransaction = null;
		private ConnectionType lastKnownConnectionType = ConnectionType.None;
		private int commandTimeOut = 30;

		internal void internal_UpdateExceptionInformation(System.Data.SqlClient.SqlException sqlException) {

			this.sqlException = sqlException;
		}

		internal void internal_UpdateExceptionInformation(System.Exception otherException) {

			this.otherException = otherException;
		}

		internal void internal_SetErrorSource(ErrorSource errorSource) {

			this.errorSource = errorSource;
		}

		private bool useDefaultValue = true;

		/// <summary>
		/// Initializes a new instance of the spU_Indexation class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spU_Indexation() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Indexation class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spU_Indexation(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateIndexation_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_DateIndexation_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Periode_Debut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Periode_Debut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Periode_Fin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Periode_Fin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TypeIndexation_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_TypeIndexation_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PourcentageDuMontant_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Facture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Facture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IndexationTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_IndexationTransporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Date_Debut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Date_Debut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Date_Fin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Date_Fin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_IndexationManuelle_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_IndexationManuelle_UseDefaultValue = this.useDefaultValue;
		}


		/// <summary>
		/// Sets the connection string to be used against the 
		/// SQL Server database.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public void SetUpConnection(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

			this.connectionString = connectionString;
			this.lastKnownConnectionType = ConnectionType.ConnectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Indexation'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Indexation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif
		}

		/// <summary>
		/// Sets the System.Data.SqlClient.SqlConnection to be used
		/// against the SQL Server database.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection object. It can be opened or not. If it is not opened, it will be opened when used then closed again after the job is done.</param>
		public void SetUpConnection(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {
				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

			this.sqlConnection = sqlConnection;
			this.lastKnownConnectionType = ConnectionType.SqlConnection;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlConnection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlConnection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Indexation'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Indexation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Sets the System.Data.SqlClient.SqlTransaction to be used
		/// against the SQL Server database.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction object.</param>
		public void SetUpConnection(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid connection!");
			}

			this.sqlTransaction= sqlTransaction;
			this.lastKnownConnectionType = ConnectionType.SqlTransaction;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				bool NotAlreadyOpened = false;
				if (sqlTransaction.Connection.State == System.Data.ConnectionState.Closed) {

					NotAlreadyOpened = true;
					sqlTransaction.Connection.Open();
				}

				System.Data.SqlClient.SqlCommand sqlCommand = sqlTransaction.Connection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Indexation'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Indexation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif
		}

		/// <summary>
		/// Disposes the current instance of this object.
		/// </summary>
		public void Dispose() {

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing) {

			if (disposing) {

				this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_DateIndexation = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_DateIndexation = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_ContratID = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Periode_Debut = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Periode_Debut = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Periode_Fin = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ConsiderNull_Periode_Fin = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_TypeIndexation = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ConsiderNull_TypeIndexation = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_PourcentageDuMontant = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_PourcentageDuMontant = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Facture = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Facture = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IndexationTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_IndexationTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Date_Debut = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_Date_Debut = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Date_Fin = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_Date_Fin = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_IndexationManuelle = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_IndexationManuelle = System.Data.SqlTypes.SqlBoolean.Null;

				this.sqlException = null;
				this.otherException = null;
				this.connectionString = null;
				this.sqlConnection = null;
				this.sqlTransaction = null;

			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~spU_Indexation() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spU_Indexation'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spU_Indexation");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateIndexation;
		internal bool internal_Param_DateIndexation_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_DateIndexation;
		internal bool internal_Param_ConsiderNull_DateIndexation_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContratID;
		internal bool internal_Param_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_ContratID;
		internal bool internal_Param_ConsiderNull_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Periode_Debut;
		internal bool internal_Param_Periode_Debut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Periode_Debut;
		internal bool internal_Param_ConsiderNull_Periode_Debut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Periode_Fin;
		internal bool internal_Param_Periode_Fin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Periode_Fin;
		internal bool internal_Param_ConsiderNull_Periode_Fin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TypeIndexation;
		internal bool internal_Param_TypeIndexation_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_TypeIndexation;
		internal bool internal_Param_ConsiderNull_TypeIndexation_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_PourcentageDuMontant;
		internal bool internal_Param_PourcentageDuMontant_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_PourcentageDuMontant;
		internal bool internal_Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Facture;
		internal bool internal_Param_Facture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Facture;
		internal bool internal_Param_ConsiderNull_Facture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IndexationTransporteur;
		internal bool internal_Param_IndexationTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_IndexationTransporteur;
		internal bool internal_Param_ConsiderNull_IndexationTransporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_Date_Debut;
		internal bool internal_Param_Date_Debut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Date_Debut;
		internal bool internal_Param_ConsiderNull_Date_Debut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_Date_Fin;
		internal bool internal_Param_Date_Fin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Date_Fin;
		internal bool internal_Param_ConsiderNull_Date_Fin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_IndexationManuelle;
		internal bool internal_Param_IndexationManuelle_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_IndexationManuelle;
		internal bool internal_Param_ConsiderNull_IndexationManuelle_UseDefaultValue = true;


		/// <summary>
		/// Allows you to know at which step did the error occured if one occured. See <see cref="ErrorSource" />
		/// for more information.
		/// </summary>
		public ErrorSource ErrorSource {

			get {

				return(this.errorSource);
			}
		}

		/// <summary>
		/// This method allows you to reset the parameter object. Please note that this
		/// method resets all the parameters members except the connection information and
		/// the command time-out which are left in their current state.
		/// </summary>
		public void Reset() {


			this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;

			this.internal_Param_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateIndexation = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateIndexation_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_DateIndexation = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_DateIndexation_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_ContratID = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Periode_Debut = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Periode_Debut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Periode_Debut = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Periode_Debut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Periode_Fin = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Periode_Fin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Periode_Fin = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Periode_Fin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TypeIndexation = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TypeIndexation_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_TypeIndexation = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_TypeIndexation_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PourcentageDuMontant = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_PourcentageDuMontant_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_PourcentageDuMontant = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Facture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Facture = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Facture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IndexationTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IndexationTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_IndexationTransporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_IndexationTransporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Date_Debut = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_Date_Debut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Date_Debut = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Date_Debut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Date_Fin = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_Date_Fin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Date_Fin = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Date_Fin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_IndexationManuelle = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_IndexationManuelle_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_IndexationManuelle = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_IndexationManuelle_UseDefaultValue = this.useDefaultValue;

			this.errorSource = ErrorSource.NotAvailable;
			this.sqlException = null;
			this.otherException = null;
		}

		/// <summary>
		/// Returns the connection string to be used against the 
		/// SQL Server database.
		/// </summary>
		public System.String ConnectionString {

			get {

				return(this.connectionString);
			}
		}
            
		/// <summary>
		/// Returns the System.Data.SqlClient.SqlConnection to be used
		/// against the SQL Server database.
		/// </summary>
		public System.Data.SqlClient.SqlConnection SqlConnection {

			get {

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Returns the System.Data.SqlClient.SqlTransaction to be used
		/// against the SQL Server database.
		/// </summary>
		public System.Data.SqlClient.SqlTransaction SqlTransaction {

			get {

				return(this.sqlTransaction);
			}
		}

		/// <summary>
		/// Returns the current type of connection that is going or has been used
		/// against the Sql Server database. It can be: ConnectionString, SqlConnection
		/// or SqlTransaction
		/// </summary>
		public ConnectionType ConnectionType {

			get {

				return(this.lastKnownConnectionType );
			}
		}

		/// <summary>
		/// In case of an ADO exception, returns the SqlException exception (System.Data.SqlClient.SqlException)
		/// that has occured.
		/// </summary>
		public System.Data.SqlClient.SqlException SqlException {

			get {

				return(this.sqlException);
			}
		}

		/// <summary>
		/// In case of a System exception, returns the standard exception (System.Exception) that 
		/// has occured.
		/// </summary>
		public System.Exception OtherException {

			get {

				return(this.otherException);
			}
		}

		/// <summary>
		/// Sets or returns the time-out (in seconds) to be use by the ADO command object
		/// (System.Data.SqlClient.SqlCommand).
		/// <remarks>
		/// Default value is 30 seconds.
		/// </remarks>
		/// </summary>
		public int CommandTimeOut {

			get {

				return(this.commandTimeOut);
			}

			set {

				this.commandTimeOut = value;
				if (this.commandTimeOut <= 0) {

					this.commandTimeOut = 30;
				}
			}
		}


		/// <summary>
		/// Returns the value returned back by the stored procedure execution.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Param_RETURN_VALUE {

			get {

				return(this.internal_Param_RETURN_VALUE);
			}
		}
            
		internal void internal_Set_RETURN_VALUE(System.Data.SqlTypes.SqlInt32 value) {

			this.internal_Param_RETURN_VALUE = value;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_ID {

			get {

				if (this.internal_Param_ID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ID);
			}

			set {

				this.internal_Param_ID_UseDefaultValue = false;
				this.internal_Param_ID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ID_UseDefaultValue() {

			this.internal_Param_ID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DateIndexation'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [datetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_DateIndexation_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateIndexation {

			get {

				if (this.internal_Param_DateIndexation_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateIndexation);
			}

			set {

				this.internal_Param_DateIndexation_UseDefaultValue = false;
				this.internal_Param_DateIndexation = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateIndexation' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateIndexation_UseDefaultValue() {

			this.internal_Param_DateIndexation_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_DateIndexation'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_DateIndexation_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_DateIndexation {

			get {

				if (this.internal_Param_ConsiderNull_DateIndexation_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_DateIndexation);
			}

			set {

				this.internal_Param_ConsiderNull_DateIndexation_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_DateIndexation = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_DateIndexation' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_DateIndexation_UseDefaultValue() {

			this.internal_Param_ConsiderNull_DateIndexation_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ContratID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](10)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ContratID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ContratID {

			get {

				if (this.internal_Param_ContratID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContratID);
			}

			set {

				this.internal_Param_ContratID_UseDefaultValue = false;
				this.internal_Param_ContratID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContratID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContratID_UseDefaultValue() {

			this.internal_Param_ContratID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_ContratID'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_ContratID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_ContratID {

			get {

				if (this.internal_Param_ConsiderNull_ContratID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_ContratID);
			}

			set {

				this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_ContratID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_ContratID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_ContratID_UseDefaultValue() {

			this.internal_Param_ConsiderNull_ContratID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Periode_Debut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Periode_Debut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Periode_Debut {

			get {

				if (this.internal_Param_Periode_Debut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Periode_Debut);
			}

			set {

				this.internal_Param_Periode_Debut_UseDefaultValue = false;
				this.internal_Param_Periode_Debut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Periode_Debut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Periode_Debut_UseDefaultValue() {

			this.internal_Param_Periode_Debut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Periode_Debut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Periode_Debut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Periode_Debut {

			get {

				if (this.internal_Param_ConsiderNull_Periode_Debut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Periode_Debut);
			}

			set {

				this.internal_Param_ConsiderNull_Periode_Debut_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Periode_Debut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Periode_Debut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Periode_Debut_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Periode_Debut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Periode_Fin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [int]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Periode_Fin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Periode_Fin {

			get {

				if (this.internal_Param_Periode_Fin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Periode_Fin);
			}

			set {

				this.internal_Param_Periode_Fin_UseDefaultValue = false;
				this.internal_Param_Periode_Fin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Periode_Fin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Periode_Fin_UseDefaultValue() {

			this.internal_Param_Periode_Fin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Periode_Fin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Periode_Fin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Periode_Fin {

			get {

				if (this.internal_Param_ConsiderNull_Periode_Fin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Periode_Fin);
			}

			set {

				this.internal_Param_ConsiderNull_Periode_Fin_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Periode_Fin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Periode_Fin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Periode_Fin_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Periode_Fin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TypeIndexation'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [char](1)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_TypeIndexation_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TypeIndexation {

			get {

				if (this.internal_Param_TypeIndexation_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TypeIndexation);
			}

			set {

				this.internal_Param_TypeIndexation_UseDefaultValue = false;
				this.internal_Param_TypeIndexation = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TypeIndexation' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TypeIndexation_UseDefaultValue() {

			this.internal_Param_TypeIndexation_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_TypeIndexation'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_TypeIndexation_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_TypeIndexation {

			get {

				if (this.internal_Param_ConsiderNull_TypeIndexation_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_TypeIndexation);
			}

			set {

				this.internal_Param_ConsiderNull_TypeIndexation_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_TypeIndexation = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_TypeIndexation' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_TypeIndexation_UseDefaultValue() {

			this.internal_Param_ConsiderNull_TypeIndexation_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PourcentageDuMontant'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [real]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_PourcentageDuMontant_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_PourcentageDuMontant {

			get {

				if (this.internal_Param_PourcentageDuMontant_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PourcentageDuMontant);
			}

			set {

				this.internal_Param_PourcentageDuMontant_UseDefaultValue = false;
				this.internal_Param_PourcentageDuMontant = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PourcentageDuMontant' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PourcentageDuMontant_UseDefaultValue() {

			this.internal_Param_PourcentageDuMontant_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_PourcentageDuMontant'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_PourcentageDuMontant {

			get {

				if (this.internal_Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_PourcentageDuMontant);
			}

			set {

				this.internal_Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_PourcentageDuMontant = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_PourcentageDuMontant' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue() {

			this.internal_Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Facture'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Facture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Facture {

			get {

				if (this.internal_Param_Facture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Facture);
			}

			set {

				this.internal_Param_Facture_UseDefaultValue = false;
				this.internal_Param_Facture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Facture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Facture_UseDefaultValue() {

			this.internal_Param_Facture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Facture'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Facture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Facture {

			get {

				if (this.internal_Param_ConsiderNull_Facture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Facture);
			}

			set {

				this.internal_Param_ConsiderNull_Facture_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Facture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Facture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Facture_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Facture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IndexationTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_IndexationTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IndexationTransporteur {

			get {

				if (this.internal_Param_IndexationTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IndexationTransporteur);
			}

			set {

				this.internal_Param_IndexationTransporteur_UseDefaultValue = false;
				this.internal_Param_IndexationTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IndexationTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IndexationTransporteur_UseDefaultValue() {

			this.internal_Param_IndexationTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_IndexationTransporteur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_IndexationTransporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_IndexationTransporteur {

			get {

				if (this.internal_Param_ConsiderNull_IndexationTransporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_IndexationTransporteur);
			}

			set {

				this.internal_Param_ConsiderNull_IndexationTransporteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_IndexationTransporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_IndexationTransporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_IndexationTransporteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_IndexationTransporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Date_Debut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [smalldatetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Date_Debut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_Date_Debut {

			get {

				if (this.internal_Param_Date_Debut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Date_Debut);
			}

			set {

				this.internal_Param_Date_Debut_UseDefaultValue = false;
				this.internal_Param_Date_Debut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Date_Debut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Date_Debut_UseDefaultValue() {

			this.internal_Param_Date_Debut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Date_Debut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Date_Debut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Date_Debut {

			get {

				if (this.internal_Param_ConsiderNull_Date_Debut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Date_Debut);
			}

			set {

				this.internal_Param_ConsiderNull_Date_Debut_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Date_Debut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Date_Debut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Date_Debut_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Date_Debut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Date_Fin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [smalldatetime]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Date_Fin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_Date_Fin {

			get {

				if (this.internal_Param_Date_Fin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Date_Fin);
			}

			set {

				this.internal_Param_Date_Fin_UseDefaultValue = false;
				this.internal_Param_Date_Fin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Date_Fin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Date_Fin_UseDefaultValue() {

			this.internal_Param_Date_Fin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Date_Fin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_Date_Fin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Date_Fin {

			get {

				if (this.internal_Param_ConsiderNull_Date_Fin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Date_Fin);
			}

			set {

				this.internal_Param_ConsiderNull_Date_Fin_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Date_Fin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Date_Fin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Date_Fin_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Date_Fin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@IndexationManuelle'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_IndexationManuelle_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_IndexationManuelle {

			get {

				if (this.internal_Param_IndexationManuelle_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_IndexationManuelle);
			}

			set {

				this.internal_Param_IndexationManuelle_UseDefaultValue = false;
				this.internal_Param_IndexationManuelle = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@IndexationManuelle' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_IndexationManuelle_UseDefaultValue() {

			this.internal_Param_IndexationManuelle_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_IndexationManuelle'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [bit]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ConsiderNull_IndexationManuelle_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_IndexationManuelle {

			get {

				if (this.internal_Param_ConsiderNull_IndexationManuelle_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_IndexationManuelle);
			}

			set {

				this.internal_Param_ConsiderNull_IndexationManuelle_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_IndexationManuelle = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_IndexationManuelle' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_IndexationManuelle_UseDefaultValue() {

			this.internal_Param_ConsiderNull_IndexationManuelle_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spU_Indexation' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/10/10 17:55:58", SqlObjectDependancyName="spU_Indexation", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spU_Indexation : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spU_Indexation class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spU_Indexation() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Indexation class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spU_Indexation(bool throwExceptionOnExecute) {

			this.throwExceptionOnExecute = throwExceptionOnExecute;
		}

		private System.Data.SqlClient.SqlConnection sqlConnection;
		/// <summary>
		/// The <see cref="System.Data.SqlClient.SqlConnection">System.Data.SqlClient.SqlConnection</see> that was actually used by this class.
		/// </summary>
		public System.Data.SqlClient.SqlConnection Connection {

			get {

				return(this.sqlConnection);
			}
		}

		/// <summary>
		/// Disposes the current instance of this object.
		/// </summary>
		public void Dispose() {

			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// This member supports the .NET Framework infrastructure and is not intended to be used directly from your code.
		/// </summary>
		private void Dispose(bool disposing) {

			if (disposing) {

			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~spU_Indexation() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spU_Indexation parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spU_Indexation parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Indexation object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Indexation object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Indexation object before doing this call.");
				}

				switch (parameters.ConnectionType) {

					case ConnectionType.ConnectionString:

						string connectionString;
				
						if (parameters.ConnectionString.Length == 0) {

							connectionString = Information.GetConnectionStringFromConfigurationFile;
							if (connectionString.Length == 0) {

								connectionString = Information.GetConnectionStringFromRegistry;
							}
						}

						else {

							connectionString = parameters.ConnectionString;
						}

						if (connectionString.Length == 0) {

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spU_Indexation)");
						}

						parameters.internal_SetErrorSource(ErrorSource.ConnectionOpening);
						this.sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString);
						this.sqlConnection.Open();

						sqlCommand = sqlConnection.CreateCommand();
						break;

					case ConnectionType.SqlConnection:

						sqlConnection = parameters.SqlConnection;

						if (this.sqlConnection.State != System.Data.ConnectionState.Open) {

							this.sqlConnection.Open();
						}
						else {

							connectionMustBeClosed = false;
						}
						sqlCommand = sqlConnection.CreateCommand();
						break;

					case ConnectionType.SqlTransaction:

						sqlCommand = new System.Data.SqlClient.SqlCommand();
						this.sqlConnection = parameters.SqlTransaction.Connection;
						if (this.sqlConnection == null) {

							throw new InvalidOperationException("The transaction is no longer valid.");
						}

						if (this.sqlConnection.State != System.Data.ConnectionState.Open) {
						
							this.sqlConnection.Open();
						}
						else {

							connectionMustBeClosed = false;
						}
						sqlCommand.Connection = sqlConnection;
						sqlCommand.Transaction = parameters.SqlTransaction;						break;
				}

				sqlCommand.CommandTimeout = parameters.CommandTimeOut;
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
				sqlCommand.CommandText = "spU_Indexation";

				return(true);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				sqlConnection = null;
				sqlCommand = null;
				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				sqlConnection = null;
				sqlCommand = null;
				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Indexation parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "ID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ID.IsNull) {

					sqlParameter.Value = parameters.Param_ID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateIndexation", System.Data.SqlDbType.DateTime, 16);
				sqlParameter.SourceColumn = "DateIndexation";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateIndexation_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateIndexation.IsNull) {

					sqlParameter.Value = parameters.Param_DateIndexation;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_DateIndexation", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_DateIndexation_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_DateIndexation.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_DateIndexation;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContratID", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.SourceColumn = "ContratID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContratID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContratID.IsNull) {

					sqlParameter.Value = parameters.Param_ContratID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_ContratID", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_ContratID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_ContratID.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_ContratID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Periode_Debut", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Periode_Debut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Periode_Debut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Periode_Debut.IsNull) {

					sqlParameter.Value = parameters.Param_Periode_Debut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Periode_Debut", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Periode_Debut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Periode_Debut.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Periode_Debut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Periode_Fin", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Periode_Fin";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Periode_Fin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Periode_Fin.IsNull) {

					sqlParameter.Value = parameters.Param_Periode_Fin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Periode_Fin", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Periode_Fin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Periode_Fin.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Periode_Fin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TypeIndexation", System.Data.SqlDbType.Char, 1);
				sqlParameter.SourceColumn = "TypeIndexation";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TypeIndexation_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TypeIndexation.IsNull) {

					sqlParameter.Value = parameters.Param_TypeIndexation;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_TypeIndexation", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_TypeIndexation_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_TypeIndexation.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_TypeIndexation;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PourcentageDuMontant", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "PourcentageDuMontant";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PourcentageDuMontant_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PourcentageDuMontant.IsNull) {

					sqlParameter.Value = parameters.Param_PourcentageDuMontant;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_PourcentageDuMontant", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_PourcentageDuMontant_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_PourcentageDuMontant.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_PourcentageDuMontant;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Facture", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Facture";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Facture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Facture.IsNull) {

					sqlParameter.Value = parameters.Param_Facture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Facture", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Facture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Facture.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Facture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IndexationTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IndexationTransporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IndexationTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IndexationTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_IndexationTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IndexationTransporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_IndexationTransporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_IndexationTransporteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_IndexationTransporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Date_Debut", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "Date_Debut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Date_Debut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Date_Debut.IsNull) {

					sqlParameter.Value = parameters.Param_Date_Debut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Date_Debut", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Date_Debut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Date_Debut.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Date_Debut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Date_Fin", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "Date_Fin";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Date_Fin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Date_Fin.IsNull) {

					sqlParameter.Value = parameters.Param_Date_Fin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Date_Fin", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Date_Fin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Date_Fin.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Date_Fin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@IndexationManuelle", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "IndexationManuelle";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_IndexationManuelle_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_IndexationManuelle.IsNull) {

					sqlParameter.Value = parameters.Param_IndexationManuelle;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_IndexationManuelle", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_IndexationManuelle_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_IndexationManuelle.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_IndexationManuelle;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);


				return(true);

			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Indexation parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				if (sqlCommand.Parameters["@RETURN_VALUE"].Value != System.DBNull.Value) {

					parameters.internal_Set_RETURN_VALUE ((System.Int32)sqlCommand.Parameters["@RETURN_VALUE"].Value);
				}
				else {

					parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
				}

				return(true);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				return(false);
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				return(false);
			}
		}

		/// <summary>
		/// This method allows you to execute the [spU_Indexation] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spU_Indexation parameters) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {
				ResetParameter(ref parameters);

				parameters.internal_SetErrorSource(ErrorSource.ConnectionInitialization);
				returnStatus = InitializeConnection(ref parameters, out sqlCommand, ref connectionMustBeClosed);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.ParametersSetting);
				returnStatus = DeclareParameters(ref parameters, ref sqlCommand);
				if (!returnStatus) {

					return(false);
				}

				parameters.internal_SetErrorSource(ErrorSource.QueryExecution);
				sqlCommand.ExecuteNonQuery();
                
				parameters.internal_SetErrorSource(ErrorSource.ParametersRetrieval);
				returnStatus = RetrieveParameters(ref parameters, ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				parameters.internal_UpdateExceptionInformation(sqlException);
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

				parameters.internal_UpdateExceptionInformation(exception);
				returnStatus = false;
				parameters.internal_SetErrorSource(ErrorSource.Other);

				if (this.throwExceptionOnExecute) {

					throw exception;
				}
			}

			finally {

				if (sqlCommand != null) {

					sqlCommand.Dispose();
				}

				if (parameters.SqlTransaction == null) {

					if (this.sqlConnection != null && connectionMustBeClosed && this.sqlConnection.State == System.Data.ConnectionState.Open) {

						this.sqlConnection.Close();
						this.sqlConnection.Dispose();
					}
				}

				if (returnStatus) {

					parameters.internal_SetErrorSource(ErrorSource.NoError);
				}
				else {

					if (this.throwExceptionOnExecute) {

						if (parameters.SqlException != null) {

							throw parameters.SqlException;
						}
						else {

							throw parameters.OtherException;
						}
					}
				}
			}
			return(returnStatus);
       
		}

	}

}
