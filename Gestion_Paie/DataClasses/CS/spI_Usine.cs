/*
	This C# source code was automatically generated using:

		SQL Server Centric .NET Code Generator
			v 1.0.1287.20792

			Generation Date: 13/09/2006 11:57:06 AM
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
	/// stored procedure 'spI_Usine'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:57:06", SqlObjectDependancyName="spI_Usine", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_Usine : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_Usine class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_Usine() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Usine class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_Usine(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Description_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UtilisationID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Paye_producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Paye_transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Specification_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_a_recevoir_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_ajustement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_transporteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_preleve_plan_conjoint_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_preleve_fond_roulement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_preleve_fond_forestier_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_preleve_divers_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_mise_en_commun_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_surcharge_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_indexation_carburant_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NePaiePasTPS_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NePaiePasTVQ_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NoTPS_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_NoTVQ_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Compte_chargeur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UsineGestionVolume_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_AuSoinsDe_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Rue_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Ville_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_PaysID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Code_postal_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telecopieur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone2_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone2_Desc_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone2_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone3_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone3_Desc_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Telephone3_Poste_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Email_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Usine'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Usine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Usine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Usine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Usine'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Usine", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_ID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Description = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UtilisationID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Paye_producteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Paye_transporteur = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Specification = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Compte_a_recevoir = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_ajustement = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_transporteur = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_producteur = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_preleve_plan_conjoint = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_preleve_fond_roulement = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_preleve_fond_forestier = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_preleve_divers = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_mise_en_commun = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_surcharge = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Compte_indexation_carburant = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_NePaiePasTPS = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_NePaiePasTVQ = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_NoTPS = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_NoTVQ = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Compte_chargeur = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_UsineGestionVolume = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Rue = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Ville = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_PaysID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Code_postal = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telecopieur = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone2 = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone3 = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Email = System.Data.SqlTypes.SqlString.Null;

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
		~spI_Usine() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_Usine'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_Usine");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlString internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Description;
		internal bool internal_Param_Description_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_UtilisationID;
		internal bool internal_Param_UtilisationID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Paye_producteur;
		internal bool internal_Param_Paye_producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Paye_transporteur;
		internal bool internal_Param_Paye_transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Specification;
		internal bool internal_Param_Specification_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_a_recevoir;
		internal bool internal_Param_Compte_a_recevoir_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_ajustement;
		internal bool internal_Param_Compte_ajustement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_transporteur;
		internal bool internal_Param_Compte_transporteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_producteur;
		internal bool internal_Param_Compte_producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_preleve_plan_conjoint;
		internal bool internal_Param_Compte_preleve_plan_conjoint_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_preleve_fond_roulement;
		internal bool internal_Param_Compte_preleve_fond_roulement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_preleve_fond_forestier;
		internal bool internal_Param_Compte_preleve_fond_forestier_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_preleve_divers;
		internal bool internal_Param_Compte_preleve_divers_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_mise_en_commun;
		internal bool internal_Param_Compte_mise_en_commun_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_surcharge;
		internal bool internal_Param_Compte_surcharge_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_indexation_carburant;
		internal bool internal_Param_Compte_indexation_carburant_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Actif;
		internal bool internal_Param_Actif_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_NePaiePasTPS;
		internal bool internal_Param_NePaiePasTPS_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_NePaiePasTVQ;
		internal bool internal_Param_NePaiePasTVQ_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NoTPS;
		internal bool internal_Param_NoTPS_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_NoTVQ;
		internal bool internal_Param_NoTVQ_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_Compte_chargeur;
		internal bool internal_Param_Compte_chargeur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_UsineGestionVolume;
		internal bool internal_Param_UsineGestionVolume_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_AuSoinsDe;
		internal bool internal_Param_AuSoinsDe_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Rue;
		internal bool internal_Param_Rue_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Ville;
		internal bool internal_Param_Ville_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_PaysID;
		internal bool internal_Param_PaysID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Code_postal;
		internal bool internal_Param_Code_postal_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone;
		internal bool internal_Param_Telephone_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone_Poste;
		internal bool internal_Param_Telephone_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telecopieur;
		internal bool internal_Param_Telecopieur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone2;
		internal bool internal_Param_Telephone2_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone2_Desc;
		internal bool internal_Param_Telephone2_Desc_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone2_Poste;
		internal bool internal_Param_Telephone2_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone3;
		internal bool internal_Param_Telephone3_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone3_Desc;
		internal bool internal_Param_Telephone3_Desc_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Telephone3_Poste;
		internal bool internal_Param_Telephone3_Poste_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Email;
		internal bool internal_Param_Email_UseDefaultValue = true;


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

			this.internal_Param_ID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Description = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Description_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UtilisationID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_UtilisationID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Paye_producteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Paye_producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Paye_transporteur = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Paye_transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Specification = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Specification_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_a_recevoir = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_a_recevoir_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_ajustement = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_ajustement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_transporteur = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_transporteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_producteur = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_preleve_plan_conjoint = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_preleve_plan_conjoint_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_preleve_fond_roulement = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_preleve_fond_roulement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_preleve_fond_forestier = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_preleve_fond_forestier_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_preleve_divers = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_preleve_divers_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_mise_en_commun = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_mise_en_commun_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_surcharge = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_surcharge_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_indexation_carburant = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_indexation_carburant_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Actif = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Actif_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NePaiePasTPS = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_NePaiePasTPS_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NePaiePasTVQ = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_NePaiePasTVQ_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NoTPS = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NoTPS_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_NoTVQ = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_NoTVQ_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Compte_chargeur = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_Compte_chargeur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UsineGestionVolume = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_UsineGestionVolume_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_AuSoinsDe = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_AuSoinsDe_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Rue = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Rue_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Ville = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Ville_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_PaysID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_PaysID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Code_postal = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Code_postal_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telecopieur = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telecopieur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone2 = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone2_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone2_Desc = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone2_Desc_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone2_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone2_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone3 = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone3_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone3_Desc = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone3_Desc_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Telephone3_Poste = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Telephone3_Poste_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Email = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Email_UseDefaultValue = this.useDefaultValue;

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
		/// In SQL Server, this parameter is of type: [varchar](6)
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
		public System.Data.SqlTypes.SqlString Param_ID {

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
		/// Sets the value of the stored procedure INPUT parameter '@Description'.
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
		/// Sets the value of the stored procedure INPUT parameter '@UtilisationID'.
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
		/// the parameter default value, consider calling the Param_UtilisationID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_UtilisationID {

			get {

				if (this.internal_Param_UtilisationID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UtilisationID);
			}

			set {

				this.internal_Param_UtilisationID_UseDefaultValue = false;
				this.internal_Param_UtilisationID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UtilisationID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UtilisationID_UseDefaultValue() {

			this.internal_Param_UtilisationID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Paye_producteur'.
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
		/// the parameter default value, consider calling the Param_Paye_producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Paye_producteur {

			get {

				if (this.internal_Param_Paye_producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Paye_producteur);
			}

			set {

				this.internal_Param_Paye_producteur_UseDefaultValue = false;
				this.internal_Param_Paye_producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Paye_producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Paye_producteur_UseDefaultValue() {

			this.internal_Param_Paye_producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Paye_transporteur'.
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
		/// the parameter default value, consider calling the Param_Paye_transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Paye_transporteur {

			get {

				if (this.internal_Param_Paye_transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Paye_transporteur);
			}

			set {

				this.internal_Param_Paye_transporteur_UseDefaultValue = false;
				this.internal_Param_Paye_transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Paye_transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Paye_transporteur_UseDefaultValue() {

			this.internal_Param_Paye_transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Specification'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [text]
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Specification_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Specification {

			get {

				if (this.internal_Param_Specification_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Specification);
			}

			set {

				this.internal_Param_Specification_UseDefaultValue = false;
				this.internal_Param_Specification = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Specification' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Specification_UseDefaultValue() {

			this.internal_Param_Specification_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_a_recevoir'.
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
		/// the parameter default value, consider calling the Param_Compte_a_recevoir_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_a_recevoir {

			get {

				if (this.internal_Param_Compte_a_recevoir_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_a_recevoir);
			}

			set {

				this.internal_Param_Compte_a_recevoir_UseDefaultValue = false;
				this.internal_Param_Compte_a_recevoir = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_a_recevoir' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_a_recevoir_UseDefaultValue() {

			this.internal_Param_Compte_a_recevoir_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_ajustement'.
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
		/// the parameter default value, consider calling the Param_Compte_ajustement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_ajustement {

			get {

				if (this.internal_Param_Compte_ajustement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_ajustement);
			}

			set {

				this.internal_Param_Compte_ajustement_UseDefaultValue = false;
				this.internal_Param_Compte_ajustement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_ajustement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_ajustement_UseDefaultValue() {

			this.internal_Param_Compte_ajustement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_transporteur'.
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
		/// the parameter default value, consider calling the Param_Compte_transporteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_transporteur {

			get {

				if (this.internal_Param_Compte_transporteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_transporteur);
			}

			set {

				this.internal_Param_Compte_transporteur_UseDefaultValue = false;
				this.internal_Param_Compte_transporteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_transporteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_transporteur_UseDefaultValue() {

			this.internal_Param_Compte_transporteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_producteur'.
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
		/// the parameter default value, consider calling the Param_Compte_producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_producteur {

			get {

				if (this.internal_Param_Compte_producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_producteur);
			}

			set {

				this.internal_Param_Compte_producteur_UseDefaultValue = false;
				this.internal_Param_Compte_producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_producteur_UseDefaultValue() {

			this.internal_Param_Compte_producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_preleve_plan_conjoint'.
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
		/// the parameter default value, consider calling the Param_Compte_preleve_plan_conjoint_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_preleve_plan_conjoint {

			get {

				if (this.internal_Param_Compte_preleve_plan_conjoint_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_preleve_plan_conjoint);
			}

			set {

				this.internal_Param_Compte_preleve_plan_conjoint_UseDefaultValue = false;
				this.internal_Param_Compte_preleve_plan_conjoint = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_preleve_plan_conjoint' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_preleve_plan_conjoint_UseDefaultValue() {

			this.internal_Param_Compte_preleve_plan_conjoint_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_preleve_fond_roulement'.
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
		/// the parameter default value, consider calling the Param_Compte_preleve_fond_roulement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_preleve_fond_roulement {

			get {

				if (this.internal_Param_Compte_preleve_fond_roulement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_preleve_fond_roulement);
			}

			set {

				this.internal_Param_Compte_preleve_fond_roulement_UseDefaultValue = false;
				this.internal_Param_Compte_preleve_fond_roulement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_preleve_fond_roulement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_preleve_fond_roulement_UseDefaultValue() {

			this.internal_Param_Compte_preleve_fond_roulement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_preleve_fond_forestier'.
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
		/// the parameter default value, consider calling the Param_Compte_preleve_fond_forestier_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_preleve_fond_forestier {

			get {

				if (this.internal_Param_Compte_preleve_fond_forestier_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_preleve_fond_forestier);
			}

			set {

				this.internal_Param_Compte_preleve_fond_forestier_UseDefaultValue = false;
				this.internal_Param_Compte_preleve_fond_forestier = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_preleve_fond_forestier' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_preleve_fond_forestier_UseDefaultValue() {

			this.internal_Param_Compte_preleve_fond_forestier_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_preleve_divers'.
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
		/// the parameter default value, consider calling the Param_Compte_preleve_divers_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_preleve_divers {

			get {

				if (this.internal_Param_Compte_preleve_divers_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_preleve_divers);
			}

			set {

				this.internal_Param_Compte_preleve_divers_UseDefaultValue = false;
				this.internal_Param_Compte_preleve_divers = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_preleve_divers' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_preleve_divers_UseDefaultValue() {

			this.internal_Param_Compte_preleve_divers_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_mise_en_commun'.
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
		/// the parameter default value, consider calling the Param_Compte_mise_en_commun_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_mise_en_commun {

			get {

				if (this.internal_Param_Compte_mise_en_commun_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_mise_en_commun);
			}

			set {

				this.internal_Param_Compte_mise_en_commun_UseDefaultValue = false;
				this.internal_Param_Compte_mise_en_commun = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_mise_en_commun' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_mise_en_commun_UseDefaultValue() {

			this.internal_Param_Compte_mise_en_commun_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_surcharge'.
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
		/// the parameter default value, consider calling the Param_Compte_surcharge_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_surcharge {

			get {

				if (this.internal_Param_Compte_surcharge_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_surcharge);
			}

			set {

				this.internal_Param_Compte_surcharge_UseDefaultValue = false;
				this.internal_Param_Compte_surcharge = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_surcharge' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_surcharge_UseDefaultValue() {

			this.internal_Param_Compte_surcharge_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_indexation_carburant'.
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
		/// the parameter default value, consider calling the Param_Compte_indexation_carburant_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_indexation_carburant {

			get {

				if (this.internal_Param_Compte_indexation_carburant_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_indexation_carburant);
			}

			set {

				this.internal_Param_Compte_indexation_carburant_UseDefaultValue = false;
				this.internal_Param_Compte_indexation_carburant = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_indexation_carburant' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_indexation_carburant_UseDefaultValue() {

			this.internal_Param_Compte_indexation_carburant_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@NePaiePasTPS'.
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
		/// the parameter default value, consider calling the Param_NePaiePasTPS_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_NePaiePasTPS {

			get {

				if (this.internal_Param_NePaiePasTPS_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NePaiePasTPS);
			}

			set {

				this.internal_Param_NePaiePasTPS_UseDefaultValue = false;
				this.internal_Param_NePaiePasTPS = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NePaiePasTPS' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NePaiePasTPS_UseDefaultValue() {

			this.internal_Param_NePaiePasTPS_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NePaiePasTVQ'.
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
		/// the parameter default value, consider calling the Param_NePaiePasTVQ_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_NePaiePasTVQ {

			get {

				if (this.internal_Param_NePaiePasTVQ_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NePaiePasTVQ);
			}

			set {

				this.internal_Param_NePaiePasTVQ_UseDefaultValue = false;
				this.internal_Param_NePaiePasTVQ = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NePaiePasTVQ' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NePaiePasTVQ_UseDefaultValue() {

			this.internal_Param_NePaiePasTVQ_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NoTPS'.
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
		/// the parameter default value, consider calling the Param_NoTPS_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NoTPS {

			get {

				if (this.internal_Param_NoTPS_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NoTPS);
			}

			set {

				this.internal_Param_NoTPS_UseDefaultValue = false;
				this.internal_Param_NoTPS = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NoTPS' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NoTPS_UseDefaultValue() {

			this.internal_Param_NoTPS_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@NoTVQ'.
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
		/// the parameter default value, consider calling the Param_NoTVQ_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_NoTVQ {

			get {

				if (this.internal_Param_NoTVQ_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_NoTVQ);
			}

			set {

				this.internal_Param_NoTVQ_UseDefaultValue = false;
				this.internal_Param_NoTVQ = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@NoTVQ' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_NoTVQ_UseDefaultValue() {

			this.internal_Param_NoTVQ_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Compte_chargeur'.
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
		/// the parameter default value, consider calling the Param_Compte_chargeur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_Compte_chargeur {

			get {

				if (this.internal_Param_Compte_chargeur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Compte_chargeur);
			}

			set {

				this.internal_Param_Compte_chargeur_UseDefaultValue = false;
				this.internal_Param_Compte_chargeur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Compte_chargeur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Compte_chargeur_UseDefaultValue() {

			this.internal_Param_Compte_chargeur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@UsineGestionVolume'.
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
		/// the parameter default value, consider calling the Param_UsineGestionVolume_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_UsineGestionVolume {

			get {

				if (this.internal_Param_UsineGestionVolume_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UsineGestionVolume);
			}

			set {

				this.internal_Param_UsineGestionVolume_UseDefaultValue = false;
				this.internal_Param_UsineGestionVolume = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UsineGestionVolume' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UsineGestionVolume_UseDefaultValue() {

			this.internal_Param_UsineGestionVolume_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@AuSoinsDe'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](30)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_AuSoinsDe_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_AuSoinsDe {

			get {

				if (this.internal_Param_AuSoinsDe_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_AuSoinsDe);
			}

			set {

				this.internal_Param_AuSoinsDe_UseDefaultValue = false;
				this.internal_Param_AuSoinsDe = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@AuSoinsDe' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_AuSoinsDe_UseDefaultValue() {

			this.internal_Param_AuSoinsDe_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Rue'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](30)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Rue_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Rue {

			get {

				if (this.internal_Param_Rue_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Rue);
			}

			set {

				this.internal_Param_Rue_UseDefaultValue = false;
				this.internal_Param_Rue = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Rue' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Rue_UseDefaultValue() {

			this.internal_Param_Rue_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Ville'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](30)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Ville_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Ville {

			get {

				if (this.internal_Param_Ville_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Ville);
			}

			set {

				this.internal_Param_Ville_UseDefaultValue = false;
				this.internal_Param_Ville = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Ville' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Ville_UseDefaultValue() {

			this.internal_Param_Ville_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@PaysID'.
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
		/// the parameter default value, consider calling the Param_PaysID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_PaysID {

			get {

				if (this.internal_Param_PaysID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_PaysID);
			}

			set {

				this.internal_Param_PaysID_UseDefaultValue = false;
				this.internal_Param_PaysID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@PaysID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_PaysID_UseDefaultValue() {

			this.internal_Param_PaysID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Code_postal'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](7)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Code_postal_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Code_postal {

			get {

				if (this.internal_Param_Code_postal_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Code_postal);
			}

			set {

				this.internal_Param_Code_postal_UseDefaultValue = false;
				this.internal_Param_Code_postal = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Code_postal' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Code_postal_UseDefaultValue() {

			this.internal_Param_Code_postal_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone'.
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
		/// the parameter default value, consider calling the Param_Telephone_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone {

			get {

				if (this.internal_Param_Telephone_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone);
			}

			set {

				this.internal_Param_Telephone_UseDefaultValue = false;
				this.internal_Param_Telephone = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone_UseDefaultValue() {

			this.internal_Param_Telephone_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone_Poste {

			get {

				if (this.internal_Param_Telephone_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone_Poste);
			}

			set {

				this.internal_Param_Telephone_Poste_UseDefaultValue = false;
				this.internal_Param_Telephone_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone_Poste_UseDefaultValue() {

			this.internal_Param_Telephone_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telecopieur'.
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
		/// the parameter default value, consider calling the Param_Telecopieur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telecopieur {

			get {

				if (this.internal_Param_Telecopieur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telecopieur);
			}

			set {

				this.internal_Param_Telecopieur_UseDefaultValue = false;
				this.internal_Param_Telecopieur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telecopieur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telecopieur_UseDefaultValue() {

			this.internal_Param_Telecopieur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone2'.
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
		/// the parameter default value, consider calling the Param_Telephone2_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone2 {

			get {

				if (this.internal_Param_Telephone2_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone2);
			}

			set {

				this.internal_Param_Telephone2_UseDefaultValue = false;
				this.internal_Param_Telephone2 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone2' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone2_UseDefaultValue() {

			this.internal_Param_Telephone2_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone2_Desc'.
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
		/// the parameter default value, consider calling the Param_Telephone2_Desc_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone2_Desc {

			get {

				if (this.internal_Param_Telephone2_Desc_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone2_Desc);
			}

			set {

				this.internal_Param_Telephone2_Desc_UseDefaultValue = false;
				this.internal_Param_Telephone2_Desc = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone2_Desc' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone2_Desc_UseDefaultValue() {

			this.internal_Param_Telephone2_Desc_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone2_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone2_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone2_Poste {

			get {

				if (this.internal_Param_Telephone2_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone2_Poste);
			}

			set {

				this.internal_Param_Telephone2_Poste_UseDefaultValue = false;
				this.internal_Param_Telephone2_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone2_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone2_Poste_UseDefaultValue() {

			this.internal_Param_Telephone2_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone3'.
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
		/// the parameter default value, consider calling the Param_Telephone3_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone3 {

			get {

				if (this.internal_Param_Telephone3_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone3);
			}

			set {

				this.internal_Param_Telephone3_UseDefaultValue = false;
				this.internal_Param_Telephone3 = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone3' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone3_UseDefaultValue() {

			this.internal_Param_Telephone3_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone3_Desc'.
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
		/// the parameter default value, consider calling the Param_Telephone3_Desc_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone3_Desc {

			get {

				if (this.internal_Param_Telephone3_Desc_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone3_Desc);
			}

			set {

				this.internal_Param_Telephone3_Desc_UseDefaultValue = false;
				this.internal_Param_Telephone3_Desc = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone3_Desc' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone3_Desc_UseDefaultValue() {

			this.internal_Param_Telephone3_Desc_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Telephone3_Poste'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Telephone3_Poste_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Telephone3_Poste {

			get {

				if (this.internal_Param_Telephone3_Poste_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Telephone3_Poste);
			}

			set {

				this.internal_Param_Telephone3_Poste_UseDefaultValue = false;
				this.internal_Param_Telephone3_Poste = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Telephone3_Poste' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Telephone3_Poste_UseDefaultValue() {

			this.internal_Param_Telephone3_Poste_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Email'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [varchar](80)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Email_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Email {

			get {

				if (this.internal_Param_Email_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Email);
			}

			set {

				this.internal_Param_Email_UseDefaultValue = false;
				this.internal_Param_Email = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Email' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Email_UseDefaultValue() {

			this.internal_Param_Email_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_Usine' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2006/09/13 15:57:06", SqlObjectDependancyName="spI_Usine", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_Usine : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_Usine class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_Usine() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Usine class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_Usine(bool throwExceptionOnExecute) {

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
		~spI_Usine() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_Usine parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_Usine parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Usine object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Usine object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Usine object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_Usine)");
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
				sqlCommand.CommandText = "spI_Usine";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Usine parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

			try {

				System.Data.SqlClient.SqlParameter sqlParameter;

				sqlParameter = new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4);
				sqlParameter.Direction = System.Data.ParameterDirection.ReturnValue;
				sqlParameter.IsNullable = true;
				sqlParameter.Value = System.DBNull.Value;
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.VarChar, 6);
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 50);
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UtilisationID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "UtilisationID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UtilisationID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UtilisationID.IsNull) {

					sqlParameter.Value = parameters.Param_UtilisationID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Paye_producteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Paye_producteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Paye_producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Paye_producteur.IsNull) {

					sqlParameter.Value = parameters.Param_Paye_producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Paye_transporteur", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Paye_transporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Paye_transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Paye_transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Paye_transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Specification", System.Data.SqlDbType.Text, 2147483647);
				sqlParameter.SourceColumn = "Specification";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Specification_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Specification.IsNull) {

					sqlParameter.Value = parameters.Param_Specification;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_a_recevoir", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_a_recevoir";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_a_recevoir_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_a_recevoir.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_a_recevoir;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_ajustement", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_ajustement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_ajustement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_ajustement.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_ajustement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_transporteur", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_transporteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_transporteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_transporteur.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_transporteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_producteur", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_producteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_producteur.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_plan_conjoint", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_preleve_plan_conjoint";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_preleve_plan_conjoint_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_preleve_plan_conjoint.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_preleve_plan_conjoint;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_roulement", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_preleve_fond_roulement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_preleve_fond_roulement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_preleve_fond_roulement.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_preleve_fond_roulement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_fond_forestier", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_preleve_fond_forestier";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_preleve_fond_forestier_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_preleve_fond_forestier.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_preleve_fond_forestier;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_preleve_divers", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_preleve_divers";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_preleve_divers_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_preleve_divers.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_preleve_divers;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_mise_en_commun", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_mise_en_commun";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_mise_en_commun_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_mise_en_commun.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_mise_en_commun;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_surcharge", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_surcharge";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_surcharge_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_surcharge.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_surcharge;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_indexation_carburant", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_indexation_carburant";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_indexation_carburant_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_indexation_carburant.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_indexation_carburant;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Actif", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Actif";
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NePaiePasTPS", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "NePaiePasTPS";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NePaiePasTPS_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NePaiePasTPS.IsNull) {

					sqlParameter.Value = parameters.Param_NePaiePasTPS;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NePaiePasTVQ", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "NePaiePasTVQ";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NePaiePasTVQ_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NePaiePasTVQ.IsNull) {

					sqlParameter.Value = parameters.Param_NePaiePasTVQ;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NoTPS", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "NoTPS";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NoTPS_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NoTPS.IsNull) {

					sqlParameter.Value = parameters.Param_NoTPS;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@NoTVQ", System.Data.SqlDbType.VarChar, 25);
				sqlParameter.SourceColumn = "NoTVQ";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_NoTVQ_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_NoTVQ.IsNull) {

					sqlParameter.Value = parameters.Param_NoTVQ;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Compte_chargeur", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "Compte_chargeur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Compte_chargeur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Compte_chargeur.IsNull) {

					sqlParameter.Value = parameters.Param_Compte_chargeur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UsineGestionVolume", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "UsineGestionVolume";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UsineGestionVolume_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UsineGestionVolume.IsNull) {

					sqlParameter.Value = parameters.Param_UsineGestionVolume;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@AuSoinsDe", System.Data.SqlDbType.VarChar, 30);
				sqlParameter.SourceColumn = "AuSoinsDe";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_AuSoinsDe_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_AuSoinsDe.IsNull) {

					sqlParameter.Value = parameters.Param_AuSoinsDe;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Rue", System.Data.SqlDbType.VarChar, 30);
				sqlParameter.SourceColumn = "Rue";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Rue_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Rue.IsNull) {

					sqlParameter.Value = parameters.Param_Rue;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Ville", System.Data.SqlDbType.VarChar, 30);
				sqlParameter.SourceColumn = "Ville";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Ville_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Ville.IsNull) {

					sqlParameter.Value = parameters.Param_Ville;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@PaysID", System.Data.SqlDbType.VarChar, 2);
				sqlParameter.SourceColumn = "PaysID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_PaysID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_PaysID.IsNull) {

					sqlParameter.Value = parameters.Param_PaysID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Code_postal", System.Data.SqlDbType.VarChar, 7);
				sqlParameter.SourceColumn = "Code_postal";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Code_postal_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Code_postal.IsNull) {

					sqlParameter.Value = parameters.Param_Code_postal;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telephone";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Telephone_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telecopieur", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telecopieur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telecopieur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telecopieur.IsNull) {

					sqlParameter.Value = parameters.Param_Telecopieur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telephone2";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone2_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone2.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone2;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Desc", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "Telephone2_Desc";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone2_Desc_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone2_Desc.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone2_Desc;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone2_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Telephone2_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone2_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone2_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone2_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3", System.Data.SqlDbType.VarChar, 12);
				sqlParameter.SourceColumn = "Telephone3";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone3_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone3.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone3;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Desc", System.Data.SqlDbType.VarChar, 20);
				sqlParameter.SourceColumn = "Telephone3_Desc";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone3_Desc_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone3_Desc.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone3_Desc;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Telephone3_Poste", System.Data.SqlDbType.VarChar, 4);
				sqlParameter.SourceColumn = "Telephone3_Poste";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Telephone3_Poste_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Telephone3_Poste.IsNull) {

					sqlParameter.Value = parameters.Param_Telephone3_Poste;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.VarChar, 80);
				sqlParameter.SourceColumn = "Email";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Email_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Email.IsNull) {

					sqlParameter.Value = parameters.Param_Email;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Usine parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spI_Usine] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_Usine parameters) {

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

