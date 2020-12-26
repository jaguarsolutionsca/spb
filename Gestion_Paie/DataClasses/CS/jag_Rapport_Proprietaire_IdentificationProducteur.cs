using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'jag_Rapport_Proprietaire_IdentificationProducteur'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class jag_Rapport_Proprietaire_IdentificationProducteur : MarshalByRefObject, IDisposable, IParameter {

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

		private CurrentExecution currentExecution = CurrentExecution.None;
		
		private System.Data.SqlClient.SqlCommand sqlCommand = null;
		internal void internal_Set_SqlCommand(ref System.Data.SqlClient.SqlCommand sqlCommand) {
		
			this.sqlCommand = sqlCommand;
		}

		/// <summary>
		/// Returns the System.Data.SqlClient.SqlCommand that has been used.
		/// </summary>
		public System.Data.SqlClient.SqlCommand SqlCommand {
		
			get {
			
				return(this.sqlCommand);
			}
		}
		
		private System.Data.SqlClient.SqlDataReader sqlDataReader = null;
		internal void internal_Set_SqlDataReader(ref System.Data.SqlClient.SqlDataReader sqlDataReader) {
		
			this.currentExecution = CurrentExecution.SqlDataReader;
			this.sqlDataReader = sqlDataReader;
		}

		internal void internal_SetErrorSource(ErrorSource errorSource) {

			this.errorSource = errorSource;
		}

		private bool useDefaultValue = true;

		/// <summary>
		/// Initializes a new instance of the jag_Rapport_Proprietaire_IdentificationProducteur class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public jag_Rapport_Proprietaire_IdentificationProducteur() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the jag_Rapport_Proprietaire_IdentificationProducteur class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public jag_Rapport_Proprietaire_IdentificationProducteur(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_SupBoiseeMin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_SupBoiseeMax_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurDebut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurFin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MembreDebut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MembreFin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ResidentDebut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ResidentFin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContingentementDebut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContingentementFin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeAccorde_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MunicipaliteDebut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_MunicipaliteFin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_SecteurDebut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_SecteurFin_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateRapport_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NePasEmettrePermis_UseDefaultValue = this.useDefaultValue;
		}

		private bool returnValueAvailable = true;

		internal void internal_Set_ReturnValue_Available(bool value) {

			this.returnValueAvailable = value;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_Rapport_Proprietaire_IdentificationProducteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_Rapport_Proprietaire_IdentificationProducteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_Rapport_Proprietaire_IdentificationProducteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_Rapport_Proprietaire_IdentificationProducteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'jag_Rapport_Proprietaire_IdentificationProducteur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "jag_Rapport_Proprietaire_IdentificationProducteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_SupBoiseeMin = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_SupBoiseeMax = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ProducteurDebut = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ProducteurFin = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_MembreDebut = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_MembreFin = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ResidentDebut = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ResidentFin = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ContingentementDebut = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ContingentementFin = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_VolumeAccorde = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_MunicipaliteDebut = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_MunicipaliteFin = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_SecteurDebut = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_SecteurFin = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_DateRapport = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_NePasEmettrePermis = System.Data.SqlTypes.SqlBoolean.Null;

				this.sqlException = null;
				this.otherException = null;
				this.connectionString = null;
				this.sqlConnection = null;
				this.sqlTransaction = null;

				this.sqlCommand = null;
				this.sqlDataReader = null;
			}
		}

		/// <summary>
		/// This member overrides 'Object.Finalize'.
		/// </summary>
		~jag_Rapport_Proprietaire_IdentificationProducteur() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'jag_Rapport_Proprietaire_IdentificationProducteur'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("jag_Rapport_Proprietaire_IdentificationProducteur");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlDouble internal_Param_SupBoiseeMin;
		internal bool internal_Param_SupBoiseeMin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_SupBoiseeMax;
		internal bool internal_Param_SupBoiseeMax_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurDebut;
		internal bool internal_Param_ProducteurDebut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurFin;
		internal bool internal_Param_ProducteurFin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MembreDebut;
		internal bool internal_Param_MembreDebut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MembreFin;
		internal bool internal_Param_MembreFin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Actif;
		internal bool internal_Param_Actif_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ResidentDebut;
		internal bool internal_Param_ResidentDebut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ResidentFin;
		internal bool internal_Param_ResidentFin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ContingentementDebut;
		internal bool internal_Param_ContingentementDebut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ContingentementFin;
		internal bool internal_Param_ContingentementFin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_VolumeAccorde;
		internal bool internal_Param_VolumeAccorde_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MunicipaliteDebut;
		internal bool internal_Param_MunicipaliteDebut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_MunicipaliteFin;
		internal bool internal_Param_MunicipaliteFin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_SecteurDebut;
		internal bool internal_Param_SecteurDebut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_SecteurFin;
		internal bool internal_Param_SecteurFin_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateRapport;
		internal bool internal_Param_DateRapport_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_NePasEmettrePermis;
		internal bool internal_Param_NePasEmettrePermis_UseDefaultValue = true;


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

			this.currentExecution = CurrentExecution.None;
			this.sqlCommand = null;
			this.sqlDataReader = null;

			this.internal_Param_RETURN_VALUE = System.Data.SqlTypes.SqlInt32.Null;

			this.internal_Param_SupBoiseeMin = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_SupBoiseeMin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_SupBoiseeMax = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_SupBoiseeMax_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurDebut = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurDebut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurFin = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurFin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MembreDebut = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MembreDebut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MembreFin = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MembreFin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ResidentDebut = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ResidentDebut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ResidentFin = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ResidentFin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContingentementDebut = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ContingentementDebut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContingentementFin = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ContingentementFin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeAccorde = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_VolumeAccorde_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MunicipaliteDebut = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MunicipaliteDebut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_MunicipaliteFin = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_MunicipaliteFin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_SecteurDebut = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_SecteurDebut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_SecteurFin = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_SecteurFin_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateRapport = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateRapport_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NePasEmettrePermis = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_NePasEmettrePermis_UseDefaultValue = this.useDefaultValue;

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

		private void RetrieveOutputParameters() {
		
			if (this.sqlCommand.Parameters["@RETURN_VALUE"].Value != System.DBNull.Value) {

				this.internal_Set_RETURN_VALUE ((System.Int32)this.sqlCommand.Parameters["@RETURN_VALUE"].Value);
			}
			else {

				this.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
			}


			this.returnValueAvailable = true;
		}

		/// <summary>
		/// Returns the value returned back by the stored procedure execution.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Param_RETURN_VALUE {

			get {

				if (!returnValueAvailable) {

					switch (this.currentExecution) {
					
						case CurrentExecution.SqlDataReader:
							if (this.sqlDataReader.IsClosed) {

								RetrieveOutputParameters();
							}
							else {
							
								throw new System.InvalidOperationException("The stored procedure return value has not been populated. You must close the underlying SqlDataReader first !");
							}
							break;

					}
				}
				return(this.internal_Param_RETURN_VALUE);
			}
		}
            
		internal void internal_Set_RETURN_VALUE(System.Data.SqlTypes.SqlInt32 value) {

			this.internal_Param_RETURN_VALUE = value;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@SupBoiseeMin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_SupBoiseeMin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_SupBoiseeMin {

			get {

				if (this.internal_Param_SupBoiseeMin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_SupBoiseeMin);
			}

			set {

				this.internal_Param_SupBoiseeMin_UseDefaultValue = false;
				this.internal_Param_SupBoiseeMin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@SupBoiseeMin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_SupBoiseeMin_UseDefaultValue() {

			this.internal_Param_SupBoiseeMin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@SupBoiseeMax'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [float]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_SupBoiseeMax_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_SupBoiseeMax {

			get {

				if (this.internal_Param_SupBoiseeMax_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_SupBoiseeMax);
			}

			set {

				this.internal_Param_SupBoiseeMax_UseDefaultValue = false;
				this.internal_Param_SupBoiseeMax = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@SupBoiseeMax' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_SupBoiseeMax_UseDefaultValue() {

			this.internal_Param_SupBoiseeMax_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ProducteurDebut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](15)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ProducteurDebut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProducteurDebut {

			get {

				if (this.internal_Param_ProducteurDebut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProducteurDebut);
			}

			set {

				this.internal_Param_ProducteurDebut_UseDefaultValue = false;
				this.internal_Param_ProducteurDebut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProducteurDebut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProducteurDebut_UseDefaultValue() {

			this.internal_Param_ProducteurDebut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ProducteurFin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](15)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_ProducteurFin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProducteurFin {

			get {

				if (this.internal_Param_ProducteurFin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProducteurFin);
			}

			set {

				this.internal_Param_ProducteurFin_UseDefaultValue = false;
				this.internal_Param_ProducteurFin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProducteurFin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProducteurFin_UseDefaultValue() {

			this.internal_Param_ProducteurFin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MembreDebut'.
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
		/// the parameter default value, consider calling the Param_MembreDebut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_MembreDebut {

			get {

				if (this.internal_Param_MembreDebut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MembreDebut);
			}

			set {

				this.internal_Param_MembreDebut_UseDefaultValue = false;
				this.internal_Param_MembreDebut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MembreDebut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MembreDebut_UseDefaultValue() {

			this.internal_Param_MembreDebut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MembreFin'.
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
		/// the parameter default value, consider calling the Param_MembreFin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_MembreFin {

			get {

				if (this.internal_Param_MembreFin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MembreFin);
			}

			set {

				this.internal_Param_MembreFin_UseDefaultValue = false;
				this.internal_Param_MembreFin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MembreFin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MembreFin_UseDefaultValue() {

			this.internal_Param_MembreFin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Actif'.
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
		/// the parameter default value, consider calling the Param_Actif_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Actif {

			get {

				if (this.internal_Param_Actif_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Actif);
			}

			set {

				this.internal_Param_Actif_UseDefaultValue = false;
				this.internal_Param_Actif = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Actif' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Actif_UseDefaultValue() {

			this.internal_Param_Actif_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ResidentDebut'.
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
		/// the parameter default value, consider calling the Param_ResidentDebut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ResidentDebut {

			get {

				if (this.internal_Param_ResidentDebut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ResidentDebut);
			}

			set {

				this.internal_Param_ResidentDebut_UseDefaultValue = false;
				this.internal_Param_ResidentDebut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ResidentDebut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ResidentDebut_UseDefaultValue() {

			this.internal_Param_ResidentDebut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ResidentFin'.
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
		/// the parameter default value, consider calling the Param_ResidentFin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ResidentFin {

			get {

				if (this.internal_Param_ResidentFin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ResidentFin);
			}

			set {

				this.internal_Param_ResidentFin_UseDefaultValue = false;
				this.internal_Param_ResidentFin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ResidentFin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ResidentFin_UseDefaultValue() {

			this.internal_Param_ResidentFin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ContingentementDebut'.
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
		/// the parameter default value, consider calling the Param_ContingentementDebut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_ContingentementDebut {

			get {

				if (this.internal_Param_ContingentementDebut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContingentementDebut);
			}

			set {

				this.internal_Param_ContingentementDebut_UseDefaultValue = false;
				this.internal_Param_ContingentementDebut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContingentementDebut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContingentementDebut_UseDefaultValue() {

			this.internal_Param_ContingentementDebut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ContingentementFin'.
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
		/// the parameter default value, consider calling the Param_ContingentementFin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_ContingentementFin {

			get {

				if (this.internal_Param_ContingentementFin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContingentementFin);
			}

			set {

				this.internal_Param_ContingentementFin_UseDefaultValue = false;
				this.internal_Param_ContingentementFin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContingentementFin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContingentementFin_UseDefaultValue() {

			this.internal_Param_ContingentementFin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeAccorde'.
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
		/// the parameter default value, consider calling the Param_VolumeAccorde_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_VolumeAccorde {

			get {

				if (this.internal_Param_VolumeAccorde_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeAccorde);
			}

			set {

				this.internal_Param_VolumeAccorde_UseDefaultValue = false;
				this.internal_Param_VolumeAccorde = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeAccorde' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeAccorde_UseDefaultValue() {

			this.internal_Param_VolumeAccorde_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MunicipaliteDebut'.
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
		/// the parameter default value, consider calling the Param_MunicipaliteDebut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_MunicipaliteDebut {

			get {

				if (this.internal_Param_MunicipaliteDebut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MunicipaliteDebut);
			}

			set {

				this.internal_Param_MunicipaliteDebut_UseDefaultValue = false;
				this.internal_Param_MunicipaliteDebut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MunicipaliteDebut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MunicipaliteDebut_UseDefaultValue() {

			this.internal_Param_MunicipaliteDebut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@MunicipaliteFin'.
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
		/// the parameter default value, consider calling the Param_MunicipaliteFin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_MunicipaliteFin {

			get {

				if (this.internal_Param_MunicipaliteFin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_MunicipaliteFin);
			}

			set {

				this.internal_Param_MunicipaliteFin_UseDefaultValue = false;
				this.internal_Param_MunicipaliteFin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@MunicipaliteFin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_MunicipaliteFin_UseDefaultValue() {

			this.internal_Param_MunicipaliteFin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@SecteurDebut'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](2)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_SecteurDebut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_SecteurDebut {

			get {

				if (this.internal_Param_SecteurDebut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_SecteurDebut);
			}

			set {

				this.internal_Param_SecteurDebut_UseDefaultValue = false;
				this.internal_Param_SecteurDebut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@SecteurDebut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_SecteurDebut_UseDefaultValue() {

			this.internal_Param_SecteurDebut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@SecteurFin'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](2)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_SecteurFin_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_SecteurFin {

			get {

				if (this.internal_Param_SecteurFin_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_SecteurFin);
			}

			set {

				this.internal_Param_SecteurFin_UseDefaultValue = false;
				this.internal_Param_SecteurFin = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@SecteurFin' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_SecteurFin_UseDefaultValue() {

			this.internal_Param_SecteurFin_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DateRapport'.
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
		/// the parameter default value, consider calling the Param_DateRapport_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateRapport {

			get {

				if (this.internal_Param_DateRapport_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateRapport);
			}

			set {

				this.internal_Param_DateRapport_UseDefaultValue = false;
				this.internal_Param_DateRapport = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateRapport' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateRapport_UseDefaultValue() {

			this.internal_Param_DateRapport_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NePasEmettrePermis'.
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
		/// the parameter default value, consider calling the Param_NePasEmettrePermis_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_NePasEmettrePermis {

			get {

				if (this.internal_Param_NePasEmettrePermis_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NePasEmettrePermis);
			}

			set {

				this.internal_Param_NePasEmettrePermis_UseDefaultValue = false;
				this.internal_Param_NePasEmettrePermis = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NePasEmettrePermis' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NePasEmettrePermis_UseDefaultValue() {

			this.internal_Param_NePasEmettrePermis_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'jag_Rapport_Proprietaire_IdentificationProducteur' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class jag_Rapport_Proprietaire_IdentificationProducteur : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the jag_Rapport_Proprietaire_IdentificationProducteur class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public jag_Rapport_Proprietaire_IdentificationProducteur() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the jag_Rapport_Proprietaire_IdentificationProducteur class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public jag_Rapport_Proprietaire_IdentificationProducteur(bool throwExceptionOnExecute) {

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
		~jag_Rapport_Proprietaire_IdentificationProducteur() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur)");
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
				sqlCommand.CommandText = "jag_Rapport_Proprietaire_IdentificationProducteur";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@SupBoiseeMin", System.Data.SqlDbType.Float, 8);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_SupBoiseeMin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_SupBoiseeMin.IsNull) {

					sqlParameter.Value = parameters.Param_SupBoiseeMin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@SupBoiseeMax", System.Data.SqlDbType.Float, 8);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_SupBoiseeMax_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_SupBoiseeMax.IsNull) {

					sqlParameter.Value = parameters.Param_SupBoiseeMax;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProducteurDebut", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProducteurDebut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProducteurDebut.IsNull) {

					sqlParameter.Value = parameters.Param_ProducteurDebut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProducteurFin", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProducteurFin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProducteurFin.IsNull) {

					sqlParameter.Value = parameters.Param_ProducteurFin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MembreDebut", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MembreDebut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MembreDebut.IsNull) {

					sqlParameter.Value = parameters.Param_MembreDebut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MembreFin", System.Data.SqlDbType.VarChar, 10);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MembreFin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MembreFin.IsNull) {

					sqlParameter.Value = parameters.Param_MembreFin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Actif", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Actif_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Actif.IsNull) {

					sqlParameter.Value = parameters.Param_Actif;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ResidentDebut", System.Data.SqlDbType.Char, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ResidentDebut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ResidentDebut.IsNull) {

					sqlParameter.Value = parameters.Param_ResidentDebut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ResidentFin", System.Data.SqlDbType.Char, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ResidentFin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ResidentFin.IsNull) {

					sqlParameter.Value = parameters.Param_ResidentFin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContingentementDebut", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContingentementDebut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContingentementDebut.IsNull) {

					sqlParameter.Value = parameters.Param_ContingentementDebut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContingentementFin", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContingentementFin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContingentementFin.IsNull) {

					sqlParameter.Value = parameters.Param_ContingentementFin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeAccorde", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeAccorde_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeAccorde.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeAccorde;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteDebut", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MunicipaliteDebut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MunicipaliteDebut.IsNull) {

					sqlParameter.Value = parameters.Param_MunicipaliteDebut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@MunicipaliteFin", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_MunicipaliteFin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_MunicipaliteFin.IsNull) {

					sqlParameter.Value = parameters.Param_MunicipaliteFin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@SecteurDebut", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_SecteurDebut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_SecteurDebut.IsNull) {

					sqlParameter.Value = parameters.Param_SecteurDebut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@SecteurFin", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_SecteurFin_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_SecteurFin.IsNull) {

					sqlParameter.Value = parameters.Param_SecteurFin;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateRapport", System.Data.SqlDbType.DateTime, 16);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateRapport_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateRapport.IsNull) {

					sqlParameter.Value = parameters.Param_DateRapport;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NePasEmettrePermis", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NePasEmettrePermis_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NePasEmettrePermis.IsNull) {

					sqlParameter.Value = parameters.Param_NePasEmettrePermis;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [jag_Rapport_Proprietaire_IdentificationProducteur] stored procedure and retrieve back the data
		/// accessible via a SqlDataReader (System.Data.SqlClient.SqlDataReader).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="sqlDataReader">
		/// Will be created after execution. Don't forget to close it after usage.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader) {

			return(Execute(ref parameters, out sqlDataReader, System.Data.CommandBehavior.Default));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Rapport_Proprietaire_IdentificationProducteur] stored procedure and retrieve back the data
		/// accessible via a SqlDataReader (System.Data.SqlClient.SqlDataReader).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="sqlDataReader">
		/// Will be created after execution. Don't forget to close it after usage.
		/// </param>
		/// <param name="commandBehavior">
		/// One of the CommandBehavior values. 
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, out System.Data.SqlClient.SqlDataReader sqlDataReader, System.Data.CommandBehavior commandBehavior) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {

				sqlDataReader = null;
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
				sqlDataReader = sqlCommand.ExecuteReader(commandBehavior);
                
				parameters.internal_Set_ReturnValue_Available(false);

				parameters.internal_Set_SqlDataReader(ref sqlDataReader);
				parameters.internal_Set_SqlCommand(ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				sqlDataReader = null;
				parameters.internal_UpdateExceptionInformation(sqlException);
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

				sqlDataReader = null;
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

				// We do not close the SqlConnection because the SqlReader object needs it.
				// It is the responsability of the caller to close it by calling: SqlDataReader.Close();

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

		/// <summary>
		/// This method allows you to execute the [jag_Rapport_Proprietaire_IdentificationProducteur] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'jag_Rapport_Proprietaire_IdentificationProducteur'.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, ref System.Data.DataSet dataset) {

			return(Execute(ref parameters, ref dataset, "jag_Rapport_Proprietaire_IdentificationProducteur", -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Rapport_Proprietaire_IdentificationProducteur] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution. The table based name used will be: 'jag_Rapport_Proprietaire_IdentificationProducteur'.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, ref System.Data.DataSet dataset, int startRecord, int maxRecords) {

			return(Execute(ref parameters, ref dataset, "jag_Rapport_Proprietaire_IdentificationProducteur", startRecord, maxRecords));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Rapport_Proprietaire_IdentificationProducteur] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution.
		/// </param>
		/// <param name="tableName">
		/// Will be the based name of the table in the database.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, ref System.Data.DataSet dataset, string tableName) {

			return(Execute(ref parameters, ref dataset, tableName, -1, -1));
		}

		/// <summary>
		/// This method allows you to execute the [jag_Rapport_Proprietaire_IdentificationProducteur] stored procedure and retrieve back the data
		/// populated in a DataSet (System.Data.DataSet).
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <param name="dataset">
		/// Will be populated with the data after execution.
		/// </param>
		/// <param name="tableName">
		/// Will be the based name of the table in the database.
		/// </param>
		/// <param name="startRecord">The zero-based record number to start with.</param>
		/// <param name="maxRecords">The maximum number of records to retrieve.</param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.jag_Rapport_Proprietaire_IdentificationProducteur parameters, ref System.Data.DataSet dataset, string tableName, int startRecord, int maxRecords) {

			System.Data.SqlClient.SqlCommand sqlCommand = null;
			System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = null;
			System.Boolean returnStatus = false;
			System.Boolean connectionMustBeClosed = true;

			try {

				if (dataset == null) {

					dataset = new System.Data.DataSet();
				}
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
				sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
				sqlDataAdapter.SelectCommand = sqlCommand;

				if (startRecord == -1) {

					sqlDataAdapter.Fill(dataset, tableName);
				}
				else {

					sqlDataAdapter.Fill(dataset, startRecord, maxRecords, tableName);
				}
				sqlDataAdapter.Dispose();

				parameters.internal_SetErrorSource(ErrorSource.ParametersRetrieval);
				returnStatus = RetrieveParameters(ref parameters, ref sqlCommand);
			}

			catch (System.Data.SqlClient.SqlException sqlException) {

				dataset = null;
				parameters.internal_UpdateExceptionInformation(sqlException);
				returnStatus = false;

				if (this.throwExceptionOnExecute) {

					throw sqlException;
				}
			}

			catch (System.Exception exception) {

				dataset = null;
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

		/// <summary>
		/// This class allows to easily retrieve the name or index of all the fields
		/// of the resulset #1 existing in the Dataset or the SqlDatReader returned by
		/// the Execute method of the 'jag_Rapport_Proprietaire_IdentificationProducteur' class.
		/// </summary>
		public sealed class Resultset1 {


			/// <summary>
			/// This collection provides the fields collection for this resultset.
			/// </summary>
			public sealed class Fields {

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurID via shared members
				/// </summary>
				public sealed class Column_FournisseurID {

					/// <summary>
					/// Returns "FournisseurID"
					/// </summary>
					public const System.String ColumnName = "FournisseurID";
					/// <summary>
					/// Returns 0
					/// </summary>
					public const System.Int32 ColumnIndex = 0;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurNom via shared members
				/// </summary>
				public sealed class Column_FournisseurNom {

					/// <summary>
					/// Returns "FournisseurNom"
					/// </summary>
					public const System.String ColumnName = "FournisseurNom";
					/// <summary>
					/// Returns 1
					/// </summary>
					public const System.Int32 ColumnIndex = 1;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurAuSoinsDe via shared members
				/// </summary>
				public sealed class Column_FournisseurAuSoinsDe {

					/// <summary>
					/// Returns "FournisseurAuSoinsDe"
					/// </summary>
					public const System.String ColumnName = "FournisseurAuSoinsDe";
					/// <summary>
					/// Returns 2
					/// </summary>
					public const System.Int32 ColumnIndex = 2;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurRep via shared members
				/// </summary>
				public sealed class Column_FournisseurRep {

					/// <summary>
					/// Returns "FournisseurRep"
					/// </summary>
					public const System.String ColumnName = "FournisseurRep";
					/// <summary>
					/// Returns 3
					/// </summary>
					public const System.Int32 ColumnIndex = 3;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurRue via shared members
				/// </summary>
				public sealed class Column_FournisseurRue {

					/// <summary>
					/// Returns "FournisseurRue"
					/// </summary>
					public const System.String ColumnName = "FournisseurRue";
					/// <summary>
					/// Returns 4
					/// </summary>
					public const System.Int32 ColumnIndex = 4;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurVille via shared members
				/// </summary>
				public sealed class Column_FournisseurVille {

					/// <summary>
					/// Returns "FournisseurVille"
					/// </summary>
					public const System.String ColumnName = "FournisseurVille";
					/// <summary>
					/// Returns 5
					/// </summary>
					public const System.Int32 ColumnIndex = 5;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurCodePostal via shared members
				/// </summary>
				public sealed class Column_FournisseurCodePostal {

					/// <summary>
					/// Returns "FournisseurCodePostal"
					/// </summary>
					public const System.String ColumnName = "FournisseurCodePostal";
					/// <summary>
					/// Returns 6
					/// </summary>
					public const System.Int32 ColumnIndex = 6;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurPhone via shared members
				/// </summary>
				public sealed class Column_FournisseurPhone {

					/// <summary>
					/// Returns "FournisseurPhone"
					/// </summary>
					public const System.String ColumnName = "FournisseurPhone";
					/// <summary>
					/// Returns 7
					/// </summary>
					public const System.Int32 ColumnIndex = 7;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurTPS via shared members
				/// </summary>
				public sealed class Column_FournisseurTPS {

					/// <summary>
					/// Returns "FournisseurTPS"
					/// </summary>
					public const System.String ColumnName = "FournisseurTPS";
					/// <summary>
					/// Returns 8
					/// </summary>
					public const System.Int32 ColumnIndex = 8;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurTVQ via shared members
				/// </summary>
				public sealed class Column_FournisseurTVQ {

					/// <summary>
					/// Returns "FournisseurTVQ"
					/// </summary>
					public const System.String ColumnName = "FournisseurTVQ";
					/// <summary>
					/// Returns 9
					/// </summary>
					public const System.Int32 ColumnIndex = 9;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurSupBoisee via shared members
				/// </summary>
				public sealed class Column_FournisseurSupBoisee {

					/// <summary>
					/// Returns "FournisseurSupBoisee"
					/// </summary>
					public const System.String ColumnName = "FournisseurSupBoisee";
					/// <summary>
					/// Returns 10
					/// </summary>
					public const System.Int32 ColumnIndex = 10;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field FournisseurNoMembre via shared members
				/// </summary>
				public sealed class Column_FournisseurNoMembre {

					/// <summary>
					/// Returns "FournisseurNoMembre"
					/// </summary>
					public const System.String ColumnName = "FournisseurNoMembre";
					/// <summary>
					/// Returns 11
					/// </summary>
					public const System.Int32 ColumnIndex = 11;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Municipalite via shared members
				/// </summary>
				public sealed class Column_Municipalite {

					/// <summary>
					/// Returns "Municipalite"
					/// </summary>
					public const System.String ColumnName = "Municipalite";
					/// <summary>
					/// Returns 12
					/// </summary>
					public const System.Int32 ColumnIndex = 12;

				}

				/// <summary>
				/// Allows to get the Index and Name of the field Secteur via shared members
				/// </summary>
				public sealed class Column_Secteur {

					/// <summary>
					/// Returns "Secteur"
					/// </summary>
					public const System.String ColumnName = "Secteur";
					/// <summary>
					/// Returns 13
					/// </summary>
					public const System.Int32 ColumnIndex = 13;

				}

			}
		}

	}

}

