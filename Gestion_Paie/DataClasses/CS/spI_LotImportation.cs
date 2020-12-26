/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 13/09/2006 11:57:05 AM
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
	/// stored procedure 'spI_LotImportation'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:57:05", SqlObjectDependancyName="spI_LotImportation", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_LotImportation : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_LotImportation class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_LotImportation() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_LotImportation class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_LotImportation(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_lo_code_canton_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_rang_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_code_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_super_tot_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_super_boisee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_super_contin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_code_fournisseur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_code_muni_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_code_prop_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_code_cont_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_date_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_lo_code_deux_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Traite_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Valide_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Raison_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_LotImportation'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_LotImportation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_LotImportation'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_LotImportation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_LotImportation'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_LotImportation", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_lo_code_canton = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_rang = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_code = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_super_tot = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_super_boisee = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_super_contin = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_code_fournisseur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_code_muni = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_code_prop = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_code_cont = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_date = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_lo_code_deux = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Traite = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Valide = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Raison = System.Data.SqlTypes.SqlString.Null;

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
		~spI_LotImportation() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_LotImportation'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_LotImportation");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_lo_code_canton;
		internal bool internal_Param_lo_code_canton_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_rang;
		internal bool internal_Param_lo_rang_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_code;
		internal bool internal_Param_lo_code_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_super_tot;
		internal bool internal_Param_lo_super_tot_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_super_boisee;
		internal bool internal_Param_lo_super_boisee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_super_contin;
		internal bool internal_Param_lo_super_contin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_code_fournisseur;
		internal bool internal_Param_lo_code_fournisseur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_code_muni;
		internal bool internal_Param_lo_code_muni_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_code_prop;
		internal bool internal_Param_lo_code_prop_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_code_cont;
		internal bool internal_Param_lo_code_cont_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_date;
		internal bool internal_Param_lo_date_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_lo_code_deux;
		internal bool internal_Param_lo_code_deux_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Traite;
		internal bool internal_Param_Traite_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Valide;
		internal bool internal_Param_Valide_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Raison;
		internal bool internal_Param_Raison_UseDefaultValue = true;


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

			this.internal_Param_lo_code_canton = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_code_canton_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_rang = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_rang_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_code = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_code_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_super_tot = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_super_tot_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_super_boisee = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_super_boisee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_super_contin = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_super_contin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_code_fournisseur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_code_fournisseur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_code_muni = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_code_muni_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_code_prop = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_code_prop_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_code_cont = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_code_cont_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_date = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_date_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_lo_code_deux = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_lo_code_deux_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Traite = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Traite_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Valide = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Valide_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Raison = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Raison_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@lo_code_canton'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_code_canton_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_code_canton {

			get {

				if (this.internal_Param_lo_code_canton_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_code_canton);
			}

			set {

				this.internal_Param_lo_code_canton_UseDefaultValue = false;
				this.internal_Param_lo_code_canton = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_code_canton' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_code_canton_UseDefaultValue() {

			this.internal_Param_lo_code_canton_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_rang'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](25)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_rang_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_rang {

			get {

				if (this.internal_Param_lo_rang_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_rang);
			}

			set {

				this.internal_Param_lo_rang_UseDefaultValue = false;
				this.internal_Param_lo_rang = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_rang' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_rang_UseDefaultValue() {

			this.internal_Param_lo_rang_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_code'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_code_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_code {

			get {

				if (this.internal_Param_lo_code_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_code);
			}

			set {

				this.internal_Param_lo_code_UseDefaultValue = false;
				this.internal_Param_lo_code = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_code' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_code_UseDefaultValue() {

			this.internal_Param_lo_code_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_super_tot'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_super_tot_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_super_tot {

			get {

				if (this.internal_Param_lo_super_tot_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_super_tot);
			}

			set {

				this.internal_Param_lo_super_tot_UseDefaultValue = false;
				this.internal_Param_lo_super_tot = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_super_tot' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_super_tot_UseDefaultValue() {

			this.internal_Param_lo_super_tot_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_super_boisee'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_super_boisee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_super_boisee {

			get {

				if (this.internal_Param_lo_super_boisee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_super_boisee);
			}

			set {

				this.internal_Param_lo_super_boisee_UseDefaultValue = false;
				this.internal_Param_lo_super_boisee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_super_boisee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_super_boisee_UseDefaultValue() {

			this.internal_Param_lo_super_boisee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_super_contin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_super_contin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_super_contin {

			get {

				if (this.internal_Param_lo_super_contin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_super_contin);
			}

			set {

				this.internal_Param_lo_super_contin_UseDefaultValue = false;
				this.internal_Param_lo_super_contin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_super_contin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_super_contin_UseDefaultValue() {

			this.internal_Param_lo_super_contin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_code_fournisseur'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_code_fournisseur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_code_fournisseur {

			get {

				if (this.internal_Param_lo_code_fournisseur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_code_fournisseur);
			}

			set {

				this.internal_Param_lo_code_fournisseur_UseDefaultValue = false;
				this.internal_Param_lo_code_fournisseur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_code_fournisseur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_code_fournisseur_UseDefaultValue() {

			this.internal_Param_lo_code_fournisseur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_code_muni'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_code_muni_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_code_muni {

			get {

				if (this.internal_Param_lo_code_muni_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_code_muni);
			}

			set {

				this.internal_Param_lo_code_muni_UseDefaultValue = false;
				this.internal_Param_lo_code_muni = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_code_muni' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_code_muni_UseDefaultValue() {

			this.internal_Param_lo_code_muni_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_code_prop'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_code_prop_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_code_prop {

			get {

				if (this.internal_Param_lo_code_prop_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_code_prop);
			}

			set {

				this.internal_Param_lo_code_prop_UseDefaultValue = false;
				this.internal_Param_lo_code_prop = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_code_prop' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_code_prop_UseDefaultValue() {

			this.internal_Param_lo_code_prop_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_code_cont'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_code_cont_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_code_cont {

			get {

				if (this.internal_Param_lo_code_cont_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_code_cont);
			}

			set {

				this.internal_Param_lo_code_cont_UseDefaultValue = false;
				this.internal_Param_lo_code_cont = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_code_cont' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_code_cont_UseDefaultValue() {

			this.internal_Param_lo_code_cont_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_date'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](50)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_date_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_date {

			get {

				if (this.internal_Param_lo_date_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_date);
			}

			set {

				this.internal_Param_lo_date_UseDefaultValue = false;
				this.internal_Param_lo_date = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_date' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_date_UseDefaultValue() {

			this.internal_Param_lo_date_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@lo_code_deux'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](6)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_lo_code_deux_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_lo_code_deux {

			get {

				if (this.internal_Param_lo_code_deux_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_lo_code_deux);
			}

			set {

				this.internal_Param_lo_code_deux_UseDefaultValue = false;
				this.internal_Param_lo_code_deux = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@lo_code_deux' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_lo_code_deux_UseDefaultValue() {

			this.internal_Param_lo_code_deux_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Traite'.
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
		/// the parameter default value, consider calling the Param_Traite_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Traite {

			get {

				if (this.internal_Param_Traite_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Traite);
			}

			set {

				this.internal_Param_Traite_UseDefaultValue = false;
				this.internal_Param_Traite = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Traite' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Traite_UseDefaultValue() {

			this.internal_Param_Traite_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Valide'.
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
		/// the parameter default value, consider calling the Param_Valide_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Valide {

			get {

				if (this.internal_Param_Valide_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Valide);
			}

			set {

				this.internal_Param_Valide_UseDefaultValue = false;
				this.internal_Param_Valide = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Valide' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Valide_UseDefaultValue() {

			this.internal_Param_Valide_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Raison'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](2000)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Raison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Raison {

			get {

				if (this.internal_Param_Raison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Raison);
			}

			set {

				this.internal_Param_Raison_UseDefaultValue = false;
				this.internal_Param_Raison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Raison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Raison_UseDefaultValue() {

			this.internal_Param_Raison_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_LotImportation' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:57:05", SqlObjectDependancyName="spI_LotImportation", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_LotImportation : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_LotImportation class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_LotImportation() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_LotImportation class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_LotImportation(bool throwExceptionOnExecute) {

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
		~spI_LotImportation() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_LotImportation parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_LotImportation parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_LotImportation object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_LotImportation object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_LotImportation object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_LotImportation)");
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
				sqlCommand.CommandText = "spI_LotImportation";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_LotImportation parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_code_canton", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "lo_code_canton";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_code_canton_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_code_canton.IsNull) {

					sqlParameter.Value = parameters.Param_lo_code_canton;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_rang", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "lo_rang";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_rang_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_rang.IsNull) {

					sqlParameter.Value = parameters.Param_lo_rang;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_code", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "lo_code";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_code_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_code.IsNull) {

					sqlParameter.Value = parameters.Param_lo_code;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_super_tot", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "lo_super_tot";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_super_tot_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_super_tot.IsNull) {

					sqlParameter.Value = parameters.Param_lo_super_tot;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_super_boisee", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "lo_super_boisee";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_super_boisee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_super_boisee.IsNull) {

					sqlParameter.Value = parameters.Param_lo_super_boisee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_super_contin", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "lo_super_contin";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_super_contin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_super_contin.IsNull) {

					sqlParameter.Value = parameters.Param_lo_super_contin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_code_fournisseur", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "lo_code_fournisseur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_code_fournisseur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_code_fournisseur.IsNull) {

					sqlParameter.Value = parameters.Param_lo_code_fournisseur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_code_muni", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "lo_code_muni";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_code_muni_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_code_muni.IsNull) {

					sqlParameter.Value = parameters.Param_lo_code_muni;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_code_prop", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "lo_code_prop";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_code_prop_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_code_prop.IsNull) {

					sqlParameter.Value = parameters.Param_lo_code_prop;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_code_cont", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "lo_code_cont";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_code_cont_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_code_cont.IsNull) {

					sqlParameter.Value = parameters.Param_lo_code_cont;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_date", System.Data.SqlDbType.VarChar, 50);
				sqlParameter.SourceColumn = "lo_date";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_date_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_date.IsNull) {

					sqlParameter.Value = parameters.Param_lo_date;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@lo_code_deux", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "lo_code_deux";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_lo_code_deux_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_lo_code_deux.IsNull) {

					sqlParameter.Value = parameters.Param_lo_code_deux;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Traite", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Traite";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Traite_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Traite.IsNull) {

					sqlParameter.Value = parameters.Param_Traite;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Valide", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Valide";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Valide_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Valide.IsNull) {

					sqlParameter.Value = parameters.Param_Valide;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Raison", System.Data.SqlDbType.VarChar, 2000);
				sqlParameter.SourceColumn = "Raison";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Raison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Raison.IsNull) {

					sqlParameter.Value = parameters.Param_Raison;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_LotImportation parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spI_LotImportation] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_LotImportation parameters) {

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

