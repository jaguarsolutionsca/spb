﻿using System;

namespace Gestion_Paie.DataClasses.Parameters {

	/// <summary>
	/// This class allows a developer to specify the parameters expected by the
	/// stored procedure 'spU_Contingentement_Producteur'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
	public sealed class spU_Contingentement_Producteur : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spU_Contingentement_Producteur class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spU_Contingentement_Producteur() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Contingentement_Producteur class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spU_Contingentement_Producteur(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ContingentementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Superficie_Contingentee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Demande_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Volume_Demande_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Facteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Volume_Facteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Fixe_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Volume_Fixe_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Supplementaire_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Accorde_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Volume_Accorde_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Date_Modification_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Date_Modification_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Volume_Inventaire_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Volume_Inventaire_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LastLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_LastLivraison_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeMaximum_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_VolumeMaximum_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Imprime_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ConsiderNull_Imprime_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Contingentement_Producteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Contingentement_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Contingentement_Producteur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Contingentement_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spU_Contingentement_Producteur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spU_Contingentement_Producteur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Superficie_Contingentee = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Superficie_Contingentee = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Volume_Demande = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Volume_Demande = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Volume_Facteur = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Volume_Facteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Volume_Fixe = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Volume_Supplementaire = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Volume_Supplementaire = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Volume_Accorde = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Volume_Accorde = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_Date_Modification = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Volume_Inventaire = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_Volume_Inventaire = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_LastLivraison = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_ConsiderNull_LastLivraison = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeMaximum = System.Data.SqlTypes.SqlSingle.Null;
				this.internal_Param_ConsiderNull_VolumeMaximum = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Imprime = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_ConsiderNull_Imprime = System.Data.SqlTypes.SqlBoolean.Null;

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
		~spU_Contingentement_Producteur() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spU_Contingentement_Producteur'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spU_Contingentement_Producteur");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ContingentementID;
		internal bool internal_Param_ContingentementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurID;
		internal bool internal_Param_ProducteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Superficie_Contingentee;
		internal bool internal_Param_Superficie_Contingentee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Superficie_Contingentee;
		internal bool internal_Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Demande;
		internal bool internal_Param_Volume_Demande_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Volume_Demande;
		internal bool internal_Param_ConsiderNull_Volume_Demande_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Facteur;
		internal bool internal_Param_Volume_Facteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Volume_Facteur;
		internal bool internal_Param_ConsiderNull_Volume_Facteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Fixe;
		internal bool internal_Param_Volume_Fixe_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Volume_Fixe;
		internal bool internal_Param_ConsiderNull_Volume_Fixe_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Supplementaire;
		internal bool internal_Param_Volume_Supplementaire_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Volume_Supplementaire;
		internal bool internal_Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Accorde;
		internal bool internal_Param_Volume_Accorde_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Volume_Accorde;
		internal bool internal_Param_ConsiderNull_Volume_Accorde_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_Date_Modification;
		internal bool internal_Param_Date_Modification_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Date_Modification;
		internal bool internal_Param_ConsiderNull_Date_Modification_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_Volume_Inventaire;
		internal bool internal_Param_Volume_Inventaire_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Volume_Inventaire;
		internal bool internal_Param_ConsiderNull_Volume_Inventaire_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_LastLivraison;
		internal bool internal_Param_LastLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_LastLivraison;
		internal bool internal_Param_ConsiderNull_LastLivraison_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlSingle internal_Param_VolumeMaximum;
		internal bool internal_Param_VolumeMaximum_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_VolumeMaximum;
		internal bool internal_Param_ConsiderNull_VolumeMaximum_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Imprime;
		internal bool internal_Param_Imprime_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_ConsiderNull_Imprime;
		internal bool internal_Param_ConsiderNull_Imprime_UseDefaultValue = true;


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

			this.internal_Param_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ContingentementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Superficie_Contingentee = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Superficie_Contingentee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Superficie_Contingentee = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Demande = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Demande_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Volume_Demande = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Volume_Demande_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Facteur = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Facteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Volume_Facteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Volume_Facteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Fixe = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Fixe_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Volume_Fixe = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Volume_Fixe_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Supplementaire = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Supplementaire_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Volume_Supplementaire = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Accorde = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Accorde_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Volume_Accorde = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Volume_Accorde_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Date_Modification = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_Date_Modification_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Date_Modification = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Date_Modification_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Volume_Inventaire = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_Volume_Inventaire_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Volume_Inventaire = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Volume_Inventaire_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_LastLivraison = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_LastLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_LastLivraison = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_LastLivraison_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeMaximum = System.Data.SqlTypes.SqlSingle.Null;
			this.internal_Param_VolumeMaximum_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_VolumeMaximum = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_VolumeMaximum_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Imprime = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Imprime_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ConsiderNull_Imprime = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_ConsiderNull_Imprime_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@ContingentementID'.
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
		/// the parameter default value, consider calling the Param_ContingentementID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_ContingentementID {

			get {

				if (this.internal_Param_ContingentementID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ContingentementID);
			}

			set {

				this.internal_Param_ContingentementID_UseDefaultValue = false;
				this.internal_Param_ContingentementID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ContingentementID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ContingentementID_UseDefaultValue() {

			this.internal_Param_ContingentementID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ProducteurID'.
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
		/// the parameter default value, consider calling the Param_ProducteurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_ProducteurID {

			get {

				if (this.internal_Param_ProducteurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ProducteurID);
			}

			set {

				this.internal_Param_ProducteurID_UseDefaultValue = false;
				this.internal_Param_ProducteurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ProducteurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ProducteurID_UseDefaultValue() {

			this.internal_Param_ProducteurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Superficie_Contingentee'.
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
		/// the parameter default value, consider calling the Param_Superficie_Contingentee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Superficie_Contingentee {

			get {

				if (this.internal_Param_Superficie_Contingentee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Superficie_Contingentee);
			}

			set {

				this.internal_Param_Superficie_Contingentee_UseDefaultValue = false;
				this.internal_Param_Superficie_Contingentee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Superficie_Contingentee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Superficie_Contingentee_UseDefaultValue() {

			this.internal_Param_Superficie_Contingentee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Superficie_Contingentee'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Superficie_Contingentee {

			get {

				if (this.internal_Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Superficie_Contingentee);
			}

			set {

				this.internal_Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Superficie_Contingentee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Superficie_Contingentee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Demande'.
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
		/// the parameter default value, consider calling the Param_Volume_Demande_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Demande {

			get {

				if (this.internal_Param_Volume_Demande_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Demande);
			}

			set {

				this.internal_Param_Volume_Demande_UseDefaultValue = false;
				this.internal_Param_Volume_Demande = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Demande' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Demande_UseDefaultValue() {

			this.internal_Param_Volume_Demande_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Volume_Demande'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Volume_Demande_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Volume_Demande {

			get {

				if (this.internal_Param_ConsiderNull_Volume_Demande_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Volume_Demande);
			}

			set {

				this.internal_Param_ConsiderNull_Volume_Demande_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Volume_Demande = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Volume_Demande' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Volume_Demande_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Volume_Demande_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Facteur'.
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
		/// the parameter default value, consider calling the Param_Volume_Facteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Facteur {

			get {

				if (this.internal_Param_Volume_Facteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Facteur);
			}

			set {

				this.internal_Param_Volume_Facteur_UseDefaultValue = false;
				this.internal_Param_Volume_Facteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Facteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Facteur_UseDefaultValue() {

			this.internal_Param_Volume_Facteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Volume_Facteur'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Volume_Facteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Volume_Facteur {

			get {

				if (this.internal_Param_ConsiderNull_Volume_Facteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Volume_Facteur);
			}

			set {

				this.internal_Param_ConsiderNull_Volume_Facteur_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Volume_Facteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Volume_Facteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Volume_Facteur_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Volume_Facteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Fixe'.
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
		/// the parameter default value, consider calling the Param_Volume_Fixe_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Fixe {

			get {

				if (this.internal_Param_Volume_Fixe_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Fixe);
			}

			set {

				this.internal_Param_Volume_Fixe_UseDefaultValue = false;
				this.internal_Param_Volume_Fixe = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Fixe' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Fixe_UseDefaultValue() {

			this.internal_Param_Volume_Fixe_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Volume_Fixe'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Volume_Fixe_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Volume_Fixe {

			get {

				if (this.internal_Param_ConsiderNull_Volume_Fixe_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Volume_Fixe);
			}

			set {

				this.internal_Param_ConsiderNull_Volume_Fixe_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Volume_Fixe = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Volume_Fixe' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Volume_Fixe_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Volume_Fixe_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Supplementaire'.
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
		/// the parameter default value, consider calling the Param_Volume_Supplementaire_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Supplementaire {

			get {

				if (this.internal_Param_Volume_Supplementaire_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Supplementaire);
			}

			set {

				this.internal_Param_Volume_Supplementaire_UseDefaultValue = false;
				this.internal_Param_Volume_Supplementaire = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Supplementaire' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Supplementaire_UseDefaultValue() {

			this.internal_Param_Volume_Supplementaire_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Volume_Supplementaire'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Volume_Supplementaire {

			get {

				if (this.internal_Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Volume_Supplementaire);
			}

			set {

				this.internal_Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Volume_Supplementaire = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Volume_Supplementaire' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Accorde'.
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
		/// the parameter default value, consider calling the Param_Volume_Accorde_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Accorde {

			get {

				if (this.internal_Param_Volume_Accorde_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Accorde);
			}

			set {

				this.internal_Param_Volume_Accorde_UseDefaultValue = false;
				this.internal_Param_Volume_Accorde = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Accorde' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Accorde_UseDefaultValue() {

			this.internal_Param_Volume_Accorde_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Volume_Accorde'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Volume_Accorde_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Volume_Accorde {

			get {

				if (this.internal_Param_ConsiderNull_Volume_Accorde_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Volume_Accorde);
			}

			set {

				this.internal_Param_ConsiderNull_Volume_Accorde_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Volume_Accorde = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Volume_Accorde' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Volume_Accorde_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Volume_Accorde_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Date_Modification'.
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
		/// the parameter default value, consider calling the Param_Date_Modification_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_Date_Modification {

			get {

				if (this.internal_Param_Date_Modification_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Date_Modification);
			}

			set {

				this.internal_Param_Date_Modification_UseDefaultValue = false;
				this.internal_Param_Date_Modification = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Date_Modification' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Date_Modification_UseDefaultValue() {

			this.internal_Param_Date_Modification_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Date_Modification'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Date_Modification_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Date_Modification {

			get {

				if (this.internal_Param_ConsiderNull_Date_Modification_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Date_Modification);
			}

			set {

				this.internal_Param_ConsiderNull_Date_Modification_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Date_Modification = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Date_Modification' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Date_Modification_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Date_Modification_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Volume_Inventaire'.
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
		/// the parameter default value, consider calling the Param_Volume_Inventaire_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_Volume_Inventaire {

			get {

				if (this.internal_Param_Volume_Inventaire_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Volume_Inventaire);
			}

			set {

				this.internal_Param_Volume_Inventaire_UseDefaultValue = false;
				this.internal_Param_Volume_Inventaire = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Volume_Inventaire' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Volume_Inventaire_UseDefaultValue() {

			this.internal_Param_Volume_Inventaire_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Volume_Inventaire'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Volume_Inventaire_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Volume_Inventaire {

			get {

				if (this.internal_Param_ConsiderNull_Volume_Inventaire_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Volume_Inventaire);
			}

			set {

				this.internal_Param_ConsiderNull_Volume_Inventaire_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Volume_Inventaire = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Volume_Inventaire' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Volume_Inventaire_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Volume_Inventaire_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@LastLivraison'.
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
		/// the parameter default value, consider calling the Param_LastLivraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_LastLivraison {

			get {

				if (this.internal_Param_LastLivraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_LastLivraison);
			}

			set {

				this.internal_Param_LastLivraison_UseDefaultValue = false;
				this.internal_Param_LastLivraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@LastLivraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_LastLivraison_UseDefaultValue() {

			this.internal_Param_LastLivraison_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_LastLivraison'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_LastLivraison_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_LastLivraison {

			get {

				if (this.internal_Param_ConsiderNull_LastLivraison_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_LastLivraison);
			}

			set {

				this.internal_Param_ConsiderNull_LastLivraison_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_LastLivraison = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_LastLivraison' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_LastLivraison_UseDefaultValue() {

			this.internal_Param_ConsiderNull_LastLivraison_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeMaximum'.
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
		/// the parameter default value, consider calling the Param_VolumeMaximum_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlSingle Param_VolumeMaximum {

			get {

				if (this.internal_Param_VolumeMaximum_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeMaximum);
			}

			set {

				this.internal_Param_VolumeMaximum_UseDefaultValue = false;
				this.internal_Param_VolumeMaximum = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeMaximum' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeMaximum_UseDefaultValue() {

			this.internal_Param_VolumeMaximum_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_VolumeMaximum'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_VolumeMaximum_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_VolumeMaximum {

			get {

				if (this.internal_Param_ConsiderNull_VolumeMaximum_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_VolumeMaximum);
			}

			set {

				this.internal_Param_ConsiderNull_VolumeMaximum_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_VolumeMaximum = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_VolumeMaximum' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_VolumeMaximum_UseDefaultValue() {

			this.internal_Param_ConsiderNull_VolumeMaximum_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Imprime'.
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
		/// the parameter default value, consider calling the Param_Imprime_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Imprime {

			get {

				if (this.internal_Param_Imprime_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Imprime);
			}

			set {

				this.internal_Param_Imprime_UseDefaultValue = false;
				this.internal_Param_Imprime = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Imprime' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Imprime_UseDefaultValue() {

			this.internal_Param_Imprime_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@ConsiderNull_Imprime'.
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
		/// the parameter default value, consider calling the Param_ConsiderNull_Imprime_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_ConsiderNull_Imprime {

			get {

				if (this.internal_Param_ConsiderNull_Imprime_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_ConsiderNull_Imprime);
			}

			set {

				this.internal_Param_ConsiderNull_Imprime_UseDefaultValue = false;
				this.internal_Param_ConsiderNull_Imprime = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@ConsiderNull_Imprime' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_ConsiderNull_Imprime_UseDefaultValue() {

			this.internal_Param_ConsiderNull_Imprime_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spU_Contingentement_Producteur' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
	public sealed class spU_Contingentement_Producteur : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spU_Contingentement_Producteur class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spU_Contingentement_Producteur() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spU_Contingentement_Producteur class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spU_Contingentement_Producteur(bool throwExceptionOnExecute) {

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
		~spU_Contingentement_Producteur() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur)");
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
				sqlCommand.CommandText = "spU_Contingentement_Producteur";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ContingentementID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "ContingentementID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ContingentementID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ContingentementID.IsNull) {

					sqlParameter.Value = parameters.Param_ContingentementID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ProducteurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "ProducteurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ProducteurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ProducteurID.IsNull) {

					sqlParameter.Value = parameters.Param_ProducteurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Superficie_Contingentee", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Superficie_Contingentee";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Superficie_Contingentee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Superficie_Contingentee.IsNull) {

					sqlParameter.Value = parameters.Param_Superficie_Contingentee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Superficie_Contingentee", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Superficie_Contingentee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Superficie_Contingentee.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Superficie_Contingentee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Demande", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Demande";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Demande_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Demande.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Demande;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Volume_Demande", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Volume_Demande_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Volume_Demande.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Volume_Demande;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Facteur", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Facteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Facteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Facteur.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Facteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Volume_Facteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Volume_Facteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Volume_Facteur.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Volume_Facteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Fixe", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Fixe";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Fixe_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Fixe.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Fixe;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Volume_Fixe", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Volume_Fixe_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Volume_Fixe.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Volume_Fixe;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Supplementaire", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Supplementaire";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Supplementaire_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Supplementaire.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Supplementaire;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Volume_Supplementaire", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Volume_Supplementaire_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Volume_Supplementaire.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Volume_Supplementaire;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Accorde", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Accorde";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Accorde_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Accorde.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Accorde;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Volume_Accorde", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Volume_Accorde_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Volume_Accorde.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Volume_Accorde;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Date_Modification", System.Data.SqlDbType.DateTime, 16);
				sqlParameter.SourceColumn = "Date_Modification";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Date_Modification_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Date_Modification.IsNull) {

					sqlParameter.Value = parameters.Param_Date_Modification;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Date_Modification", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Date_Modification_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Date_Modification.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Date_Modification;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Volume_Inventaire", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "Volume_Inventaire";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Volume_Inventaire_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Volume_Inventaire.IsNull) {

					sqlParameter.Value = parameters.Param_Volume_Inventaire;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Volume_Inventaire", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Volume_Inventaire_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Volume_Inventaire.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Volume_Inventaire;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LastLivraison", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "LastLivraison";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_LastLivraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_LastLivraison.IsNull) {

					sqlParameter.Value = parameters.Param_LastLivraison;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_LastLivraison", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_LastLivraison_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_LastLivraison.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_LastLivraison;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeMaximum", System.Data.SqlDbType.Real, 4);
				sqlParameter.SourceColumn = "VolumeMaximum";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeMaximum_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeMaximum.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeMaximum;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_VolumeMaximum", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_VolumeMaximum_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_VolumeMaximum.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_VolumeMaximum;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Imprime", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Imprime";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Imprime_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Imprime.IsNull) {

					sqlParameter.Value = parameters.Param_Imprime;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ConsiderNull_Imprime", System.Data.SqlDbType.Bit, 1);
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_ConsiderNull_Imprime_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_ConsiderNull_Imprime.IsNull) {

					sqlParameter.Value = parameters.Param_ConsiderNull_Imprime;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spU_Contingentement_Producteur] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spU_Contingentement_Producteur parameters) {

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

