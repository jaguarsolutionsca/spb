using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Fournisseur_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

		private System.Collections.ArrayList internalRecords;
		private bool recordsAreLoaded = false;

		private IBusinessComponentRecord parent = null;
		public IBusinessComponentRecord Parent {

			get {

				return(parent);
			}
		}

		public bool ContainsListCollection {

			get {

				return(true);
			}
		}

		public System.Collections.IList GetList() {

			return(internalRecords);
		}

		public int Count {

			get {

				if (!this.recordsAreLoaded) {

					Refresh();
				}

				return(internalRecords.Count);
			}
		}

		private string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}

		private System.Data.SqlTypes.SqlString col_PaysID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_PaysID {

			get {

				return(this.col_PaysID);
			}
			set {

				this.col_PaysID = value;
			}
		}

		internal void LoadFrom_PaysID(System.Data.SqlTypes.SqlString col_PaysID, Pays_Record parent) {
		
			if (col_PaysID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_PaysID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_PaysID = col_PaysID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlString col_InstitutionBanquaireID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_InstitutionBanquaireID {

			get {

				return(this.col_InstitutionBanquaireID);
			}
			set {

				this.col_InstitutionBanquaireID = value;
			}
		}

		internal void LoadFrom_InstitutionBanquaireID(System.Data.SqlTypes.SqlString col_InstitutionBanquaireID, InstitutionBanquaire_Record parent) {
		
			if (col_InstitutionBanquaireID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_InstitutionBanquaireID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_InstitutionBanquaireID = col_InstitutionBanquaireID;
			this.parent = parent;
		}


		public Fournisseur_Collection(string connectionString) {
			
			this.connectionString = connectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

			string DebugConnectionString = connectionString;

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
			}

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
			}

			if (DebugConnectionString != String.Empty) {

				System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

				sqlConnection.Open();

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Fournisseur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_PaysID">[To be supplied.]</param>
		/// <param name="col_InstitutionBanquaireID">[To be supplied.]</param>
		public Fournisseur_Collection(string connectionString, System.Data.SqlTypes.SqlString col_PaysID, System.Data.SqlTypes.SqlString col_InstitutionBanquaireID) {
			
			this.connectionString = connectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

			string DebugConnectionString = connectionString;

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
			}

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
			}

			if (DebugConnectionString != String.Empty) {

				System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

				sqlConnection.Open();

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Fournisseur'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Fournisseur", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_PaysID = col_PaysID;
			this.col_InstitutionBanquaireID = col_InstitutionBanquaireID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Fournisseur_Record recordToAdd = record as Fournisseur_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Fournisseur_Record'.", "record");
			}

			Params.spI_Fournisseur Param = new Params.spI_Fournisseur();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_CleTri = recordToAdd.Col_CleTri;
			Param.Param_Nom = recordToAdd.Col_Nom;
			Param.Param_AuSoinsDe = recordToAdd.Col_AuSoinsDe;
			Param.Param_Rue = recordToAdd.Col_Rue;
			Param.Param_Ville = recordToAdd.Col_Ville;
			Param.Param_PaysID = recordToAdd.Col_PaysID;
			Param.Param_Code_postal = recordToAdd.Col_Code_postal;
			Param.Param_Telephone = recordToAdd.Col_Telephone;
			Param.Param_Telephone_Poste = recordToAdd.Col_Telephone_Poste;
			Param.Param_Telecopieur = recordToAdd.Col_Telecopieur;
			Param.Param_Telephone2 = recordToAdd.Col_Telephone2;
			Param.Param_Telephone2_Desc = recordToAdd.Col_Telephone2_Desc;
			Param.Param_Telephone2_Poste = recordToAdd.Col_Telephone2_Poste;
			Param.Param_Telephone3 = recordToAdd.Col_Telephone3;
			Param.Param_Telephone3_Desc = recordToAdd.Col_Telephone3_Desc;
			Param.Param_Telephone3_Poste = recordToAdd.Col_Telephone3_Poste;
			Param.Param_No_membre = recordToAdd.Col_No_membre;
			Param.Param_Resident = recordToAdd.Col_Resident;
			Param.Param_Email = recordToAdd.Col_Email;
			Param.Param_WWW = recordToAdd.Col_WWW;
			Param.Param_Commentaires = recordToAdd.Col_Commentaires;
			Param.Param_AfficherCommentaires = recordToAdd.Col_AfficherCommentaires;
			Param.Param_DepotDirect = recordToAdd.Col_DepotDirect;
			Param.Param_InstitutionBanquaireID = recordToAdd.Col_InstitutionBanquaireID;
			Param.Param_Banque_transit = recordToAdd.Col_Banque_transit;
			Param.Param_Banque_folio = recordToAdd.Col_Banque_folio;
			Param.Param_No_TPS = recordToAdd.Col_No_TPS;
			Param.Param_No_TVQ = recordToAdd.Col_No_TVQ;
			Param.Param_PayerA = recordToAdd.Col_PayerA;
			Param.Param_PayerAID = recordToAdd.Col_PayerAID;
			Param.Param_Statut = recordToAdd.Col_Statut;
			Param.Param_Rep_Nom = recordToAdd.Col_Rep_Nom;
			Param.Param_Rep_Telephone = recordToAdd.Col_Rep_Telephone;
			Param.Param_Rep_Telephone_Poste = recordToAdd.Col_Rep_Telephone_Poste;
			Param.Param_Rep_Email = recordToAdd.Col_Rep_Email;
			Param.Param_EnAnglais = recordToAdd.Col_EnAnglais;
			Param.Param_Actif = recordToAdd.Col_Actif;
			Param.Param_MRCProducteurID = recordToAdd.Col_MRCProducteurID;
			Param.Param_PaiementManuel = recordToAdd.Col_PaiementManuel;
			Param.Param_Journal = recordToAdd.Col_Journal;
			Param.Param_RecoitTPS = recordToAdd.Col_RecoitTPS;
			Param.Param_RecoitTVQ = recordToAdd.Col_RecoitTVQ;
			Param.Param_ModifierTrigger = recordToAdd.Col_ModifierTrigger;
			Param.Param_IsProducteur = recordToAdd.Col_IsProducteur;
			Param.Param_IsTransporteur = recordToAdd.Col_IsTransporteur;
			Param.Param_IsChargeur = recordToAdd.Col_IsChargeur;
			Param.Param_IsAutre = recordToAdd.Col_IsAutre;
			Param.Param_AfficherCommentairesSurPermit = recordToAdd.Col_AfficherCommentairesSurPermit;
			Param.Param_PasEmissionPermis = recordToAdd.Col_PasEmissionPermis;
			Param.Param_Generique = recordToAdd.Col_Generique;
			Param.Param_Membre_OGC = recordToAdd.Col_Membre_OGC;
			Param.Param_InscritTPS = recordToAdd.Col_InscritTPS;
			Param.Param_InscritTVQ = recordToAdd.Col_InscritTVQ;
			Param.Param_IsOGC = recordToAdd.Col_IsOGC;
			Param.Param_Rep2_Nom = recordToAdd.Col_Rep2_Nom;
			Param.Param_Rep2_Telephone = recordToAdd.Col_Rep2_Telephone;
			Param.Param_Rep2_Telephone_Poste = recordToAdd.Col_Rep2_Telephone_Poste;
			Param.Param_Rep2_Email = recordToAdd.Col_Rep2_Email;
			Param.Param_Rep2_Commentaires = recordToAdd.Col_Rep2_Commentaires;

			SPs.spI_Fournisseur Sp = new SPs.spI_Fournisseur();
			if (Sp.Execute(ref Param)) {

				Fournisseur_Record newRecord = new Fournisseur_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_ID) {
		
			Params.spD_Fournisseur Param = new Params.spD_Fournisseur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Fournisseur Sp = new SPs.spD_Fournisseur(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Fournisseur_Record recordToDelete = record as Fournisseur_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Fournisseur_Record'.", "record");
			}

			Params.spD_Fournisseur Param = new Params.spD_Fournisseur(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Fournisseur Sp = new SPs.spD_Fournisseur(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Fournisseur_Display Param = new Params.spS_Fournisseur_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_PaysID.IsNull) {

				Param.Param_PaysID = this.col_PaysID;
			}

			if (!this.col_InstitutionBanquaireID.IsNull) {

				Param.Param_InstitutionBanquaireID = this.col_InstitutionBanquaireID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Fournisseur_Display Sp = new SPs.spS_Fournisseur_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Fournisseur_Record record = new Fournisseur_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Fournisseur_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Fournisseur_Display";

					internalRecords.Add(record);
				}

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = true;
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = false;
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Fournisseur_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Fournisseur_Record this[int index] {

			get {
				
				return((Fournisseur_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Fournisseur_Record this[System.Data.SqlTypes.SqlString col_ID] {

			get {

				foreach(Fournisseur_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ID == col_ID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
