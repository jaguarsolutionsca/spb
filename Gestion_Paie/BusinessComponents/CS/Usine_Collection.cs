using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Usine_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlInt32 col_UtilisationID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_UtilisationID {

			get {

				return(this.col_UtilisationID);
			}
			set {

				this.col_UtilisationID = value;
			}
		}

		internal void LoadFrom_UtilisationID(System.Data.SqlTypes.SqlInt32 col_UtilisationID, UsineUtilisation_Record parent) {
		
			if (col_UtilisationID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_UtilisationID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_UtilisationID = col_UtilisationID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_a_recevoir = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_a_recevoir {

			get {

				return(this.col_Compte_a_recevoir);
			}
			set {

				this.col_Compte_a_recevoir = value;
			}
		}

		internal void LoadFrom_Compte_a_recevoir(System.Data.SqlTypes.SqlInt32 col_Compte_a_recevoir, Compte_Record parent) {
		
			if (col_Compte_a_recevoir.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_a_recevoir");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_a_recevoir = col_Compte_a_recevoir;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_ajustement = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_ajustement {

			get {

				return(this.col_Compte_ajustement);
			}
			set {

				this.col_Compte_ajustement = value;
			}
		}

		internal void LoadFrom_Compte_ajustement(System.Data.SqlTypes.SqlInt32 col_Compte_ajustement, Compte_Record parent) {
		
			if (col_Compte_ajustement.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_ajustement");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_ajustement = col_Compte_ajustement;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_transporteur = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_transporteur {

			get {

				return(this.col_Compte_transporteur);
			}
			set {

				this.col_Compte_transporteur = value;
			}
		}

		internal void LoadFrom_Compte_transporteur(System.Data.SqlTypes.SqlInt32 col_Compte_transporteur, Compte_Record parent) {
		
			if (col_Compte_transporteur.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_transporteur");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_transporteur = col_Compte_transporteur;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_producteur = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_producteur {

			get {

				return(this.col_Compte_producteur);
			}
			set {

				this.col_Compte_producteur = value;
			}
		}

		internal void LoadFrom_Compte_producteur(System.Data.SqlTypes.SqlInt32 col_Compte_producteur, Compte_Record parent) {
		
			if (col_Compte_producteur.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_producteur");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_producteur = col_Compte_producteur;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_plan_conjoint = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_plan_conjoint {

			get {

				return(this.col_Compte_preleve_plan_conjoint);
			}
			set {

				this.col_Compte_preleve_plan_conjoint = value;
			}
		}

		internal void LoadFrom_Compte_preleve_plan_conjoint(System.Data.SqlTypes.SqlInt32 col_Compte_preleve_plan_conjoint, Compte_Record parent) {
		
			if (col_Compte_preleve_plan_conjoint.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_preleve_plan_conjoint");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_preleve_plan_conjoint = col_Compte_preleve_plan_conjoint;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_roulement = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_fond_roulement {

			get {

				return(this.col_Compte_preleve_fond_roulement);
			}
			set {

				this.col_Compte_preleve_fond_roulement = value;
			}
		}

		internal void LoadFrom_Compte_preleve_fond_roulement(System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_roulement, Compte_Record parent) {
		
			if (col_Compte_preleve_fond_roulement.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_preleve_fond_roulement");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_preleve_fond_roulement = col_Compte_preleve_fond_roulement;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_forestier = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_fond_forestier {

			get {

				return(this.col_Compte_preleve_fond_forestier);
			}
			set {

				this.col_Compte_preleve_fond_forestier = value;
			}
		}

		internal void LoadFrom_Compte_preleve_fond_forestier(System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_forestier, Compte_Record parent) {
		
			if (col_Compte_preleve_fond_forestier.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_preleve_fond_forestier");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_preleve_fond_forestier = col_Compte_preleve_fond_forestier;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_preleve_divers = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_preleve_divers {

			get {

				return(this.col_Compte_preleve_divers);
			}
			set {

				this.col_Compte_preleve_divers = value;
			}
		}

		internal void LoadFrom_Compte_preleve_divers(System.Data.SqlTypes.SqlInt32 col_Compte_preleve_divers, Compte_Record parent) {
		
			if (col_Compte_preleve_divers.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_preleve_divers");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_preleve_divers = col_Compte_preleve_divers;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_mise_en_commun = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_mise_en_commun {

			get {

				return(this.col_Compte_mise_en_commun);
			}
			set {

				this.col_Compte_mise_en_commun = value;
			}
		}

		internal void LoadFrom_Compte_mise_en_commun(System.Data.SqlTypes.SqlInt32 col_Compte_mise_en_commun, Compte_Record parent) {
		
			if (col_Compte_mise_en_commun.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_mise_en_commun");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_mise_en_commun = col_Compte_mise_en_commun;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_surcharge = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_surcharge {

			get {

				return(this.col_Compte_surcharge);
			}
			set {

				this.col_Compte_surcharge = value;
			}
		}

		internal void LoadFrom_Compte_surcharge(System.Data.SqlTypes.SqlInt32 col_Compte_surcharge, Compte_Record parent) {
		
			if (col_Compte_surcharge.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_surcharge");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_surcharge = col_Compte_surcharge;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_Compte_indexation_carburant = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Compte_indexation_carburant {

			get {

				return(this.col_Compte_indexation_carburant);
			}
			set {

				this.col_Compte_indexation_carburant = value;
			}
		}

		internal void LoadFrom_Compte_indexation_carburant(System.Data.SqlTypes.SqlInt32 col_Compte_indexation_carburant, Compte_Record parent) {
		
			if (col_Compte_indexation_carburant.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_Compte_indexation_carburant");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_Compte_indexation_carburant = col_Compte_indexation_carburant;
			this.parent = parent;
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


		public Usine_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Usine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Usine", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}

		/// <param name="col_UtilisationID">[To be supplied.]</param>
		/// <param name="col_Compte_a_recevoir">[To be supplied.]</param>
		/// <param name="col_Compte_ajustement">[To be supplied.]</param>
		/// <param name="col_Compte_transporteur">[To be supplied.]</param>
		/// <param name="col_Compte_producteur">[To be supplied.]</param>
		/// <param name="col_Compte_preleve_plan_conjoint">[To be supplied.]</param>
		/// <param name="col_Compte_preleve_fond_roulement">[To be supplied.]</param>
		/// <param name="col_Compte_preleve_fond_forestier">[To be supplied.]</param>
		/// <param name="col_Compte_preleve_divers">[To be supplied.]</param>
		/// <param name="col_Compte_mise_en_commun">[To be supplied.]</param>
		/// <param name="col_Compte_surcharge">[To be supplied.]</param>
		/// <param name="col_Compte_indexation_carburant">[To be supplied.]</param>
		/// <param name="col_PaysID">[To be supplied.]</param>
		public Usine_Collection(string connectionString, System.Data.SqlTypes.SqlInt32 col_UtilisationID, System.Data.SqlTypes.SqlInt32 col_Compte_a_recevoir, System.Data.SqlTypes.SqlInt32 col_Compte_ajustement, System.Data.SqlTypes.SqlInt32 col_Compte_transporteur, System.Data.SqlTypes.SqlInt32 col_Compte_producteur, System.Data.SqlTypes.SqlInt32 col_Compte_preleve_plan_conjoint, System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_roulement, System.Data.SqlTypes.SqlInt32 col_Compte_preleve_fond_forestier, System.Data.SqlTypes.SqlInt32 col_Compte_preleve_divers, System.Data.SqlTypes.SqlInt32 col_Compte_mise_en_commun, System.Data.SqlTypes.SqlInt32 col_Compte_surcharge, System.Data.SqlTypes.SqlInt32 col_Compte_indexation_carburant, System.Data.SqlTypes.SqlString col_PaysID) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Usine'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Usine", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

			this.col_UtilisationID = col_UtilisationID;
			this.col_Compte_a_recevoir = col_Compte_a_recevoir;
			this.col_Compte_ajustement = col_Compte_ajustement;
			this.col_Compte_transporteur = col_Compte_transporteur;
			this.col_Compte_producteur = col_Compte_producteur;
			this.col_Compte_preleve_plan_conjoint = col_Compte_preleve_plan_conjoint;
			this.col_Compte_preleve_fond_roulement = col_Compte_preleve_fond_roulement;
			this.col_Compte_preleve_fond_forestier = col_Compte_preleve_fond_forestier;
			this.col_Compte_preleve_divers = col_Compte_preleve_divers;
			this.col_Compte_mise_en_commun = col_Compte_mise_en_commun;
			this.col_Compte_surcharge = col_Compte_surcharge;
			this.col_Compte_indexation_carburant = col_Compte_indexation_carburant;
			this.col_PaysID = col_PaysID;
		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Usine_Record recordToAdd = record as Usine_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Usine_Record'.", "record");
			}

			Params.spI_Usine Param = new Params.spI_Usine();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToAdd.Col_ID;
			Param.Param_Description = recordToAdd.Col_Description;
			Param.Param_UtilisationID = recordToAdd.Col_UtilisationID;
			Param.Param_Paye_producteur = recordToAdd.Col_Paye_producteur;
			Param.Param_Paye_transporteur = recordToAdd.Col_Paye_transporteur;
			Param.Param_Specification = recordToAdd.Col_Specification;
			Param.Param_Compte_a_recevoir = recordToAdd.Col_Compte_a_recevoir;
			Param.Param_Compte_ajustement = recordToAdd.Col_Compte_ajustement;
			Param.Param_Compte_transporteur = recordToAdd.Col_Compte_transporteur;
			Param.Param_Compte_producteur = recordToAdd.Col_Compte_producteur;
			Param.Param_Compte_preleve_plan_conjoint = recordToAdd.Col_Compte_preleve_plan_conjoint;
			Param.Param_Compte_preleve_fond_roulement = recordToAdd.Col_Compte_preleve_fond_roulement;
			Param.Param_Compte_preleve_fond_forestier = recordToAdd.Col_Compte_preleve_fond_forestier;
			Param.Param_Compte_preleve_divers = recordToAdd.Col_Compte_preleve_divers;
			Param.Param_Compte_mise_en_commun = recordToAdd.Col_Compte_mise_en_commun;
			Param.Param_Compte_surcharge = recordToAdd.Col_Compte_surcharge;
			Param.Param_Compte_indexation_carburant = recordToAdd.Col_Compte_indexation_carburant;
			Param.Param_Actif = recordToAdd.Col_Actif;
			Param.Param_NePaiePasTPS = recordToAdd.Col_NePaiePasTPS;
			Param.Param_NePaiePasTVQ = recordToAdd.Col_NePaiePasTVQ;
			Param.Param_NoTPS = recordToAdd.Col_NoTPS;
			Param.Param_NoTVQ = recordToAdd.Col_NoTVQ;
			Param.Param_Compte_chargeur = recordToAdd.Col_Compte_chargeur;
			Param.Param_UsineGestionVolume = recordToAdd.Col_UsineGestionVolume;
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
			Param.Param_Email = recordToAdd.Col_Email;

			SPs.spI_Usine Sp = new SPs.spI_Usine();
			if (Sp.Execute(ref Param)) {

				Usine_Record newRecord = new Usine_Record(this.connectionString, Param.Param_ID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Usine_Collection", "Add");
			}	
		}

		/// <param name="Col_ID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_ID) {
		
			Params.spD_Usine Param = new Params.spD_Usine(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = Col_ID;


			SPs.spD_Usine Sp = new SPs.spD_Usine(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Usine_Record recordToDelete = record as Usine_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Usine_Record'.", "record");
			}

			Params.spD_Usine Param = new Params.spD_Usine(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ID = recordToDelete.Col_ID;


			SPs.spD_Usine Sp = new SPs.spD_Usine(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Usine_Display Param = new Params.spS_Usine_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_UtilisationID.IsNull) {

				Param.Param_UtilisationID = this.col_UtilisationID;
			}

			if (!this.col_Compte_a_recevoir.IsNull) {

				Param.Param_Compte_a_recevoir = this.col_Compte_a_recevoir;
			}

			if (!this.col_Compte_ajustement.IsNull) {

				Param.Param_Compte_ajustement = this.col_Compte_ajustement;
			}

			if (!this.col_Compte_transporteur.IsNull) {

				Param.Param_Compte_transporteur = this.col_Compte_transporteur;
			}

			if (!this.col_Compte_producteur.IsNull) {

				Param.Param_Compte_producteur = this.col_Compte_producteur;
			}

			if (!this.col_Compte_preleve_plan_conjoint.IsNull) {

				Param.Param_Compte_preleve_plan_conjoint = this.col_Compte_preleve_plan_conjoint;
			}

			if (!this.col_Compte_preleve_fond_roulement.IsNull) {

				Param.Param_Compte_preleve_fond_roulement = this.col_Compte_preleve_fond_roulement;
			}

			if (!this.col_Compte_preleve_fond_forestier.IsNull) {

				Param.Param_Compte_preleve_fond_forestier = this.col_Compte_preleve_fond_forestier;
			}

			if (!this.col_Compte_preleve_divers.IsNull) {

				Param.Param_Compte_preleve_divers = this.col_Compte_preleve_divers;
			}

			if (!this.col_Compte_mise_en_commun.IsNull) {

				Param.Param_Compte_mise_en_commun = this.col_Compte_mise_en_commun;
			}

			if (!this.col_Compte_surcharge.IsNull) {

				Param.Param_Compte_surcharge = this.col_Compte_surcharge;
			}

			if (!this.col_Compte_indexation_carburant.IsNull) {

				Param.Param_Compte_indexation_carburant = this.col_Compte_indexation_carburant;
			}

			if (!this.col_PaysID.IsNull) {

				Param.Param_PaysID = this.col_PaysID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Usine_Display Sp = new SPs.spS_Usine_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Usine_Record record = new Usine_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Usine_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_Usine_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Usine_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Usine_Record this[int index] {

			get {
				
				return((Usine_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Usine_Record this[System.Data.SqlTypes.SqlString col_ID] {

			get {

				foreach(Usine_Record record in internalRecords) {

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
