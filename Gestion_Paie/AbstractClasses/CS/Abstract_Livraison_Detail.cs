using System;
using Gestion_Paie.DataClasses;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.AbstractClasses {

	/// <summary>
	/// This class allows you to very easily retrieve a record from the [Livraison_Detail] table.
	/// </summary>
	[Serializable()]
	public sealed class Abstract_Livraison_Detail {

		Params.spS_Livraison_Detail Param;
		private bool CloseConnectionAfterUse = true;

		/// <summary>
		/// Create a new instance of the Abstract_Livraison_Detail class.
		/// </summary>
		/// <param name="connectionString">A valid connection string to the database.</param>
		public Abstract_Livraison_Detail(string connectionString) {

			if (connectionString == null) {

				throw new ArgumentNullException("connectionString", "connectionString can be an empty string but can not be null.");
			}

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

				string DebugConnectionString = connectionString;

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
				}

				if (DebugConnectionString.Length == 0) {

					DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
				}

				if (DebugConnectionString.Length != 0) {

					System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

					sqlConnection.Open();

					System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

					sqlCommand.CommandType = System.Data.CommandType.Text;
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Detail'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

						throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Livraison_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
					}
				}
			}
#endif

			this.Param = new Params.spS_Livraison_Detail(true);
			this.Param.SetUpConnection(connectionString);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Livraison_Detail class.
		/// </summary>
		/// <param name="sqlConnection">A valid System.Data.SqlClient.SqlConnection to the database.</param>
		public Abstract_Livraison_Detail(System.Data.SqlClient.SqlConnection sqlConnection) {

			if (sqlConnection == null) {

				throw new ArgumentNullException("sqlConnection", "Invalid connection!");
			}

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Detail'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlConnection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Livraison_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Livraison_Detail(true);
			this.Param.SetUpConnection(sqlConnection);
			CloseConnectionAfterUse = (this.Param.SqlConnection.State != System.Data.ConnectionState.Open);
		}

		/// <summary>
		/// Create a new instance of the Abstract_Livraison_Detail class.
		/// </summary>
		/// <param name="sqlTransaction">A valid System.Data.SqlClient.SqlTransaction to the database.</param>
		public Abstract_Livraison_Detail(System.Data.SqlClient.SqlTransaction sqlTransaction) {

			if (sqlTransaction == null || sqlTransaction.Connection == null) {
				throw new ArgumentNullException("sqlTransaction", "Invalid transaction!");
			}

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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Livraison_Detail'";
				sqlCommand.Transaction = sqlTransaction;

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				if (NotAlreadyOpened) {

					sqlTransaction.Connection.Close();
				}

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}{3}{3}You can either regenerate the code for this class so that it will be based on the new version or edit the configuration file of the class caller application and paste the following code:{3}{3}<?xml version=\"1.0\" encoding=\"utf-8\" ?>{3}<configuration>{3}\t<appSettings>{3}\t\t<add key=\"OlymarsDebugCheck\" value=\"False\" />{3}\t</appSettings>{3}</configuration>{3}{3}You will need to reload the caller application if it is a Windows Forms based application.", "Livraison_Detail", CurrentRevision, OriginalRevision, System.Environment.NewLine));
				}
			}
#endif

			this.Param = new Params.spS_Livraison_Detail(true);
			this.Param.SetUpConnection(sqlTransaction);
		}

		private System.Data.SqlTypes.SqlInt32 col_ID;
		/// <summary>
		/// Returns the value of the ID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_ID {

			get {

				return (this.col_ID);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_LivraisonID;
		/// <summary>
		/// Returns the value of the LivraisonID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;LivraisonID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonID {

			get {

				return (this.col_LivraisonID);
			}
		}

		private System.Data.SqlTypes.SqlString col_ContratID;
		/// <summary>
		/// Returns the value of the ContratID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContratID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ContratID {

			get {

				return (this.col_ContratID);
			}
		}

		private System.Data.SqlTypes.SqlString col_EssenceID;
		/// <summary>
		/// Returns the value of the EssenceID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;EssenceID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_EssenceID {

			get {

				return (this.col_EssenceID);
			}
		}

		private System.Data.SqlTypes.SqlString col_UniteMesureID;
		/// <summary>
		/// Returns the value of the UniteMesureID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UniteMesureID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_UniteMesureID {

			get {

				return (this.col_UniteMesureID);
			}
		}

		private System.Data.SqlTypes.SqlString col_ProducteurID;
		/// <summary>
		/// Returns the value of the ProducteurID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ProducteurID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_ProducteurID {

			get {

				return (this.col_ProducteurID);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Droit_Coupe;
		/// <summary>
		/// Returns the value of the Droit_Coupe column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Droit_Coupe&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Droit_Coupe {

			get {

				return (this.col_Droit_Coupe);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeBrut;
		/// <summary>
		/// Returns the value of the VolumeBrut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeBrut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeBrut {

			get {

				return (this.col_VolumeBrut);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeReduction;
		/// <summary>
		/// Returns the value of the VolumeReduction column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeReduction&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeReduction {

			get {

				return (this.col_VolumeReduction);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeNet;
		/// <summary>
		/// Returns the value of the VolumeNet column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeNet&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeNet {

			get {

				return (this.col_VolumeNet);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_VolumeContingente;
		/// <summary>
		/// Returns the value of the VolumeContingente column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;VolumeContingente&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_VolumeContingente {

			get {

				return (this.col_VolumeContingente);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_ContingentementID;
		/// <summary>
		/// Returns the value of the ContingentementID column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ContingentementID&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlInt32 Col_ContingentementID {

			get {

				return (this.col_ContingentementID);
			}
		}

		private System.Data.SqlTypes.SqlDateTime col_DateCalcul;
		/// <summary>
		/// Returns the value of the DateCalcul column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;DateCalcul&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDateTime Col_DateCalcul {

			get {

				return (this.col_DateCalcul);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_Usine;
		/// <summary>
		/// Returns the value of the Taux_Usine column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Usine&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Usine {

			get {

				return (this.col_Taux_Usine);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Usine;
		/// <summary>
		/// Returns the value of the Montant_Usine column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Usine&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Usine {

			get {

				return (this.col_Montant_Usine);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_Producteur;
		/// <summary>
		/// Returns the value of the Taux_Producteur column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Producteur&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Producteur {

			get {

				return (this.col_Taux_Producteur);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_ProducteurBrut;
		/// <summary>
		/// Returns the value of the Montant_ProducteurBrut column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_ProducteurBrut&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_ProducteurBrut {

			get {

				return (this.col_Montant_ProducteurBrut);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_TransporteurMoyen;
		/// <summary>
		/// Returns the value of the Taux_TransporteurMoyen column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_TransporteurMoyen&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_TransporteurMoyen {

			get {

				return (this.col_Taux_TransporteurMoyen);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Taux_TransporteurMoyen_Override;
		/// <summary>
		/// Returns the value of the Taux_TransporteurMoyen_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_TransporteurMoyen_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Taux_TransporteurMoyen_Override {

			get {

				return (this.col_Taux_TransporteurMoyen_Override);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_TransporteurMoyen;
		/// <summary>
		/// Returns the value of the Montant_TransporteurMoyen column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_TransporteurMoyen&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_TransporteurMoyen {

			get {

				return (this.col_Montant_TransporteurMoyen);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Plan_Conjoint;
		/// <summary>
		/// Returns the value of the Taux_Preleve_Plan_Conjoint column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Preleve_Plan_Conjoint&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Plan_Conjoint {

			get {

				return (this.col_Taux_Preleve_Plan_Conjoint);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Plan_Conjoint;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Plan_Conjoint column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Plan_Conjoint&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Plan_Conjoint {

			get {

				return (this.col_Montant_Preleve_Plan_Conjoint);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Fond_Roulement;
		/// <summary>
		/// Returns the value of the Taux_Preleve_Fond_Roulement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Preleve_Fond_Roulement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Fond_Roulement {

			get {

				return (this.col_Taux_Preleve_Fond_Roulement);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Fond_Roulement;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Fond_Roulement column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Fond_Roulement&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Fond_Roulement {

			get {

				return (this.col_Montant_Preleve_Fond_Roulement);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Fond_Forestier;
		/// <summary>
		/// Returns the value of the Taux_Preleve_Fond_Forestier column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Preleve_Fond_Forestier&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Fond_Forestier {

			get {

				return (this.col_Taux_Preleve_Fond_Forestier);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Fond_Forestier;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Fond_Forestier column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Fond_Forestier&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Fond_Forestier {

			get {

				return (this.col_Montant_Preleve_Fond_Forestier);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Taux_Preleve_Divers;
		/// <summary>
		/// Returns the value of the Taux_Preleve_Divers column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Preleve_Divers&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Taux_Preleve_Divers {

			get {

				return (this.col_Taux_Preleve_Divers);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_Preleve_Divers;
		/// <summary>
		/// Returns the value of the Montant_Preleve_Divers column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_Preleve_Divers&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_Preleve_Divers {

			get {

				return (this.col_Montant_Preleve_Divers);
			}
		}

		private System.Data.SqlTypes.SqlDouble col_Montant_ProducteurNet;
		/// <summary>
		/// Returns the value of the Montant_ProducteurNet column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Montant_ProducteurNet&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlDouble Col_Montant_ProducteurNet {

			get {

				return (this.col_Montant_ProducteurNet);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Taux_Producteur_Override;
		/// <summary>
		/// Returns the value of the Taux_Producteur_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Producteur_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Producteur_Override {

			get {

				return (this.col_Taux_Producteur_Override);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_Taux_Usine_Override;
		/// <summary>
		/// Returns the value of the Taux_Usine_Override column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Taux_Usine_Override&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_Taux_Usine_Override {

			get {

				return (this.col_Taux_Usine_Override);
			}
		}

		private System.Data.SqlTypes.SqlString col_Code;
		/// <summary>
		/// Returns the value of the Code column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;Code&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlString Col_Code {

			get {

				return (this.col_Code);
			}
		}

		private System.Data.SqlTypes.SqlBoolean col_UsePreleveMontant;
		/// <summary>
		/// Returns the value of the UsePreleveMontant column.
		/// More info on this column: Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;UsePreleveMontant&quot; column.
		/// </summary>
		public System.Data.SqlTypes.SqlBoolean Col_UsePreleveMontant {

			get {

				return (this.col_UsePreleveMontant);
			}
		}

		/// <summary>
		/// This method allows to clear all the properties previously loaded by a call to the Refresh method.
		/// </summary>
		public void Reset() {

			this.col_ID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_LivraisonID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_ContratID = System.Data.SqlTypes.SqlString.Null;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;
			this.col_UniteMesureID = System.Data.SqlTypes.SqlString.Null;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
			this.col_Droit_Coupe = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_VolumeBrut = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeReduction = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeNet = System.Data.SqlTypes.SqlDouble.Null;
			this.col_VolumeContingente = System.Data.SqlTypes.SqlDouble.Null;
			this.col_ContingentementID = System.Data.SqlTypes.SqlInt32.Null;
			this.col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
			this.col_Taux_Usine = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Usine = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_Producteur = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_ProducteurBrut = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_TransporteurMoyen_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Montant_TransporteurMoyen = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Plan_Conjoint = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Fond_Roulement = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Fond_Forestier = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_Preleve_Divers = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Montant_ProducteurNet = System.Data.SqlTypes.SqlDouble.Null;
			this.col_Taux_Producteur_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Taux_Usine_Override = System.Data.SqlTypes.SqlBoolean.Null;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;
			this.col_UsePreleveMontant = System.Data.SqlTypes.SqlBoolean.Null;
		}

		/// <summary>
		/// Allows you to load a specific record of the [Livraison_Detail] table.
		/// </summary>
		/// <param name="col_ID">Update this description in the &quot;Olymars/Description&quot; extended property of the &quot;ID&quot; column.</param>
		public bool Refresh(System.Data.SqlTypes.SqlInt32 col_ID) {

			bool Status;
			Reset();

			if (col_ID.IsNull) {

				throw new ArgumentNullException("col_ID" , "The primary key 'col_ID' can not have a Null value!");
			}


			this.col_ID = col_ID;

			this.Param.Reset();

			this.Param.Param_ID = this.col_ID;

			System.Data.SqlClient.SqlDataReader DR;
			SPs.spS_Livraison_Detail SP = new SPs.spS_Livraison_Detail(false);

			if (SP.Execute(ref this.Param, out DR)) {

				Status = false;
				if (DR.Read()) {

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex)) {

						this.col_LivraisonID = DR.GetSqlInt32(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_LivraisonID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex)) {

						this.col_ContratID = DR.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContratID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = DR.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex)) {

						this.col_UniteMesureID = DR.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UniteMesureID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = DR.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Droit_Coupe.ColumnIndex)) {

						this.col_Droit_Coupe = DR.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Droit_Coupe.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex)) {

						this.col_VolumeBrut = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeBrut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex)) {

						this.col_VolumeReduction = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeReduction.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex)) {

						this.col_VolumeNet = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeNet.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeContingente.ColumnIndex)) {

						this.col_VolumeContingente = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_VolumeContingente.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContingentementID.ColumnIndex)) {

						this.col_ContingentementID = DR.GetSqlInt32(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_ContingentementID.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_DateCalcul.ColumnIndex)) {

						this.col_DateCalcul = DR.GetSqlDateTime(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_DateCalcul.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine.ColumnIndex)) {

						this.col_Taux_Usine = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Usine.ColumnIndex)) {

						this.col_Montant_Usine = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Usine.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur.ColumnIndex)) {

						this.col_Taux_Producteur = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurBrut.ColumnIndex)) {

						this.col_Montant_ProducteurBrut = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurBrut.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen.ColumnIndex)) {

						this.col_Taux_TransporteurMoyen = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen_Override.ColumnIndex)) {

						this.col_Taux_TransporteurMoyen_Override = DR.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_TransporteurMoyen_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_TransporteurMoyen.ColumnIndex)) {

						this.col_Montant_TransporteurMoyen = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_TransporteurMoyen.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Plan_Conjoint.ColumnIndex)) {

						this.col_Taux_Preleve_Plan_Conjoint = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Plan_Conjoint.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex)) {

						this.col_Montant_Preleve_Plan_Conjoint = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Plan_Conjoint.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Roulement.ColumnIndex)) {

						this.col_Taux_Preleve_Fond_Roulement = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Roulement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Roulement = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Roulement.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Forestier.ColumnIndex)) {

						this.col_Taux_Preleve_Fond_Forestier = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Fond_Forestier.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex)) {

						this.col_Montant_Preleve_Fond_Forestier = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Fond_Forestier.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Divers.ColumnIndex)) {

						this.col_Taux_Preleve_Divers = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Preleve_Divers.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex)) {

						this.col_Montant_Preleve_Divers = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_Preleve_Divers.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurNet.ColumnIndex)) {

						this.col_Montant_ProducteurNet = DR.GetSqlDouble(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Montant_ProducteurNet.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur_Override.ColumnIndex)) {

						this.col_Taux_Producteur_Override = DR.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Producteur_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex)) {

						this.col_Taux_Usine_Override = DR.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Taux_Usine_Override.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = DR.GetSqlString(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (!DR.IsDBNull(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UsePreleveMontant.ColumnIndex)) {

						this.col_UsePreleveMontant = DR.GetSqlBoolean(SPs.spS_Livraison_Detail.Resultset1.Fields.Column_UsePreleveMontant.ColumnIndex);
					}

					Status = true;
				}

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				return(Status);
			}

			else {

				if (DR != null && !DR.IsClosed) {

					DR.Close();
				}

				if (CloseConnectionAfterUse && SP.Connection != null && SP.Connection.State == System.Data.ConnectionState.Open) {

					SP.Connection.Close();
					SP.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(this.Param, "Gestion_Paie.AbstractClasses.Abstract_Livraison_Detail", "Refresh");
			}
		}
	}
}
