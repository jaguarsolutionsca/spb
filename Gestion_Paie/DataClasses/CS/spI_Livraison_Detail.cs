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
	/// stored procedure 'spI_Livraison_Detail'. It allows also to specify specific connection
	/// information such as the ConnectionString to be use, the command time-out and so forth.
	/// </summary>
	[Serializable()]
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:17", SqlObjectDependancyName="spI_Livraison_Detail", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_Livraison_Detail : MarshalByRefObject, IDisposable, IParameter {

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
		/// Initializes a new instance of the spI_Livraison_Detail class. If you use this constructor version,
		/// not assigning parameter values implies using the parameter default values.
		/// </summary>
		public spI_Livraison_Detail() : this(true) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Livraison_Detail class.
		/// </summary>
		/// <param name="useDefaultValue">If True, this parameter indicates that "not assigning parameter values" implies "using the parameter default values". If False, this parameter indicates that "not assigning parameter values" implies "using the SQL Server Null value".</param>
		public spI_Livraison_Detail(bool useDefaultValue) {

			this.useDefaultValue = useDefaultValue;

			this.internal_Param_ID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_LivraisonID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Droit_Coupe_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeBrut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeReduction_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeNet_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_VolumeContingente_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_ContingentementID_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_DateCalcul_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Usine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Usine_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Producteur_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_ProducteurBrut_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_TransporteurMoyen_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_TransporteurMoyen_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_TransporteurMoyen_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Preleve_Divers_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Montant_ProducteurNet_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Producteur_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Taux_Usine_Override_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;
			this.internal_Param_UsePreleveMontant_UseDefaultValue = this.useDefaultValue;
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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Livraison_Detail'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Livraison_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Livraison_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Livraison_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'spI_Livraison_Detail'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "spI_Livraison_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
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
				this.internal_Param_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_Droit_Coupe = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_VolumeContingente = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
				this.internal_Param_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
				this.internal_Param_Taux_Usine = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_Producteur = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_ProducteurBrut = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_TransporteurMoyen_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Montant_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Montant_ProducteurNet = System.Data.SqlTypes.SqlDouble.Null;
				this.internal_Param_Taux_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;
				this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
				this.internal_Param_UsePreleveMontant = System.Data.SqlTypes.SqlBoolean.Null;

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
		~spI_Livraison_Detail() {

			Dispose(false);
		}

		/// <summary>
		/// Returns the stored procedure name for which this class was built, i.e. 'spI_Livraison_Detail'.
		/// </summary>
		public string StoredProcedureName {

			get {

				return("spI_Livraison_Detail");
			}
		}

		private System.Data.SqlTypes.SqlInt32 internal_Param_RETURN_VALUE;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ID;
		internal bool internal_Param_ID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_LivraisonID;
		internal bool internal_Param_LivraisonID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ContratID;
		internal bool internal_Param_ContratID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_EssenceID;
		internal bool internal_Param_EssenceID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_UniteMesureID;
		internal bool internal_Param_UniteMesureID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_ProducteurID;
		internal bool internal_Param_ProducteurID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Droit_Coupe;
		internal bool internal_Param_Droit_Coupe_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeBrut;
		internal bool internal_Param_VolumeBrut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeReduction;
		internal bool internal_Param_VolumeReduction_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeNet;
		internal bool internal_Param_VolumeNet_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_VolumeContingente;
		internal bool internal_Param_VolumeContingente_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlInt32 internal_Param_ContingentementID;
		internal bool internal_Param_ContingentementID_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDateTime internal_Param_DateCalcul;
		internal bool internal_Param_DateCalcul_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_Usine;
		internal bool internal_Param_Taux_Usine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Usine;
		internal bool internal_Param_Montant_Usine_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_Producteur;
		internal bool internal_Param_Taux_Producteur_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_ProducteurBrut;
		internal bool internal_Param_Montant_ProducteurBrut_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_TransporteurMoyen;
		internal bool internal_Param_Taux_TransporteurMoyen_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Taux_TransporteurMoyen_Override;
		internal bool internal_Param_Taux_TransporteurMoyen_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_TransporteurMoyen;
		internal bool internal_Param_Montant_TransporteurMoyen_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_Preleve_Plan_Conjoint;
		internal bool internal_Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Plan_Conjoint;
		internal bool internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_Preleve_Fond_Roulement;
		internal bool internal_Param_Taux_Preleve_Fond_Roulement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Fond_Roulement;
		internal bool internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_Preleve_Fond_Forestier;
		internal bool internal_Param_Taux_Preleve_Fond_Forestier_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Fond_Forestier;
		internal bool internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Taux_Preleve_Divers;
		internal bool internal_Param_Taux_Preleve_Divers_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_Preleve_Divers;
		internal bool internal_Param_Montant_Preleve_Divers_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlDouble internal_Param_Montant_ProducteurNet;
		internal bool internal_Param_Montant_ProducteurNet_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Taux_Producteur_Override;
		internal bool internal_Param_Taux_Producteur_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_Taux_Usine_Override;
		internal bool internal_Param_Taux_Usine_Override_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlString internal_Param_Code;
		internal bool internal_Param_Code_UseDefaultValue = true;

		private System.Data.SqlTypes.SqlBoolean internal_Param_UsePreleveMontant;
		internal bool internal_Param_UsePreleveMontant_UseDefaultValue = true;


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

			this.internal_Param_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_LivraisonID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ContratID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_EssenceID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_UniteMesureID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_ProducteurID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Droit_Coupe = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Droit_Coupe_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeBrut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeReduction_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeNet_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_VolumeContingente = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_VolumeContingente_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.internal_Param_ContingentementID_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
			this.internal_Param_DateCalcul_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Usine = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_Usine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Usine_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Producteur = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_Producteur_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_ProducteurBrut = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_ProducteurBrut_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_TransporteurMoyen_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_TransporteurMoyen_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Taux_TransporteurMoyen_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_TransporteurMoyen_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Taux_Preleve_Divers_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Montant_ProducteurNet = System.Data.SqlTypes.SqlDouble.Null;
			this.internal_Param_Montant_ProducteurNet_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Taux_Producteur_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_Taux_Usine_Override_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_Code = System.Data.SqlTypes.SqlString.Null;
			this.internal_Param_Code_UseDefaultValue = this.useDefaultValue;

			this.internal_Param_UsePreleveMontant = System.Data.SqlTypes.SqlBoolean.Null;
			this.internal_Param_UsePreleveMontant_UseDefaultValue = this.useDefaultValue;

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
		/// Sets the value of the stored procedure INPUT parameter '@LivraisonID'.
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
		/// the parameter default value, consider calling the Param_LivraisonID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlInt32 Param_LivraisonID {

			get {

				if (this.internal_Param_LivraisonID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_LivraisonID);
			}

			set {

				this.internal_Param_LivraisonID_UseDefaultValue = false;
				this.internal_Param_LivraisonID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@LivraisonID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_LivraisonID_UseDefaultValue() {

			this.internal_Param_LivraisonID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@EssenceID'.
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
		/// the parameter default value, consider calling the Param_EssenceID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_EssenceID {

			get {

				if (this.internal_Param_EssenceID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_EssenceID);
			}

			set {

				this.internal_Param_EssenceID_UseDefaultValue = false;
				this.internal_Param_EssenceID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@EssenceID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_EssenceID_UseDefaultValue() {

			this.internal_Param_EssenceID_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@UniteMesureID'.
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
		/// the parameter default value, consider calling the Param_UniteMesureID_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_UniteMesureID {

			get {

				if (this.internal_Param_UniteMesureID_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UniteMesureID);
			}

			set {

				this.internal_Param_UniteMesureID_UseDefaultValue = false;
				this.internal_Param_UniteMesureID = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UniteMesureID' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UniteMesureID_UseDefaultValue() {

			this.internal_Param_UniteMesureID_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@Droit_Coupe'.
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
		/// the parameter default value, consider calling the Param_Droit_Coupe_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Droit_Coupe {

			get {

				if (this.internal_Param_Droit_Coupe_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Droit_Coupe);
			}

			set {

				this.internal_Param_Droit_Coupe_UseDefaultValue = false;
				this.internal_Param_Droit_Coupe = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Droit_Coupe' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Droit_Coupe_UseDefaultValue() {

			this.internal_Param_Droit_Coupe_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeBrut'.
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
		/// the parameter default value, consider calling the Param_VolumeBrut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeBrut {

			get {

				if (this.internal_Param_VolumeBrut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeBrut);
			}

			set {

				this.internal_Param_VolumeBrut_UseDefaultValue = false;
				this.internal_Param_VolumeBrut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeBrut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeBrut_UseDefaultValue() {

			this.internal_Param_VolumeBrut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeReduction'.
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
		/// the parameter default value, consider calling the Param_VolumeReduction_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeReduction {

			get {

				if (this.internal_Param_VolumeReduction_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeReduction);
			}

			set {

				this.internal_Param_VolumeReduction_UseDefaultValue = false;
				this.internal_Param_VolumeReduction = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeReduction' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeReduction_UseDefaultValue() {

			this.internal_Param_VolumeReduction_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeNet'.
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
		/// the parameter default value, consider calling the Param_VolumeNet_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeNet {

			get {

				if (this.internal_Param_VolumeNet_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeNet);
			}

			set {

				this.internal_Param_VolumeNet_UseDefaultValue = false;
				this.internal_Param_VolumeNet = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeNet' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeNet_UseDefaultValue() {

			this.internal_Param_VolumeNet_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@VolumeContingente'.
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
		/// the parameter default value, consider calling the Param_VolumeContingente_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_VolumeContingente {

			get {

				if (this.internal_Param_VolumeContingente_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_VolumeContingente);
			}

			set {

				this.internal_Param_VolumeContingente_UseDefaultValue = false;
				this.internal_Param_VolumeContingente = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@VolumeContingente' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_VolumeContingente_UseDefaultValue() {

			this.internal_Param_VolumeContingente_UseDefaultValue = true;
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
		/// Sets the value of the stored procedure INPUT parameter '@DateCalcul'.
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
		/// the parameter default value, consider calling the Param_DateCalcul_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDateTime Param_DateCalcul {

			get {

				if (this.internal_Param_DateCalcul_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_DateCalcul);
			}

			set {

				this.internal_Param_DateCalcul_UseDefaultValue = false;
				this.internal_Param_DateCalcul = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@DateCalcul' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_DateCalcul_UseDefaultValue() {

			this.internal_Param_DateCalcul_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Usine'.
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
		/// the parameter default value, consider calling the Param_Taux_Usine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_Usine {

			get {

				if (this.internal_Param_Taux_Usine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Usine);
			}

			set {

				this.internal_Param_Taux_Usine_UseDefaultValue = false;
				this.internal_Param_Taux_Usine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Usine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Usine_UseDefaultValue() {

			this.internal_Param_Taux_Usine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Usine'.
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
		/// the parameter default value, consider calling the Param_Montant_Usine_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Usine {

			get {

				if (this.internal_Param_Montant_Usine_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Usine);
			}

			set {

				this.internal_Param_Montant_Usine_UseDefaultValue = false;
				this.internal_Param_Montant_Usine = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Usine' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Usine_UseDefaultValue() {

			this.internal_Param_Montant_Usine_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Producteur'.
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
		/// the parameter default value, consider calling the Param_Taux_Producteur_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_Producteur {

			get {

				if (this.internal_Param_Taux_Producteur_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Producteur);
			}

			set {

				this.internal_Param_Taux_Producteur_UseDefaultValue = false;
				this.internal_Param_Taux_Producteur = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Producteur' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Producteur_UseDefaultValue() {

			this.internal_Param_Taux_Producteur_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_ProducteurBrut'.
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
		/// the parameter default value, consider calling the Param_Montant_ProducteurBrut_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_ProducteurBrut {

			get {

				if (this.internal_Param_Montant_ProducteurBrut_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_ProducteurBrut);
			}

			set {

				this.internal_Param_Montant_ProducteurBrut_UseDefaultValue = false;
				this.internal_Param_Montant_ProducteurBrut = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_ProducteurBrut' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_ProducteurBrut_UseDefaultValue() {

			this.internal_Param_Montant_ProducteurBrut_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_TransporteurMoyen'.
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
		/// the parameter default value, consider calling the Param_Taux_TransporteurMoyen_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_TransporteurMoyen {

			get {

				if (this.internal_Param_Taux_TransporteurMoyen_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_TransporteurMoyen);
			}

			set {

				this.internal_Param_Taux_TransporteurMoyen_UseDefaultValue = false;
				this.internal_Param_Taux_TransporteurMoyen = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_TransporteurMoyen' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_TransporteurMoyen_UseDefaultValue() {

			this.internal_Param_Taux_TransporteurMoyen_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_TransporteurMoyen_Override'.
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
		/// the parameter default value, consider calling the Param_Taux_TransporteurMoyen_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Taux_TransporteurMoyen_Override {

			get {

				if (this.internal_Param_Taux_TransporteurMoyen_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_TransporteurMoyen_Override);
			}

			set {

				this.internal_Param_Taux_TransporteurMoyen_Override_UseDefaultValue = false;
				this.internal_Param_Taux_TransporteurMoyen_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_TransporteurMoyen_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_TransporteurMoyen_Override_UseDefaultValue() {

			this.internal_Param_Taux_TransporteurMoyen_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_TransporteurMoyen'.
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
		/// the parameter default value, consider calling the Param_Montant_TransporteurMoyen_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_TransporteurMoyen {

			get {

				if (this.internal_Param_Montant_TransporteurMoyen_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_TransporteurMoyen);
			}

			set {

				this.internal_Param_Montant_TransporteurMoyen_UseDefaultValue = false;
				this.internal_Param_Montant_TransporteurMoyen = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_TransporteurMoyen' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_TransporteurMoyen_UseDefaultValue() {

			this.internal_Param_Montant_TransporteurMoyen_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Preleve_Plan_Conjoint'.
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
		/// the parameter default value, consider calling the Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_Preleve_Plan_Conjoint {

			get {

				if (this.internal_Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Preleve_Plan_Conjoint);
			}

			set {

				this.internal_Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue = false;
				this.internal_Param_Taux_Preleve_Plan_Conjoint = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Preleve_Plan_Conjoint' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue() {

			this.internal_Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Plan_Conjoint'.
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
		/// the parameter default value, consider calling the Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Plan_Conjoint {

			get {

				if (this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Plan_Conjoint);
			}

			set {

				this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Plan_Conjoint = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Plan_Conjoint' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Preleve_Fond_Roulement'.
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
		/// the parameter default value, consider calling the Param_Taux_Preleve_Fond_Roulement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_Preleve_Fond_Roulement {

			get {

				if (this.internal_Param_Taux_Preleve_Fond_Roulement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Preleve_Fond_Roulement);
			}

			set {

				this.internal_Param_Taux_Preleve_Fond_Roulement_UseDefaultValue = false;
				this.internal_Param_Taux_Preleve_Fond_Roulement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Preleve_Fond_Roulement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Preleve_Fond_Roulement_UseDefaultValue() {

			this.internal_Param_Taux_Preleve_Fond_Roulement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Fond_Roulement'.
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
		/// the parameter default value, consider calling the Param_Montant_Preleve_Fond_Roulement_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Fond_Roulement {

			get {

				if (this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Fond_Roulement);
			}

			set {

				this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Fond_Roulement = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Fond_Roulement' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Fond_Roulement_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Preleve_Fond_Forestier'.
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
		/// the parameter default value, consider calling the Param_Taux_Preleve_Fond_Forestier_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_Preleve_Fond_Forestier {

			get {

				if (this.internal_Param_Taux_Preleve_Fond_Forestier_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Preleve_Fond_Forestier);
			}

			set {

				this.internal_Param_Taux_Preleve_Fond_Forestier_UseDefaultValue = false;
				this.internal_Param_Taux_Preleve_Fond_Forestier = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Preleve_Fond_Forestier' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Preleve_Fond_Forestier_UseDefaultValue() {

			this.internal_Param_Taux_Preleve_Fond_Forestier_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Fond_Forestier'.
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
		/// the parameter default value, consider calling the Param_Montant_Preleve_Fond_Forestier_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Fond_Forestier {

			get {

				if (this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Fond_Forestier);
			}

			set {

				this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Fond_Forestier = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Fond_Forestier' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Fond_Forestier_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Preleve_Divers'.
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
		/// the parameter default value, consider calling the Param_Taux_Preleve_Divers_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Taux_Preleve_Divers {

			get {

				if (this.internal_Param_Taux_Preleve_Divers_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Preleve_Divers);
			}

			set {

				this.internal_Param_Taux_Preleve_Divers_UseDefaultValue = false;
				this.internal_Param_Taux_Preleve_Divers = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Preleve_Divers' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Preleve_Divers_UseDefaultValue() {

			this.internal_Param_Taux_Preleve_Divers_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_Preleve_Divers'.
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
		/// the parameter default value, consider calling the Param_Montant_Preleve_Divers_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_Preleve_Divers {

			get {

				if (this.internal_Param_Montant_Preleve_Divers_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_Preleve_Divers);
			}

			set {

				this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = false;
				this.internal_Param_Montant_Preleve_Divers = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_Preleve_Divers' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_Preleve_Divers_UseDefaultValue() {

			this.internal_Param_Montant_Preleve_Divers_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Montant_ProducteurNet'.
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
		/// the parameter default value, consider calling the Param_Montant_ProducteurNet_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlDouble Param_Montant_ProducteurNet {

			get {

				if (this.internal_Param_Montant_ProducteurNet_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Montant_ProducteurNet);
			}

			set {

				this.internal_Param_Montant_ProducteurNet_UseDefaultValue = false;
				this.internal_Param_Montant_ProducteurNet = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Montant_ProducteurNet' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Montant_ProducteurNet_UseDefaultValue() {

			this.internal_Param_Montant_ProducteurNet_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Producteur_Override'.
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
		/// the parameter default value, consider calling the Param_Taux_Producteur_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Taux_Producteur_Override {

			get {

				if (this.internal_Param_Taux_Producteur_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Producteur_Override);
			}

			set {

				this.internal_Param_Taux_Producteur_Override_UseDefaultValue = false;
				this.internal_Param_Taux_Producteur_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Producteur_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Producteur_Override_UseDefaultValue() {

			this.internal_Param_Taux_Producteur_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Taux_Usine_Override'.
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
		/// the parameter default value, consider calling the Param_Taux_Usine_Override_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_Taux_Usine_Override {

			get {

				if (this.internal_Param_Taux_Usine_Override_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Taux_Usine_Override);
			}

			set {

				this.internal_Param_Taux_Usine_Override_UseDefaultValue = false;
				this.internal_Param_Taux_Usine_Override = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Taux_Usine_Override' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Taux_Usine_Override_UseDefaultValue() {

			this.internal_Param_Taux_Usine_Override_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@Code'.
		/// </summary>
		/// <remarks>
		/// <list type="number">
		/// <item>
		/// <description>
		/// In SQL Server, this parameter is of type: [char](4)
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// If this parameter is not set before the stored procedure call occurs, a Null (SQL Server meaning) value
		/// will be supplied to the corresponding parameter when the call is made. If you wish to use
		/// the parameter default value, consider calling the Param_Code_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlString Param_Code {

			get {

				if (this.internal_Param_Code_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_Code);
			}

			set {

				this.internal_Param_Code_UseDefaultValue = false;
				this.internal_Param_Code = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@Code' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_Code_UseDefaultValue() {

			this.internal_Param_Code_UseDefaultValue = true;
		}

		/// <summary>
		/// Sets the value of the stored procedure INPUT parameter '@UsePreleveMontant'.
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
		/// the parameter default value, consider calling the Param_UsePreleveMontant_UseDefaultValue() method.
		/// </description>
		/// </item>
		/// </list>
		/// </remarks>
		public System.Data.SqlTypes.SqlBoolean Param_UsePreleveMontant {

			get {

				if (this.internal_Param_UsePreleveMontant_UseDefaultValue) {
				
					throw new InvalidOperationException("This parameter is not assigned and maps to the stored procedure parameter default value.");
				}
				return(this.internal_Param_UsePreleveMontant);
			}

			set {

				this.internal_Param_UsePreleveMontant_UseDefaultValue = false;
				this.internal_Param_UsePreleveMontant = value;
			}
		}            

		/// <summary>
		/// Indicates that the '@UsePreleveMontant' parameter value is not supplied and that the default value should be used.
		/// </summary>
		public void Param_UsePreleveMontant_UseDefaultValue() {

			this.internal_Param_UsePreleveMontant_UseDefaultValue = true;
		}

  	}
}

namespace Gestion_Paie.DataClasses.StoredProcedures {

	/// <summary>
	/// This class allows you to execute the 'spI_Livraison_Detail' stored procedure;
	/// it gives you the ability to:
	/// <list type="bullet">
	/// <item><description>Set all the necessary parameters to execute the stored procedure</description></item>
	/// <item><description>To execute the stored procedure</description></item>
	/// <item><description>To get back after the execution the return value and all the output parameters value</description></item>
	/// </list>
	/// </summary>
#if OLYMARS_ATTRIBUTE || OLYMARS_DEBUG
	[OlymarsInformation(DeveloperName="<Developer Name Here>", GeneratedOn="2007/03/30 13:55:17", SqlObjectDependancyName="spI_Livraison_Detail", SqlObjectDependancyRevision=0)]
#endif
	public sealed class spI_Livraison_Detail : MarshalByRefObject, IDisposable {


		private bool throwExceptionOnExecute = false;

		/// <summary>
		/// Initializes a new instance of the spI_Livraison_Detail class.
		/// By default, no exception will be thrown when you call the Execute method. Instead, a Boolean return status will be returned.
		/// </summary>
		public spI_Livraison_Detail() : this(false) {

		}

		/// <summary>
		/// Initializes a new instance of the spI_Livraison_Detail class.
		/// </summary>
		/// <param name="throwExceptionOnExecute">True if an exception has to be thrown if the Execute call fails.</param>
		public spI_Livraison_Detail(bool throwExceptionOnExecute) {

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
		~spI_Livraison_Detail() {

			Dispose(false);
		}

		private void ResetParameter(ref Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail parameters) {

			parameters.internal_Set_RETURN_VALUE (System.Data.SqlTypes.SqlInt32.Null);
		}

		private bool InitializeConnection(ref Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail parameters, out System.Data.SqlClient.SqlCommand sqlCommand, ref bool connectionMustBeClosed) {

			try {

				this.sqlConnection = null;
				sqlCommand = null;
				connectionMustBeClosed = true;

				if (parameters.ConnectionType == ConnectionType.None) {

					throw new InvalidOperationException("No connection information was supplied. Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlConnection && parameters.SqlConnection == null) {

					throw new InvalidOperationException("No connection information was supplied (SqlConnection == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail object before doing this call.");
				}

				if (parameters.ConnectionType == ConnectionType.SqlTransaction && parameters.SqlTransaction== null) {

					throw new InvalidOperationException("No connection information was supplied (SqlTransaction == null). Consider calling the 'SetUpConnection' method of the Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail object before doing this call.");
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

							throw new System.InvalidOperationException("No connection information was supplied (ConnectionString == \"\")! (Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail)");
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
				sqlCommand.CommandText = "spI_Livraison_Detail";

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

		private bool DeclareParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@LivraisonID", System.Data.SqlDbType.Int, 4);
				sqlParameter.SourceColumn = "LivraisonID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_LivraisonID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_LivraisonID.IsNull) {

					sqlParameter.Value = parameters.Param_LivraisonID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@EssenceID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "EssenceID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_EssenceID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_EssenceID.IsNull) {

					sqlParameter.Value = parameters.Param_EssenceID;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UniteMesureID", System.Data.SqlDbType.VarChar, 6);
				sqlParameter.SourceColumn = "UniteMesureID";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UniteMesureID_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UniteMesureID.IsNull) {

					sqlParameter.Value = parameters.Param_UniteMesureID;
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Droit_Coupe", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Droit_Coupe";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Droit_Coupe_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Droit_Coupe.IsNull) {

					sqlParameter.Value = parameters.Param_Droit_Coupe;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeBrut", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeBrut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeBrut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeBrut.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeBrut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeReduction", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeReduction";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeReduction_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeReduction.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeReduction;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeNet", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeNet";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeNet_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeNet.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeNet;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@VolumeContingente", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "VolumeContingente";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_VolumeContingente_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_VolumeContingente.IsNull) {

					sqlParameter.Value = parameters.Param_VolumeContingente;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
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

				sqlParameter = new System.Data.SqlClient.SqlParameter("@DateCalcul", System.Data.SqlDbType.DateTime, 16);
				sqlParameter.SourceColumn = "DateCalcul";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_DateCalcul_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_DateCalcul.IsNull) {

					sqlParameter.Value = parameters.Param_DateCalcul;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Usine", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_Usine";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Usine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Usine.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Usine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Usine", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Usine";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Usine_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Usine.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Usine;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Producteur", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_Producteur";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Producteur_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Producteur.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Producteur;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_ProducteurBrut", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_ProducteurBrut";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_ProducteurBrut_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_ProducteurBrut.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_ProducteurBrut;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_TransporteurMoyen", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_TransporteurMoyen";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_TransporteurMoyen_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_TransporteurMoyen.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_TransporteurMoyen;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_TransporteurMoyen_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Taux_TransporteurMoyen_Override";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_TransporteurMoyen_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_TransporteurMoyen_Override.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_TransporteurMoyen_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_TransporteurMoyen", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_TransporteurMoyen";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_TransporteurMoyen_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_TransporteurMoyen.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_TransporteurMoyen;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Preleve_Plan_Conjoint", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_Preleve_Plan_Conjoint";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Preleve_Plan_Conjoint_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Preleve_Plan_Conjoint.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Preleve_Plan_Conjoint;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Plan_Conjoint", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Plan_Conjoint";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Plan_Conjoint_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Plan_Conjoint.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Plan_Conjoint;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Preleve_Fond_Roulement", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_Preleve_Fond_Roulement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Preleve_Fond_Roulement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Preleve_Fond_Roulement.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Preleve_Fond_Roulement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Roulement", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Fond_Roulement";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Fond_Roulement_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Fond_Roulement.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Fond_Roulement;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Preleve_Fond_Forestier", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_Preleve_Fond_Forestier";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Preleve_Fond_Forestier_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Preleve_Fond_Forestier.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Preleve_Fond_Forestier;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Fond_Forestier", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Fond_Forestier";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Fond_Forestier_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Fond_Forestier.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Fond_Forestier;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Preleve_Divers", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Taux_Preleve_Divers";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Preleve_Divers_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Preleve_Divers.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Preleve_Divers;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_Preleve_Divers", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_Preleve_Divers";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_Preleve_Divers_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_Preleve_Divers.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_Preleve_Divers;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Montant_ProducteurNet", System.Data.SqlDbType.Float, 8);
				sqlParameter.SourceColumn = "Montant_ProducteurNet";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Montant_ProducteurNet_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Montant_ProducteurNet.IsNull) {

					sqlParameter.Value = parameters.Param_Montant_ProducteurNet;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Producteur_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Taux_Producteur_Override";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Producteur_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Producteur_Override.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Producteur_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Taux_Usine_Override", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "Taux_Usine_Override";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Taux_Usine_Override_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Taux_Usine_Override.IsNull) {

					sqlParameter.Value = parameters.Param_Taux_Usine_Override;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@Code", System.Data.SqlDbType.Char, 4);
				sqlParameter.SourceColumn = "Code";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_Code_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_Code.IsNull) {

					sqlParameter.Value = parameters.Param_Code;
				}
				else {

					sqlParameter.IsNullable = true;
					sqlParameter.Value = System.DBNull.Value;
				}
				sqlCommand.Parameters.Add(sqlParameter);

				sqlParameter = new System.Data.SqlClient.SqlParameter("@UsePreleveMontant", System.Data.SqlDbType.Bit, 1);
				sqlParameter.SourceColumn = "UsePreleveMontant";
				sqlParameter.Direction = System.Data.ParameterDirection.Input;
				if (parameters.internal_Param_UsePreleveMontant_UseDefaultValue) {

					sqlParameter.Value = null;				
				}
				else if (!parameters.Param_UsePreleveMontant.IsNull) {

					sqlParameter.Value = parameters.Param_UsePreleveMontant;
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

		private bool RetrieveParameters(ref Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail parameters, ref System.Data.SqlClient.SqlCommand sqlCommand) {

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
		/// This method allows you to execute the [spI_Livraison_Detail] stored procedure.
		/// </summary>
		/// <param name="parameters">
		/// Contains all the necessary information to execute correctly the stored procedure, i.e. 
		/// the database connection to use and all the necessary input parameters to be supplied
		/// for this stored procedure execution. After the execution, this object will allow you
		/// to retrieve back the stored procedure return value and all the output parameters.
		/// </param>
		/// <returns>True if the call was successful. Otherwise, it returns False.</returns>
		public bool Execute(ref Gestion_Paie.DataClasses.Parameters.spI_Livraison_Detail parameters) {

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

