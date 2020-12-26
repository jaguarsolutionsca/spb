/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 30/03/2007 9:55:17 AM
			Generator name: <Developer Name Here>
			Template last update: 24/06/2002 1:53:57 AM
			Template revision: 15083637

			SQL Server version: 08.00.0760
			Server: CALIN\francais
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
	/// stored procedure 'spI_jag_System'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:17", SqlObjectDependancyName="spI_jag_System", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_jag_System : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_jag_System class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_jag_System() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_jag_System class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_jag_System(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_Paiements_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_ARecevoir_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_APayer_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TPSpercues_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TPSpayees_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TVQpercues_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_TVQpayees_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_TPS_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_TVQ_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Fournisseur_Fond_Roulement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Fournisseur_Fond_Forestier_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Fournisseur_Preleve_Divers_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_jag_System'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_jag_System", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_jag_System'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_jag_System", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_jag_System'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_jag_System", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_Fournisseur_PlanConjoint = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Fournisseur_Surcharge = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Compte_Paiements = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_ARecevoir = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_APayer = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_DuAuxProducteurs = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TPSpercues = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TPSpayees = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TVQpercues = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_TVQpayees = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Taux_TPS = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_TVQ = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Fournisseur_Fond_Roulement = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Fournisseur_Fond_Forestier = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Fournisseur_Preleve_Divers = System.Data.SqlTypes.SqlString.Null;

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
		~spI_jag_System() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_jag_System'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_jag_System");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur_PlanConjoint;
		internal bool internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur_Surcharge;
		internal bool internal_Param_Fournisseur_Surcharge_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_Paiements;
		internal bool internal_Param_Compte_Paiements_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_ARecevoir;
		internal bool internal_Param_Compte_ARecevoir_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_APayer;
		internal bool internal_Param_Compte_APayer_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_DuAuxProducteurs;
		internal bool internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TPSpercues;
		internal bool internal_Param_Compte_TPSpercues_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TPSpayees;
		internal bool internal_Param_Compte_TPSpayees_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TVQpercues;
		internal bool internal_Param_Compte_TVQpercues_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_TVQpayees;
		internal bool internal_Param_Compte_TVQpayees_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_TPS;
		internal bool internal_Param_Taux_TPS_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_TVQ;
		internal bool internal_Param_Taux_TVQ_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur_Fond_Roulement;
		internal bool internal_Param_Fournisseur_Fond_Roulement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur_Fond_Forestier;
		internal bool internal_Param_Fournisseur_Fond_Forestier_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Fournisseur_Preleve_Divers;
		internal bool internal_Param_Fournisseur_Preleve_Divers_UseDefaultValue = true;


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

			this.internal_Param_Fournisseur_PlanConjoint = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Fournisseur_Surcharge = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_Paiements = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_Paiements_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_ARecevoir = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_ARecevoir_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_APayer = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_APayer_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_DuAuxProducteurs = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TPSpercues = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TPSpercues_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TPSpayees = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TPSpayees_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TVQpercues = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TVQpercues_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_TVQpayees = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_TVQpayees_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_TPS = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_TPS_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_TVQ = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_TVQ_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Fournisseur_Fond_Roulement = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_Fond_Roulement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Fournisseur_Fond_Forestier = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_Fond_Forestier_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Fournisseur_Preleve_Divers = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Fournisseur_Preleve_Divers_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur_PlanConjoint'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_PlanConjoint_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur_PlanConjoint {

			get {

				if (this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur_PlanConjoint);
			}

			set {

				this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = false;
				this.internal_Param_Fournisseur_PlanConjoint = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur_PlanConjoint' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_PlanConjoint_UseDefaultValue() {

			this.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur_Surcharge'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_Surcharge_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur_Surcharge {

			get {

				if (this.internal_Param_Fournisseur_Surcharge_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur_Surcharge);
			}

			set {

				this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = false;
				this.internal_Param_Fournisseur_Surcharge = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur_Surcharge' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_Surcharge_UseDefaultValue() {

			this.internal_Param_Fournisseur_Surcharge_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_Paiements'.
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
		/// the parameter default value, consider calling the Param_Compte_Paiements_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_Paiements {

			get {

				if (this.internal_Param_Compte_Paiements_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_Paiements);
			}

			set {

				this.internal_Param_Compte_Paiements_UseDefaultValue = false;
				this.internal_Param_Compte_Paiements = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_Paiements' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_Paiements_UseDefaultValue() {

			this.internal_Param_Compte_Paiements_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_ARecevoir'.
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
		/// the parameter default value, consider calling the Param_Compte_ARecevoir_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_ARecevoir {

			get {

				if (this.internal_Param_Compte_ARecevoir_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_ARecevoir);
			}

			set {

				this.internal_Param_Compte_ARecevoir_UseDefaultValue = false;
				this.internal_Param_Compte_ARecevoir = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_ARecevoir' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_ARecevoir_UseDefaultValue() {

			this.internal_Param_Compte_ARecevoir_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_APayer'.
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
		/// the parameter default value, consider calling the Param_Compte_APayer_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_APayer {

			get {

				if (this.internal_Param_Compte_APayer_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_APayer);
			}

			set {

				this.internal_Param_Compte_APayer_UseDefaultValue = false;
				this.internal_Param_Compte_APayer = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_APayer' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_APayer_UseDefaultValue() {

			this.internal_Param_Compte_APayer_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_DuAuxProducteurs'.
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
		/// the parameter default value, consider calling the Param_Compte_DuAuxProducteurs_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_DuAuxProducteurs {

			get {

				if (this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_DuAuxProducteurs);
			}

			set {

				this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = false;
				this.internal_Param_Compte_DuAuxProducteurs = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_DuAuxProducteurs' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_DuAuxProducteurs_UseDefaultValue() {

			this.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TPSpercues'.
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
		/// the parameter default value, consider calling the Param_Compte_TPSpercues_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TPSpercues {

			get {

				if (this.internal_Param_Compte_TPSpercues_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TPSpercues);
			}

			set {

				this.internal_Param_Compte_TPSpercues_UseDefaultValue = false;
				this.internal_Param_Compte_TPSpercues = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TPSpercues' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TPSpercues_UseDefaultValue() {

			this.internal_Param_Compte_TPSpercues_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TPSpayees'.
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
		/// the parameter default value, consider calling the Param_Compte_TPSpayees_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TPSpayees {

			get {

				if (this.internal_Param_Compte_TPSpayees_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TPSpayees);
			}

			set {

				this.internal_Param_Compte_TPSpayees_UseDefaultValue = false;
				this.internal_Param_Compte_TPSpayees = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TPSpayees' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TPSpayees_UseDefaultValue() {

			this.internal_Param_Compte_TPSpayees_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TVQpercues'.
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
		/// the parameter default value, consider calling the Param_Compte_TVQpercues_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TVQpercues {

			get {

				if (this.internal_Param_Compte_TVQpercues_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TVQpercues);
			}

			set {

				this.internal_Param_Compte_TVQpercues_UseDefaultValue = false;
				this.internal_Param_Compte_TVQpercues = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TVQpercues' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TVQpercues_UseDefaultValue() {

			this.internal_Param_Compte_TVQpercues_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_TVQpayees'.
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
		/// the parameter default value, consider calling the Param_Compte_TVQpayees_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_TVQpayees {

			get {

				if (this.internal_Param_Compte_TVQpayees_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_TVQpayees);
			}

			set {

				this.internal_Param_Compte_TVQpayees_UseDefaultValue = false;
				this.internal_Param_Compte_TVQpayees = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_TVQpayees' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_TVQpayees_UseDefaultValue() {

			this.internal_Param_Compte_TVQpayees_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_TPS'.
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
		/// the parameter default value, consider calling the Param_Taux_TPS_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_TPS {

			get {

				if (this.internal_Param_Taux_TPS_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_TPS);
			}

			set {

				this.internal_Param_Taux_TPS_UseDefaultValue = false;
				this.internal_Param_Taux_TPS = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_TPS' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_TPS_UseDefaultValue() {

			this.internal_Param_Taux_TPS_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_TVQ'.
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
		/// the parameter default value, consider calling the Param_Taux_TVQ_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_TVQ {

			get {

				if (this.internal_Param_Taux_TVQ_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_TVQ);
			}

			set {

				this.internal_Param_Taux_TVQ_UseDefaultValue = false;
				this.internal_Param_Taux_TVQ = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_TVQ' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_TVQ_UseDefaultValue() {

			this.internal_Param_Taux_TVQ_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur_Fond_Roulement'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_Fond_Roulement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur_Fond_Roulement {

			get {

				if (this.internal_Param_Fournisseur_Fond_Roulement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur_Fond_Roulement);
			}

			set {

				this.internal_Param_Fournisseur_Fond_Roulement_UseDefaultValue = false;
				this.internal_Param_Fournisseur_Fond_Roulement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur_Fond_Roulement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_Fond_Roulement_UseDefaultValue() {

			this.internal_Param_Fournisseur_Fond_Roulement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur_Fond_Forestier'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_Fond_Forestier_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur_Fond_Forestier {

			get {

				if (this.internal_Param_Fournisseur_Fond_Forestier_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur_Fond_Forestier);
			}

			set {

				this.internal_Param_Fournisseur_Fond_Forestier_UseDefaultValue = false;
				this.internal_Param_Fournisseur_Fond_Forestier = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur_Fond_Forestier' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_Fond_Forestier_UseDefaultValue() {

			this.internal_Param_Fournisseur_Fond_Forestier_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Fournisseur_Preleve_Divers'.
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
		/// the parameter default value, consider calling the Param_Fournisseur_Preleve_Divers_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Fournisseur_Preleve_Divers {

			get {

				if (this.internal_Param_Fournisseur_Preleve_Divers_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Fournisseur_Preleve_Divers);
			}

			set {

				this.internal_Param_Fournisseur_Preleve_Divers_UseDefaultValue = false;
				this.internal_Param_Fournisseur_Preleve_Divers = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Fournisseur_Preleve_Divers' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Fournisseur_Preleve_Divers_UseDefaultValue() {

			this.internal_Param_Fournisseur_Preleve_Divers_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_jag_System' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:17", SqlObjectDependancyName="spI_jag_System", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_jag_System : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_jag_System class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_jag_System() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_jag_System class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_jag_System(bool throwExceptionOnExecute) {

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
		~spI_jag_System() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_jag_System parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_jag_System parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_jag_System object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_jag_System object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_jag_System object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_jag_System)");
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
				sqlCommand.CommandText = "spI_jag_System";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_jag_System parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur_PlanConjoint", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur_PlanConjoint";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_PlanConjoint_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur_PlanConjoint.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur_PlanConjoint;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur_Surcharge", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur_Surcharge";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_Surcharge_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur_Surcharge.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur_Surcharge;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_Paiements", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_Paiements";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_Paiements_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_Paiements.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_Paiements;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_ARecevoir", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_ARecevoir";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_ARecevoir_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_ARecevoir.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_ARecevoir;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_APayer", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_APayer";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_APayer_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_APayer.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_APayer;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_DuAuxProducteurs", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_DuAuxProducteurs";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_DuAuxProducteurs_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_DuAuxProducteurs.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_DuAuxProducteurs;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TPSpercues", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TPSpercues";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TPSpercues_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TPSpercues.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TPSpercues;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TPSpayees", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TPSpayees";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TPSpayees_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TPSpayees.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TPSpayees;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TVQpercues", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TVQpercues";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TVQpercues_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TVQpercues.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TVQpercues;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_TVQpayees", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_TVQpayees";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_TVQpayees_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_TVQpayees.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_TVQpayees;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_TPS", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_TPS";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_TPS_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_TPS.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_TPS;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_TVQ", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_TVQ";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_TVQ_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_TVQ.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_TVQ;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur_Fond_Roulement", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur_Fond_Roulement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_Fond_Roulement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur_Fond_Roulement.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur_Fond_Roulement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur_Fond_Forestier", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur_Fond_Forestier";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_Fond_Forestier_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur_Fond_Forestier.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur_Fond_Forestier;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Fournisseur_Preleve_Divers", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Fournisseur_Preleve_Divers";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Fournisseur_Preleve_Divers_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Fournisseur_Preleve_Divers.IsNull) {

					sqlParameter.Value = parameters.Param_Fournisseur_Preleve_Divers;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_jag_System parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spI_jag_System] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_jag_System parameters) {

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

