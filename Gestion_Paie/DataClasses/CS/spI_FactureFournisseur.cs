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
	/// stored procedure 'spI_FactureFournisseur'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:17", SqlObjectDependancyName="spI_FactureFournisseur", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_FactureFournisseur : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_FactureFournisseur class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_FactureFournisseur() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_FactureFournisseur class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_FactureFournisseur(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NoFacture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateFacture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TypeFactureFournisseur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TypeFacture_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_TypeInvoiceAcomba_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_FournisseurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PayerAID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Total_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_TPS_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_TVQ_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Description_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Status_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_StatusDescription_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NumeroCheque_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NumeroPaiement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NumeroPaiementUnique_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateFactureAcomba_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DatePaiementAcomba_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_FactureFournisseur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_FactureFournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_FactureFournisseur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_FactureFournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_FactureFournisseur'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_FactureFournisseur", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_NoFacture = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_DateFacture = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_TypeFactureFournisseur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TypeFacture = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_TypeInvoiceAcomba = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_FournisseurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_PayerAID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Montant_Total = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_TPS = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_TVQ = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Description = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Status = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_StatusDescription = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_NumeroCheque = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_NumeroPaiement = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_NumeroPaiementUnique = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_DateFactureAcomba = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_DatePaiementAcomba = System.Data.SqlTypes.SqlDateTime.Null;

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
		~spI_FactureFournisseur() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_FactureFournisseur'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_FactureFournisseur");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NoFacture;
		internal bool internal_Param_NoFacture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateFacture;
		internal bool internal_Param_DateFacture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Annee;
		internal bool internal_Param_Annee_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TypeFactureFournisseur;
		internal bool internal_Param_TypeFactureFournisseur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_TypeFacture;
		internal bool internal_Param_TypeFacture_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_TypeInvoiceAcomba;
		internal bool internal_Param_TypeInvoiceAcomba_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_FournisseurID;
		internal bool internal_Param_FournisseurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_PayerAID;
		internal bool internal_Param_PayerAID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Total;
		internal bool internal_Param_Montant_Total_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_TPS;
		internal bool internal_Param_Montant_TPS_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_TVQ;
		internal bool internal_Param_Montant_TVQ_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Description;
		internal bool internal_Param_Description_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Status;
		internal bool internal_Param_Status_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_StatusDescription;
		internal bool internal_Param_StatusDescription_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NumeroCheque;
		internal bool internal_Param_NumeroCheque_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NumeroPaiement;
		internal bool internal_Param_NumeroPaiement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NumeroPaiementUnique;
		internal bool internal_Param_NumeroPaiementUnique_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateFactureAcomba;
		internal bool internal_Param_DateFactureAcomba_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DatePaiementAcomba;
		internal bool internal_Param_DatePaiementAcomba_UseDefaultValue = true;


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

			this.internal_Param_NoFacture = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NoFacture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateFacture = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateFacture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Annee = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Annee_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TypeFactureFournisseur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TypeFactureFournisseur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TypeFacture = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_TypeFacture_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_TypeInvoiceAcomba = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_TypeInvoiceAcomba_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_FournisseurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_FournisseurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PayerAID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_PayerAID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Total = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Total_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_TPS = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_TPS_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_TVQ = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_TVQ_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Description = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Description_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Status = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Status_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_StatusDescription = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_StatusDescription_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NumeroCheque = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NumeroCheque_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NumeroPaiement = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NumeroPaiement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NumeroPaiementUnique = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NumeroPaiementUnique_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateFactureAcomba = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateFactureAcomba_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DatePaiementAcomba = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DatePaiementAcomba_UseDefaultValue = this.useDefaultValue;

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
		/// Sets or returns the value of the stored procedure OUTPUT parameter '@ID'.
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
		/// Sets the value of the stored procedure INPUT parameter '@NoFacture'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](12)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NoFacture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NoFacture {

			get {

				if (this.internal_Param_NoFacture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NoFacture);
			}

			set {

				this.internal_Param_NoFacture_UseDefaultValue = false;
				this.internal_Param_NoFacture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NoFacture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NoFacture_UseDefaultValue() {

			this.internal_Param_NoFacture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DateFacture'.
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
		/// the parameter default value, consider calling the Param_DateFacture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateFacture {

			get {

				if (this.internal_Param_DateFacture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateFacture);
			}

			set {

				this.internal_Param_DateFacture_UseDefaultValue = false;
				this.internal_Param_DateFacture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateFacture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateFacture_UseDefaultValue() {

			this.internal_Param_DateFacture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Annee'.
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
		/// the parameter default value, consider calling the Param_Annee_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Annee {

			get {

				if (this.internal_Param_Annee_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Annee);
			}

			set {

				this.internal_Param_Annee_UseDefaultValue = false;
				this.internal_Param_Annee = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Annee' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Annee_UseDefaultValue() {

			this.internal_Param_Annee_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TypeFactureFournisseur'.
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
		/// the parameter default value, consider calling the Param_TypeFactureFournisseur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TypeFactureFournisseur {

			get {

				if (this.internal_Param_TypeFactureFournisseur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TypeFactureFournisseur);
			}

			set {

				this.internal_Param_TypeFactureFournisseur_UseDefaultValue = false;
				this.internal_Param_TypeFactureFournisseur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TypeFactureFournisseur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TypeFactureFournisseur_UseDefaultValue() {

			this.internal_Param_TypeFactureFournisseur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TypeFacture'.
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
		/// the parameter default value, consider calling the Param_TypeFacture_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_TypeFacture {

			get {

				if (this.internal_Param_TypeFacture_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TypeFacture);
			}

			set {

				this.internal_Param_TypeFacture_UseDefaultValue = false;
				this.internal_Param_TypeFacture = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TypeFacture' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TypeFacture_UseDefaultValue() {

			this.internal_Param_TypeFacture_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@TypeInvoiceAcomba'.
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
		/// the parameter default value, consider calling the Param_TypeInvoiceAcomba_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_TypeInvoiceAcomba {

			get {

				if (this.internal_Param_TypeInvoiceAcomba_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_TypeInvoiceAcomba);
			}

			set {

				this.internal_Param_TypeInvoiceAcomba_UseDefaultValue = false;
				this.internal_Param_TypeInvoiceAcomba = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@TypeInvoiceAcomba' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_TypeInvoiceAcomba_UseDefaultValue() {

			this.internal_Param_TypeInvoiceAcomba_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@FournisseurID'.
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
		/// the parameter default value, consider calling the Param_FournisseurID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_FournisseurID {

			get {

				if (this.internal_Param_FournisseurID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_FournisseurID);
			}

			set {

				this.internal_Param_FournisseurID_UseDefaultValue = false;
				this.internal_Param_FournisseurID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@FournisseurID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_FournisseurID_UseDefaultValue() {

			this.internal_Param_FournisseurID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PayerAID'.
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
		/// the parameter default value, consider calling the Param_PayerAID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_PayerAID {

			get {

				if (this.internal_Param_PayerAID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PayerAID);
			}

			set {

				this.internal_Param_PayerAID_UseDefaultValue = false;
				this.internal_Param_PayerAID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PayerAID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PayerAID_UseDefaultValue() {

			this.internal_Param_PayerAID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Total'.
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
		/// the parameter default value, consider calling the Param_Montant_Total_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Total {

			get {

				if (this.internal_Param_Montant_Total_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Total);
			}

			set {

				this.internal_Param_Montant_Total_UseDefaultValue = false;
				this.internal_Param_Montant_Total = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Total' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Total_UseDefaultValue() {

			this.internal_Param_Montant_Total_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_TPS'.
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
		/// the parameter default value, consider calling the Param_Montant_TPS_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_TPS {

			get {

				if (this.internal_Param_Montant_TPS_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_TPS);
			}

			set {

				this.internal_Param_Montant_TPS_UseDefaultValue = false;
				this.internal_Param_Montant_TPS = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_TPS' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_TPS_UseDefaultValue() {

			this.internal_Param_Montant_TPS_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_TVQ'.
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
		/// the parameter default value, consider calling the Param_Montant_TVQ_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_TVQ {

			get {

				if (this.internal_Param_Montant_TVQ_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_TVQ);
			}

			set {

				this.internal_Param_Montant_TVQ_UseDefaultValue = false;
				this.internal_Param_Montant_TVQ = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_TVQ' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_TVQ_UseDefaultValue() {

			this.internal_Param_Montant_TVQ_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Description'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](255)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Description_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Description {

			get {

				if (this.internal_Param_Description_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Description);
			}

			set {

				this.internal_Param_Description_UseDefaultValue = false;
				this.internal_Param_Description = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Description' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Description_UseDefaultValue() {

			this.internal_Param_Description_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Status'.
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
		/// the parameter default value, consider calling the Param_Status_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Status {

			get {

				if (this.internal_Param_Status_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Status);
			}

			set {

				this.internal_Param_Status_UseDefaultValue = false;
				this.internal_Param_Status = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Status' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Status_UseDefaultValue() {

			this.internal_Param_Status_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@StatusDescription'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](300)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_StatusDescription_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_StatusDescription {

			get {

				if (this.internal_Param_StatusDescription_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_StatusDescription);
			}

			set {

				this.internal_Param_StatusDescription_UseDefaultValue = false;
				this.internal_Param_StatusDescription = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@StatusDescription' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_StatusDescription_UseDefaultValue() {

			this.internal_Param_StatusDescription_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NumeroCheque'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](20)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NumeroCheque_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NumeroCheque {

			get {

				if (this.internal_Param_NumeroCheque_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NumeroCheque);
			}

			set {

				this.internal_Param_NumeroCheque_UseDefaultValue = false;
				this.internal_Param_NumeroCheque = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NumeroCheque' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NumeroCheque_UseDefaultValue() {

			this.internal_Param_NumeroCheque_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NumeroPaiement'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](20)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NumeroPaiement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NumeroPaiement {

			get {

				if (this.internal_Param_NumeroPaiement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NumeroPaiement);
			}

			set {

				this.internal_Param_NumeroPaiement_UseDefaultValue = false;
				this.internal_Param_NumeroPaiement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NumeroPaiement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NumeroPaiement_UseDefaultValue() {

			this.internal_Param_NumeroPaiement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NumeroPaiementUnique'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](20)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_NumeroPaiementUnique_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NumeroPaiementUnique {

			get {

				if (this.internal_Param_NumeroPaiementUnique_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NumeroPaiementUnique);
			}

			set {

				this.internal_Param_NumeroPaiementUnique_UseDefaultValue = false;
				this.internal_Param_NumeroPaiementUnique = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NumeroPaiementUnique' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NumeroPaiementUnique_UseDefaultValue() {

			this.internal_Param_NumeroPaiementUnique_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DateFactureAcomba'.
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
		/// the parameter default value, consider calling the Param_DateFactureAcomba_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateFactureAcomba {

			get {

				if (this.internal_Param_DateFactureAcomba_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateFactureAcomba);
			}

			set {

				this.internal_Param_DateFactureAcomba_UseDefaultValue = false;
				this.internal_Param_DateFactureAcomba = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateFactureAcomba' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateFactureAcomba_UseDefaultValue() {

			this.internal_Param_DateFactureAcomba_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@DatePaiementAcomba'.
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
		/// the parameter default value, consider calling the Param_DatePaiementAcomba_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DatePaiementAcomba {

			get {

				if (this.internal_Param_DatePaiementAcomba_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DatePaiementAcomba);
			}

			set {

				this.internal_Param_DatePaiementAcomba_UseDefaultValue = false;
				this.internal_Param_DatePaiementAcomba = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DatePaiementAcomba' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DatePaiementAcomba_UseDefaultValue() {

			this.internal_Param_DatePaiementAcomba_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_FactureFournisseur' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:17", SqlObjectDependancyName="spI_FactureFournisseur", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_FactureFournisseur : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_FactureFournisseur class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_FactureFournisseur() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_FactureFournisseur class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_FactureFournisseur(bool throwExceptionOnExecute) {

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
		~spI_FactureFournisseur() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur)");
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
				sqlCommand.CommandText = "spI_FactureFournisseur";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "ID";
				sqlParameter.Direction = System.Data.ParameterDirection.InputOutput;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NoFacture", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "NoFacture";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NoFacture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NoFacture.IsNull) {

					sqlParameter.Value = parameters.Param_NoFacture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateFacture", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DateFacture";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateFacture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateFacture.IsNull) {

					sqlParameter.Value = parameters.Param_DateFacture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Annee", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Annee";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Annee_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Annee.IsNull) {

					sqlParameter.Value = parameters.Param_Annee;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TypeFactureFournisseur", System.Data.SqlDbType.Char, 1);
				sqlParameter.SourceColumn = "TypeFactureFournisseur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TypeFactureFournisseur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TypeFactureFournisseur.IsNull) {

					sqlParameter.Value = parameters.Param_TypeFactureFournisseur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TypeFacture", System.Data.SqlDbType.Char, 1);
				sqlParameter.SourceColumn = "TypeFacture";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TypeFacture_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TypeFacture.IsNull) {

					sqlParameter.Value = parameters.Param_TypeFacture;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@TypeInvoiceAcomba", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "TypeInvoiceAcomba";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_TypeInvoiceAcomba_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_TypeInvoiceAcomba.IsNull) {

					sqlParameter.Value = parameters.Param_TypeInvoiceAcomba;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@FournisseurID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "FournisseurID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_FournisseurID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_FournisseurID.IsNull) {

					sqlParameter.Value = parameters.Param_FournisseurID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PayerAID", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "PayerAID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PayerAID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PayerAID.IsNull) {

					sqlParameter.Value = parameters.Param_PayerAID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Total", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Total";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Total_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Total.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Total;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_TPS", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_TPS";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_TPS_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_TPS.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_TPS;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_TVQ", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_TVQ";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_TVQ_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_TVQ.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_TVQ;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 255);
				sqlParameter.SourceColumn = "Description";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Description_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Description.IsNull) {

					sqlParameter.Value = parameters.Param_Description;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Status", System.Data.SqlDbType.VarChar, 15);
				sqlParameter.SourceColumn = "Status";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Status_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Status.IsNull) {

					sqlParameter.Value = parameters.Param_Status;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@StatusDescription", System.Data.SqlDbType.VarChar, 300);
				sqlParameter.SourceColumn = "StatusDescription";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_StatusDescription_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_StatusDescription.IsNull) {

					sqlParameter.Value = parameters.Param_StatusDescription;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroCheque", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "NumeroCheque";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NumeroCheque_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NumeroCheque.IsNull) {

					sqlParameter.Value = parameters.Param_NumeroCheque;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroPaiement", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "NumeroPaiement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NumeroPaiement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NumeroPaiement.IsNull) {

					sqlParameter.Value = parameters.Param_NumeroPaiement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NumeroPaiementUnique", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "NumeroPaiementUnique";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NumeroPaiementUnique_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NumeroPaiementUnique.IsNull) {

					sqlParameter.Value = parameters.Param_NumeroPaiementUnique;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateFactureAcomba", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DateFactureAcomba";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateFactureAcomba_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateFactureAcomba.IsNull) {

					sqlParameter.Value = parameters.Param_DateFactureAcomba;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DatePaiementAcomba", System.Data.SqlDbType.SmallDateTime, 16);
				sqlParameter.SourceColumn = "DatePaiementAcomba";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DatePaiementAcomba_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DatePaiementAcomba.IsNull) {

					sqlParameter.Value = parameters.Param_DatePaiementAcomba;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				if (sqlCommand.Parameters["@RETURN_VALUE"].Value != System.DBNull.Value) {

					parameters.internal_Set_RETURN_VALUE ((System.Int32)sqlCommand.Parameters["@RETURN_VALUE"].Value);
				}
				else {

					parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
				}

				if (sqlCommand.Parameters["@ID"].Value != System.DBNull.Value) {

						try {

							parameters.Param_ID = (System.Data.SqlTypes.SqlInt32)sqlCommand.Parameters["@ID"].Value;
						}
						catch (System.InvalidCastException) {

							parameters.Param_ID = (System.Int32)sqlCommand.Parameters["@ID"].Value;
						}
				}
				else {

					parameters.Param_ID = System.Data.SqlTypes.SqlInt32.Null;
				}
				parameters.internal_Param_ID_UseDefaultValue = false;

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
		/// This method allows you to execute the [spI_FactureFournisseur] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_FactureFournisseur parameters) {

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

